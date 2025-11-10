<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStockIssuance
    Inherits System.Windows.Forms.Form

#Region "Designer Generated Code"

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
        Panel1 = New Panel()
        btnBack = New Button()
        Label1 = New Label()
        Panel2 = New Panel()
        GroupBox1 = New GroupBox()
        txtRemarks = New TextBox()
        Label12 = New Label()
        btnAddItem = New Button()
        txtQuantity = New NumericUpDown()
        Label11 = New Label()
        cboSize = New ComboBox()
        Label10 = New Label()
        cboGender = New ComboBox()
        Label9 = New Label()
        cboLevel = New ComboBox()
        Label8 = New Label()
        cboCategory = New ComboBox()
        Label7 = New Label()
        lblAvailableStock = New Label()
        Label5 = New Label()
        cboProduct = New ComboBox()
        Label4 = New Label()
        txtRequestedBy = New TextBox()
        Label3 = New Label()
        dtpIssuanceDate = New DateTimePicker()
        lblTransactionID = New Label()
        Panel3 = New Panel()
        DataGridView1 = New DataGridView()
        Panel4 = New Panel()
        btnClear = New Button()
        btnSave = New Button()
        lblTotalAmount = New Label()
        Label6 = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        GroupBox1.SuspendLayout()
        CType(txtQuantity, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.DarkSlateGray
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(btnBack)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1386, 70)
        Panel1.TabIndex = 0
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.White
        btnBack.FlatAppearance.BorderColor = Color.Silver
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Font = New Font("Segoe UI", 10.0F)
        btnBack.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnBack.Location = New Point(20, 15)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(100, 40)
        btnBack.TabIndex = 1
        btnBack.Text = "← Back"
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(140, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(180, 32)
        Label1.TabIndex = 0
        Label1.Text = "Stock Issuance"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightCyan
        Panel2.Controls.Add(GroupBox1)
        Panel2.Dock = DockStyle.Top
        Panel2.ForeColor = SystemColors.ControlDarkDark
        Panel2.Location = New Point(0, 70)
        Panel2.Name = "Panel2"
        Panel2.Padding = New Padding(20)
        Panel2.Size = New Size(1386, 350)
        Panel2.TabIndex = 1
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.White
        GroupBox1.Controls.Add(txtRemarks)
        GroupBox1.Controls.Add(Label12)
        GroupBox1.Controls.Add(btnAddItem)
        GroupBox1.Controls.Add(txtQuantity)
        GroupBox1.Controls.Add(Label11)
        GroupBox1.Controls.Add(cboSize)
        GroupBox1.Controls.Add(Label10)
        GroupBox1.Controls.Add(cboGender)
        GroupBox1.Controls.Add(Label9)
        GroupBox1.Controls.Add(cboLevel)
        GroupBox1.Controls.Add(Label8)
        GroupBox1.Controls.Add(cboCategory)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(lblAvailableStock)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(cboProduct)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(txtRequestedBy)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(dtpIssuanceDate)
        GroupBox1.Controls.Add(lblTransactionID)
        GroupBox1.Dock = DockStyle.Fill
        GroupBox1.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        GroupBox1.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        GroupBox1.Location = New Point(20, 20)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(15)
        GroupBox1.Size = New Size(1346, 310)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Issuance Information"
        ' 
        ' txtRemarks
        ' 
        txtRemarks.Font = New Font("Segoe UI", 10.0F)
        txtRemarks.Location = New Point(730, 210)
        txtRemarks.Multiline = True
        txtRemarks.Name = "txtRemarks"
        txtRemarks.Size = New Size(250, 60)
        txtRemarks.TabIndex = 20
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI", 10.0F)
        Label12.Location = New Point(730, 185)
        Label12.Name = "Label12"
        Label12.Size = New Size(64, 19)
        Label12.TabIndex = 19
        Label12.Text = "Remarks:"
        ' 
        ' btnAddItem
        ' 
        btnAddItem.BackColor = Color.OliveDrab
        btnAddItem.FlatStyle = FlatStyle.Flat
        btnAddItem.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnAddItem.ForeColor = Color.White
        btnAddItem.Location = New Point(505, 245)
        btnAddItem.Name = "btnAddItem"
        btnAddItem.Size = New Size(180, 45)
        btnAddItem.TabIndex = 18
        btnAddItem.Text = "Add to List"
        btnAddItem.UseVisualStyleBackColor = False
        ' 
        ' txtQuantity
        ' 
        txtQuantity.Font = New Font("Segoe UI", 10.0F)
        txtQuantity.Location = New Point(505, 210)
        txtQuantity.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        txtQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(180, 25)
        txtQuantity.TabIndex = 17
        txtQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 10.0F)
        Label11.Location = New Point(505, 185)
        Label11.Name = "Label11"
        Label11.Size = New Size(66, 19)
        Label11.TabIndex = 16
        Label11.Text = "Quantity:"
        ' 
        ' cboSize
        ' 
        cboSize.DropDownStyle = ComboBoxStyle.DropDownList
        cboSize.Font = New Font("Segoe UI", 10.0F)
        cboSize.FormattingEnabled = True
        cboSize.Location = New Point(280, 210)
        cboSize.Name = "cboSize"
        cboSize.Size = New Size(180, 25)
        cboSize.TabIndex = 15
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 10.0F)
        Label10.Location = New Point(280, 185)
        Label10.Name = "Label10"
        Label10.Size = New Size(35, 19)
        Label10.TabIndex = 14
        Label10.Text = "Size:"
        ' 
        ' cboGender
        ' 
        cboGender.DropDownStyle = ComboBoxStyle.DropDownList
        cboGender.Font = New Font("Segoe UI", 10.0F)
        cboGender.FormattingEnabled = True
        cboGender.Location = New Point(30, 210)
        cboGender.Name = "cboGender"
        cboGender.Size = New Size(200, 25)
        cboGender.TabIndex = 13
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 10.0F)
        Label9.Location = New Point(30, 185)
        Label9.Name = "Label9"
        Label9.Size = New Size(57, 19)
        Label9.TabIndex = 12
        Label9.Text = "Gender:"
        ' 
        ' cboLevel
        ' 
        cboLevel.DropDownStyle = ComboBoxStyle.DropDownList
        cboLevel.Font = New Font("Segoe UI", 10.0F)
        cboLevel.FormattingEnabled = True
        cboLevel.Items.AddRange(New Object() {"Kindergarten", "Elementary", "Integrated High School", "College"})
        cboLevel.Location = New Point(730, 130)
        cboLevel.Name = "cboLevel"
        cboLevel.Size = New Size(250, 25)
        cboLevel.TabIndex = 11
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 10.0F)
        Label8.Location = New Point(730, 105)
        Label8.Name = "Label8"
        Label8.Size = New Size(43, 19)
        Label8.TabIndex = 10
        Label8.Text = "Level:"
        ' 
        ' cboCategory
        ' 
        cboCategory.DropDownStyle = ComboBoxStyle.DropDownList
        cboCategory.Font = New Font("Segoe UI", 10.0F)
        cboCategory.FormattingEnabled = True
        cboCategory.Items.AddRange(New Object() {"School Uniform", "PE Uniform", "Corporate Attire", "Accessories"})
        cboCategory.Location = New Point(400, 130)
        cboCategory.Name = "cboCategory"
        cboCategory.Size = New Size(285, 25)
        cboCategory.TabIndex = 9
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 10.0F)
        Label7.Location = New Point(400, 105)
        Label7.Name = "Label7"
        Label7.Size = New Size(68, 19)
        Label7.TabIndex = 8
        Label7.Text = "Category:"
        ' 
        ' lblAvailableStock
        ' 
        lblAvailableStock.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        lblAvailableStock.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblAvailableStock.ForeColor = Color.Green
        lblAvailableStock.Location = New Point(1008, 115)
        lblAvailableStock.Name = "lblAvailableStock"
        lblAvailableStock.Size = New Size(320, 50)
        lblAvailableStock.TabIndex = 7
        lblAvailableStock.Text = "Available Stock: -"
        lblAvailableStock.TextAlign = ContentAlignment.MiddleCenter
        lblAvailableStock.UseCompatibleTextRendering = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 10.0F)
        Label5.Location = New Point(30, 105)
        Label5.Name = "Label5"
        Label5.Size = New Size(100, 19)
        Label5.TabIndex = 6
        Label5.Text = "Product Name:"
        ' 
        ' cboProduct
        ' 
        cboProduct.DropDownStyle = ComboBoxStyle.DropDownList
        cboProduct.Font = New Font("Segoe UI", 10.0F)
        cboProduct.FormattingEnabled = True
        cboProduct.Location = New Point(30, 130)
        cboProduct.Name = "cboProduct"
        cboProduct.Size = New Size(330, 25)
        cboProduct.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10.0F)
        Label4.Location = New Point(730, 40)
        Label4.Name = "Label4"
        Label4.Size = New Size(95, 19)
        Label4.TabIndex = 4
        Label4.Text = "Requested By:"
        ' 
        ' txtRequestedBy
        ' 
        txtRequestedBy.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        txtRequestedBy.Font = New Font("Segoe UI", 10.0F)
        txtRequestedBy.Location = New Point(730, 65)
        txtRequestedBy.Name = "txtRequestedBy"
        txtRequestedBy.ReadOnly = True
        txtRequestedBy.Size = New Size(250, 25)
        txtRequestedBy.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10.0F)
        Label3.Location = New Point(400, 40)
        Label3.Name = "Label3"
        Label3.Size = New Size(97, 19)
        Label3.TabIndex = 2
        Label3.Text = "Issuance Date:"
        ' 
        ' dtpIssuanceDate
        ' 
        dtpIssuanceDate.Font = New Font("Segoe UI", 10.0F)
        dtpIssuanceDate.Location = New Point(400, 65)
        dtpIssuanceDate.Name = "dtpIssuanceDate"
        dtpIssuanceDate.Size = New Size(285, 25)
        dtpIssuanceDate.TabIndex = 1
        ' 
        ' lblTransactionID
        ' 
        lblTransactionID.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        lblTransactionID.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblTransactionID.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblTransactionID.Location = New Point(30, 40)
        lblTransactionID.Name = "lblTransactionID"
        lblTransactionID.Padding = New Padding(10)
        lblTransactionID.Size = New Size(330, 50)
        lblTransactionID.TabIndex = 0
        lblTransactionID.Text = "Transaction ID: -"
        lblTransactionID.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.White
        Panel3.Controls.Add(DataGridView1)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(0, 420)
        Panel3.Name = "Panel3"
        Panel3.Padding = New Padding(20, 10, 20, 10)
        Panel3.Size = New Size(1386, 288)
        Panel3.TabIndex = 2
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.BorderStyle = BorderStyle.None
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridView1.ColumnHeadersHeight = 40
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.GridColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        DataGridView1.Location = New Point(20, 10)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowTemplate.Height = 35
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(1346, 268)
        DataGridView1.TabIndex = 0
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.DarkSlateGray
        Panel4.BorderStyle = BorderStyle.FixedSingle
        Panel4.Controls.Add(btnClear)
        Panel4.Controls.Add(btnSave)
        Panel4.Controls.Add(lblTotalAmount)
        Panel4.Controls.Add(Label6)
        Panel4.Dock = DockStyle.Bottom
        Panel4.Location = New Point(0, 708)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1386, 80)
        Panel4.TabIndex = 3
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.White
        btnClear.FlatAppearance.BorderColor = Color.Silver
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        btnClear.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnClear.Location = New Point(1010, 8)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(150, 46)
        btnClear.TabIndex = 3
        btnClear.Text = "Clear All"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.Green
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(1180, 8)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(200, 46)
        btnSave.TabIndex = 2
        btnSave.Text = "Save Issuance"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' lblTotalAmount
        ' 
        lblTotalAmount.BackColor = Color.DarkSlateGray
        lblTotalAmount.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblTotalAmount.ForeColor = Color.White
        lblTotalAmount.Location = New Point(150, 8)
        lblTotalAmount.Name = "lblTotalAmount"
        lblTotalAmount.Size = New Size(200, 46)
        lblTotalAmount.TabIndex = 1
        lblTotalAmount.Text = "₱0.00"
        lblTotalAmount.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.DarkSlateGray
        Label6.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(20, 21)
        Label6.Name = "Label6"
        Label6.Size = New Size(118, 21)
        Label6.TabIndex = 0
        Label6.Text = "Total Amount:"
        ' 
        ' frmStockIssuance
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1386, 788)
        Controls.Add(Panel3)
        Controls.Add(Panel4)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmStockIssuance"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Stock Issuance"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(txtQuantity, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        ResumeLayout(False)

    End Sub

#End Region

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblTransactionID As Label
    Friend WithEvents dtpIssuanceDate As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRequestedBy As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboProduct As ComboBox
    Friend WithEvents lblAvailableStock As Label
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cboLevel As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cboGender As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cboSize As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtQuantity As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents btnAddItem As Button
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClear As Button
End Class