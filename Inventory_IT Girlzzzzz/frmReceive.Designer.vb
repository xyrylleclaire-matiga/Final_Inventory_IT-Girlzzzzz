<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReceive
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
        pnlHeader = New Panel()
        lblHeader = New Label()
        grpPurchaseOrders = New GroupBox()
        dgvPurchaseOrders = New DataGridView()
        grpPurchaseDetails = New GroupBox()
        dgvPurchaseDetails = New DataGridView()
        pnlInstructions = New Panel()
        lblInstructions = New Label()
        lblInstruction1 = New Label()
        lblInstruction2 = New Label()
        pnlLegend = New Panel()
        lblLegendTitle = New Label()
        pnlEditableColor = New Panel()
        lblEditable = New Label()
        pnlNoRejectColor = New Panel()
        lblNoReject = New Label()
        lblHasReject = New Label()
        btnReceive = New Button()
        btnCancel = New Button()
        pnlStatusBar = New Panel()
        lblStatus = New Label()
        lblUserInfo = New Label()
        lblVersion = New Label()
        cmbRejectReason = New ComboBox()
        pnlHeader.SuspendLayout()
        grpPurchaseOrders.SuspendLayout()
        CType(dgvPurchaseOrders, ComponentModel.ISupportInitialize).BeginInit()
        grpPurchaseDetails.SuspendLayout()
        CType(dgvPurchaseDetails, ComponentModel.ISupportInitialize).BeginInit()
        pnlInstructions.SuspendLayout()
        pnlLegend.SuspendLayout()
        pnlStatusBar.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.DarkSlateGray
        pnlHeader.Controls.Add(lblHeader)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1370, 70)
        pnlHeader.TabIndex = 0
        ' 
        ' lblHeader
        ' 
        lblHeader.AutoSize = True
        lblHeader.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        lblHeader.ForeColor = Color.White
        lblHeader.Location = New Point(20, 18)
        lblHeader.Name = "lblHeader"
        lblHeader.Size = New Size(488, 37)
        lblHeader.TabIndex = 0
        lblHeader.Text = "📦 Purchase Order Receiving System"
        ' 
        ' grpPurchaseOrders
        ' 
        grpPurchaseOrders.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        grpPurchaseOrders.Controls.Add(dgvPurchaseOrders)
        grpPurchaseOrders.Font = New Font("Gadugi", 11.0F, FontStyle.Bold)
        grpPurchaseOrders.Location = New Point(9, 90)
        grpPurchaseOrders.Name = "grpPurchaseOrders"
        grpPurchaseOrders.Size = New Size(1360, 159)
        grpPurchaseOrders.TabIndex = 1
        grpPurchaseOrders.TabStop = False
        grpPurchaseOrders.Text = "1️⃣ Approved Purchase Orders"
        ' 
        ' dgvPurchaseOrders
        ' 
        dgvPurchaseOrders.AllowUserToAddRows = False
        dgvPurchaseOrders.AllowUserToDeleteRows = False
        dgvPurchaseOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPurchaseOrders.BackgroundColor = Color.White
        dgvPurchaseOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPurchaseOrders.Location = New Point(10, 30)
        dgvPurchaseOrders.MultiSelect = False
        dgvPurchaseOrders.Name = "dgvPurchaseOrders"
        dgvPurchaseOrders.ReadOnly = True
        dgvPurchaseOrders.RowHeadersWidth = 51
        dgvPurchaseOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPurchaseOrders.Size = New Size(1340, 112)
        dgvPurchaseOrders.TabIndex = 0
        ' 
        ' grpPurchaseDetails
        ' 
        grpPurchaseDetails.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        grpPurchaseDetails.Controls.Add(dgvPurchaseDetails)
        grpPurchaseDetails.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        grpPurchaseDetails.Location = New Point(13, 257)
        grpPurchaseDetails.Name = "grpPurchaseDetails"
        grpPurchaseDetails.Size = New Size(1360, 240)
        grpPurchaseDetails.TabIndex = 2
        grpPurchaseDetails.TabStop = False
        grpPurchaseDetails.Text = "2️⃣ Purchase Order Details (Click a row above to view)"
        ' 
        ' dgvPurchaseDetails
        ' 
        dgvPurchaseDetails.AllowUserToAddRows = False
        dgvPurchaseDetails.AllowUserToDeleteRows = False
        dgvPurchaseDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPurchaseDetails.BackgroundColor = Color.White
        dgvPurchaseDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPurchaseDetails.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        dgvPurchaseDetails.Location = New Point(7, 30)
        dgvPurchaseDetails.Name = "dgvPurchaseDetails"
        dgvPurchaseDetails.RowHeadersWidth = 51
        dgvPurchaseDetails.Size = New Size(1340, 200)
        dgvPurchaseDetails.TabIndex = 0
        ' 
        ' pnlInstructions
        ' 
        pnlInstructions.BackColor = Color.FromArgb(CByte(209), CByte(236), CByte(241))
        pnlInstructions.BorderStyle = BorderStyle.FixedSingle
        pnlInstructions.Controls.Add(lblInstructions)
        pnlInstructions.Controls.Add(lblInstruction1)
        pnlInstructions.Controls.Add(lblInstruction2)
        pnlInstructions.Location = New Point(20, 503)
        pnlInstructions.Name = "pnlInstructions"
        pnlInstructions.Size = New Size(1340, 65)
        pnlInstructions.TabIndex = 3
        ' 
        ' lblInstructions
        ' 
        lblInstructions.AutoSize = True
        lblInstructions.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblInstructions.ForeColor = Color.FromArgb(CByte(12), CByte(84), CByte(96))
        lblInstructions.Location = New Point(10, 8)
        lblInstructions.Name = "lblInstructions"
        lblInstructions.Size = New Size(113, 19)
        lblInstructions.TabIndex = 0
        lblInstructions.Text = "💡 Instructions:"
        ' 
        ' lblInstruction1
        ' 
        lblInstruction1.AutoSize = True
        lblInstruction1.Font = New Font("Segoe UI", 9F)
        lblInstruction1.ForeColor = Color.FromArgb(CByte(12), CByte(84), CByte(96))
        lblInstruction1.Location = New Point(25, 28)
        lblInstruction1.Name = "lblInstruction1"
        lblInstruction1.Size = New Size(465, 15)
        lblInstruction1.TabIndex = 1
        lblInstruction1.Text = "• Edit the ""Approved Qty"" column (yellow cells) - the ""Rejected Qty"" will auto-calculate"
        ' 
        ' lblInstruction2
        ' 
        lblInstruction2.AutoSize = True
        lblInstruction2.Font = New Font("Segoe UI", 9F)
        lblInstruction2.ForeColor = Color.FromArgb(CByte(12), CByte(84), CByte(96))
        lblInstruction2.Location = New Point(25, 43)
        lblInstruction2.Name = "lblInstruction2"
        lblInstruction2.Size = New Size(338, 15)
        lblInstruction2.TabIndex = 2
        lblInstruction2.Text = "• If there are rejected items, select a reason from the dropdown"
        ' 
        ' pnlLegend
        ' 
        pnlLegend.BackColor = Color.White
        pnlLegend.BorderStyle = BorderStyle.FixedSingle
        pnlLegend.Controls.Add(lblLegendTitle)
        pnlLegend.Controls.Add(pnlEditableColor)
        pnlLegend.Controls.Add(lblEditable)
        pnlLegend.Controls.Add(pnlNoRejectColor)
        pnlLegend.Controls.Add(lblNoReject)
        pnlLegend.Controls.Add(lblHasReject)
        pnlLegend.Location = New Point(46, 574)
        pnlLegend.Name = "pnlLegend"
        pnlLegend.Size = New Size(500, 60)
        pnlLegend.TabIndex = 4
        ' 
        ' lblLegendTitle
        ' 
        lblLegendTitle.AutoSize = True
        lblLegendTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblLegendTitle.Location = New Point(10, 8)
        lblLegendTitle.Name = "lblLegendTitle"
        lblLegendTitle.Size = New Size(51, 15)
        lblLegendTitle.TabIndex = 0
        lblLegendTitle.Text = "Legend:"
        ' 
        ' pnlEditableColor
        ' 
        pnlEditableColor.BackColor = Color.FromArgb(CByte(255), CByte(243), CByte(205))
        pnlEditableColor.BorderStyle = BorderStyle.FixedSingle
        pnlEditableColor.Location = New Point(10, 30)
        pnlEditableColor.Name = "pnlEditableColor"
        pnlEditableColor.Size = New Size(20, 20)
        pnlEditableColor.TabIndex = 1
        ' 
        ' lblEditable
        ' 
        lblEditable.AutoSize = True
        lblEditable.Font = New Font("Segoe UI", 9F)
        lblEditable.Location = New Point(35, 33)
        lblEditable.Name = "lblEditable"
        lblEditable.Size = New Size(86, 15)
        lblEditable.TabIndex = 2
        lblEditable.Text = "= Editable field"
        ' 
        ' pnlNoRejectColor
        ' 
        pnlNoRejectColor.BackColor = Color.FromArgb(CByte(232), CByte(248), CByte(245))
        pnlNoRejectColor.BorderStyle = BorderStyle.FixedSingle
        pnlNoRejectColor.Location = New Point(160, 30)
        pnlNoRejectColor.Name = "pnlNoRejectColor"
        pnlNoRejectColor.Size = New Size(20, 20)
        pnlNoRejectColor.TabIndex = 3
        ' 
        ' lblNoReject
        ' 
        lblNoReject.AutoSize = True
        lblNoReject.Font = New Font("Segoe UI", 9F)
        lblNoReject.Location = New Point(185, 33)
        lblNoReject.Name = "lblNoReject"
        lblNoReject.Size = New Size(83, 15)
        lblNoReject.TabIndex = 4
        lblNoReject.Text = "= No rejection"
        ' 
        ' lblHasReject
        ' 
        lblHasReject.AutoSize = True
        lblHasReject.Font = New Font("Segoe UI", 9F)
        lblHasReject.ForeColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        lblHasReject.Location = New Point(310, 33)
        lblHasReject.Name = "lblHasReject"
        lblHasReject.Size = New Size(102, 15)
        lblHasReject.TabIndex = 5
        lblHasReject.Text = "🔴 = Has rejection"
        ' 
        ' btnReceive
        ' 
        btnReceive.BackColor = Color.DarkSlateGray
        btnReceive.Enabled = False
        btnReceive.FlatStyle = FlatStyle.Flat
        btnReceive.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        btnReceive.ForeColor = Color.White
        btnReceive.Location = New Point(1006, 583)
        btnReceive.Name = "btnReceive"
        btnReceive.Size = New Size(168, 42)
        btnReceive.TabIndex = 5
        btnReceive.Text = "✓ Receive Order"
        btnReceive.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Gray
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(1180, 583)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(168, 42)
        btnCancel.TabIndex = 6
        btnCancel.Text = "✗ Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' pnlStatusBar
        ' 
        pnlStatusBar.BackColor = Color.DarkSlateGray
        pnlStatusBar.Controls.Add(lblStatus)
        pnlStatusBar.Controls.Add(lblUserInfo)
        pnlStatusBar.Controls.Add(lblVersion)
        pnlStatusBar.Dock = DockStyle.Bottom
        pnlStatusBar.Location = New Point(0, 649)
        pnlStatusBar.Name = "pnlStatusBar"
        pnlStatusBar.Size = New Size(1370, 100)
        pnlStatusBar.TabIndex = 7
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Segoe UI", 10F)
        lblStatus.ForeColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        lblStatus.Location = New Point(20, 15)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(177, 19)
        lblStatus.TabIndex = 0
        lblStatus.Text = "📊 Status: Ready to receive"
        ' 
        ' lblUserInfo
        ' 
        lblUserInfo.AutoSize = True
        lblUserInfo.Font = New Font("Segoe UI", 9F)
        lblUserInfo.ForeColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        lblUserInfo.Location = New Point(20, 45)
        lblUserInfo.Name = "lblUserInfo"
        lblUserInfo.Size = New Size(282, 15)
        lblUserInfo.TabIndex = 1
        lblUserInfo.Text = "Logged in as: Admin User | Date: November 09, 2025"
        ' 
        ' lblVersion
        ' 
        lblVersion.AutoSize = True
        lblVersion.Font = New Font("Segoe UI", 9F)
        lblVersion.ForeColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        lblVersion.Location = New Point(1230, 30)
        lblVersion.Name = "lblVersion"
        lblVersion.Size = New Size(141, 15)
        lblVersion.TabIndex = 2
        lblVersion.Text = "Ver 1.0 | Inventory System"
        ' 
        ' cmbRejectReason
        ' 
        cmbRejectReason.FormattingEnabled = True
        cmbRejectReason.Location = New Point(600, 760)
        cmbRejectReason.Name = "cmbRejectReason"
        cmbRejectReason.Size = New Size(200, 23)
        cmbRejectReason.TabIndex = 8
        cmbRejectReason.Visible = False
        ' 
        ' frmReceive
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(245), CByte(245))
        ClientSize = New Size(1370, 749)
        Controls.Add(cmbRejectReason)
        Controls.Add(pnlStatusBar)
        Controls.Add(btnCancel)
        Controls.Add(btnReceive)
        Controls.Add(pnlLegend)
        Controls.Add(pnlInstructions)
        Controls.Add(grpPurchaseDetails)
        Controls.Add(grpPurchaseOrders)
        Controls.Add(pnlHeader)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "frmReceive"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Purchase Order Receiving System"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        grpPurchaseOrders.ResumeLayout(False)
        CType(dgvPurchaseOrders, ComponentModel.ISupportInitialize).EndInit()
        grpPurchaseDetails.ResumeLayout(False)
        CType(dgvPurchaseDetails, ComponentModel.ISupportInitialize).EndInit()
        pnlInstructions.ResumeLayout(False)
        pnlInstructions.PerformLayout()
        pnlLegend.ResumeLayout(False)
        pnlLegend.PerformLayout()
        pnlStatusBar.ResumeLayout(False)
        pnlStatusBar.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblHeader As Label
    Friend WithEvents grpPurchaseOrders As GroupBox
    Friend WithEvents dgvPurchaseOrders As DataGridView
    Friend WithEvents grpPurchaseDetails As GroupBox
    Friend WithEvents dgvPurchaseDetails As DataGridView
    Friend WithEvents pnlInstructions As Panel
    Friend WithEvents lblInstructions As Label
    Friend WithEvents lblInstruction1 As Label
    Friend WithEvents lblInstruction2 As Label
    Friend WithEvents pnlLegend As Panel
    Friend WithEvents lblLegendTitle As Label
    Friend WithEvents pnlEditableColor As Panel
    Friend WithEvents lblEditable As Label
    Friend WithEvents pnlNoRejectColor As Panel
    Friend WithEvents lblNoReject As Label
    Friend WithEvents lblHasReject As Label
    Friend WithEvents btnReceive As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents pnlStatusBar As Panel
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblUserInfo As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents cmbRejectReason As ComboBox
End Class