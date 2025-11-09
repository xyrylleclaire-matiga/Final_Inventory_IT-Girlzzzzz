Imports MySql.Data.MySqlClient

Public Class frmPurchaseOrder
    Dim selectedTransactionID As Integer = 0
    Dim selectedDetailID As Integer = 0
    Private itemPanels As New List(Of Panel) ' Track all dynamic item panels
    Private pnlScrollable As Panel ' Scrollable panel inside GroupBox

    Private Sub frmPurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ✅ SECURITY CHECK: Verify user is logged in
        If Not isLoggedIn OrElse currentAdminId = 0 Then
            MessageBox.Show("You must be logged in to access this form!",
                          "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Return
        End If

        ' 🔄 Make form scrollable
        Me.AutoScroll = True

        ' Make grpOrderDetails scrollable by adding a Panel inside it
        pnlScrollable = New Panel()
        pnlScrollable.AutoScroll = True
        pnlScrollable.Dock = DockStyle.Fill
        pnlScrollable.BorderStyle = BorderStyle.None
        grpOrderDetails.Controls.Add(pnlScrollable)

        ' Initialize form
        LoadPurchaseOrders()
        LoadOverallProducts()
        SetupDataGridViews()

        ' Set default values
        dtpTransactionDate.Value = DateTime.Now

        ' ✅ LOCKED TO PURCHASE ORDER ONLY
        cmbTransactionType.Items.Clear()
        cmbTransactionType.Items.Add("Purchase Order")
        cmbTransactionType.SelectedIndex = 0
        cmbTransactionType.Enabled = False

        cmbItemType.Items.Clear()
        cmbItemType.Items.AddRange(New String() {"Uniform", "Accessory"})
        cmbItemType.SelectedIndex = -1

        ' Disable detail controls initially
        grpOrderDetails.Enabled = False
    End Sub

    Private Sub SetupDataGridViews()
        ' Setup dgvPurchaseOrders - ONLY PURCHASE ORDERS
        With dgvPurchaseOrders
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .Columns.Clear()

            .Columns.Add("TransactionID", "PO #")
            .Columns("TransactionID").DataPropertyName = "TransactionID"
            .Columns("TransactionID").Width = 80

            .Columns.Add("TransactionDate", "Date")
            .Columns("TransactionDate").DataPropertyName = "TransactionDate"
            .Columns("TransactionDate").Width = 100

            .Columns.Add("ItemType", "Item Type")
            .Columns("ItemType").DataPropertyName = "ItemType"
            .Columns("ItemType").Width = 100

            .Columns.Add("Quantity", "Total Qty")
            .Columns("Quantity").DataPropertyName = "Quantity"
            .Columns("Quantity").Width = 80

            .Columns.Add("Status", "Status")
            .Columns("Status").DataPropertyName = "Status"
            .Columns("Status").Width = 100

            .Columns.Add("ProcessedBy", "Processed By")
            .Columns("ProcessedBy").DataPropertyName = "ProcessedByName"
            .Columns("ProcessedBy").Width = 120

            .Columns.Add("ApprovedBy", "Approved By")
            .Columns("ApprovedBy").DataPropertyName = "ApprovedByName"
            .Columns("ApprovedBy").Width = 120

            .Columns.Add("Remarks", "Remarks")
            .Columns("Remarks").DataPropertyName = "Remarks"
            .Columns("Remarks").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        ' Setup dgvOrderDetails
        With dgvOrderDetails
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AllowUserToAddRows = False
            .Columns.Clear()

            .Columns.Add("DetailID", "ID")
            .Columns("DetailID").DataPropertyName = "DetailID"
            .Columns("DetailID").Width = 60
            .Columns("DetailID").Visible = False

            .Columns.Add("ProductCode", "Code")
            .Columns("ProductCode").DataPropertyName = "productCode"
            .Columns("ProductCode").Width = 80

            .Columns.Add("ProductName", "Product")
            .Columns("ProductName").DataPropertyName = "ProductName"
            .Columns("ProductName").Width = 150

            .Columns.Add("Category", "Category")
            .Columns("Category").DataPropertyName = "Category"
            .Columns("Category").Width = 120

            .Columns.Add("Level", "Level")
            .Columns("Level").DataPropertyName = "Level"
            .Columns("Level").Width = 100

            .Columns.Add("Gender", "Gender")
            .Columns("Gender").DataPropertyName = "Gender"
            .Columns("Gender").Width = 80

            .Columns.Add("Size", "Size")
            .Columns("Size").DataPropertyName = "Size"
            .Columns("Size").Width = 80

            .Columns.Add("OrderType", "Type")
            .Columns("OrderType").DataPropertyName = "OrderType"
            .Columns("OrderType").Width = 80

            .Columns.Add("Quantity", "Qty")
            .Columns("Quantity").DataPropertyName = "Quantity"
            .Columns("Quantity").Width = 60

            .Columns.Add("UnitPrice", "Price")
            .Columns("UnitPrice").DataPropertyName = "UnitPrice"
            .Columns("UnitPrice").Width = 90
            .Columns("UnitPrice").DefaultCellStyle.Format = "N2"

            .Columns.Add("TotalPrice", "Total")
            .Columns("TotalPrice").DataPropertyName = "TotalPrice"
            .Columns("TotalPrice").Width = 100
            .Columns("TotalPrice").DefaultCellStyle.Format = "N2"

            ' Add Delete button column
            Dim btnDelete As New DataGridViewButtonColumn()
            btnDelete.Name = "btnDelete"
            btnDelete.HeaderText = "Action"
            btnDelete.Text = "Delete"
            btnDelete.UseColumnTextForButtonValue = True
            btnDelete.Width = 80
            .Columns.Add(btnDelete)
        End With
    End Sub

    Private Sub LoadOverallProducts()
        Try
            con()
            sql = "SELECT productCode, ProductName, Category FROM overallproduct WHERE Status = 'Active' ORDER BY ProductName"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            ' Store products in a list for reuse
            Dim products As New List(Of OverallProductItem)
            While dr.Read()
                products.Add(New OverallProductItem With {
                    .ProductCode = Convert.ToInt32(dr("productCode")),
                    .ProductName = dr("ProductName").ToString(),
                    .Category = dr("Category").ToString()
                })
            End While
            dr.Close()
            cn.Close()

            ' Store for later use when creating dynamic controls
            Me.Tag = products

        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    ' 🆕 CREATE DYNAMIC ITEM INPUT PANEL
    Private Function CreateItemPanel(itemNumber As Integer) As Panel
        Dim panel As New Panel With {
            .Width = pnlScrollable.Width - 40,
            .Height = 180,
            .BorderStyle = BorderStyle.FixedSingle,
            .BackColor = Color.WhiteSmoke,
            .Tag = itemNumber
        }

        Dim yPos As Integer = 10
        Dim lblItemNum As New Label With {
            .Text = "Item #" & itemNumber,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .Location = New Point(10, yPos),
            .AutoSize = True
        }
        panel.Controls.Add(lblItemNum)
        yPos += 30

        ' Product ComboBox
        Dim lblProduct As New Label With {.Text = "Product:", .Location = New Point(10, yPos), .Width = 80}
        Dim cmbProduct As New ComboBox With {
            .Name = "cmbProduct" & itemNumber,
            .Location = New Point(100, yPos - 3),
            .Width = 300,
            .DropDownStyle = ComboBoxStyle.DropDownList
        }

        ' Load products
        If Me.Tag IsNot Nothing Then
            Dim products As List(Of OverallProductItem) = CType(Me.Tag, List(Of OverallProductItem))
            For Each p In products
                cmbProduct.Items.Add(p)
            Next
        End If

        panel.Controls.Add(lblProduct)
        panel.Controls.Add(cmbProduct)

        ' Level ComboBox
        Dim lblLevel As New Label With {.Text = "Level:", .Location = New Point(420, yPos), .Width = 60}
        Dim cmbLevel As New ComboBox With {
            .Name = "cmbLevel" & itemNumber,
            .Location = New Point(490, yPos - 3),
            .Width = 150,
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        cmbLevel.Items.AddRange(New String() {"Kindergarten", "Elementary", "Integrated High School", "College"})
        panel.Controls.Add(lblLevel)
        panel.Controls.Add(cmbLevel)

        yPos += 35

        ' Gender ComboBox
        Dim lblGender As New Label With {.Text = "Gender:", .Location = New Point(10, yPos), .Width = 80}
        Dim cmbGender As New ComboBox With {
            .Name = "cmbGender" & itemNumber,
            .Location = New Point(100, yPos - 3),
            .Width = 150,
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        cmbGender.Items.AddRange(New String() {"Male", "Female", "Unisex"})
        panel.Controls.Add(lblGender)
        panel.Controls.Add(cmbGender)

        ' Size ComboBox
        Dim lblSize As New Label With {.Text = "Size:", .Location = New Point(270, yPos), .Width = 50}
        Dim cmbSize As New ComboBox With {
            .Name = "cmbSize" & itemNumber,
            .Location = New Point(330, yPos - 3),
            .Width = 120,
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        cmbSize.Items.AddRange(New String() {"XXSmall", "XSmall", "Small", "Medium", "Large", "XLarge", "XXLarge", "N/A"})
        panel.Controls.Add(lblSize)
        panel.Controls.Add(cmbSize)

        ' Order Type ComboBox
        Dim lblOrderType As New Label With {.Text = "Type:", .Location = New Point(470, yPos), .Width = 50}
        Dim cmbOrderType As New ComboBox With {
            .Name = "cmbOrderType" & itemNumber,
            .Location = New Point(530, yPos - 3),
            .Width = 110,
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        cmbOrderType.Items.AddRange(New String() {"AlaCarte", "Set"})
        panel.Controls.Add(lblOrderType)
        panel.Controls.Add(cmbOrderType)

        yPos += 35

        ' Quantity NumericUpDown
        Dim lblQty As New Label With {.Text = "Quantity:", .Location = New Point(10, yPos), .Width = 80}
        Dim nudQty As New NumericUpDown With {
            .Name = "nudQty" & itemNumber,
            .Location = New Point(100, yPos - 3),
            .Width = 100,
            .Minimum = 1,
            .Maximum = 10000,
            .Value = 1
        }
        panel.Controls.Add(lblQty)
        panel.Controls.Add(nudQty)

        ' Unit Price NumericUpDown
        Dim lblPrice As New Label With {.Text = "Unit Price:", .Location = New Point(220, yPos), .Width = 80}
        Dim nudPrice As New NumericUpDown With {
            .Name = "nudPrice" & itemNumber,
            .Location = New Point(310, yPos - 3),
            .Width = 120,
            .DecimalPlaces = 2,
            .Maximum = 999999,
            .Value = 0
        }
        panel.Controls.Add(lblPrice)
        panel.Controls.Add(nudPrice)

        ' Remove Button
        Dim btnRemove As New Button With {
            .Text = "Remove Item",
            .Location = New Point(panel.Width - 120, yPos - 5),
            .Width = 100,
            .Height = 30,
            .BackColor = Color.IndianRed,
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Tag = panel
        }
        AddHandler btnRemove.Click, AddressOf btnRemoveItem_Click
        panel.Controls.Add(btnRemove)

        Return panel
    End Function

    ' 🆕 ADD MORE ITEM BUTTON HANDLER
    Private Sub btnAddMoreItem_Click(sender As Object, e As EventArgs) Handles btnAddMoreItem.Click
        Dim itemNumber As Integer = itemPanels.Count + 1
        Dim newPanel As Panel = CreateItemPanel(itemNumber)

        ' Position the panel
        Dim yPosition As Integer = 10
        For Each p As Panel In itemPanels
            yPosition += p.Height + 10
        Next

        newPanel.Location = New Point(10, yPosition)
        pnlScrollable.Controls.Add(newPanel)
        itemPanels.Add(newPanel)

        ' Scroll to the new panel
        pnlScrollable.ScrollControlIntoView(newPanel)
    End Sub

    ' 🆕 REMOVE ITEM BUTTON HANDLER
    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim panel As Panel = CType(btn.Tag, Panel)

        If itemPanels.Count <= 1 Then
            MessageBox.Show("You must have at least one item!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        pnlScrollable.Controls.Remove(panel)
        itemPanels.Remove(panel)

        ' Reposition remaining panels
        Dim yPosition As Integer = 10
        For i As Integer = 0 To itemPanels.Count - 1
            itemPanels(i).Location = New Point(10, yPosition)
            ' Update item number label
            CType(itemPanels(i).Controls(0), Label).Text = "Item #" & (i + 1)
            itemPanels(i).Tag = i + 1
            yPosition += itemPanels(i).Height + 10
        Next
    End Sub

    Private Sub LoadPurchaseOrders()
        Try
            con()

            sql = "SELECT t.TransactionID, t.TransactionDate, t.ItemType, t.Quantity, " &
                  "t.Status, t.Remarks, " &
                  "CONCAT(u1.FirstName, ' ', u1.LastName) AS ProcessedByName, " &
                  "CONCAT(u2.FirstName, ' ', u2.LastName) AS ApprovedByName " &
                  "FROM tbltransactions t " &
                  "LEFT JOIN tbladmin_users u1 ON t.ProcessedBy = u1.admin_id " &
                  "LEFT JOIN tbladmin_users u2 ON t.ApprovedBy = u2.admin_id " &
                  "WHERE t.TransactionType = 'Purchase Order' " &
                  "ORDER BY t.TransactionID DESC"

            cmd = New MySqlCommand(sql, cn)
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            dgvPurchaseOrders.DataSource = dt
            cn.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading purchase orders: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub LoadOrderDetails(transactionID As Integer)
        Try
            con()

            sql = "SELECT d.DetailID, d.productCode, op.ProductName, op.Category, " &
                  "d.Level, d.Gender, d.Size, d.OrderType, " &
                  "d.Quantity, d.UnitPrice, d.TotalPrice " &
                  "FROM purchase_details d " &
                  "INNER JOIN overallproduct op ON d.productCode = op.productCode " &
                  "WHERE d.TransactionID = @transactionID"

            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@transactionID", transactionID)

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            dgvOrderDetails.DataSource = dt
            cn.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading order details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub dgvPurchaseOrders_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPurchaseOrders.SelectionChanged
        If dgvPurchaseOrders.SelectedRows.Count > 0 AndAlso dgvPurchaseOrders.SelectedRows(0).Cells("TransactionID").Value IsNot Nothing Then
            selectedTransactionID = Convert.ToInt32(dgvPurchaseOrders.SelectedRows(0).Cells("TransactionID").Value)
            LoadOrderDetails(selectedTransactionID)

            Dim status As String = dgvPurchaseOrders.SelectedRows(0).Cells("Status").Value.ToString()
            btnApprovePO.Enabled = (status = "Pending")
            btnRejectPO.Enabled = (status = "Pending")
        End If
    End Sub

    Private Function AuthenticateAdmin() As Boolean
        Try
            Using passwordDialog As New frmPasswordDialog()
                If passwordDialog.ShowDialog() = DialogResult.OK Then
                    Dim password As String = passwordDialog.Password

                    If String.IsNullOrEmpty(password) Then
                        Return False
                    End If

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

    Private Sub btnNewPO_Click(sender As Object, e As EventArgs) Handles btnNewPO.Click
        If String.IsNullOrWhiteSpace(cmbItemType.Text) Then
            MessageBox.Show("Please select Item Type!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not AuthenticateAdmin() Then
            Return
        End If

        ' Clear any existing dynamic panels
        For Each p As Panel In itemPanels
            pnlScrollable.Controls.Remove(p)
        Next
        itemPanels.Clear()

        ' Enable form and create first item panel
        grpOrderDetails.Enabled = True
        selectedTransactionID = 0

        ' Add first item panel automatically
        btnAddMoreItem_Click(Nothing, Nothing)

        MessageBox.Show("Purchase Order form ready! Add items and click 'Save All Items' when done.", "Ready", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' 🆕 SAVE ALL ITEMS AT ONCE
    Private Sub btnSaveAllItems_Click(sender As Object, e As EventArgs) Handles btnSaveAllItems.Click
        If itemPanels.Count = 0 Then
            MessageBox.Show("No items to save!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate all items first
        For Each panel As Panel In itemPanels
            Dim itemNum As Integer = CType(panel.Tag, Integer)

            Dim cmbProduct As ComboBox = CType(panel.Controls("cmbProduct" & itemNum), ComboBox)
            Dim cmbLevel As ComboBox = CType(panel.Controls("cmbLevel" & itemNum), ComboBox)
            Dim cmbGender As ComboBox = CType(panel.Controls("cmbGender" & itemNum), ComboBox)
            Dim cmbSize As ComboBox = CType(panel.Controls("cmbSize" & itemNum), ComboBox)
            Dim cmbOrderType As ComboBox = CType(panel.Controls("cmbOrderType" & itemNum), ComboBox)
            Dim nudQty As NumericUpDown = CType(panel.Controls("nudQty" & itemNum), NumericUpDown)
            Dim nudPrice As NumericUpDown = CType(panel.Controls("nudPrice" & itemNum), NumericUpDown)

            If cmbProduct.SelectedIndex = -1 Then
                MessageBox.Show($"Please select product for Item #{itemNum}!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If cmbLevel.SelectedIndex = -1 Then
                MessageBox.Show($"Please select level for Item #{itemNum}!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If cmbGender.SelectedIndex = -1 Then
                MessageBox.Show($"Please select gender for Item #{itemNum}!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If cmbSize.SelectedIndex = -1 Then
                MessageBox.Show($"Please select size for Item #{itemNum}!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If cmbOrderType.SelectedIndex = -1 Then
                MessageBox.Show($"Please select order type for Item #{itemNum}!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If nudQty.Value <= 0 Then
                MessageBox.Show($"Please enter quantity for Item #{itemNum}!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If nudPrice.Value <= 0 Then
                MessageBox.Show($"Please enter unit price for Item #{itemNum}!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Next

        Try
            con()

            ' Create transaction first
            If selectedTransactionID = 0 Then
                sql = "INSERT INTO tbltransactions (TransactionType, ItemType, Quantity, TransactionDate, ProcessedBy, Status, Remarks) " &
                      "VALUES (@type, @itemType, 0, @date, @processedBy, 'Pending', @remarks)"

                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@type", "Purchase Order")
                cmd.Parameters.AddWithValue("@itemType", cmbItemType.Text)
                cmd.Parameters.AddWithValue("@date", dtpTransactionDate.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@processedBy", currentAdminId)
                cmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrWhiteSpace(txtRemarks.Text), DBNull.Value, txtRemarks.Text))

                cmd.ExecuteNonQuery()
                selectedTransactionID = Convert.ToInt32(cmd.LastInsertedId)
            End If

            ' Save all items
            For Each panel As Panel In itemPanels
                Dim itemNum As Integer = CType(panel.Tag, Integer)

                Dim cmbProduct As ComboBox = CType(panel.Controls("cmbProduct" & itemNum), ComboBox)
                Dim cmbLevel As ComboBox = CType(panel.Controls("cmbLevel" & itemNum), ComboBox)
                Dim cmbGender As ComboBox = CType(panel.Controls("cmbGender" & itemNum), ComboBox)
                Dim cmbSize As ComboBox = CType(panel.Controls("cmbSize" & itemNum), ComboBox)
                Dim cmbOrderType As ComboBox = CType(panel.Controls("cmbOrderType" & itemNum), ComboBox)
                Dim nudQty As NumericUpDown = CType(panel.Controls("nudQty" & itemNum), NumericUpDown)
                Dim nudPrice As NumericUpDown = CType(panel.Controls("nudPrice" & itemNum), NumericUpDown)

                Dim selectedProduct As OverallProductItem = CType(cmbProduct.SelectedItem, OverallProductItem)
                Dim totalPrice As Decimal = nudQty.Value * nudPrice.Value

                sql = "INSERT INTO purchase_details (TransactionID, productCode, Level, Gender, Size, OrderType, Quantity, UnitPrice, TotalPrice) " &
                      "VALUES (@transactionID, @productCode, @level, @gender, @size, @orderType, @quantity, @unitPrice, @totalPrice)"

                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@transactionID", selectedTransactionID)
                cmd.Parameters.AddWithValue("@productCode", selectedProduct.ProductCode)
                cmd.Parameters.AddWithValue("@level", cmbLevel.Text)
                cmd.Parameters.AddWithValue("@gender", cmbGender.Text)
                cmd.Parameters.AddWithValue("@size", cmbSize.Text)
                cmd.Parameters.AddWithValue("@orderType", cmbOrderType.Text)
                cmd.Parameters.AddWithValue("@quantity", nudQty.Value)
                cmd.Parameters.AddWithValue("@unitPrice", nudPrice.Value)
                cmd.Parameters.AddWithValue("@totalPrice", totalPrice)

                cmd.ExecuteNonQuery()
            Next

            ' Update transaction quantity
            sql = "UPDATE tbltransactions SET Quantity = (SELECT SUM(Quantity) FROM purchase_details WHERE TransactionID = @transactionID) " &
                  "WHERE TransactionID = @transactionID"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@transactionID", selectedTransactionID)
            cmd.ExecuteNonQuery()

            cn.Close()

            MessageBox.Show($"Purchase Order created successfully with {itemPanels.Count} items!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear all panels
            For Each p As Panel In itemPanels
                pnlScrollable.Controls.Remove(p)
            Next
            itemPanels.Clear()
            grpOrderDetails.Enabled = False

            LoadPurchaseOrders()
            LoadOrderDetails(selectedTransactionID)

        Catch ex As Exception
            MessageBox.Show("Error saving items: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub dgvOrderDetails_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrderDetails.CellClick
        If e.RowIndex < 0 Then Return

        If e.ColumnIndex = dgvOrderDetails.Columns("btnDelete").Index Then
            If dgvPurchaseOrders.SelectedRows.Count > 0 Then
                Dim status As String = dgvPurchaseOrders.SelectedRows(0).Cells("Status").Value.ToString()
                If status <> "Pending" Then
                    MessageBox.Show("Cannot delete items from " & status & " transactions!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If

            If MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                DeleteOrderDetail(e.RowIndex)
            End If
        End If
    End Sub

    Private Sub DeleteOrderDetail(rowIndex As Integer)
        Try
            Dim detailID As Integer = Convert.ToInt32(dgvOrderDetails.Rows(rowIndex).Cells("DetailID").Value)

            con()

            sql = "DELETE FROM purchase_details WHERE DetailID = @detailID"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@detailID", detailID)
            cmd.ExecuteNonQuery()

            sql = "UPDATE tbltransactions SET Quantity = (SELECT COALESCE(SUM(Quantity), 0) FROM purchase_details WHERE TransactionID = @transactionID) " &
                  "WHERE TransactionID = @transactionID"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@transactionID", selectedTransactionID)
            cmd.ExecuteNonQuery()

            cn.Close()

            MessageBox.Show("Item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadOrderDetails(selectedTransactionID)
            LoadPurchaseOrders()

        Catch ex As Exception
            MessageBox.Show("Error deleting item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub btnApprovePO_Click(sender As Object, e As EventArgs) Handles btnApprovePO.Click
        If selectedTransactionID = 0 Then
            MessageBox.Show("Please select a purchase order!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If Not AuthenticateAdmin() Then
            Return
        End If
        If MessageBox.Show("Are you sure you want to approve this purchase order?", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                con()
                sql = "UPDATE tbltransactions SET Status = 'Approved', ApprovedBy = @approvedBy " &
                  "WHERE TransactionID = @transactionID"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@approvedBy", currentAdminId)
                cmd.Parameters.AddWithValue("@transactionID", selectedTransactionID)
                cmd.ExecuteNonQuery()
                cn.Close()
                MessageBox.Show("Purchase Order approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadPurchaseOrders()
            Catch ex As Exception
                MessageBox.Show("Error approving purchase order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If cn.State = ConnectionState.Open Then cn.Close()
            End Try
        End If
    End Sub


    Private Sub btnRejectPO_Click(sender As Object, e As EventArgs) Handles btnRejectPO.Click
        If selectedTransactionID = 0 Then
            MessageBox.Show("Please select a purchase order!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 🔐 REQUIRE PASSWORD TO REJECT
        If Not AuthenticateAdmin() Then
            Return
        End If

        If MessageBox.Show("Are you sure you want to reject this purchase order?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                con()

                sql = "UPDATE tbltransactions SET Status = 'Rejected' WHERE TransactionID = @transactionID"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@transactionID", selectedTransactionID)
                cmd.ExecuteNonQuery()

                cn.Close()

                MessageBox.Show("Purchase Order rejected!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadPurchaseOrders()

            Catch ex As Exception
                MessageBox.Show("Error rejecting purchase order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If cn.State = ConnectionState.Open Then cn.Close()
            End Try
        End If
    End Sub

    Private Sub CalculateTotalAmount()
        Dim total As Decimal = 0

        If dgvOrderDetails.DataSource IsNot Nothing Then
            Dim dt As DataTable = CType(dgvOrderDetails.DataSource, DataTable)
            For Each row As DataRow In dt.Rows
                total += Convert.ToDecimal(row("TotalPrice"))
            Next
        End If

        lblTotalAmount.Text = "Total Amount: ₱" & total.ToString("N2")
    End Sub

    Private Class OverallProductItem
        Public Property ProductCode As Integer
        Public Property ProductName As String
        Public Property Category As String

        Public Overrides Function ToString() As String
            Return ProductCode & " - " & ProductName & " (" & Category & ")"
        End Function
    End Class

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmMain.Show()
        Me.Close()
    End Sub
End Class