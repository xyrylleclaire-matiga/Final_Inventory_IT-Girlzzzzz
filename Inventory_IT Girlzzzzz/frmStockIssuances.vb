Imports MySql.Data.MySqlClient

Public Class frmStockIssuance
    Private itemsList As New DataTable()
    Private currentTransactionID As Integer = 0
    Private isLoadingForm As Boolean = True ' Flag to prevent validation on load

    Private Sub frmStockIssuance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isLoadingForm = True ' Start loading

            ' Set requested by from logged in user
            If Not String.IsNullOrEmpty(currentFullName) Then
                txtRequestedBy.Text = currentFullName
            ElseIf Not String.IsNullOrEmpty(currentUsername) Then
                txtRequestedBy.Text = currentUsername
            Else
                txtRequestedBy.Text = "Unknown User"
            End If
            txtRequestedBy.ReadOnly = True
            txtRequestedBy.BackColor = Color.FromArgb(240, 240, 240)

            ' Set transaction ID - AUTO GENERATE NEXT ID
            LoadNextTransactionID()

            ' Initialize DataTable for items list
            InitializeItemsTable()

            ' Format DataGridView
            FormatDataGridView()

            ' Load products
            LoadProducts()

            ' Set default date
            dtpIssuanceDate.Value = DateTime.Now

            isLoadingForm = False ' Finished loading

        Catch ex As Exception
            isLoadingForm = False
            MessageBox.Show("Error loading form: " & ex.Message, "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadNextTransactionID()
        Try
            con()

            ' Get the next transaction ID
            sql = "SELECT IFNULL(MAX(TransactionID), 0) + 1 AS NextID FROM tbltransactions"
            cmd = New MySqlCommand(sql, cn)

            Dim result = cmd.ExecuteScalar()
            cn.Close()

            If result IsNot Nothing Then
                currentTransactionID = Convert.ToInt32(result)
                lblTransactionID.Text = "Transaction ID: " & currentTransactionID.ToString()
            Else
                currentTransactionID = 1
                lblTransactionID.Text = "Transaction ID: 1"
            End If

        Catch ex As Exception
            lblTransactionID.Text = "Transaction ID: ERROR"
            MessageBox.Show("Error loading Transaction ID: " & ex.Message, "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error)
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub InitializeItemsTable()
        itemsList.Columns.Add("ProductID", GetType(Integer))
        itemsList.Columns.Add("ProductCode", GetType(Integer))
        itemsList.Columns.Add("ProductName", GetType(String))
        itemsList.Columns.Add("Category", GetType(String))
        itemsList.Columns.Add("Level", GetType(String))
        itemsList.Columns.Add("Gender", GetType(String))
        itemsList.Columns.Add("Size", GetType(String))
        itemsList.Columns.Add("Quantity", GetType(Integer))
        itemsList.Columns.Add("UnitPrice", GetType(Decimal))
        itemsList.Columns.Add("TotalPrice", GetType(Decimal))

        DataGridView1.DataSource = itemsList
    End Sub

    Private Sub FormatDataGridView()
        ' --- Global Grid Line Settings ---
        DataGridView1.ShowCellToolTips = False
        DataGridView1.BorderStyle = BorderStyle.None
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridView1.GridColor = Color.FromArgb(220, 220, 220)
        ' -----------------------------------

        ' --- Column Headers Style: Left align headers by default for better text flow ---
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .BackColor = Color.FromArgb(250, 250, 250)
            .ForeColor = Color.FromArgb(64, 64, 64)
            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .Alignment = DataGridViewContentAlignment.MiddleLeft ' Set headers to Left Align
        End With

        ' --- Default Cell Style (All Cells) ---
        With DataGridView1.DefaultCellStyle
            .BackColor = Color.White
            .ForeColor = Color.FromArgb(64, 64, 64)
            .Font = New Font("Segoe UI", 10)
            .SelectionBackColor = Color.FromArgb(240, 240, 240)
            .SelectionForeColor = Color.FromArgb(64, 64, 64)
            .Alignment = DataGridViewContentAlignment.MiddleLeft ' Default cell alignment sa kaliwa para sa text
        End With

        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250)
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        If DataGridView1.Columns.Count >= 11 Then ' Check for enough columns, assuming 11 total columns including hidden ProductID
            ' Column Weights (Proportional Sizing)
            ' Columns returned by LoadStockData: 
            ' ProductID, Product Code, Product Name, Category, Level, Gender, Size, Stock Qty, Unit Price, Approval Status, Stock Status

            DataGridView1.Columns("ProductID").FillWeight = 5 ' Hidden, but give a small weight

            ' 1. Left-aligned Text Columns
            DataGridView1.Columns("Product Name").FillWeight = 180
            DataGridView1.Columns("Category").FillWeight = 120

            ' 2. Center-aligned Columns (Short Text / Codes)
            DataGridView1.Columns("Product Code").FillWeight = 80
            DataGridView1.Columns("Product Code").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns("Level").FillWeight = 100
            DataGridView1.Columns("Level").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns("Gender").FillWeight = 70
            DataGridView1.Columns("Gender").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns("Size").FillWeight = 70
            DataGridView1.Columns("Size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns("Approval Status").FillWeight = 100
            DataGridView1.Columns("Approval Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns("Stock Status").FillWeight = 100
            DataGridView1.Columns("Stock Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' 3. Right-aligned Numeric/Price Columns
            DataGridView1.Columns("Stock Qty").FillWeight = 70
            DataGridView1.Columns("Stock Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns("Unit Price").FillWeight = 100
            DataGridView1.Columns("Unit Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            ' Hide ProductID
            DataGridView1.Columns("ProductID").Visible = False
        End If

        ' Row headers
        DataGridView1.RowHeadersVisible = False
    End Sub

    Private Sub LoadProducts()
        Try
            con()
            cboProduct.Items.Clear()

            sql = "SELECT DISTINCT ProductName FROM products WHERE Status = 'Approved' ORDER BY ProductName"
            cmd = New MySqlCommand(sql, cn)
            dr = cmd.ExecuteReader()

            Dim count As Integer = 0
            While dr.Read()
                cboProduct.Items.Add(dr("ProductName").ToString())
                count += 1
            End While

            dr.Close()
            cn.Close()

            If count = 0 AndAlso Not isLoadingForm Then
                MessageBox.Show("No approved products found!" & vbCrLf & vbCrLf &
                                 "Please make sure products are approved in the system.",
                                 "No Products", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Error)
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub cboProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProduct.SelectedIndexChanged
        If isLoadingForm Then Return

        ' 1. Reset dependent dropdowns
        cboCategory.SelectedIndex = -1
        cboLevel.SelectedIndex = -1
        'cboStatus.SelectedIndex = -1 ' REMOVED
        cboGender.Items.Clear()
        cboSize.Items.Clear()
        lblAvailableStock.Text = "Available Stock: 0"
        lblAvailableStock.ForeColor = Color.Gray

        ' 2. Load the next options
        LoadCategoryOptions()
    End Sub

    ' *** NEW METHOD: Load Category ***
    Private Sub LoadCategoryOptions()
        Try
            If cboProduct.SelectedIndex = -1 Then Return

            con()
            cboCategory.Items.Clear()

            sql = "SELECT DISTINCT Category FROM products WHERE ProductName = @product AND Status = 'Approved' ORDER BY Category"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@product", cboProduct.Text)
            dr = cmd.ExecuteReader()

            While dr.Read()
                cboCategory.Items.Add(dr("Category").ToString())
            End While

            dr.Close()
            cn.Close()

            If cboCategory.Items.Count > 0 Then
                cboCategory.SelectedIndex = 0
            End If

        Catch ex As Exception
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        If isLoadingForm Then Return

        ' 1. Reset dependent dropdowns
        cboLevel.SelectedIndex = -1
        'cboStatus.SelectedIndex = -1 ' REMOVED
        cboGender.Items.Clear()
        cboSize.Items.Clear()
        lblAvailableStock.Text = "Available Stock: 0"

        ' 2. Load the next options
        LoadLevelOptions()
    End Sub

    ' *** NEW METHOD: Load Level ***
    Private Sub LoadLevelOptions()
        Try
            If cboProduct.SelectedIndex = -1 Or cboCategory.SelectedIndex = -1 Then Return

            con()
            cboLevel.Items.Clear()

            sql = "SELECT DISTINCT Level FROM products WHERE ProductName = @product AND Category = @category AND Status = 'Approved' ORDER BY Level"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@product", cboProduct.Text)
            cmd.Parameters.AddWithValue("@category", cboCategory.Text)
            dr = cmd.ExecuteReader()

            While dr.Read()
                cboLevel.Items.Add(dr("Level").ToString())
            End While

            dr.Close()
            cn.Close()

            If cboLevel.Items.Count > 0 Then
                cboLevel.SelectedIndex = 0
            End If

        Catch ex As Exception
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub cboLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLevel.SelectedIndexChanged
        If isLoadingForm Then Return

        ' 1. Reset dependent dropdowns
        'cboStatus.SelectedIndex = -1 ' REMOVED
        cboGender.Items.Clear()
        cboSize.Items.Clear()
        lblAvailableStock.Text = "Available Stock: 0"

        ' 2. Load the next options (Gender) - Now called directly from Level
        LoadGenderOptions()
    End Sub

    ' *** REMOVED: LoadStatusOptions() ***

    ' *** REMOVED: cboStatus_SelectedIndexChanged() ***

    Private Sub LoadGenderOptions()
        Try
            If cboProduct.SelectedIndex = -1 Or cboCategory.SelectedIndex = -1 Or
               cboLevel.SelectedIndex = -1 Then ' Adjusted check
                Return
            End If

            con()
            cboGender.Items.Clear()

            ' Removed ProductType/status filter from SQL
            sql = "SELECT DISTINCT gender FROM products WHERE ProductName = @product AND Category = @category AND Level = @level AND Status = 'Approved' ORDER BY gender"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@product", cboProduct.Text)
            cmd.Parameters.AddWithValue("@category", cboCategory.Text)
            cmd.Parameters.AddWithValue("@level", cboLevel.Text)
            ' Removed cmd.Parameters.AddWithValue("@status", cboStatus.Text)
            dr = cmd.ExecuteReader()

            While dr.Read()
                cboGender.Items.Add(dr("gender").ToString())
            End While

            dr.Close()
            cn.Close()

            If cboGender.Items.Count > 0 Then
                cboGender.SelectedIndex = 0
            End If

        Catch ex As Exception
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub cboGender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGender.SelectedIndexChanged
        If isLoadingForm Then Return

        ' 1. Reset dependent dropdowns
        cboSize.Items.Clear()
        lblAvailableStock.Text = "Available Stock: 0"

        ' 2. Load the next options (Size)
        LoadSizeOptions()
    End Sub

    Private Sub LoadSizeOptions()
        Try
            If cboProduct.SelectedIndex = -1 Or cboCategory.SelectedIndex = -1 Or
               cboLevel.SelectedIndex = -1 Or cboGender.SelectedIndex = -1 Then ' Adjusted check
                Return
            End If

            con()
            cboSize.Items.Clear()

            ' Removed ProductType/status filter from SQL
            sql = "SELECT DISTINCT Unit FROM products WHERE ProductName = @product AND Category = @category AND Level = @level AND gender = @gender AND Status = 'Approved' ORDER BY Unit"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@product", cboProduct.Text)
            cmd.Parameters.AddWithValue("@category", cboCategory.Text)
            cmd.Parameters.AddWithValue("@level", cboLevel.Text)
            ' Removed cmd.Parameters.AddWithValue("@status", cboStatus.Text)
            cmd.Parameters.AddWithValue("@gender", cboGender.Text)
            dr = cmd.ExecuteReader()

            While dr.Read()
                cboSize.Items.Add(dr("Unit").ToString())
            End While

            dr.Close()
            cn.Close()

            If cboSize.Items.Count > 0 Then
                cboSize.SelectedIndex = 0
            End If

        Catch ex As Exception
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub cboSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSize.SelectedIndexChanged
        If isLoadingForm Then Return
        LoadAvailableStock()
    End Sub

    Private Sub LoadAvailableStock()
        Try
            If cboProduct.SelectedIndex = -1 Or cboCategory.SelectedIndex = -1 Or
               cboLevel.SelectedIndex = -1 Or cboGender.SelectedIndex = -1 Or cboSize.SelectedIndex = -1 Then ' Adjusted check
                lblAvailableStock.Text = "Available Stock: 0"
                lblAvailableStock.ForeColor = Color.Red
                Return
            End If

            con()

            ' Removed ProductType/status filter from SQL
            sql = "SELECT StockQuantity FROM products WHERE ProductName = @product AND Category = @category AND Level = @level AND gender = @gender AND Unit = @size AND Status = 'Approved'"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@product", cboProduct.Text)
            cmd.Parameters.AddWithValue("@category", cboCategory.Text)
            cmd.Parameters.AddWithValue("@level", cboLevel.Text)
            ' Removed cmd.Parameters.AddWithValue("@status", cboStatus.Text)
            cmd.Parameters.AddWithValue("@gender", cboGender.Text)
            cmd.Parameters.AddWithValue("@size", cboSize.Text)

            Dim result = cmd.ExecuteScalar()
            cn.Close()

            If result IsNot Nothing Then
                Dim stockStr As String = result.ToString().Trim()
                Dim stock As Integer = 0

                If String.IsNullOrEmpty(stockStr) OrElse Not Integer.TryParse(stockStr, stock) Then
                    stock = 0
                End If

                lblAvailableStock.Text = "Available Stock: " & stock.ToString()

                If stock = 0 Then
                    lblAvailableStock.ForeColor = Color.Red
                ElseIf stock <= 10 Then
                    lblAvailableStock.ForeColor = Color.Orange
                Else
                    lblAvailableStock.ForeColor = Color.Green
                End If
            Else
                lblAvailableStock.Text = "Available Stock: 0"
                lblAvailableStock.ForeColor = Color.Red
            End If

        Catch ex As Exception
            lblAvailableStock.Text = "Available Stock: Error"
            lblAvailableStock.ForeColor = Color.Red
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        Try
            ' Validate all selections
            If cboProduct.SelectedIndex = -1 Then
                MessageBox.Show("Please select a product.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboProduct.Focus()
                Return
            End If

            If cboCategory.SelectedIndex = -1 Then
                MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboCategory.Focus()
                Return
            End If

            If cboLevel.SelectedIndex = -1 Then
                MessageBox.Show("Please select a level.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboLevel.Focus()
                Return
            End If

            ' If cboStatus was meant for mandatory selection:
            ' Removed: If cboStatus.SelectedIndex = -1 Then
            ' Removed:     MessageBox.Show("Please select a status (Set/AlaCarte).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ' Removed:     cboStatus.Focus()
            ' Removed:     Return
            ' Removed: End If

            If cboGender.SelectedIndex = -1 Then
                MessageBox.Show("Please select a gender.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboGender.Focus()
                Return
            End If

            If cboSize.SelectedIndex = -1 Then
                MessageBox.Show("Please select a size.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboSize.Focus()
                Return
            End If

            ' Get product details
            con()
            ' Removed ProductType/status filter from SQL
            sql = "SELECT ProductID, productCode, UnitPrice, StockQuantity, ProductType FROM products WHERE ProductName = @product AND Category = @category AND Level = @level AND gender = @gender AND Unit = @size AND Status = 'Approved'"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@product", cboProduct.Text)
            cmd.Parameters.AddWithValue("@category", cboCategory.Text)
            cmd.Parameters.AddWithValue("@level", cboLevel.Text)
            ' Removed cmd.Parameters.AddWithValue("@status", cboStatus.Text)
            cmd.Parameters.AddWithValue("@gender", cboGender.Text)
            cmd.Parameters.AddWithValue("@size", cboSize.Text)
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                Dim productID As Integer = Convert.ToInt32(dr("ProductID"))
                Dim productCode As Integer = Convert.ToInt32(dr("productCode"))
                Dim unitPrice As Decimal = Convert.ToDecimal(dr("UnitPrice"))
                ' Added ProductType reading to maintain its data in the detail table if needed later
                ' NOTE: This ProductType data is NOT validated as the control was removed.
                Dim productType As String = dr("ProductType").ToString()


                Dim stockStr As String = dr("StockQuantity").ToString().Trim()
                Dim availableStock As Integer = 0
                If Not String.IsNullOrEmpty(stockStr) Then
                    Integer.TryParse(stockStr, availableStock)
                End If

                dr.Close()

                ' Check if quantity exceeds available stock
                If txtQuantity.Value > availableStock Then
                    MessageBox.Show($"Insufficient stock! Available: {availableStock}", "Stock Error",
                                     MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cn.Close()
                    Return
                End If

                ' Check if item already exists in list
                Dim existingRow As DataRow = Nothing
                For Each row As DataRow In itemsList.Rows
                    If row("ProductID") = productID Then
                        existingRow = row
                        Exit For
                    End If
                Next

                If existingRow IsNot Nothing Then
                    ' Update existing item
                    Dim newQty As Integer = Convert.ToInt32(existingRow("Quantity")) + txtQuantity.Value
                    If newQty > availableStock Then
                        MessageBox.Show($"Total quantity would exceed available stock! Available: {availableStock}",
                                         "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        cn.Close()
                        Return
                    End If
                    existingRow("Quantity") = newQty
                    existingRow("TotalPrice") = newQty * unitPrice
                Else
                    ' Add new item
                    Dim newRow As DataRow = itemsList.NewRow()
                    newRow("ProductID") = productID
                    newRow("ProductCode") = productCode
                    newRow("ProductName") = cboProduct.Text
                    newRow("Category") = cboCategory.Text
                    newRow("Level") = cboLevel.Text
                    newRow("Gender") = cboGender.Text
                    newRow("Size") = cboSize.Text
                    newRow("Quantity") = txtQuantity.Value
                    newRow("UnitPrice") = unitPrice
                    newRow("TotalPrice") = txtQuantity.Value * unitPrice
                    itemsList.Rows.Add(newRow)
                End If

                ' Update total
                UpdateTotalAmount()

                ' Reset quantity
                txtQuantity.Value = 1

                MessageBox.Show("Item added to list!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                dr.Close()
                MessageBox.Show("Product not found in database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            cn.Close()

        Catch ex As Exception
            MessageBox.Show("Error adding item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub UpdateTotalAmount()
        Dim total As Decimal = 0
        For Each row As DataRow In itemsList.Rows
            total += Convert.ToDecimal(row("TotalPrice"))
        Next
        lblTotalAmount.Text = "₱" & total.ToString("N2")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Validate
            If String.IsNullOrWhiteSpace(txtRequestedBy.Text) Then
                MessageBox.Show("Requested by field is empty!", "Validation",
                             MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If itemsList.Rows.Count = 0 Then
                MessageBox.Show("Please add at least one item to the list.", "Validation",
                             MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If MessageBox.Show("Save this stock issuance?" & vbCrLf & vbCrLf &
                             "Transaction ID: " & currentTransactionID & vbCrLf &
                             "This will create a new issuance transaction.", "Confirm Save",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If

            con()

            Dim generalRemarks As String = txtRemarks.Text.Trim()

            ' 1. Insert transaction into tbltransactions with specific TransactionID
            sql = "INSERT INTO tbltransactions (TransactionID, TransactionType, ItemType, Quantity, TransactionDate, ProcessedBy, Status, Remarks) " &
              "VALUES (@transID, 'Issuance', 'Uniform', @qty, @date, @processedBy, 'Pending', @remarks)"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@transID", currentTransactionID)
            cmd.Parameters.AddWithValue("@qty", GetTotalQuantity())
            cmd.Parameters.AddWithValue("@date", dtpIssuanceDate.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@processedBy", currentAdminId)
            cmd.Parameters.AddWithValue("@remarks", generalRemarks)
            cmd.ExecuteNonQuery()

            ' 2. Insert purchase details for each item
            For Each row As DataRow In itemsList.Rows
                sql = "INSERT INTO purchase_details (TransactionID, productCode, Size, Level, Gender, Quantity, UnitPrice, Remarks) " &
                  "VALUES (@transID, @code, @size, @level, @gender, @qty, @price, @Remarks)"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@transID", currentTransactionID)
                cmd.Parameters.AddWithValue("@code", row("ProductCode"))
                cmd.Parameters.AddWithValue("@size", row("Size"))
                cmd.Parameters.AddWithValue("@level", row("Level"))
                cmd.Parameters.AddWithValue("@gender", row("Gender"))
                cmd.Parameters.AddWithValue("@qty", row("Quantity"))
                cmd.Parameters.AddWithValue("@price", row("UnitPrice"))
                cmd.Parameters.AddWithValue("@Remarks", generalRemarks)
                cmd.ExecuteNonQuery()
            Next

            cn.Close()

            MessageBox.Show("Stock issuance saved successfully!" & vbCrLf & vbCrLf &
                         "Transaction ID: " & currentTransactionID & vbCrLf &
                         "Total Items: " & itemsList.Rows.Count,
                         "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Ask if user wants to create another
            If MessageBox.Show("Do you want to create another issuance?", "Create Another",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ClearForm()
                LoadNextTransactionID() ' Load next ID for new transaction
            Else
                Me.Close()
                frmMain.Show()
            End If

        Catch ex As Exception
            MessageBox.Show("Error saving issuance: " & ex.Message & vbCrLf & vbCrLf &
                         "Please contact system administrator if problem persists.", "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error)
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Function GetTotalQuantity() As Integer
        Dim total As Integer = 0
        For Each row As DataRow In itemsList.Rows
            total += Convert.ToInt32(row("Quantity"))
        Next
        Return total
    End Function

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If itemsList.Rows.Count > 0 Then
            If MessageBox.Show("Clear all items from the list?" & vbCrLf & vbCrLf &
                                 "This action cannot be undone.", "Confirm Clear",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ClearForm()
            End If
        Else
            MessageBox.Show("List is already empty.", "Information",
                             MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ClearForm()
        itemsList.Clear()
        txtRemarks.Clear()
        txtQuantity.Value = 1
        dtpIssuanceDate.Value = DateTime.Now
        lblTotalAmount.Text = "₱0.00"
        lblAvailableStock.Text = "Available Stock: -"
        lblAvailableStock.ForeColor = Color.Gray

        ' Load next transaction ID
        LoadNextTransactionID()

        ' Reset ComboBoxes and clear dependent items
        cboProduct.SelectedIndex = -1
        cboCategory.SelectedIndex = -1
        cboLevel.SelectedIndex = -1

        cboGender.Items.Clear()
        cboSize.Items.Clear()

        ' Re-load products to start fresh
        LoadProducts()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ' Check if there are unsaved items
        If itemsList.Rows.Count > 0 OrElse Not String.IsNullOrWhiteSpace(txtRemarks.Text) Then
            Dim result = MessageBox.Show("Are you sure you want to go back?" & vbCrLf & vbCrLf &
                                         "All unsaved information will be lost.", "Confirm Exit",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.No Then
                Return
            End If
        End If

        Me.Close()
        frmMain.Show()
    End Sub

    Private Sub frmStockIssuance_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Additional check when closing form via X button
        If e.CloseReason = CloseReason.UserClosing Then
            If itemsList.Rows.Count > 0 OrElse Not String.IsNullOrWhiteSpace(txtRemarks.Text) Then
                Dim result = MessageBox.Show("Are you sure you want to close?" & vbCrLf & vbCrLf &
                                             "All unsaved information will be lost.", "Confirm Close",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If result = DialogResult.No Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class