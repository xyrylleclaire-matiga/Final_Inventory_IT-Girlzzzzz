Public Class frmPasswordDialog
    Private passwordResult As String = ""

    Public ReadOnly Property Password As String
        Get
            Return passwordResult
        End Get
    End Property

    Private Sub frmPasswordDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configure password textbox to show bullets
        txtPassword.PasswordChar = "•"c
        txtPassword.MaxLength = 50
        txtPassword.Focus()

        ' Set form properties
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please enter your password!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        passwordResult = txtPassword.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        passwordResult = ""
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' Allow Enter key to confirm
    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' Prevent beep sound
            btnConfirm_Click(sender, Nothing)
        End If
    End Sub
End Class