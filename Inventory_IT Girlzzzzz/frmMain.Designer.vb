<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        btnLogout = New Button()
        btnPurchaseOrder = New Button()
        btnReceive = New Button()
        btnHistory = New Button()
        btnStockMonitoring = New Button()
        btnStockIssuance = New Button()
        SuspendLayout()
        ' 
        ' btnLogout
        ' 
        btnLogout.Location = New Point(22, 12)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(75, 23)
        btnLogout.TabIndex = 0
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' btnPurchaseOrder
        ' 
        btnPurchaseOrder.Location = New Point(22, 95)
        btnPurchaseOrder.Name = "btnPurchaseOrder"
        btnPurchaseOrder.Size = New Size(157, 38)
        btnPurchaseOrder.TabIndex = 1
        btnPurchaseOrder.Text = "Purchase Order"
        btnPurchaseOrder.UseVisualStyleBackColor = True
        ' 
        ' btnReceive
        ' 
        btnReceive.Location = New Point(199, 95)
        btnReceive.Name = "btnReceive"
        btnReceive.Size = New Size(157, 38)
        btnReceive.TabIndex = 2
        btnReceive.Text = "Receive"
        btnReceive.UseVisualStyleBackColor = True
        ' 
        ' btnHistory
        ' 
        btnHistory.Location = New Point(391, 95)
        btnHistory.Name = "btnHistory"
        btnHistory.Size = New Size(157, 38)
        btnHistory.TabIndex = 3
        btnHistory.Text = "History"
        btnHistory.UseVisualStyleBackColor = True
        ' 
        ' btnStockMonitoring
        ' 
        btnStockMonitoring.Location = New Point(581, 95)
        btnStockMonitoring.Name = "btnStockMonitoring"
        btnStockMonitoring.Size = New Size(157, 38)
        btnStockMonitoring.TabIndex = 4
        btnStockMonitoring.Text = "Stock Monitoring"
        btnStockMonitoring.UseVisualStyleBackColor = True
        ' 
        ' btnStockIssuance
        ' 
        btnStockIssuance.Location = New Point(779, 95)
        btnStockIssuance.Name = "btnStockIssuance"
        btnStockIssuance.Size = New Size(157, 38)
        btnStockIssuance.TabIndex = 5
        btnStockIssuance.Text = "Stock Issuance"
        btnStockIssuance.UseVisualStyleBackColor = True
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.InactiveCaption
        ClientSize = New Size(1269, 586)
        Controls.Add(btnStockIssuance)
        Controls.Add(btnStockMonitoring)
        Controls.Add(btnHistory)
        Controls.Add(btnReceive)
        Controls.Add(btnPurchaseOrder)
        Controls.Add(btnLogout)
        Name = "frmMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmMain"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnLogout As Button
    Friend WithEvents btnPurchaseOrder As Button
    Friend WithEvents btnReceive As Button
    Friend WithEvents btnHistory As Button
    Friend WithEvents btnStockMonitoring As Button
    Friend WithEvents btnStockIssuance As Button
End Class
