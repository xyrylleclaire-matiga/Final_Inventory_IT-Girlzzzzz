Imports MySql.Data.MySqlClient

Public Class frmLogin
    Dim attemptCount As Integer = 0
    Dim loginUsername As String = ""

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize form
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False

        ' Clear textboxes
        txtUsername.Clear()
        txtPassword.Clear()
        txtPassword.PasswordChar = "●"
        txtUsername.Focus()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Validate inputs
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Please enter username!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please enter password!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        ' Check if this is a new username or same username
        If loginUsername <> txtUsername.Text.Trim() Then
            loginUsername = txtUsername.Text.Trim()
            attemptCount = 0
        End If

        ' Perform login
        LoginUser()
    End Sub

    Private Sub LoginUser()
        Try
            con() ' Use your existing connection function

            ' First check if account is active (for staff only)
            sql = "SELECT role FROM tbladmin_users WHERE username = @username"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
            dr = cmd.ExecuteReader()

            Dim userRole As String = ""
            If dr.Read() Then
                userRole = dr("role").ToString()
            End If
            dr.Close()

            ' For STAFF, check if account is active
            If userRole.ToUpper() <> "ADMIN" And userRole.ToUpper() <> "SUPER ADMIN" Then
                sql = "SELECT status FROM tbladmin_users WHERE username = @username"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                dr = cmd.ExecuteReader()

                If dr.Read() Then
                    Dim status As String = dr("status").ToString()
                    If status.ToUpper() = "DEACTIVATED" Then
                        dr.Close()
                        MessageBox.Show("Your account has been deactivated due to multiple failed login attempts. Please contact the administrator.", "Account Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtPassword.Clear()
                        cn.Close()
                        Return
                    End If
                End If
                dr.Close()
            End If

            ' Now perform actual login check
            sql = "SELECT admin_id, role, FirstName, LastName FROM tbladmin_users WHERE username = @username AND Password = @password"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
            cmd.Parameters.AddWithValue("@password", txtPassword.Text)
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                ' Login successful
                currentAdminId = Convert.ToInt32(dr("admin_id"))
                currentUserRole = dr("role").ToString()
                Dim firstName As String = dr("FirstName").ToString()
                Dim lastName As String = dr("LastName").ToString()
                currentUsername = txtUsername.Text.Trim()
                currentFullName = firstName & " " & lastName
                isLoggedIn = True

                dr.Close()

                MessageBox.Show("Login Successful!" & vbCrLf & "Welcome, " & firstName & " " & lastName & "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Reset attempt count on successful login
                attemptCount = 0

                Dim mainForm As New frmMain()
                mainForm.Show()
                Me.Hide()

            Else
                ' Login failed
                dr.Close()
                attemptCount += 1

                ' Check if user is STAFF (not ADMIN or SUPER ADMIN)
                sql = "SELECT role FROM tbladmin_users WHERE username = @username"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                dr = cmd.ExecuteReader()

                userRole = ""
                If dr.Read() Then
                    userRole = dr("role").ToString()
                End If
                dr.Close()

                ' If STAFF and reached 3 attempts, deactivate account
                If userRole.ToUpper() <> "ADMIN" And userRole.ToUpper() <> "SUPER ADMIN" And attemptCount >= 3 Then
                    ' Deactivate the account
                    sql = "UPDATE tbladmin_users SET status = 'DEACTIVATED' WHERE username = @username"
                    cmd = New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("You have exceeded the maximum login attempts (3). Your account has been deactivated. Please contact the administrator.", "Account Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtUsername.Clear()
                    txtPassword.Clear()
                    txtUsername.Focus()
                    attemptCount = 0
                    loginUsername = ""
                Else
                    ' Show remaining attempts for STAFF
                    If userRole.ToUpper() <> "ADMIN" And userRole.ToUpper() <> "SUPER ADMIN" Then
                        Dim remainingAttempts As Integer = 3 - attemptCount
                        MessageBox.Show("Invalid username or password!" & vbCrLf & "Remaining attempts: " & remainingAttempts, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        ' For ADMIN, just show error without attempt count
                        MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    txtPassword.Clear()
                    txtPassword.Focus()
                End If
            End If

            cn.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click, btnCancel.Click
        If MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit
        End If
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            txtPassword.PasswordChar = ""
        Else
            txtPassword.PasswordChar = "●"
        End If
    End Sub
End Class