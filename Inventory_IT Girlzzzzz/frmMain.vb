Public Class frmMain
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        frmLogin.Show()
        Me.Close()
    End Sub

    Private Sub btnPurchaseOrder_Click(sender As Object, e As EventArgs) Handles btnPurchaseOrder.Click
        frmPurchaseOrder.Show()
        Me.Hide()
    End Sub

    Private Sub btnPullout_Click(sender As Object, e As EventArgs) Handles btnReceive.Click
        frmReceive.Show()
        Me.Hide()
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        frmHistory.Show()
        Me.Hide()
    End Sub
End Class