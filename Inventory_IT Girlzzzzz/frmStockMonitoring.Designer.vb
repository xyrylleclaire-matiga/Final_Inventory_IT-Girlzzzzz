<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStockMonitoring
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Panel1 = New Panel()
        btnBack = New Button()
        Label1 = New Label()
        Panel2 = New Panel()
        Panel9 = New Panel()
        lblTotalPulledOut = New Label()
        Label16 = New Label()
        Panel10 = New Panel()
        lblTotalIssued = New Label()
        Label14 = New Label()
        Panel11 = New Panel()
        lblTotalPurchased = New Label()
        Label12 = New Label()
        Panel8 = New Panel()
        lblTotalValue = New Label()
        Label10 = New Label()
        Panel6 = New Panel()
        lblOutOfStock = New Label()
        Label8 = New Label()
        Panel5 = New Panel()
        lblLowStock = New Label()
        Label6 = New Label()
        Panel4 = New Panel()
        lblTotalStock = New Label()
        Label4 = New Label()
        Panel3 = New Panel()
        lblTotalProducts = New Label()
        Label2 = New Label()
        Panel7 = New Panel()
        Label13 = New Label()
        cboStockStatus = New ComboBox()
        Label3 = New Label()
        cboStatus = New ComboBox()
        btnRefresh = New Button()
        btnExport = New Button()
        cboGender = New ComboBox()
        cboLevel = New ComboBox()
        cboCategory = New ComboBox()
        txtSearch = New TextBox()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        DataGridView1 = New DataGridView()
        TabPage2 = New TabPage()
        Panel12 = New Panel()
        chartStockTrend = New DataVisualization.Charting.Chart()
        Panel13 = New Panel()
        chartCategoryDistribution = New DataVisualization.Charting.Chart()
        TabPage3 = New TabPage()
        dgvMovementHistory = New DataGridView()
        Panel14 = New Panel()
        Label11 = New Label()
        dtpTo = New DateTimePicker()
        Label9 = New Label()
        dtpFrom = New DateTimePicker()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel9.SuspendLayout()
        Panel10.SuspendLayout()
        Panel11.SuspendLayout()
        Panel8.SuspendLayout()
        Panel6.SuspendLayout()
        Panel5.SuspendLayout()
        Panel4.SuspendLayout()
        Panel3.SuspendLayout()
        Panel7.SuspendLayout()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        TabPage2.SuspendLayout()
        Panel12.SuspendLayout()
        CType(chartStockTrend, ComponentModel.ISupportInitialize).BeginInit()
        Panel13.SuspendLayout()
        CType(chartCategoryDistribution, ComponentModel.ISupportInitialize).BeginInit()
        TabPage3.SuspendLayout()
        CType(dgvMovementHistory, ComponentModel.ISupportInitialize).BeginInit()
        Panel14.SuspendLayout()
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
        Panel1.Size = New Size(1386, 63)
        Panel1.TabIndex = 0
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.White
        btnBack.FlatAppearance.BorderColor = Color.Silver
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Font = New Font("Segoe UI", 10.0F)
        btnBack.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnBack.Location = New Point(23, 8)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(105, 40)
        btnBack.TabIndex = 1
        btnBack.Text = "← Back"
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(152, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(221, 21)
        Label1.TabIndex = 0
        Label1.Text = "Stock Monitoring & Analytics"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightCyan
        Panel2.Controls.Add(Panel9)
        Panel2.Controls.Add(Panel10)
        Panel2.Controls.Add(Panel11)
        Panel2.Controls.Add(Panel8)
        Panel2.Controls.Add(Panel6)
        Panel2.Controls.Add(Panel5)
        Panel2.Controls.Add(Panel4)
        Panel2.Controls.Add(Panel3)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 63)
        Panel2.Name = "Panel2"
        Panel2.Padding = New Padding(23, 17, 23, 17)
        Panel2.Size = New Size(1386, 160)
        Panel2.TabIndex = 1
        ' 
        ' Panel9
        ' 
        Panel9.BackColor = Color.White
        Panel9.BorderStyle = BorderStyle.FixedSingle
        Panel9.Controls.Add(lblTotalPulledOut)
        Panel9.Controls.Add(Label16)
        Panel9.Location = New Point(888, 84)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(180, 60)
        Panel9.TabIndex = 7
        ' 
        ' lblTotalPulledOut
        ' 
        lblTotalPulledOut.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblTotalPulledOut.ForeColor = Color.FromArgb(CByte(128), CByte(0), CByte(128))
        lblTotalPulledOut.Location = New Point(3, 25)
        lblTotalPulledOut.Name = "lblTotalPulledOut"
        lblTotalPulledOut.Size = New Size(172, 30)
        lblTotalPulledOut.TabIndex = 1
        lblTotalPulledOut.Text = "0"
        lblTotalPulledOut.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label16
        ' 
        Label16.Font = New Font("Segoe UI", 8.0F)
        Label16.ForeColor = Color.Gray
        Label16.Location = New Point(3, 5)
        Label16.Name = "Label16"
        Label16.Size = New Size(172, 18)
        Label16.TabIndex = 0
        Label16.Text = "Pulled Out (30d)"
        Label16.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel10
        ' 
        Panel10.BackColor = Color.White
        Panel10.BorderStyle = BorderStyle.FixedSingle
        Panel10.Controls.Add(lblTotalIssued)
        Panel10.Controls.Add(Label14)
        Panel10.Location = New Point(670, 84)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(180, 60)
        Panel10.TabIndex = 6
        ' 
        ' lblTotalIssued
        ' 
        lblTotalIssued.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblTotalIssued.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        lblTotalIssued.Location = New Point(3, 25)
        lblTotalIssued.Name = "lblTotalIssued"
        lblTotalIssued.Size = New Size(172, 30)
        lblTotalIssued.TabIndex = 1
        lblTotalIssued.Text = "0"
        lblTotalIssued.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label14
        ' 
        Label14.Font = New Font("Segoe UI", 8.0F)
        Label14.ForeColor = Color.Gray
        Label14.Location = New Point(3, 5)
        Label14.Name = "Label14"
        Label14.Size = New Size(172, 18)
        Label14.TabIndex = 0
        Label14.Text = "Total Issued (30d)"
        Label14.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel11
        ' 
        Panel11.BackColor = Color.White
        Panel11.BorderStyle = BorderStyle.FixedSingle
        Panel11.Controls.Add(lblTotalPurchased)
        Panel11.Controls.Add(Label12)
        Panel11.Location = New Point(453, 84)
        Panel11.Name = "Panel11"
        Panel11.Size = New Size(180, 60)
        Panel11.TabIndex = 5
        ' 
        ' lblTotalPurchased
        ' 
        lblTotalPurchased.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblTotalPurchased.ForeColor = Color.Green
        lblTotalPurchased.Location = New Point(3, 25)
        lblTotalPurchased.Name = "lblTotalPurchased"
        lblTotalPurchased.Size = New Size(172, 30)
        lblTotalPurchased.TabIndex = 1
        lblTotalPurchased.Text = "0"
        lblTotalPurchased.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label12
        ' 
        Label12.Font = New Font("Segoe UI", 8.0F)
        Label12.ForeColor = Color.Gray
        Label12.Location = New Point(3, 5)
        Label12.Name = "Label12"
        Label12.Size = New Size(172, 18)
        Label12.TabIndex = 0
        Label12.Text = "Total Purchased (30d)"
        Label12.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.White
        Panel8.BorderStyle = BorderStyle.FixedSingle
        Panel8.Controls.Add(lblTotalValue)
        Panel8.Controls.Add(Label10)
        Panel8.Location = New Point(237, 84)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(180, 60)
        Panel8.TabIndex = 4
        ' 
        ' lblTotalValue
        ' 
        lblTotalValue.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        lblTotalValue.ForeColor = Color.FromArgb(CByte(0), CByte(123), CByte(255))
        lblTotalValue.Location = New Point(3, 25)
        lblTotalValue.Name = "lblTotalValue"
        lblTotalValue.Size = New Size(172, 30)
        lblTotalValue.TabIndex = 1
        lblTotalValue.Text = "₱0.00"
        lblTotalValue.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label10
        ' 
        Label10.Font = New Font("Segoe UI", 8.0F)
        Label10.ForeColor = Color.Gray
        Label10.Location = New Point(3, 5)
        Label10.Name = "Label10"
        Label10.Size = New Size(172, 18)
        Label10.TabIndex = 0
        Label10.Text = "Total Inventory Value"
        Label10.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.White
        Panel6.BorderStyle = BorderStyle.FixedSingle
        Panel6.Controls.Add(lblOutOfStock)
        Panel6.Controls.Add(Label8)
        Panel6.Location = New Point(1029, 14)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(242, 60)
        Panel6.TabIndex = 3
        ' 
        ' lblOutOfStock
        ' 
        lblOutOfStock.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        lblOutOfStock.ForeColor = Color.Red
        lblOutOfStock.Location = New Point(40, 25)
        lblOutOfStock.Name = "lblOutOfStock"
        lblOutOfStock.Size = New Size(162, 30)
        lblOutOfStock.TabIndex = 1
        lblOutOfStock.Text = "0"
        lblOutOfStock.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label8
        ' 
        Label8.Font = New Font("Segoe UI", 9.0F)
        Label8.ForeColor = Color.Gray
        Label8.Location = New Point(36, 5)
        Label8.Name = "Label8"
        Label8.Size = New Size(162, 18)
        Label8.TabIndex = 0
        Label8.Text = "Out of Stock"
        Label8.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.White
        Panel5.BorderStyle = BorderStyle.FixedSingle
        Panel5.Controls.Add(lblLowStock)
        Panel5.Controls.Add(Label6)
        Panel5.Location = New Point(721, 14)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(248, 60)
        Panel5.TabIndex = 2
        ' 
        ' lblLowStock
        ' 
        lblLowStock.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        lblLowStock.ForeColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        lblLowStock.Location = New Point(42, 25)
        lblLowStock.Name = "lblLowStock"
        lblLowStock.Size = New Size(172, 30)
        lblLowStock.TabIndex = 1
        lblLowStock.Text = "0"
        lblLowStock.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label6
        ' 
        Label6.Font = New Font("Segoe UI", 9.0F)
        Label6.ForeColor = Color.Gray
        Label6.Location = New Point(38, 5)
        Label6.Name = "Label6"
        Label6.Size = New Size(172, 18)
        Label6.TabIndex = 0
        Label6.Text = "Low Stock Items"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.White
        Panel4.BorderStyle = BorderStyle.FixedSingle
        Panel4.Controls.Add(lblTotalStock)
        Panel4.Controls.Add(Label4)
        Panel4.Location = New Point(377, 14)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(254, 60)
        Panel4.TabIndex = 1
        ' 
        ' lblTotalStock
        ' 
        lblTotalStock.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        lblTotalStock.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblTotalStock.Location = New Point(22, 25)
        lblTotalStock.Name = "lblTotalStock"
        lblTotalStock.Size = New Size(212, 30)
        lblTotalStock.TabIndex = 1
        lblTotalStock.Text = "0"
        lblTotalStock.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label4
        ' 
        Label4.Font = New Font("Segoe UI", 9.0F)
        Label4.ForeColor = Color.Gray
        Label4.Location = New Point(23, 5)
        Label4.Name = "Label4"
        Label4.Size = New Size(212, 18)
        Label4.TabIndex = 0
        Label4.Text = "Total Stock Quantity"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.White
        Panel3.BorderStyle = BorderStyle.FixedSingle
        Panel3.Controls.Add(lblTotalProducts)
        Panel3.Controls.Add(Label2)
        Panel3.Location = New Point(85, 14)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(234, 60)
        Panel3.TabIndex = 0
        ' 
        ' lblTotalProducts
        ' 
        lblTotalProducts.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        lblTotalProducts.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblTotalProducts.Location = New Point(16, 25)
        lblTotalProducts.Name = "lblTotalProducts"
        lblTotalProducts.Size = New Size(192, 30)
        lblTotalProducts.TabIndex = 1
        lblTotalProducts.Text = "0"
        lblTotalProducts.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Segoe UI", 9.0F)
        Label2.ForeColor = Color.Gray
        Label2.Location = New Point(19, 5)
        Label2.Name = "Label2"
        Label2.Size = New Size(192, 18)
        Label2.TabIndex = 0
        Label2.Text = "Total Products"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = Color.LightCyan
        Panel7.BorderStyle = BorderStyle.FixedSingle
        Panel7.Controls.Add(Label13)
        Panel7.Controls.Add(cboStockStatus)
        Panel7.Controls.Add(Label3)
        Panel7.Controls.Add(cboStatus)
        Panel7.Controls.Add(btnRefresh)
        Panel7.Controls.Add(btnExport)
        Panel7.Controls.Add(cboGender)
        Panel7.Controls.Add(cboLevel)
        Panel7.Controls.Add(cboCategory)
        Panel7.Controls.Add(txtSearch)
        Panel7.Dock = DockStyle.Top
        Panel7.Location = New Point(0, 223)
        Panel7.Name = "Panel7"
        Panel7.Padding = New Padding(23, 10, 23, 10)
        Panel7.Size = New Size(1386, 100)
        Panel7.TabIndex = 2
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Segoe UI", 8.0F)
        Label13.ForeColor = Color.Gray
        Label13.Location = New Point(910, 46)
        Label13.Name = "Label13"
        Label13.Size = New Size(73, 13)
        Label13.TabIndex = 9
        Label13.Text = "Stock Status:"
        ' 
        ' cboStockStatus
        ' 
        cboStockStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboStockStatus.FlatStyle = FlatStyle.Flat
        cboStockStatus.Font = New Font("Segoe UI", 9.0F)
        cboStockStatus.FormattingEnabled = True
        cboStockStatus.Items.AddRange(New Object() {"All Stock Status", "In Stock", "Low Stock", "Out of Stock"})
        cboStockStatus.Location = New Point(910, 62)
        cboStockStatus.Name = "cboStockStatus"
        cboStockStatus.Size = New Size(150, 23)
        cboStockStatus.TabIndex = 8
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 8.0F)
        Label3.ForeColor = Color.Gray
        Label3.Location = New Point(659, 46)
        Label3.Name = "Label3"
        Label3.Size = New Size(91, 13)
        Label3.TabIndex = 7
        Label3.Text = "Approval Status:"
        ' 
        ' cboStatus
        ' 
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatus.FlatStyle = FlatStyle.Flat
        cboStatus.Font = New Font("Segoe UI", 9.0F)
        cboStatus.FormattingEnabled = True
        cboStatus.Items.AddRange(New Object() {"All Status", "Approved", "Pending", "Rejected"})
        cboStatus.Location = New Point(659, 61)
        cboStatus.Name = "cboStatus"
        cboStatus.Size = New Size(230, 23)
        cboStatus.TabIndex = 6
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.SteelBlue
        btnRefresh.FlatAppearance.BorderSize = 0
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 10.0F)
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(1078, 30)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(114, 35)
        btnRefresh.TabIndex = 5
        btnRefresh.Text = "🔄 Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' btnExport
        ' 
        btnExport.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnExport.FlatAppearance.BorderSize = 0
        btnExport.FlatStyle = FlatStyle.Flat
        btnExport.Font = New Font("Segoe UI", 10.0F)
        btnExport.ForeColor = Color.White
        btnExport.Location = New Point(1210, 30)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(138, 35)
        btnExport.TabIndex = 4
        btnExport.Text = "📊 Export to Excel"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' cboGender
        ' 
        cboGender.DropDownStyle = ComboBoxStyle.DropDownList
        cboGender.FlatStyle = FlatStyle.Flat
        cboGender.Font = New Font("Segoe UI", 10.0F)
        cboGender.FormattingEnabled = True
        cboGender.Items.AddRange(New Object() {"All Gender", "Female", "Male", "Unisex"})
        cboGender.Location = New Point(910, 16)
        cboGender.Name = "cboGender"
        cboGender.Size = New Size(150, 25)
        cboGender.TabIndex = 3
        ' 
        ' cboLevel
        ' 
        cboLevel.DropDownStyle = ComboBoxStyle.DropDownList
        cboLevel.FlatStyle = FlatStyle.Flat
        cboLevel.Font = New Font("Segoe UI", 10.0F)
        cboLevel.FormattingEnabled = True
        cboLevel.Items.AddRange(New Object() {"All Levels", "Kindergarten", "Elementary", "Integrated High School", "College"})
        cboLevel.Location = New Point(660, 16)
        cboLevel.Name = "cboLevel"
        cboLevel.Size = New Size(230, 25)
        cboLevel.TabIndex = 2
        ' 
        ' cboCategory
        ' 
        cboCategory.DropDownStyle = ComboBoxStyle.DropDownList
        cboCategory.FlatStyle = FlatStyle.Flat
        cboCategory.Font = New Font("Segoe UI", 10.0F)
        cboCategory.FormattingEnabled = True
        cboCategory.Items.AddRange(New Object() {"All Categories", "School Uniform", "PE Uniform", "Corporate Attire", "Accessories"})
        cboCategory.Location = New Point(440, 16)
        cboCategory.Name = "cboCategory"
        cboCategory.Size = New Size(200, 25)
        cboCategory.TabIndex = 1
        ' 
        ' txtSearch
        ' 
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.Font = New Font("Segoe UI", 11.0F)
        txtSearch.ForeColor = Color.Gray
        txtSearch.Location = New Point(25, 16)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(390, 27)
        txtSearch.TabIndex = 0
        txtSearch.Text = "Search products..."
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Dock = DockStyle.Fill
        TabControl1.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        TabControl1.Location = New Point(0, 323)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(1386, 465)
        TabControl1.TabIndex = 3
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(DataGridView1)
        TabPage1.Location = New Point(4, 26)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(1378, 435)
        TabPage1.TabIndex = 0
        TabPage1.Text = "📋 Stock List"
        TabPage1.UseVisualStyleBackColor = True
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
        DataGridView1.Location = New Point(3, 3)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowTemplate.Height = 35
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(1372, 429)
        DataGridView1.TabIndex = 0
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(Panel12)
        TabPage2.Controls.Add(Panel13)
        TabPage2.Location = New Point(4, 26)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(1378, 435)
        TabPage2.TabIndex = 1
        TabPage2.Text = "📊 Analytics & Charts"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' Panel12
        ' 
        Panel12.Controls.Add(chartStockTrend)
        Panel12.Dock = DockStyle.Fill
        Panel12.Location = New Point(3, 3)
        Panel12.Name = "Panel12"
        Panel12.Padding = New Padding(10)
        Panel12.Size = New Size(872, 429)
        Panel12.TabIndex = 0
        ' 
        ' chartStockTrend
        ' 
        ChartArea1.Name = "ChartArea1"
        chartStockTrend.ChartAreas.Add(ChartArea1)
        chartStockTrend.Dock = DockStyle.Fill
        chartStockTrend.Location = New Point(10, 10)
        chartStockTrend.Name = "chartStockTrend"
        chartStockTrend.Size = New Size(852, 409)
        chartStockTrend.TabIndex = 0
        chartStockTrend.Text = "Stock Movement Trend"
        ' 
        ' Panel13
        ' 
        Panel13.Controls.Add(chartCategoryDistribution)
        Panel13.Dock = DockStyle.Right
        Panel13.Location = New Point(875, 3)
        Panel13.Name = "Panel13"
        Panel13.Padding = New Padding(10)
        Panel13.Size = New Size(500, 429)
        Panel13.TabIndex = 1
        ' 
        ' chartCategoryDistribution
        ' 
        ChartArea2.Name = "ChartArea1"
        chartCategoryDistribution.ChartAreas.Add(ChartArea2)
        chartCategoryDistribution.Dock = DockStyle.Fill
        chartCategoryDistribution.Location = New Point(10, 10)
        chartCategoryDistribution.Name = "chartCategoryDistribution"
        chartCategoryDistribution.Size = New Size(480, 409)
        chartCategoryDistribution.TabIndex = 0
        chartCategoryDistribution.Text = "Category Distribution"
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(dgvMovementHistory)
        TabPage3.Controls.Add(Panel14)
        TabPage3.Location = New Point(4, 26)
        TabPage3.Name = "TabPage3"
        TabPage3.Size = New Size(1378, 435)
        TabPage3.TabIndex = 2
        TabPage3.Text = "📜 Movement History"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' dgvMovementHistory
        ' 
        dgvMovementHistory.AllowUserToAddRows = False
        dgvMovementHistory.AllowUserToDeleteRows = False
        dgvMovementHistory.BackgroundColor = Color.White
        dgvMovementHistory.BorderStyle = BorderStyle.None
        dgvMovementHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvMovementHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        dgvMovementHistory.ColumnHeadersHeight = 35
        dgvMovementHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvMovementHistory.Dock = DockStyle.Fill
        dgvMovementHistory.EnableHeadersVisualStyles = False
        dgvMovementHistory.GridColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        dgvMovementHistory.Location = New Point(0, 60)
        dgvMovementHistory.Name = "dgvMovementHistory"
        dgvMovementHistory.ReadOnly = True
        dgvMovementHistory.RowHeadersVisible = False
        dgvMovementHistory.RowTemplate.Height = 30
        dgvMovementHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMovementHistory.Size = New Size(1378, 375)
        dgvMovementHistory.TabIndex = 1
        ' 
        ' Panel14
        ' 
        Panel14.BackColor = Color.WhiteSmoke
        Panel14.BorderStyle = BorderStyle.FixedSingle
        Panel14.Controls.Add(Label11)
        Panel14.Controls.Add(dtpTo)
        Panel14.Controls.Add(Label9)
        Panel14.Controls.Add(dtpFrom)
        Panel14.Dock = DockStyle.Top
        Panel14.Location = New Point(0, 0)
        Panel14.Name = "Panel14"
        Panel14.Padding = New Padding(20, 12, 20, 12)
        Panel14.Size = New Size(1378, 60)
        Panel14.TabIndex = 0
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Label11.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label11.Location = New Point(350, 18)
        Label11.Name = "Label11"
        Label11.Size = New Size(29, 19)
        Label11.TabIndex = 3
        Label11.Text = "To:"
        ' 
        ' dtpTo
        ' 
        dtpTo.CalendarFont = New Font("Segoe UI", 9.0F)
        dtpTo.Font = New Font("Segoe UI", 10.0F)
        dtpTo.Format = DateTimePickerFormat.Short
        dtpTo.Location = New Point(385, 15)
        dtpTo.Name = "dtpTo"
        dtpTo.Size = New Size(150, 25)
        dtpTo.TabIndex = 2
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Label9.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label9.Location = New Point(30, 18)
        Label9.Name = "Label9"
        Label9.Size = New Size(83, 19)
        Label9.TabIndex = 1
        Label9.Text = "Date From:"
        ' 
        ' dtpFrom
        ' 
        dtpFrom.CalendarFont = New Font("Segoe UI", 9.0F)
        dtpFrom.Font = New Font("Segoe UI", 10.0F)
        dtpFrom.Format = DateTimePickerFormat.Short
        dtpFrom.Location = New Point(120, 15)
        dtpFrom.Name = "dtpFrom"
        dtpFrom.Size = New Size(150, 25)
        dtpFrom.TabIndex = 0
        ' 
        ' frmStockMonitoring
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1386, 788)
        Controls.Add(TabControl1)
        Controls.Add(Panel7)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmStockMonitoring"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Stock Monitoring & Analytics"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel9.ResumeLayout(False)
        Panel10.ResumeLayout(False)
        Panel11.ResumeLayout(False)
        Panel8.ResumeLayout(False)
        Panel6.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        TabPage2.ResumeLayout(False)
        Panel12.ResumeLayout(False)
        CType(chartStockTrend, ComponentModel.ISupportInitialize).EndInit()
        Panel13.ResumeLayout(False)
        CType(chartCategoryDistribution, ComponentModel.ISupportInitialize).EndInit()
        TabPage3.ResumeLayout(False)
        CType(dgvMovementHistory, ComponentModel.ISupportInitialize).EndInit()
        Panel14.ResumeLayout(False)
        Panel14.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblTotalProducts As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblTotalStock As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblLowStock As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lblOutOfStock As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents cboLevel As ComboBox
    Friend WithEvents cboGender As ComboBox
    Friend WithEvents btnExport As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents lblTotalValue As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents lblTotalPulledOut As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents lblTotalIssued As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents lblTotalPurchased As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboStockStatus As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Panel12 As Panel
    Friend WithEvents chartStockTrend As DataVisualization.Charting.Chart
    Friend WithEvents Panel13 As Panel
    Friend WithEvents chartCategoryDistribution As DataVisualization.Charting.Chart
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents dgvMovementHistory As DataGridView
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpFrom As DateTimePicker
End Class