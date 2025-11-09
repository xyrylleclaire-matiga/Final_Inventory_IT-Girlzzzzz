<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHistory
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlMain = New Panel()
        pnlContent = New Panel()
        pnlPagination = New Panel()
        lblPagination = New Label()
        btnNext = New Button()
        btnPrevious = New Button()
        pnlActions = New Panel()
        btnPrint = New Button()
        dgvHistory = New DataGridView()
        pnlFilter = New Panel()
        btnSearch = New Button()
        rbRequest = New RadioButton()
        rbIssuance = New RadioButton()
        txtSearch = New TextBox()
        lblSearchTitle = New Label()
        rbReceiving = New RadioButton()
        rbPurchaseOrder = New RadioButton()
        rbShowAll = New RadioButton()
        lblFilterTitle = New Label()
        pnlHeader = New Panel()
        btnBack = New Button()
        lblTitle = New Label()
        lblIcon = New Label()
        pnlMain.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlPagination.SuspendLayout()
        pnlActions.SuspendLayout()
        CType(dgvHistory, ComponentModel.ISupportInitialize).BeginInit()
        pnlFilter.SuspendLayout()
        pnlHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlMain
        ' 
        pnlMain.AutoScroll = True
        pnlMain.BackColor = Color.White
        pnlMain.Controls.Add(pnlContent)
        pnlMain.Controls.Add(pnlHeader)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(0, 0)
        pnlMain.Name = "pnlMain"
        pnlMain.Size = New Size(1370, 749)
        pnlMain.TabIndex = 0
        ' 
        ' pnlContent
        ' 
        pnlContent.BackColor = Color.LightCyan
        pnlContent.Controls.Add(pnlPagination)
        pnlContent.Controls.Add(pnlActions)
        pnlContent.Controls.Add(dgvHistory)
        pnlContent.Controls.Add(pnlFilter)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(0, 80)
        pnlContent.Name = "pnlContent"
        pnlContent.Padding = New Padding(30)
        pnlContent.Size = New Size(1370, 669)
        pnlContent.TabIndex = 1
        ' 
        ' pnlPagination
        ' 
        pnlPagination.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        pnlPagination.Controls.Add(lblPagination)
        pnlPagination.Controls.Add(btnNext)
        pnlPagination.Controls.Add(btnPrevious)
        pnlPagination.Location = New Point(30, 549)
        pnlPagination.Name = "pnlPagination"
        pnlPagination.Padding = New Padding(20)
        pnlPagination.Size = New Size(1310, 80)
        pnlPagination.TabIndex = 4
        ' 
        ' lblPagination
        ' 
        lblPagination.AutoSize = True
        lblPagination.Dock = DockStyle.Left
        lblPagination.Font = New Font("Segoe UI", 10F)
        lblPagination.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblPagination.Location = New Point(20, 20)
        lblPagination.Name = "lblPagination"
        lblPagination.Padding = New Padding(0, 10, 0, 0)
        lblPagination.Size = New Size(205, 48)
        lblPagination.TabIndex = 0
        lblPagination.Text = "Displaying 10 of 150 total items" & vbCrLf & "Page 1 of 15"
        ' 
        ' btnNext
        ' 
        btnNext.BackColor = Color.White
        btnNext.Cursor = Cursors.Hand
        btnNext.Dock = DockStyle.Right
        btnNext.FlatAppearance.BorderColor = Color.FromArgb(CByte(102), CByte(126), CByte(234))
        btnNext.FlatAppearance.BorderSize = 2
        btnNext.FlatStyle = FlatStyle.Flat
        btnNext.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnNext.ForeColor = Color.DarkSlateGray
        btnNext.Location = New Point(1000, 20)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(140, 40)
        btnNext.TabIndex = 2
        btnNext.Text = "Next ▶"
        btnNext.UseVisualStyleBackColor = False
        ' 
        ' btnPrevious
        ' 
        btnPrevious.BackColor = Color.White
        btnPrevious.Cursor = Cursors.Hand
        btnPrevious.Dock = DockStyle.Right
        btnPrevious.Enabled = False
        btnPrevious.FlatAppearance.BorderColor = Color.FromArgb(CByte(102), CByte(126), CByte(234))
        btnPrevious.FlatAppearance.BorderSize = 2
        btnPrevious.FlatStyle = FlatStyle.Flat
        btnPrevious.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnPrevious.ForeColor = Color.DarkSlateGray
        btnPrevious.Location = New Point(1140, 20)
        btnPrevious.Margin = New Padding(0, 0, 10, 0)
        btnPrevious.Name = "btnPrevious"
        btnPrevious.Size = New Size(150, 40)
        btnPrevious.TabIndex = 1
        btnPrevious.Text = "◀ Previous"
        btnPrevious.UseVisualStyleBackColor = False
        ' 
        ' pnlActions
        ' 
        pnlActions.Controls.Add(btnPrint)
        pnlActions.Location = New Point(30, 489)
        pnlActions.Name = "pnlActions"
        pnlActions.Padding = New Padding(0, 0, 0, 20)
        pnlActions.Size = New Size(1310, 60)
        pnlActions.TabIndex = 3
        ' 
        ' btnPrint
        ' 
        btnPrint.BackColor = Color.DarkSlateGray
        btnPrint.Cursor = Cursors.Hand
        btnPrint.FlatAppearance.BorderSize = 0
        btnPrint.FlatStyle = FlatStyle.Flat
        btnPrint.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnPrint.ForeColor = Color.White
        btnPrint.Location = New Point(1178, 10)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(124, 40)
        btnPrint.TabIndex = 0
        btnPrint.Text = "🖨️ Print"
        btnPrint.UseVisualStyleBackColor = False
        ' 
        ' dgvHistory
        ' 
        dgvHistory.AllowUserToAddRows = False
        dgvHistory.AllowUserToDeleteRows = False
        dgvHistory.AllowUserToOrderColumns = True
        dgvHistory.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        dgvHistory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvHistory.BackgroundColor = Color.White
        dgvHistory.BorderStyle = BorderStyle.None
        dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.DarkSlateGray
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.Padding = New Padding(10)
        DataGridViewCellStyle2.SelectionBackColor = Color.DarkSlateGray
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvHistory.ColumnHeadersHeight = 50
        dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(73), CByte(80), CByte(87))
        DataGridViewCellStyle3.Padding = New Padding(10, 5, 10, 5)
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(231), CByte(241), CByte(255))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(73), CByte(80), CByte(87))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvHistory.DefaultCellStyle = DataGridViewCellStyle3
        dgvHistory.Dock = DockStyle.Top
        dgvHistory.EnableHeadersVisualStyles = False
        dgvHistory.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvHistory.Location = New Point(30, 209)
        dgvHistory.Name = "dgvHistory"
        dgvHistory.ReadOnly = True
        dgvHistory.RowHeadersVisible = False
        dgvHistory.RowTemplate.Height = 45
        dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvHistory.Size = New Size(1310, 280)
        dgvHistory.TabIndex = 2
        ' 
        ' pnlFilter
        ' 
        pnlFilter.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        pnlFilter.BorderStyle = BorderStyle.FixedSingle
        pnlFilter.Controls.Add(btnSearch)
        pnlFilter.Controls.Add(rbRequest)
        pnlFilter.Controls.Add(rbIssuance)
        pnlFilter.Controls.Add(txtSearch)
        pnlFilter.Controls.Add(lblSearchTitle)
        pnlFilter.Controls.Add(rbReceiving)
        pnlFilter.Controls.Add(rbPurchaseOrder)
        pnlFilter.Controls.Add(rbShowAll)
        pnlFilter.Controls.Add(lblFilterTitle)
        pnlFilter.Dock = DockStyle.Top
        pnlFilter.Location = New Point(30, 30)
        pnlFilter.Name = "pnlFilter"
        pnlFilter.Padding = New Padding(20)
        pnlFilter.Size = New Size(1310, 179)
        pnlFilter.TabIndex = 0
        ' 
        ' btnSearch
        ' 
        btnSearch.BackColor = Color.DarkSlateGray
        btnSearch.Cursor = Cursors.Hand
        btnSearch.FlatAppearance.BorderSize = 0
        btnSearch.FlatStyle = FlatStyle.Flat
        btnSearch.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnSearch.ForeColor = Color.White
        btnSearch.Location = New Point(1205, 123)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(97, 27)
        btnSearch.TabIndex = 2
        btnSearch.Text = "🔍 Search"
        btnSearch.TextAlign = ContentAlignment.MiddleLeft
        btnSearch.UseVisualStyleBackColor = False
        ' 
        ' rbRequest
        ' 
        rbRequest.AutoSize = True
        rbRequest.Cursor = Cursors.Hand
        rbRequest.Font = New Font("Gadugi", 9.75F, FontStyle.Bold)
        rbRequest.ForeColor = Color.FromArgb(CByte(73), CByte(80), CByte(87))
        rbRequest.Location = New Point(540, 48)
        rbRequest.Name = "rbRequest"
        rbRequest.Size = New Size(75, 21)
        rbRequest.TabIndex = 5
        rbRequest.Text = "Request"
        rbRequest.UseVisualStyleBackColor = True
        ' 
        ' rbIssuance
        ' 
        rbIssuance.AutoSize = True
        rbIssuance.Cursor = Cursors.Hand
        rbIssuance.Font = New Font("Gadugi", 9.75F, FontStyle.Bold)
        rbIssuance.ForeColor = Color.FromArgb(CByte(73), CByte(80), CByte(87))
        rbIssuance.Location = New Point(420, 48)
        rbIssuance.Name = "rbIssuance"
        rbIssuance.Size = New Size(78, 21)
        rbIssuance.TabIndex = 4
        rbIssuance.Text = "Issuance"
        rbIssuance.UseVisualStyleBackColor = True
        ' 
        ' txtSearch
        ' 
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.Font = New Font("Gadugi", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearch.Location = New Point(30, 123)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = "Search by ID, Type, Status, User, Remarks..."
        txtSearch.Size = New Size(1169, 27)
        txtSearch.TabIndex = 1
        ' 
        ' lblSearchTitle
        ' 
        lblSearchTitle.AutoSize = True
        lblSearchTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblSearchTitle.ForeColor = Color.FromArgb(CByte(73), CByte(80), CByte(87))
        lblSearchTitle.Location = New Point(30, 98)
        lblSearchTitle.Name = "lblSearchTitle"
        lblSearchTitle.Padding = New Padding(0, 0, 0, 10)
        lblSearchTitle.Size = New Size(125, 25)
        lblSearchTitle.TabIndex = 0
        lblSearchTitle.Text = "🔎 SEARCH RECORDS"
        ' 
        ' rbReceiving
        ' 
        rbReceiving.AutoSize = True
        rbReceiving.Cursor = Cursors.Hand
        rbReceiving.Font = New Font("Gadugi", 9.75F, FontStyle.Bold)
        rbReceiving.ForeColor = Color.FromArgb(CByte(73), CByte(80), CByte(87))
        rbReceiving.Location = New Point(300, 48)
        rbReceiving.Name = "rbReceiving"
        rbReceiving.Size = New Size(85, 21)
        rbReceiving.TabIndex = 3
        rbReceiving.Text = "Receiving"
        rbReceiving.UseVisualStyleBackColor = True
        ' 
        ' rbPurchaseOrder
        ' 
        rbPurchaseOrder.AutoSize = True
        rbPurchaseOrder.Cursor = Cursors.Hand
        rbPurchaseOrder.Font = New Font("Gadugi", 9.75F, FontStyle.Bold)
        rbPurchaseOrder.ForeColor = Color.FromArgb(CByte(73), CByte(80), CByte(87))
        rbPurchaseOrder.Location = New Point(140, 48)
        rbPurchaseOrder.Name = "rbPurchaseOrder"
        rbPurchaseOrder.Size = New Size(120, 21)
        rbPurchaseOrder.TabIndex = 2
        rbPurchaseOrder.Text = "Purchase Order"
        rbPurchaseOrder.UseVisualStyleBackColor = True
        ' 
        ' rbShowAll
        ' 
        rbShowAll.AutoSize = True
        rbShowAll.Checked = True
        rbShowAll.Cursor = Cursors.Hand
        rbShowAll.Font = New Font("Gadugi", 9.75F, FontStyle.Bold)
        rbShowAll.ForeColor = Color.FromArgb(CByte(73), CByte(80), CByte(87))
        rbShowAll.Location = New Point(30, 48)
        rbShowAll.Name = "rbShowAll"
        rbShowAll.Size = New Size(80, 21)
        rbShowAll.TabIndex = 1
        rbShowAll.TabStop = True
        rbShowAll.Text = "Show All"
        rbShowAll.UseVisualStyleBackColor = True
        ' 
        ' lblFilterTitle
        ' 
        lblFilterTitle.AutoSize = True
        lblFilterTitle.Dock = DockStyle.Top
        lblFilterTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblFilterTitle.ForeColor = Color.FromArgb(CByte(73), CByte(80), CByte(87))
        lblFilterTitle.Location = New Point(20, 20)
        lblFilterTitle.Name = "lblFilterTitle"
        lblFilterTitle.Padding = New Padding(0, 0, 0, 10)
        lblFilterTitle.Size = New Size(193, 25)
        lblFilterTitle.TabIndex = 0
        lblFilterTitle.Text = "🔍 FILTER BY TRANSACTION TYPE"
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.DarkSlateGray
        pnlHeader.Controls.Add(btnBack)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Controls.Add(lblIcon)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(30, 25, 30, 25)
        pnlHeader.Size = New Size(1370, 80)
        pnlHeader.TabIndex = 0
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.White
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnBack.Location = New Point(1235, 22)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(120, 30)
        btnBack.TabIndex = 6
        btnBack.Text = "← Back to Main"
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Dock = DockStyle.Left
        lblTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(94, 25)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(237, 32)
        lblTitle.TabIndex = 1
        lblTitle.Text = "Transaction History"
        ' 
        ' lblIcon
        ' 
        lblIcon.AutoSize = True
        lblIcon.Dock = DockStyle.Left
        lblIcon.Font = New Font("Segoe UI", 24F)
        lblIcon.ForeColor = Color.White
        lblIcon.Location = New Point(30, 25)
        lblIcon.Name = "lblIcon"
        lblIcon.Size = New Size(64, 45)
        lblIcon.TabIndex = 0
        lblIcon.Text = "📋"
        ' 
        ' frmHistory
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1370, 749)
        Controls.Add(pnlMain)
        MinimumSize = New Size(1200, 700)
        Name = "frmHistory"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Transaction History"
        pnlMain.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlPagination.ResumeLayout(False)
        pnlPagination.PerformLayout()
        pnlActions.ResumeLayout(False)
        CType(dgvHistory, ComponentModel.ISupportInitialize).EndInit()
        pnlFilter.ResumeLayout(False)
        pnlFilter.PerformLayout()
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        ResumeLayout(False)

    End Sub

    ' Control declarations
    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblIcon As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlContent As Panel
    Friend WithEvents pnlFilter As Panel
    Friend WithEvents lblFilterTitle As Label
    Friend WithEvents rbShowAll As RadioButton
    Friend WithEvents rbPurchaseOrder As RadioButton
    Friend WithEvents rbReceiving As RadioButton
    Friend WithEvents rbIssuance As RadioButton
    Friend WithEvents rbRequest As RadioButton
    Friend WithEvents lblSearchTitle As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents dgvHistory As DataGridView
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnPrint As Button
    Friend WithEvents pnlPagination As Panel
    Friend WithEvents lblPagination As Label
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnBack As Button

End Class