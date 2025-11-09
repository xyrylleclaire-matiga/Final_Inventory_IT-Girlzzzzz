Imports MySql.Data.MySqlClient
Imports System.Linq

Public Class frmReceive
    ' ✅ No hardcoded admin ID - using global from databaseConnection module
    Private selectedTransactionID As Integer = 0
    Private WithEvents refreshTimer As New Timer()

    Private Sub frmReceivePurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ✅ SECURITY CHECK: Verify user is logged in
        If Not isLoggedIn OrElse currentAdminId = 0 Then
            MessageBox.Show("You must be logged in to access this form!",
                          "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Return
        End If

        ' Update status bar with current user info
        lblUserInfo.Text = GetUserInfoDisplay()

        ' Initialize form
        LoadApprovedPurchaseOrders()
        InitializeReceivingGridColumns()
        btnReceive.Enabled = False

        ' Setup ComboBox for rejection reasons
        cmbRejectReason.Items.Clear()
        cmbRejectReason.Items.AddRange(New String() {
             "Damaged",
             "Wrong Item",
             "Quality Issues",
             "Incomplete Order",
             "Expired",
             "Other"
         })
        cmbRejectReason.SelectedIndex = 0

        ' 🔄 REAL-TIME REFRESH: Auto-refresh every 5 seconds
        refreshTimer.Interval = 5000 ' 5 seconds
        refreshTimer.Start()
    End Sub

    ' 🔄 REAL-TIME REFRESH: Timer event handler
    Private Sub refreshTimer_Tick(sender As Object, e As EventArgs) Handles refreshTimer.Tick
        LoadApprovedPurchaseOrders()
    End Sub

    ' Override OnVisibleChanged to refresh when form becomes visible
    Protected Overrides Sub OnVisibleChanged(e As EventArgs)
        MyBase.OnVisibleChanged(e)
        If Me.Visible Then
            LoadApprovedPurchaseOrders()
        End If
    End Sub

    ' 1️⃣ Load all approved purchase orders
    Private Sub LoadApprovedPurchaseOrders()
        Try
            Dim query As String = "SELECT t.TransactionID, t.TransactionType, t.ItemType, " &
                                  "t.TransactionDate, t.Quantity, t.Status, " &
                                  "CONCAT(a.FirstName, ' ', a.LastName) AS ApprovedByName " &
                                  "FROM tbltransactions t " &
                                  "LEFT JOIN tbladmin_users a ON t.ApprovedBy = a.admin_id " &
                                  "WHERE t.TransactionType = 'Purchase Order' " &
                                  "AND t.Status = 'Approved' " &
                                  "AND t.TransactionID NOT IN (SELECT ReferenceID FROM tbltransactions WHERE TransactionType = 'Receiving' AND Status = 'Completed') " &
                                  "ORDER BY t.TransactionDate DESC"

            con() ' Open connection

            Using cmd As New MySqlCommand(query, cn)
                Using adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    ' Preserve current selection if exists
                    Dim currentSelection As Integer = -1
                    If dgvPurchaseOrders.SelectedRows.Count > 0 Then
                        currentSelection = dgvPurchaseOrders.SelectedRows(0).Index
                    End If

                    dgvPurchaseOrders.DataSource = dt

                    If dgvPurchaseOrders.Columns.Count > 0 Then
                        dgvPurchaseOrders.Columns("TransactionID").HeaderText = "Transaction ID"
                        dgvPurchaseOrders.Columns("TransactionType").HeaderText = "Type"
                        dgvPurchaseOrders.Columns("ItemType").HeaderText = "Item Type"
                        dgvPurchaseOrders.Columns("TransactionDate").HeaderText = "Order Date"
                        dgvPurchaseOrders.Columns("Quantity").HeaderText = "Total Qty"
                        dgvPurchaseOrders.Columns("Status").HeaderText = "Status"
                        dgvPurchaseOrders.Columns("ApprovedByName").HeaderText = "Approved By"
                    End If

                    ' Restore selection if possible
                    If currentSelection >= 0 AndAlso currentSelection < dgvPurchaseOrders.Rows.Count Then
                        dgvPurchaseOrders.Rows(currentSelection).Selected = True
                    End If
                End Using
            End Using

        Catch ex As Exception
            ' Silent fail for background refresh
            ' MessageBox.Show("Error loading purchase orders: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    ' Initialize columns for receiving grid
    Private Sub InitializeReceivingGridColumns()
        dgvPurchaseDetails.AutoGenerateColumns = False
        dgvPurchaseDetails.Columns.Clear()

        dgvPurchaseDetails.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "DetailID",
            .HeaderText = "Detail ID",
            .DataPropertyName = "DetailID",
            .Visible = False
        })

        dgvPurchaseDetails.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "productCode",
            .HeaderText = "Product Code",
            .DataPropertyName = "productCode",
            .ReadOnly = True
        })

        dgvPurchaseDetails.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "ProductName",
            .HeaderText = "Product Name",
            .DataPropertyName = "ProductName",
            .ReadOnly = True,
            .Width = 200
        })

        dgvPurchaseDetails.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Size",
            .HeaderText = "Size",
            .DataPropertyName = "Size",
            .ReadOnly = True
        })

        dgvPurchaseDetails.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Level",
            .HeaderText = "Level",
            .DataPropertyName = "Level",
            .ReadOnly = True
        })

        dgvPurchaseDetails.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Gender",
            .HeaderText = "Gender",
            .DataPropertyName = "Gender",
            .ReadOnly = True
        })

        dgvPurchaseDetails.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "RequestedQuantity",
            .HeaderText = "Requested Qty",
            .DataPropertyName = "Quantity",
            .ReadOnly = True
        })

        dgvPurchaseDetails.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "ApprovedQuantity",
            .HeaderText = "Approved Qty",
            .ReadOnly = False
        })

        dgvPurchaseDetails.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "RejectedQuantity",
            .HeaderText = "Rejected Qty",
            .ReadOnly = True
        })

        Dim cmbColumn As New DataGridViewComboBoxColumn With {
            .Name = "RejectReason",
            .HeaderText = "Reject Reason"
        }

        cmbColumn.Items.AddRange(New String() {
            "Damaged",
            "Wrong Item",
            "Quality Issues",
            "Incomplete Order",
            "Expired",
            "Other",
            "N/A"
        }.Cast(Of Object)().ToArray())

        dgvPurchaseDetails.Columns.Add(cmbColumn)

        dgvPurchaseDetails.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Category",
            .HeaderText = "Category",
            .DataPropertyName = "Category",
            .Visible = False
        })
    End Sub

    ' 2️⃣ Handle row selection
    Private Sub dgvPurchaseOrders_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPurchaseOrders.SelectionChanged
        If dgvPurchaseOrders.SelectedRows.Count > 0 Then
            selectedTransactionID = Convert.ToInt32(dgvPurchaseOrders.SelectedRows(0).Cells("TransactionID").Value)
            InitializeReceivingGridColumns()
            LoadPurchaseDetails(selectedTransactionID)
            btnReceive.Enabled = True

            ' ⏸️ STOP auto-refresh when user is working on a transaction
            If refreshTimer.Enabled Then
                refreshTimer.Stop()
            End If
        Else
            btnReceive.Enabled = False
            If dgvPurchaseDetails.Columns.Count > 0 Then
                dgvPurchaseDetails.Rows.Clear()
            End If

            ' ▶️ RESUME auto-refresh when no transaction selected
            If Not refreshTimer.Enabled Then
                refreshTimer.Start()
            End If
        End If
    End Sub

    ' Load purchase details
    Private Sub LoadPurchaseDetails(transactionID As Integer)
        Try
            Dim query As String = "SELECT pd.DetailID, pd.productCode, op.ProductName, " &
                                  "pd.Size, pd.Level, pd.Gender, pd.Quantity, op.Category " &
                                  "FROM purchase_details pd " &
                                  "INNER JOIN overallproduct op ON pd.productCode = op.productCode " &
                                  "WHERE pd.TransactionID = @TransactionID"

            con()

            Using cmd As New MySqlCommand(query, cn)
                cmd.Parameters.AddWithValue("@TransactionID", transactionID)

                Using adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    dgvPurchaseDetails.Rows.Clear()

                    For Each row As DataRow In dt.Rows
                        Dim index As Integer = dgvPurchaseDetails.Rows.Add()
                        dgvPurchaseDetails.Rows(index).Cells("DetailID").Value = row("DetailID")
                        dgvPurchaseDetails.Rows(index).Cells("productCode").Value = row("productCode")
                        dgvPurchaseDetails.Rows(index).Cells("ProductName").Value = row("ProductName")
                        dgvPurchaseDetails.Rows(index).Cells("Size").Value = row("Size")
                        dgvPurchaseDetails.Rows(index).Cells("Level").Value = row("Level")
                        dgvPurchaseDetails.Rows(index).Cells("Gender").Value = row("Gender")
                        dgvPurchaseDetails.Rows(index).Cells("RequestedQuantity").Value = row("Quantity")
                        dgvPurchaseDetails.Rows(index).Cells("ApprovedQuantity").Value = row("Quantity")
                        dgvPurchaseDetails.Rows(index).Cells("RejectedQuantity").Value = 0
                        dgvPurchaseDetails.Rows(index).Cells("RejectReason").Value = "N/A"
                        dgvPurchaseDetails.Rows(index).Cells("Category").Value = row("Category")
                    Next
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading purchase details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    ' 3️⃣ Auto-calculate rejected quantity
    Private Sub dgvPurchaseDetails_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPurchaseDetails.CellValueChanged
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgvPurchaseDetails.Columns("ApprovedQuantity").Index Then
            Try
                Dim requestedQty As Integer = Convert.ToInt32(dgvPurchaseDetails.Rows(e.RowIndex).Cells("RequestedQuantity").Value)
                Dim approvedQty As Integer = 0

                If IsNumeric(dgvPurchaseDetails.Rows(e.RowIndex).Cells("ApprovedQuantity").Value) Then
                    approvedQty = Convert.ToInt32(dgvPurchaseDetails.Rows(e.RowIndex).Cells("ApprovedQuantity").Value)
                End If

                If approvedQty < 0 Then
                    approvedQty = 0
                    dgvPurchaseDetails.Rows(e.RowIndex).Cells("ApprovedQuantity").Value = 0
                ElseIf approvedQty > requestedQty Then
                    approvedQty = requestedQty
                    dgvPurchaseDetails.Rows(e.RowIndex).Cells("ApprovedQuantity").Value = requestedQty
                    MessageBox.Show("Approved quantity cannot exceed requested quantity!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                Dim rejectedQty As Integer = requestedQty - approvedQty
                dgvPurchaseDetails.Rows(e.RowIndex).Cells("RejectedQuantity").Value = rejectedQty

                If rejectedQty > 0 Then
                    If dgvPurchaseDetails.Rows(e.RowIndex).Cells("RejectReason").Value Is Nothing OrElse
                       dgvPurchaseDetails.Rows(e.RowIndex).Cells("RejectReason").Value.ToString() = "N/A" Then
                        dgvPurchaseDetails.Rows(e.RowIndex).Cells("RejectReason").Value = "Damaged"
                    End If
                Else
                    dgvPurchaseDetails.Rows(e.RowIndex).Cells("RejectReason").Value = "N/A"
                End If

            Catch ex As Exception
                MessageBox.Show("Invalid quantity entered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' 🔐 PASSWORD AUTHENTICATION FUNCTION (UPDATED WITH PASSWORD DIALOG)
    Private Function AuthenticateAdmin() As Boolean
        Try
            ' Use custom password dialog instead of InputBox
            Using passwordDialog As New frmPasswordDialog()
                If passwordDialog.ShowDialog() = DialogResult.OK Then
                    Dim password As String = passwordDialog.Password

                    If String.IsNullOrEmpty(password) Then
                        Return False
                    End If

                    ' Verify password against current logged-in admin
                    con()
                    Dim query As String = "SELECT COUNT(*) FROM tbladmin_users WHERE admin_id = @admin_id AND Password = @password"

                    Using cmd As New MySqlCommand(query, cn)
                        cmd.Parameters.AddWithValue("@admin_id", currentAdminId)
                        cmd.Parameters.AddWithValue("@password", password)

                        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                        If count > 0 Then
                            Return True
                        Else
                            MessageBox.Show("Incorrect password! Access denied.",
                                          "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                        End If
                    End Using
                Else
                    MessageBox.Show("Authentication cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Authentication error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Function

    ' 4️⃣ Receive button click with authentication
    Private Sub btnReceive_Click(sender As Object, e As EventArgs) Handles btnReceive.Click
        ' Validate all rows first
        For Each row As DataGridViewRow In dgvPurchaseDetails.Rows
            If row.Cells("ApprovedQuantity").Value Is Nothing OrElse
               Not IsNumeric(row.Cells("ApprovedQuantity").Value) Then
                MessageBox.Show("Please enter approved quantity for all items!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim rejectedQty As Integer = Convert.ToInt32(row.Cells("RejectedQuantity").Value)
            Dim rejectReason As String = row.Cells("RejectReason").Value.ToString()

            If rejectedQty > 0 AndAlso (rejectReason = "N/A" OrElse String.IsNullOrEmpty(rejectReason)) Then
                MessageBox.Show("Please specify a rejection reason for items with rejected quantities!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Next

        ' 🔐 AUTHENTICATE ADMIN PASSWORD FIRST
        If Not AuthenticateAdmin() Then
            Return ' Exit if authentication fails
        End If

        ' Proceed with confirmation after successful authentication
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to receive this purchase order?",
                                                     "Confirm Receiving", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ProcessReceiving()
        End If
    End Sub

    ' ✅✅✅ CORRECTED Process receiving transaction
    Private Sub ProcessReceiving()
        Dim conn As MySqlConnection = Nothing
        Dim transaction As MySqlTransaction = Nothing

        Try
            con()
            conn = cn
            transaction = conn.BeginTransaction()

            ' ✅ Use global currentAdminId from databaseConnection module
            Dim processingAdminID As Integer = currentAdminId

            If processingAdminID = 0 Then
                transaction.Rollback()
                MessageBox.Show("Invalid session. Please login again.",
                              "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim totalApproved As Integer = 0
            Dim receivingRemarks As String = ""

            ' ✅ Dictionary to track quantities per productCode for stock update
            Dim productQuantities As New Dictionary(Of Integer, Integer)

            For Each row As DataGridViewRow In dgvPurchaseDetails.Rows
                Dim detailID As Integer = 0
                If row.Cells("DetailID").Value IsNot Nothing AndAlso Integer.TryParse(row.Cells("DetailID").Value.ToString(), detailID) Then
                End If

                Dim productCode As Integer = 0
                If row.Cells("productCode").Value IsNot Nothing AndAlso Integer.TryParse(row.Cells("productCode").Value.ToString(), productCode) Then
                End If

                Dim requestedQty As Integer = 0
                If row.Cells("RequestedQuantity").Value IsNot Nothing AndAlso Integer.TryParse(row.Cells("RequestedQuantity").Value.ToString(), requestedQty) Then
                End If

                Dim approvedQty As Integer = 0
                If row.Cells("ApprovedQuantity").Value IsNot Nothing AndAlso Integer.TryParse(row.Cells("ApprovedQuantity").Value.ToString(), approvedQty) Then
                End If

                Dim rejectedQty As Integer = 0
                If row.Cells("RejectedQuantity").Value IsNot Nothing AndAlso Integer.TryParse(row.Cells("RejectedQuantity").Value.ToString(), rejectedQty) Then
                End If

                Dim productName As String = If(row.Cells("ProductName").Value Is Nothing, "", row.Cells("ProductName").Value.ToString())
                Dim size As String = If(row.Cells("Size").Value Is Nothing, "", row.Cells("Size").Value.ToString())
                Dim level As String = If(row.Cells("Level").Value Is Nothing, "", row.Cells("Level").Value.ToString())
                Dim gender As String = If(row.Cells("Gender").Value Is Nothing, "", row.Cells("Gender").Value.ToString())
                Dim category As String = If(row.Cells("Category").Value Is Nothing, "", row.Cells("Category").Value.ToString())
                Dim rejectReason As String = If(row.Cells("RejectReason").Value Is Nothing, "N/A", row.Cells("RejectReason").Value.ToString())

                If productCode = 0 OrElse approvedQty < 0 Then Continue For

                totalApproved += approvedQty

                ' 1. Insert into incoming_items
                Dim insertIncomingQuery As String = "INSERT INTO incoming_items " &
                    "(TransactionID, productCode, QuantityReceived, DetailID, QCStatus, " &
                    "QuantityApproved, Notes, ReceivedDate) " &
                    "VALUES (@TransactionID, @productCode, @QuantityReceived, @DetailID, " &
                    "@QCStatus, @QuantityApproved, @Notes, @ReceivedDate)"

                Using cmd As New MySqlCommand(insertIncomingQuery, conn, transaction)
                    cmd.Parameters.AddWithValue("@TransactionID", selectedTransactionID)
                    cmd.Parameters.AddWithValue("@productCode", productCode)
                    cmd.Parameters.AddWithValue("@QuantityReceived", requestedQty)
                    cmd.Parameters.AddWithValue("@DetailID", detailID)
                    cmd.Parameters.AddWithValue("@QCStatus", If(rejectedQty > 0, "Partial", "Fully Approved"))
                    cmd.Parameters.AddWithValue("@QuantityApproved", approvedQty)
                    cmd.Parameters.AddWithValue("@Notes", If(rejectedQty > 0, $"Rejected: {rejectedQty} ({rejectReason})", "Fully received and approved"))
                    cmd.Parameters.AddWithValue("@ReceivedDate", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using

                ' 2. Insert into products (one row per approved item)
                If approvedQty > 0 Then
                    For i As Integer = 1 To approvedQty
                        Dim insertProductQuery As String = "INSERT INTO products " &
                            "(productCode, ProductName, gender, Size, Category, Level, ProductType, UnitPrice) " &
                            "SELECT @productCode, ProductName, @gender, @size, Category, @level, " &
                            "'AlaCarte', 0.00 " &
                            "FROM overallproduct WHERE productCode = @productCode LIMIT 1"

                        Using cmd As New MySqlCommand(insertProductQuery, conn, transaction)
                            cmd.Parameters.AddWithValue("@productCode", productCode)
                            cmd.Parameters.AddWithValue("@gender", gender)
                            cmd.Parameters.AddWithValue("@size", size)
                            cmd.Parameters.AddWithValue("@level", level)
                            cmd.ExecuteNonQuery()
                        End Using
                    Next

                    ' ✅ Track quantities for stock update
                    If productQuantities.ContainsKey(productCode) Then
                        productQuantities(productCode) += approvedQty
                    Else
                        productQuantities.Add(productCode, approvedQty)
                    End If
                End If

                If rejectedQty > 0 Then
                    receivingRemarks &= $"Product {productCode}: Approved={approvedQty}, Rejected={rejectedQty} ({rejectReason}); "
                End If
            Next

            ' ✅ 3. NOW UPDATE overallproduct stock for ALL affected productCodes
            For Each kvp In productQuantities
                Dim updateStockQuery As String = "UPDATE overallproduct " &
                    "SET total_stock = (SELECT COUNT(*) FROM products WHERE productCode = @productCode) " &
                    "WHERE productCode = @productCode"

                Using cmd As New MySqlCommand(updateStockQuery, conn, transaction)
                    cmd.Parameters.AddWithValue("@productCode", kvp.Key)
                    cmd.ExecuteNonQuery()
                End Using
            Next

            ' 4. Create receiving transaction with ReceivedBy (ProcessedBy)
            Dim insertReceivingQuery As String = "INSERT INTO tbltransactions " &
                "(TransactionType, ItemType, Quantity, TransactionDate, ReferenceID, " &
                "ProcessedBy, ApprovedBy, Status, Remarks) " &
                "VALUES ('Receiving', @ItemType, @Quantity, @TransactionDate, @ReferenceID, " &
                "@ProcessedBy, @ApprovedBy, 'Completed', @Remarks)"

            Dim itemType As String = dgvPurchaseOrders.SelectedRows(0).Cells("ItemType").Value.ToString()

            Using cmd As New MySqlCommand(insertReceivingQuery, conn, transaction)
                cmd.Parameters.AddWithValue("@ItemType", itemType)
                cmd.Parameters.AddWithValue("@Quantity", totalApproved)
                cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now)
                cmd.Parameters.AddWithValue("@ReferenceID", selectedTransactionID)
                cmd.Parameters.AddWithValue("@ProcessedBy", processingAdminID)
                cmd.Parameters.AddWithValue("@ApprovedBy", processingAdminID)
                cmd.Parameters.AddWithValue("@Remarks", If(String.IsNullOrEmpty(receivingRemarks), "Order fully received and processed.", receivingRemarks.TrimEnd(";"c, " "c)))
                cmd.ExecuteNonQuery()
            End Using

            ' 5. Update PO status with ReceivedBy
            Dim updatePOQuery As String = "UPDATE tbltransactions " &
                "SET Status = 'Received', " &
                "ApprovedBy = @ApprovedBy, " &
                "Remarks = CONCAT(IFNULL(Remarks, ''), ' | Received on ', @ReceivedDate, ' by Admin ID: ', @ApprovedByID) " &
                "WHERE TransactionID = @TransactionID"

            Using cmd As New MySqlCommand(updatePOQuery, conn, transaction)
                cmd.Parameters.AddWithValue("@ReceivedDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                cmd.Parameters.AddWithValue("@ApprovedBy", processingAdminID)
                cmd.Parameters.AddWithValue("@ApprovedByID", processingAdminID)
                cmd.Parameters.AddWithValue("@TransactionID", selectedTransactionID)
                cmd.ExecuteNonQuery()
            End Using

            transaction.Commit()

            MessageBox.Show("Purchase Order successfully received!" & vbCrLf &
                           $"Total items approved: {totalApproved}",
                           "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' 📄 ASK IF USER WANTS TO PRINT RECEIVING DOCUMENT
            Dim printResult As DialogResult = MessageBox.Show(
                "Do you want to print the receiving document?",
                "Print Document",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If printResult = DialogResult.Yes Then
                PrintReceivingDocument(selectedTransactionID, totalApproved)
            End If

            LoadApprovedPurchaseOrders()
            dgvPurchaseDetails.Rows.Clear()
            btnReceive.Enabled = False

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            MessageBox.Show("Error processing receiving: " & ex.Message,
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub dgvPurchaseDetails_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPurchaseDetails.CellContentClick
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        frmMain.Show()
        Me.Hide()
    End Sub

    ' ✅ Stop timer when form closes
    Private Sub frmReceive_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If refreshTimer IsNot Nothing Then
            refreshTimer.Stop()
            refreshTimer.Dispose()
        End If
    End Sub

    ' 📄 PRINT RECEIVING DOCUMENT
    Private Sub PrintReceivingDocument(transactionID As Integer, totalApproved As Integer)
        Try
            Dim printDoc As New Printing.PrintDocument()
            AddHandler printDoc.PrintPage, AddressOf PrintDocument_PrintPage

            ' Store transaction data for printing
            printTransactionID = transactionID
            printTotalApproved = totalApproved

            ' Show print preview dialog
            Dim previewDialog As New PrintPreviewDialog()
            previewDialog.Document = printDoc
            previewDialog.Width = 800
            previewDialog.Height = 600
            previewDialog.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error preparing document for printing: " & ex.Message,
                          "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Variables to store print data
    Private printTransactionID As Integer = 0
    Private printTotalApproved As Integer = 0

    ' 📄 PRINT PAGE EVENT HANDLER
    Private Sub PrintDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)
        Try
            Dim font As New Font("Arial", 10)
            Dim fontBold As New Font("Arial", 12, FontStyle.Bold)
            Dim fontTitle As New Font("Arial", 16, FontStyle.Bold)
            Dim yPos As Single = 50
            Dim xPos As Single = 50
            Dim lineHeight As Single = 20

            ' 📋 TITLE
            e.Graphics.DrawString("RECEIVING DOCUMENT", fontTitle, Brushes.Black, xPos, yPos)
            yPos += 40

            ' 📋 DOCUMENT INFO
            e.Graphics.DrawString($"Transaction ID: {printTransactionID}", fontBold, Brushes.Black, xPos, yPos)
            yPos += lineHeight
            e.Graphics.DrawString($"Date Received: {DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt")}", font, Brushes.Black, xPos, yPos)
            yPos += lineHeight

            ' Get admin info
            Dim adminName As String = GetAdminName(currentAdminId)
            e.Graphics.DrawString($"Received By: {adminName}", font, Brushes.Black, xPos, yPos)
            yPos += lineHeight
            e.Graphics.DrawString($"Total Items Approved: {printTotalApproved}", fontBold, Brushes.Black, xPos, yPos)
            yPos += 30

            ' 📋 TABLE HEADER
            e.Graphics.DrawLine(Pens.Black, xPos, yPos, 750, yPos)
            yPos += 5

            e.Graphics.DrawString("Product Code", fontBold, Brushes.Black, xPos, yPos)
            e.Graphics.DrawString("Product Name", fontBold, Brushes.Black, xPos + 100, yPos)
            e.Graphics.DrawString("Size", fontBold, Brushes.Black, xPos + 350, yPos)
            e.Graphics.DrawString("Level", fontBold, Brushes.Black, xPos + 420, yPos)
            e.Graphics.DrawString("Gender", fontBold, Brushes.Black, xPos + 490, yPos)
            e.Graphics.DrawString("Approved", fontBold, Brushes.Black, xPos + 570, yPos)
            e.Graphics.DrawString("Rejected", fontBold, Brushes.Black, xPos + 640, yPos)
            yPos += 20

            e.Graphics.DrawLine(Pens.Black, xPos, yPos, 750, yPos)
            yPos += 10

            ' 📋 FETCH AND DISPLAY RECEIVING DETAILS
            con()
            Dim query As String = "SELECT ii.productCode, op.ProductName, pd.Size, pd.Level, pd.Gender, " &
                                  "ii.QuantityApproved, (pd.Quantity - ii.QuantityApproved) AS Rejected, ii.Notes " &
                                  "FROM incoming_items ii " &
                                  "INNER JOIN purchase_details pd ON ii.DetailID = pd.DetailID " &
                                  "INNER JOIN overallproduct op ON ii.productCode = op.productCode " &
                                  "WHERE ii.TransactionID = @TransactionID"

            Using cmd As New MySqlCommand(query, cn)
                cmd.Parameters.AddWithValue("@TransactionID", printTransactionID)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        If yPos > e.MarginBounds.Bottom - 50 Then
                            Exit While ' Prevent overflow
                        End If

                        e.Graphics.DrawString(reader("productCode").ToString(), font, Brushes.Black, xPos, yPos)
                        e.Graphics.DrawString(reader("ProductName").ToString(), font, Brushes.Black, xPos + 100, yPos)
                        e.Graphics.DrawString(reader("Size").ToString(), font, Brushes.Black, xPos + 350, yPos)
                        e.Graphics.DrawString(reader("Level").ToString(), font, Brushes.Black, xPos + 420, yPos)
                        e.Graphics.DrawString(reader("Gender").ToString(), font, Brushes.Black, xPos + 490, yPos)
                        e.Graphics.DrawString(reader("QuantityApproved").ToString(), font, Brushes.Black, xPos + 590, yPos)
                        e.Graphics.DrawString(reader("Rejected").ToString(), font, Brushes.Black, xPos + 660, yPos)
                        yPos += lineHeight

                        ' If there are notes (rejected items), display them
                        Dim notes As String = reader("Notes").ToString()
                        If Not String.IsNullOrEmpty(notes) AndAlso notes <> "Fully received and approved" Then
                            e.Graphics.DrawString($"   Note: {notes}", New Font("Arial", 8, FontStyle.Italic), Brushes.Red, xPos + 100, yPos)
                            yPos += 15
                        End If
                    End While
                End Using
            End Using

            yPos += 10
            e.Graphics.DrawLine(Pens.Black, xPos, yPos, 750, yPos)
            yPos += 30

            ' 📋 FOOTER
            e.Graphics.DrawString("_____________________________", font, Brushes.Black, xPos + 50, yPos + 40)
            e.Graphics.DrawString("Authorized Signature", font, Brushes.Black, xPos + 80, yPos + 65)

            e.Graphics.DrawString("_____________________________", font, Brushes.Black, xPos + 400, yPos + 40)
            e.Graphics.DrawString("Warehouse Staff", font, Brushes.Black, xPos + 440, yPos + 65)

        Catch ex As Exception
            MessageBox.Show("Error printing document: " & ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    ' 🔍 GET ADMIN NAME FOR PRINTING
    Private Function GetAdminName(adminId As Integer) As String
        Try
            con()
            Dim query As String = "SELECT CONCAT(FirstName, ' ', LastName) AS FullName FROM tbladmin_users WHERE admin_id = @admin_id"

            Using cmd As New MySqlCommand(query, cn)
                cmd.Parameters.AddWithValue("@admin_id", adminId)
                Dim result = cmd.ExecuteScalar()
                Return If(result IsNot Nothing, result.ToString(), "Unknown Admin")
            End Using

        Catch ex As Exception
            Return "Unknown Admin"
        Finally
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Function
End Class