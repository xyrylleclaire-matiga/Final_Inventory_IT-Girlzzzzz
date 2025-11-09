Imports MySql.Data.MySqlClient
Module databaseConnection
    Public cn As New MySqlConnection
    Public cmd As MySqlCommand
    Public dr As MySqlDataReader

    Public currentAdminId As Integer = 0
    Public currentUserId As Integer = 0
    Public currentUsername As String = ""
    Public currentFullName As String = ""
    Public currentUserRole As String = "" ' "Admin" or "User"
    Public isLoggedIn As Boolean = False
    Public Function GetUserInfoDisplay() As String
        If isLoggedIn Then
            Return $"Logged in as: {currentFullName} ({currentUserRole}) | Date: {DateTime.Now:MMMM dd, yyyy}"
        Else
            Return "Not logged in"
        End If
    End Function

    Public Sub ClearLoginSession()
        currentAdminId = 0
        currentUsername = ""
        currentFullName = ""
        currentUserRole = ""
        isLoggedIn = False
    End Sub

    Public Function IsAdmin() As Boolean
        Return isLoggedIn AndAlso (currentUserRole.ToUpper() = "ADMIN" OrElse currentUserRole.ToUpper() = "SUPER ADMIN")
    End Function

    ''' <summary>
    ''' Check if user has Super Admin privileges
    ''' </summary>
    Public Function IsSuperAdmin() As Boolean
        Return isLoggedIn AndAlso currentUserRole.ToUpper() = "SUPER ADMIN"
    End Function

    Public sql As String
    Public Sub con()
        cn.Close()
        cn.ConnectionString = "server=localhost; password =; user=root; database=db_inventorysystem"
        cn.Open()
        'MsgBox("Connection Success!")
    End Sub
End Module
