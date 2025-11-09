' ============================================
' IMPORTANT: This must be in frmPurchaseOrder.Designer.vb file
' ============================================

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPurchaseOrder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        dgvPurchaseOrders = New DataGridView()
        dgvOrderDetails = New DataGridView()
        grpOrderDetails = New GroupBox()
        btnSaveAllItems = New Button()
        btnAddMoreItem = New Button()
        Panel1 = New Panel()
        btnNewPO = New Button()
        txtRemarks = New TextBox()
        dtpTransactionDate = New DateTimePicker()
        cmbItemType = New ComboBox()
        cmbTransactionType = New ComboBox()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        lblTransactionType = New Label()
        Label8 = New Label()
        btnBack = New Button()
        Panel2 = New Panel()
        Label4 = New Label()
        lblTotalAmount = New Label()
        btnRejectPO = New Button()
        btnApprovePO = New Button()
        Label5 = New Label()
        CType(dgvPurchaseOrders, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvOrderDetails, ComponentModel.ISupportInitialize).BeginInit()
        grpOrderDetails.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvPurchaseOrders
        ' 
        dgvPurchaseOrders.AllowUserToAddRows = False
        dgvPurchaseOrders.AllowUserToDeleteRows = False
        dgvPurchaseOrders.BackgroundColor = Color.White
        dgvPurchaseOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPurchaseOrders.Location = New Point(30, 220)
        dgvPurchaseOrders.MultiSelect = False
        dgvPurchaseOrders.Name = "dgvPurchaseOrders"
        dgvPurchaseOrders.ReadOnly = True
        dgvPurchaseOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPurchaseOrders.Size = New Size(1290, 200)
        dgvPurchaseOrders.TabIndex = 0
        ' 
        ' dgvOrderDetails
        ' 
        dgvOrderDetails.AllowUserToAddRows = False
        dgvOrderDetails.BackgroundColor = Color.White
        dgvOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvOrderDetails.Location = New Point(30, 905)
        dgvOrderDetails.MultiSelect = False
        dgvOrderDetails.Name = "dgvOrderDetails"
        dgvOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvOrderDetails.Size = New Size(1290, 200)
        dgvOrderDetails.TabIndex = 1
        ' 
        ' grpOrderDetails
        ' 
        grpOrderDetails.Controls.Add(btnSaveAllItems)
        grpOrderDetails.Controls.Add(btnAddMoreItem)
        grpOrderDetails.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        grpOrderDetails.Location = New Point(30, 485)
        grpOrderDetails.Name = "grpOrderDetails"
        grpOrderDetails.Size = New Size(1290, 380)
        grpOrderDetails.TabIndex = 2
        grpOrderDetails.TabStop = False
        grpOrderDetails.Text = "📝 Order Details (Add Items Here)"
        ' 
        ' btnSaveAllItems
        ' 
        btnSaveAllItems.BackColor = Color.MediumSeaGreen
        btnSaveAllItems.FlatStyle = FlatStyle.Flat
        btnSaveAllItems.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnSaveAllItems.ForeColor = Color.White
        btnSaveAllItems.Location = New Point(645, 330)
        btnSaveAllItems.Name = "btnSaveAllItems"
        btnSaveAllItems.Size = New Size(630, 40)
        btnSaveAllItems.TabIndex = 22
        btnSaveAllItems.Text = "💾 Save All Items to Purchase Order"
        btnSaveAllItems.UseVisualStyleBackColor = False
        ' 
        ' btnAddMoreItem
        ' 
        btnAddMoreItem.BackColor = Color.DodgerBlue
        btnAddMoreItem.FlatStyle = FlatStyle.Flat
        btnAddMoreItem.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnAddMoreItem.ForeColor = Color.White
        btnAddMoreItem.Location = New Point(15, 330)
        btnAddMoreItem.Name = "btnAddMoreItem"
        btnAddMoreItem.Size = New Size(620, 40)
        btnAddMoreItem.TabIndex = 21
        btnAddMoreItem.Text = "➕ Add More Item to List"
        btnAddMoreItem.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(btnNewPO)
        Panel1.Controls.Add(txtRemarks)
        Panel1.Controls.Add(dtpTransactionDate)
        Panel1.Controls.Add(cmbItemType)
        Panel1.Controls.Add(cmbTransactionType)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(lblTransactionType)
        Panel1.Location = New Point(30, 70)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1290, 110)
        Panel1.TabIndex = 3
        ' 
        ' btnNewPO
        ' 
        btnNewPO.BackColor = Color.DarkSlateGray
        btnNewPO.FlatStyle = FlatStyle.Flat
        btnNewPO.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnNewPO.ForeColor = Color.White
        btnNewPO.Location = New Point(860, 55)
        btnNewPO.Name = "btnNewPO"
        btnNewPO.Size = New Size(260, 45)
        btnNewPO.TabIndex = 8
        btnNewPO.Text = "🆕 Create New Purchase Order"
        btnNewPO.UseVisualStyleBackColor = False
        ' 
        ' txtRemarks
        ' 
        txtRemarks.Font = New Font("Segoe UI", 9.0F)
        txtRemarks.Location = New Point(560, 8)
        txtRemarks.Multiline = True
        txtRemarks.Name = "txtRemarks"
        txtRemarks.PlaceholderText = "Enter optional remarks here..."
        txtRemarks.Size = New Size(560, 40)
        txtRemarks.TabIndex = 7
        ' 
        ' dtpTransactionDate
        ' 
        dtpTransactionDate.Font = New Font("Segoe UI", 9.0F)
        dtpTransactionDate.Format = DateTimePickerFormat.Short
        dtpTransactionDate.Location = New Point(150, 75)
        dtpTransactionDate.Name = "dtpTransactionDate"
        dtpTransactionDate.Size = New Size(340, 23)
        dtpTransactionDate.TabIndex = 6
        ' 
        ' cmbItemType
        ' 
        cmbItemType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbItemType.Font = New Font("Segoe UI", 9.0F)
        cmbItemType.FormattingEnabled = True
        cmbItemType.Items.AddRange(New Object() {"Uniform", "Accessory", "Purchase Order", "Issuance", "Request", "Pull-out"})
        cmbItemType.Location = New Point(150, 42)
        cmbItemType.Name = "cmbItemType"
        cmbItemType.Size = New Size(340, 23)
        cmbItemType.TabIndex = 5
        ' 
        ' cmbTransactionType
        ' 
        cmbTransactionType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbTransactionType.Font = New Font("Segoe UI", 9.0F)
        cmbTransactionType.FormattingEnabled = True
        cmbTransactionType.Location = New Point(150, 9)
        cmbTransactionType.Name = "cmbTransactionType"
        cmbTransactionType.Size = New Size(340, 23)
        cmbTransactionType.TabIndex = 4
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        Label3.Location = New Point(510, 11)
        Label3.Name = "Label3"
        Label3.Size = New Size(43, 15)
        Label3.TabIndex = 3
        Label3.Text = "Notes:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        Label2.Location = New Point(15, 78)
        Label2.Name = "Label2"
        Label2.Size = New Size(103, 15)
        Label2.TabIndex = 2
        Label2.Text = "Transaction Date:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        Label1.Location = New Point(15, 45)
        Label1.Name = "Label1"
        Label1.Size = New Size(66, 15)
        Label1.TabIndex = 1
        Label1.Text = "Item Type:"
        ' 
        ' lblTransactionType
        ' 
        lblTransactionType.AutoSize = True
        lblTransactionType.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblTransactionType.Location = New Point(15, 12)
        lblTransactionType.Name = "lblTransactionType"
        lblTransactionType.Size = New Size(102, 15)
        lblTransactionType.TabIndex = 0
        lblTransactionType.Text = "Transaction Type:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        Label8.ForeColor = Color.White
        Label8.Location = New Point(15, 15)
        Label8.Name = "Label8"
        Label8.Size = New Size(318, 21)
        Label8.TabIndex = 4
        Label8.Text = "📦 Purchase Order Management System"
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.White
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnBack.Location = New Point(1221, 11)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(120, 30)
        btnBack.TabIndex = 5
        btnBack.Text = "← Back to Main"
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.DarkSlateGray
        Panel2.Controls.Add(btnBack)
        Panel2.Controls.Add(Label8)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1353, 52)
        Panel2.TabIndex = 6
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Label4.Location = New Point(30, 195)
        Label4.Name = "Label4"
        Label4.Size = New Size(191, 19)
        Label4.TabIndex = 7
        Label4.Text = "📋 All Purchase Orders List"
        ' 
        ' lblTotalAmount
        ' 
        lblTotalAmount.BackColor = Color.Honeydew
        lblTotalAmount.BorderStyle = BorderStyle.FixedSingle
        lblTotalAmount.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblTotalAmount.ForeColor = Color.ForestGreen
        lblTotalAmount.Location = New Point(30, 1115)
        lblTotalAmount.Name = "lblTotalAmount"
        lblTotalAmount.Size = New Size(1290, 40)
        lblTotalAmount.TabIndex = 18
        lblTotalAmount.Text = "Total Amount: ₱ 0.00"
        lblTotalAmount.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' btnRejectPO
        ' 
        btnRejectPO.BackColor = Color.Brown
        btnRejectPO.FlatStyle = FlatStyle.Flat
        btnRejectPO.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnRejectPO.ForeColor = Color.White
        btnRejectPO.Location = New Point(740, 430)
        btnRejectPO.Name = "btnRejectPO"
        btnRejectPO.Size = New Size(233, 40)
        btnRejectPO.TabIndex = 17
        btnRejectPO.Text = "✕ Reject Purchase Order"
        btnRejectPO.UseVisualStyleBackColor = False
        ' 
        ' btnApprovePO
        ' 
        btnApprovePO.BackColor = Color.SeaGreen
        btnApprovePO.FlatStyle = FlatStyle.Flat
        btnApprovePO.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnApprovePO.ForeColor = Color.White
        btnApprovePO.Location = New Point(490, 430)
        btnApprovePO.Name = "btnApprovePO"
        btnApprovePO.Size = New Size(233, 40)
        btnApprovePO.TabIndex = 16
        btnApprovePO.Text = "✓ Approve Purchase Order"
        btnApprovePO.UseVisualStyleBackColor = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Label5.Location = New Point(30, 880)
        Label5.Name = "Label5"
        Label5.Size = New Size(291, 19)
        Label5.TabIndex = 19
        Label5.Text = "📦 Selected Purchase Order - Item Details"
        ' 
        ' frmPurchaseOrder
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        AutoScrollMinSize = New Size(1350, 1180)
        BackColor = Color.LightCyan
        ClientSize = New Size(1370, 749)
        Controls.Add(Label5)
        Controls.Add(btnApprovePO)
        Controls.Add(btnRejectPO)
        Controls.Add(lblTotalAmount)
        Controls.Add(Label4)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(dgvOrderDetails)
        Controls.Add(grpOrderDetails)
        Controls.Add(dgvPurchaseOrders)
        MinimumSize = New Size(1364, 718)
        Name = "frmPurchaseOrder"
        StartPosition = FormStartPosition.CenterScreen
        Text = "📦 Purchase Order Management"
        CType(dgvPurchaseOrders, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvOrderDetails, ComponentModel.ISupportInitialize).EndInit()
        grpOrderDetails.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvPurchaseOrders As DataGridView
    Friend WithEvents dgvOrderDetails As DataGridView
    Friend WithEvents grpOrderDetails As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTransactionType As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbTransactionType As ComboBox
    Friend WithEvents cmbItemType As ComboBox
    Friend WithEvents dtpTransactionDate As DateTimePicker
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents btnNewPO As Button
    Friend WithEvents btnApprovePO As Button
    Friend WithEvents btnRejectPO As Button
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents btnAddMoreItem As Button
    Friend WithEvents btnSaveAllItems As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class