Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing

Public Class frmHistory
    ' Pagination variables
    Private itemsPerPage As Integer = 10
    Private currentPage As Integer = 1
    Private totalRecords As Integer = 0
    Private allTransactions As DataTable
    Private filteredTransactions As DataTable

    ' Database connection
    Private connectionString As String = "Server=127.0.0.1;Database=db_inventorysystem;Uid=root;Pwd=;"

    ' Print variables
    Private printDoc As New PrintDocument()
    Private printFont As Font
    Private printPageNumber As Integer = 0
    Private printRowIndex As Integer = 0
    Private printDataTable As DataTable
    Private printCriteria As String = ""

    Private Sub frmHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize DataGridView first
            InitializeDataGridView()

            ' Load all transactions
            LoadAllTransactions()

            ' Setup print document
            AddHandler printDoc.PrintPage, AddressOf PrintDocument_PrintPage

            ' Display first page only if data is loaded
            If allTransactions IsNot Nothing AndAlso allTransactions.Rows.Count > 0 Then
                DisplayPage()
            Else
                ' Show empty state
                lblPagination.Text = "No records found"
                btnPrevious.Enabled = False
                btnNext.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading form: " & ex.Message & vbCrLf & vbCrLf &
                          "Stack Trace: " & ex.StackTrace,
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeDataGridView()
        Try
            ' DataGridView settings
            dgvHistory.AutoGenerateColumns = False
            dgvHistory.AllowUserToAddRows = False
            dgvHistory.AllowUserToDeleteRows = False
            dgvHistory.AllowUserToOrderColumns = False
            dgvHistory.AllowUserToResizeColumns = False
            dgvHistory.ReadOnly = True ' Changed to True since we removed checkbox column
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvHistory.MultiSelect = True
            dgvHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250)
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Add columns (NO CHECKBOX COLUMN)
            dgvHistory.Columns.Clear()

            Dim colID As New DataGridViewTextBoxColumn()
            colID.Name = "TransactionID"
            colID.HeaderText = "Transaction ID"
            colID.DataPropertyName = "TransactionID"
            colID.ReadOnly = True
            colID.Width = 50
            dgvHistory.Columns.Add(colID)

            Dim colType As New DataGridViewTextBoxColumn()
            colType.Name = "TransactionType"
            colType.HeaderText = "Transaction Type"
            colType.DataPropertyName = "TransactionType"
            colType.ReadOnly = True
            colType.Width = 150
            dgvHistory.Columns.Add(colType)

            Dim colItemType As New DataGridViewTextBoxColumn()
            colItemType.Name = "ItemType"
            colItemType.HeaderText = "Item Type"
            colItemType.DataPropertyName = "ItemType"
            colItemType.ReadOnly = True
            colItemType.Width = 100
            dgvHistory.Columns.Add(colItemType)

            Dim colProduct As New DataGridViewTextBoxColumn()
            colProduct.Name = "productCode"
            colProduct.HeaderText = "Product Code"
            colProduct.DataPropertyName = "productCode"
            colProduct.ReadOnly = True
            colProduct.Width = 100
            dgvHistory.Columns.Add(colProduct)

            Dim colQty As New DataGridViewTextBoxColumn()
            colQty.Name = "Quantity"
            colQty.HeaderText = "Quantity"
            colQty.DataPropertyName = "Quantity"
            colQty.ReadOnly = True
            colQty.Width = 50
            dgvHistory.Columns.Add(colQty)

            Dim colDate As New DataGridViewTextBoxColumn()
            colDate.Name = "TransactionDate"
            colDate.HeaderText = "Date"
            colDate.DataPropertyName = "TransactionDate"
            colDate.ReadOnly = True
            colDate.Width = 150
            dgvHistory.Columns.Add(colDate)

            Dim colProcessed As New DataGridViewTextBoxColumn()
            colProcessed.Name = "ProcessedBy"
            colProcessed.HeaderText = "Processed By"
            colProcessed.DataPropertyName = "ProcessedByName"
            colProcessed.ReadOnly = True
            colProcessed.Width = 90
            dgvHistory.Columns.Add(colProcessed)

            Dim colApproved As New DataGridViewTextBoxColumn()
            colApproved.Name = "ApprovedBy"
            colApproved.HeaderText = "Approved By"
            colApproved.DataPropertyName = "ApprovedByName"
            colApproved.ReadOnly = True
            colApproved.Width = 90
            dgvHistory.Columns.Add(colApproved)

            Dim colStatus As New DataGridViewTextBoxColumn()
            colStatus.Name = "Status"
            colStatus.HeaderText = "Status"
            colStatus.DataPropertyName = "Status"
            colStatus.ReadOnly = True
            colStatus.Width = 90
            dgvHistory.Columns.Add(colStatus)

            Dim colRemarks As New DataGridViewTextBoxColumn()
            colRemarks.Name = "Remarks"
            colRemarks.HeaderText = "Remarks"
            colRemarks.DataPropertyName = "Remarks"
            colRemarks.ReadOnly = True
            colRemarks.Width = 200
            dgvHistory.Columns.Add(colRemarks)

        Catch ex As Exception
            MessageBox.Show("Error initializing DataGridView: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAllTransactions()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim query As String = "SELECT t.TransactionID, t.TransactionType, t.ItemType, " &
                                    "t.productCode, t.Quantity, t.TransactionDate, " &
                                    "t.Status, t.Remarks, " &
                                    "CONCAT(IFNULL(p.FirstName, ''), ' ', IFNULL(p.LastName, '')) AS ProcessedByName, " &
                                    "CONCAT(IFNULL(a.FirstName, ''), ' ', IFNULL(a.LastName, '')) AS ApprovedByName " &
                                    "FROM tbltransactions t " &
                                    "LEFT JOIN tbladmin_users p ON t.ProcessedBy = p.admin_id " &
                                    "LEFT JOIN tbladmin_users a ON t.ApprovedBy = a.admin_id " &
                                    "ORDER BY t.TransactionDate DESC"

                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        allTransactions = New DataTable()
                        adapter.Fill(allTransactions)
                        filteredTransactions = allTransactions.Copy()
                        totalRecords = filteredTransactions.Rows.Count
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading transactions: " & ex.Message & vbCrLf & vbCrLf &
                          "Please check your database connection.",
                          "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Initialize empty tables to prevent null reference errors
            allTransactions = New DataTable()
            filteredTransactions = New DataTable()
        End Try
    End Sub

    Private Sub DisplayPage()
        Try
            If filteredTransactions IsNot Nothing AndAlso filteredTransactions.Rows.Count > 0 Then
                Dim startIndex As Integer = (currentPage - 1) * itemsPerPage
                Dim endIndex As Integer = Math.Min(startIndex + itemsPerPage, filteredTransactions.Rows.Count)

                ' Create a new DataTable for current page
                Dim pageData As DataTable = filteredTransactions.Clone()

                For i As Integer = startIndex To endIndex - 1
                    pageData.ImportRow(filteredTransactions.Rows(i))
                Next

                dgvHistory.DataSource = pageData

                ' Update pagination label
                Dim totalPages As Integer = Math.Ceiling(filteredTransactions.Rows.Count / itemsPerPage)
                lblPagination.Text = $"Displaying {pageData.Rows.Count} of {filteredTransactions.Rows.Count} total items{vbCrLf}Page {currentPage} of {totalPages}"

                ' Enable/disable navigation buttons
                btnPrevious.Enabled = (currentPage > 1)
                btnNext.Enabled = (endIndex < filteredTransactions.Rows.Count)
            Else
                dgvHistory.DataSource = Nothing
                lblPagination.Text = "No records found"
                btnPrevious.Enabled = False
                btnNext.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error displaying page: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentPage > 1 Then
            currentPage -= 1
            DisplayPage()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If filteredTransactions IsNot Nothing AndAlso filteredTransactions.Rows.Count > 0 Then
            Dim maxPage As Integer = Math.Ceiling(filteredTransactions.Rows.Count / itemsPerPage)
            If currentPage < maxPage Then
                currentPage += 1
                DisplayPage()
            End If
        End If
    End Sub

    Private Sub rbShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles rbShowAll.CheckedChanged
        If rbShowAll.Checked AndAlso allTransactions IsNot Nothing Then
            filteredTransactions = allTransactions.Copy()
            currentPage = 1
            DisplayPage()
        End If
    End Sub

    Private Sub rbPurchaseOrder_CheckedChanged(sender As Object, e As EventArgs) Handles rbPurchaseOrder.CheckedChanged
        If rbPurchaseOrder.Checked Then
            FilterByTransactionType("Purchase Order")
        End If
    End Sub

    Private Sub rbReceiving_CheckedChanged(sender As Object, e As EventArgs) Handles rbReceiving.CheckedChanged
        If rbReceiving.Checked Then
            FilterByTransactionType("Receiving")
        End If
    End Sub

    Private Sub rbIssuance_CheckedChanged(sender As Object, e As EventArgs) Handles rbIssuance.CheckedChanged
        If rbIssuance.Checked Then
            FilterByTransactionType("Issuance")
        End If
    End Sub

    Private Sub rbRequest_CheckedChanged(sender As Object, e As EventArgs) Handles rbRequest.CheckedChanged
        If rbRequest.Checked Then
            FilterByTransactionType("Request")
        End If
    End Sub

    Private Sub FilterByTransactionType(transactionType As String)
        Try
            ' Check if allTransactions is loaded
            If allTransactions Is Nothing OrElse allTransactions.Rows.Count = 0 Then
                MessageBox.Show("No data available to filter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            filteredTransactions = allTransactions.Clone()

            For Each row As DataRow In allTransactions.Rows
                If Not IsDBNull(row("TransactionType")) AndAlso row("TransactionType").ToString() = transactionType Then
                    filteredTransactions.ImportRow(row)
                End If
            Next

            currentPage = 1
            DisplayPage()

        Catch ex As Exception
            MessageBox.Show("Error filtering data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            ' Check if allTransactions is loaded
            If allTransactions Is Nothing OrElse allTransactions.Rows.Count = 0 Then
                MessageBox.Show("No data available to search.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim searchTerm As String = txtSearch.Text.Trim()

            If String.IsNullOrEmpty(searchTerm) Then
                filteredTransactions = allTransactions.Copy()
            Else
                filteredTransactions = allTransactions.Clone()

                For Each row As DataRow In allTransactions.Rows
                    Dim found As Boolean = False

                    For Each col As DataColumn In allTransactions.Columns
                        If Not IsDBNull(row(col)) AndAlso row(col).ToString().ToLower().Contains(searchTerm.ToLower()) Then
                            found = True
                            Exit For
                        End If
                    Next

                    If found Then
                        filteredTransactions.ImportRow(row)
                    End If
                Next
            End If

            currentPage = 1
            DisplayPage()

        Catch ex As Exception
            MessageBox.Show("Error searching: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============= NEW PRINT SYSTEM =============
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            ' Check if there's data
            If allTransactions Is Nothing OrElse allTransactions.Rows.Count = 0 Then
                MessageBox.Show("No data available to print.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim result As DialogResult = MessageBox.Show(
                "Do you want to print ALL records?" & vbCrLf & vbCrLf &
                "YES - Print all records" & vbCrLf &
                "NO - Choose specific records/filters" & vbCrLf &
                "CANCEL - Cancel printing",
                "Print Options",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Yes
                    PrintAllRecords()
                Case DialogResult.No
                    ShowCustomPrintOptions()
                Case DialogResult.Cancel
                    Return
            End Select

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintAllRecords()
        Try
            printDataTable = allTransactions.Copy()
            printCriteria = "All Records"

            Dim confirmMsg As String = $"Ready to print ALL {printDataTable.Rows.Count} records." & vbCrLf & vbCrLf &
                                      "Proceed with printing?"

            If MessageBox.Show(confirmMsg, "Confirm Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ' Reset print variables
                printRowIndex = 0
                printPageNumber = 0

                ' Show print preview
                Dim printPreview As New PrintPreviewDialog()
                printPreview.Document = printDoc
                printDoc.DocumentName = "Transaction History - All Records"
                printPreview.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show("Error printing all records: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ShowCustomPrintOptions()
        Dim optionsForm As New Form()
        optionsForm.Text = "Custom Print Options"
        optionsForm.Size = New Size(550, 500)
        optionsForm.StartPosition = FormStartPosition.CenterParent
        optionsForm.FormBorderStyle = FormBorderStyle.FixedDialog
        optionsForm.MaximizeBox = False
        optionsForm.MinimizeBox = False

        ' Title Label
        Dim lblTitle As New Label()
        lblTitle.Text = "Select what you want to print:"
        lblTitle.Location = New Point(20, 20)
        lblTitle.Size = New Size(500, 25)
        lblTitle.Font = New Font("Arial", 11, FontStyle.Bold)
        optionsForm.Controls.Add(lblTitle)

        ' === TRANSACTION TYPE PANEL ===
        Dim pnlTransactionType As New Panel()
        pnlTransactionType.Location = New Point(30, 55)
        pnlTransactionType.Size = New Size(490, 150)
        pnlTransactionType.BorderStyle = BorderStyle.FixedSingle
        optionsForm.Controls.Add(pnlTransactionType)

        Dim lblTransType As New Label()
        lblTransType.Text = "Filter by Transaction Type:"
        lblTransType.Location = New Point(10, 10)
        lblTransType.Size = New Size(250, 20)
        lblTransType.Font = New Font("Arial", 9, FontStyle.Bold)
        pnlTransactionType.Controls.Add(lblTransType)

        Dim chkAllTypes As New CheckBox()
        chkAllTypes.Text = "All Types"
        chkAllTypes.Location = New Point(20, 40)
        chkAllTypes.Size = New Size(200, 25)
        chkAllTypes.Checked = True
        chkAllTypes.Font = New Font("Arial", 9)
        pnlTransactionType.Controls.Add(chkAllTypes)

        Dim chkPurchaseOrder As New CheckBox()
        chkPurchaseOrder.Text = "Purchase Order"
        chkPurchaseOrder.Location = New Point(20, 70)
        chkPurchaseOrder.Size = New Size(200, 25)
        chkPurchaseOrder.Font = New Font("Arial", 9)
        pnlTransactionType.Controls.Add(chkPurchaseOrder)

        Dim chkReceiving As New CheckBox()
        chkReceiving.Text = "Receiving"
        chkReceiving.Location = New Point(250, 70)
        chkReceiving.Size = New Size(200, 25)
        chkReceiving.Font = New Font("Arial", 9)
        pnlTransactionType.Controls.Add(chkReceiving)

        Dim chkIssuance As New CheckBox()
        chkIssuance.Text = "Issuance"
        chkIssuance.Location = New Point(20, 100)
        chkIssuance.Size = New Size(200, 25)
        chkIssuance.Font = New Font("Arial", 9)
        pnlTransactionType.Controls.Add(chkIssuance)

        Dim chkRequest As New CheckBox()
        chkRequest.Text = "Request"
        chkRequest.Location = New Point(250, 100)
        chkRequest.Size = New Size(200, 25)
        chkRequest.Font = New Font("Arial", 9)
        pnlTransactionType.Controls.Add(chkRequest)

        ' Handle "All Types" checkbox
        AddHandler chkAllTypes.CheckedChanged, Sub(s, e)
                                                   If chkAllTypes.Checked Then
                                                       chkPurchaseOrder.Checked = False
                                                       chkReceiving.Checked = False
                                                       chkIssuance.Checked = False
                                                       chkRequest.Checked = False
                                                   End If
                                               End Sub

        ' Uncheck "All Types" when others are checked
        Dim uncheckAll As EventHandler = Sub(s, e)
                                             If CType(s, CheckBox).Checked Then
                                                 chkAllTypes.Checked = False
                                             End If
                                         End Sub
        AddHandler chkPurchaseOrder.CheckedChanged, uncheckAll
        AddHandler chkReceiving.CheckedChanged, uncheckAll
        AddHandler chkIssuance.CheckedChanged, uncheckAll
        AddHandler chkRequest.CheckedChanged, uncheckAll

        ' === DATE RANGE PANEL ===
        Dim pnlDateRange As New Panel()
        pnlDateRange.Location = New Point(30, 215)
        pnlDateRange.Size = New Size(490, 100)
        pnlDateRange.BorderStyle = BorderStyle.FixedSingle
        optionsForm.Controls.Add(pnlDateRange)

        Dim lblDateRange As New Label()
        lblDateRange.Text = "Filter by Date Range:"
        lblDateRange.Location = New Point(10, 10)
        lblDateRange.Size = New Size(250, 20)
        lblDateRange.Font = New Font("Arial", 9, FontStyle.Bold)
        pnlDateRange.Controls.Add(lblDateRange)

        Dim lblFrom As New Label()
        lblFrom.Text = "From:"
        lblFrom.Location = New Point(20, 45)
        lblFrom.Size = New Size(60, 20)
        lblFrom.Font = New Font("Arial", 9)
        pnlDateRange.Controls.Add(lblFrom)

        Dim dtpFrom As New DateTimePicker()
        dtpFrom.Location = New Point(80, 42)
        dtpFrom.Size = New Size(150, 25)
        dtpFrom.Format = DateTimePickerFormat.Short
        dtpFrom.Value = Date.Today.AddMonths(-1)
        pnlDateRange.Controls.Add(dtpFrom)

        Dim lblTo As New Label()
        lblTo.Text = "To:"
        lblTo.Location = New Point(260, 45)
        lblTo.Size = New Size(40, 20)
        lblTo.Font = New Font("Arial", 9)
        pnlDateRange.Controls.Add(lblTo)

        Dim dtpTo As New DateTimePicker()
        dtpTo.Location = New Point(300, 42)
        dtpTo.Size = New Size(150, 25)
        dtpTo.Format = DateTimePickerFormat.Short
        dtpTo.Value = Date.Today
        pnlDateRange.Controls.Add(dtpTo)

        ' === SPECIFIC IDs PANEL ===
        Dim pnlSpecificIDs As New Panel()
        pnlSpecificIDs.Location = New Point(30, 325)
        pnlSpecificIDs.Size = New Size(490, 90)
        pnlSpecificIDs.BorderStyle = BorderStyle.FixedSingle
        optionsForm.Controls.Add(pnlSpecificIDs)

        Dim lblSpecificIDs As New Label()
        lblSpecificIDs.Text = "OR Enter Specific Transaction IDs (comma-separated):"
        lblSpecificIDs.Location = New Point(10, 10)
        lblSpecificIDs.Size = New Size(450, 20)
        lblSpecificIDs.Font = New Font("Arial", 9, FontStyle.Bold)
        pnlSpecificIDs.Controls.Add(lblSpecificIDs)

        Dim txtTransactionIDs As New TextBox()
        txtTransactionIDs.Location = New Point(20, 40)
        txtTransactionIDs.Size = New Size(450, 25)
        txtTransactionIDs.Font = New Font("Arial", 9)
        txtTransactionIDs.PlaceholderText = "Example: TR001, TR005, TR010"
        pnlSpecificIDs.Controls.Add(txtTransactionIDs)

        ' === BUTTONS ===
        Dim btnPrint As New Button()
        btnPrint.Text = "Print"
        btnPrint.Location = New Point(290, 430)
        btnPrint.Size = New Size(110, 35)
        btnPrint.Font = New Font("Arial", 10, FontStyle.Bold)
        btnPrint.BackColor = Color.FromArgb(0, 123, 255)
        btnPrint.ForeColor = Color.White
        btnPrint.FlatStyle = FlatStyle.Flat
        optionsForm.Controls.Add(btnPrint)

        Dim btnCancel As New Button()
        btnCancel.Text = "Cancel"
        btnCancel.Location = New Point(410, 430)
        btnCancel.Size = New Size(110, 35)
        btnCancel.Font = New Font("Arial", 10)
        btnCancel.FlatStyle = FlatStyle.Flat
        optionsForm.Controls.Add(btnCancel)

        ' === BUTTON EVENTS ===
        AddHandler btnCancel.Click, Sub(s, e) optionsForm.Close()

        AddHandler btnPrint.Click, Sub(s, e)
                                       Try
                                           Dim dataToPrint As DataTable = allTransactions.Clone()
                                           Dim criteria As New List(Of String)

                                           ' Check if specific IDs are provided
                                           If Not String.IsNullOrWhiteSpace(txtTransactionIDs.Text) Then
                                               ' Print by specific IDs
                                               Dim ids As String() = txtTransactionIDs.Text.Split(","c)

                                               For Each row As DataRow In allTransactions.Rows
                                                   If Not IsDBNull(row("TransactionID")) Then
                                                       Dim transId As String = row("TransactionID").ToString().Trim()

                                                       For Each id As String In ids
                                                           If transId.Equals(id.Trim(), StringComparison.OrdinalIgnoreCase) Then
                                                               dataToPrint.ImportRow(row)
                                                               Exit For
                                                           End If
                                                       Next
                                                   End If
                                               Next

                                               criteria.Add($"Transaction IDs: {txtTransactionIDs.Text}")
                                           Else
                                               ' Apply transaction type and date filters
                                               Dim selectedTypes As New List(Of String)

                                               If chkAllTypes.Checked Then
                                                   selectedTypes.Add("All")
                                               Else
                                                   If chkPurchaseOrder.Checked Then selectedTypes.Add("Purchase Order")
                                                   If chkReceiving.Checked Then selectedTypes.Add("Receiving")
                                                   If chkIssuance.Checked Then selectedTypes.Add("Issuance")
                                                   If chkRequest.Checked Then selectedTypes.Add("Request")
                                               End If

                                               If selectedTypes.Count = 0 Then
                                                   MessageBox.Show("Please select at least one transaction type or enter specific Transaction IDs.",
                                                                 "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                   Return
                                               End If

                                               ' Validate date range
                                               If dtpFrom.Value.Date > dtpTo.Value.Date Then
                                                   MessageBox.Show("'From' date cannot be later than 'To' date.",
                                                                 "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                   Return
                                               End If

                                               ' Filter data
                                               For Each row As DataRow In allTransactions.Rows
                                                   Dim includeRow As Boolean = False

                                                   ' Check transaction type
                                                   If chkAllTypes.Checked Then
                                                       includeRow = True
                                                   Else
                                                       If Not IsDBNull(row("TransactionType")) Then
                                                           Dim transType As String = row("TransactionType").ToString()
                                                           If selectedTypes.Contains(transType) Then
                                                               includeRow = True
                                                           End If
                                                       End If
                                                   End If

                                                   ' Check date range
                                                   If includeRow AndAlso Not IsDBNull(row("TransactionDate")) Then
                                                       Dim transDate As Date = CDate(row("TransactionDate"))
                                                       If transDate.Date < dtpFrom.Value.Date OrElse transDate.Date > dtpTo.Value.Date Then
                                                           includeRow = False
                                                       End If
                                                   End If

                                                   If includeRow Then
                                                       dataToPrint.ImportRow(row)
                                                   End If
                                               Next

                                               criteria.Add($"Type: {String.Join(", ", selectedTypes)}")
                                               criteria.Add($"Date: {dtpFrom.Value:yyyy-MM-dd} to {dtpTo.Value:yyyy-MM-dd}")
                                           End If

                                           ' Check if any records found
                                           If dataToPrint.Rows.Count = 0 Then
                                               MessageBox.Show("No records match your criteria.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                               Return
                                           End If

                                           ' Confirm print
                                           Dim confirmMsg As String = $"Ready to print {dataToPrint.Rows.Count} record(s)." & vbCrLf & vbCrLf &
                                                                     "Criteria:" & vbCrLf & String.Join(vbCrLf, criteria) & vbCrLf & vbCrLf &
                                                                     "Proceed with printing?"

                                           If MessageBox.Show(confirmMsg, "Confirm Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                               printDataTable = dataToPrint
                                               printCriteria = String.Join(" | ", criteria)
                                               printRowIndex = 0
                                               printPageNumber = 0

                                               ' Show print preview
                                               Dim printPreview As New PrintPreviewDialog()
                                               printPreview.Document = printDoc
                                               printDoc.DocumentName = "Transaction History Report"
                                               printPreview.ShowDialog()

                                               optionsForm.Close()
                                           End If

                                       Catch ex As Exception
                                           MessageBox.Show("Error preparing print: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                       End Try
                                   End Sub

        optionsForm.ShowDialog()
    End Sub

    Private Function GetCurrentFilterDescription() As String
        If rbPurchaseOrder.Checked Then
            Return "Purchase Order Only"
        ElseIf rbReceiving.Checked Then
            Return "Receiving Only"
        ElseIf rbIssuance.Checked Then
            Return "Issuance Only"
        ElseIf rbRequest.Checked Then
            Return "Request Only"
        Else
            Return "All Records"
        End If
    End Function

    Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
        Try
            printFont = New Font("Arial", 8)
            Dim headerFont As New Font("Arial", 14, FontStyle.Bold)
            Dim titleFont As New Font("Arial", 12, FontStyle.Bold)

            Dim yPos As Single = e.MarginBounds.Top
            Dim leftMargin As Single = e.MarginBounds.Left
            Dim lineHeight As Single = printFont.GetHeight(e.Graphics)

            ' Print header
            printPageNumber += 1
            e.Graphics.DrawString("Uniform Inventory Management System", headerFont, Brushes.Black, leftMargin, yPos)
            yPos += headerFont.GetHeight(e.Graphics) + 5
            e.Graphics.DrawString("Transaction History Report", titleFont, Brushes.Black, leftMargin, yPos)
            yPos += titleFont.GetHeight(e.Graphics) + 5
            e.Graphics.DrawString($"Criteria: {printCriteria}", printFont, Brushes.Black, leftMargin, yPos)
            yPos += lineHeight + 5
            e.Graphics.DrawString("Printed: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), printFont, Brushes.Black, leftMargin, yPos)
            yPos += lineHeight + 5
            e.Graphics.DrawString($"Page: {printPageNumber} | Total Records: {printDataTable.Rows.Count}", printFont, Brushes.Black, leftMargin, yPos)
            yPos += lineHeight + 10

            ' Draw separator line
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, e.MarginBounds.Right, yPos)
            yPos += 10

            ' Define columns to print
            Dim columnsToPrint As String() = {"TransactionID", "TransactionType", "ItemType",
                                          "productCode", "Quantity", "TransactionDate",
                                          "ProcessedByName", "Status"}

            Dim colWidth As Single = e.MarginBounds.Width / columnsToPrint.Length
            Dim xPos As Single = leftMargin

            ' Print column headers
            For Each colName As String In columnsToPrint
                Dim header As String = colName.Replace("productCode", "Product").Replace("ProcessedByName", "Processed By")
                e.Graphics.DrawString(header, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, xPos, yPos)
                xPos += colWidth
            Next

            yPos += lineHeight + 5
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, e.MarginBounds.Right, yPos)
            yPos += 5

            ' Print rows
            While printRowIndex < printDataTable.Rows.Count
                If yPos + lineHeight > e.MarginBounds.Bottom Then
                    e.HasMorePages = True
                    Return
                End If

                xPos = leftMargin
                Dim row As DataRow = printDataTable.Rows(printRowIndex)

                For Each colName As String In columnsToPrint
                    Dim cellValue As String = ""
                    If printDataTable.Columns.Contains(colName) AndAlso Not IsDBNull(row(colName)) Then
                        cellValue = row(colName).ToString()
                        ' Truncate long text to fit in column
                        If cellValue.Length > 15 Then
                            cellValue = cellValue.Substring(0, 12) & "..."
                        End If
                    End If
                    e.Graphics.DrawString(cellValue, printFont, Brushes.Black, xPos, yPos)
                    xPos += colWidth
                Next

                yPos += lineHeight
                printRowIndex += 1
            End While

            ' Print footer
            yPos = e.MarginBounds.Bottom + 10
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, e.MarginBounds.Right, yPos)
            yPos += 5
            e.Graphics.DrawString($"End of Report - {printDataTable.Rows.Count} record(s) printed",
                            printFont, Brushes.Black, leftMargin, yPos)

            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show("Error during printing: " & ex.Message, "Print Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.HasMorePages = False
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmMain.Show()
        Me.Hide()
    End Sub

    Private Sub pnlHeader_Paint(sender As Object, e As PaintEventArgs) Handles pnlHeader.Paint

    End Sub
End Class