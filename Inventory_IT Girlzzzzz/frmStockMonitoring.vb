Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient

Public Class frmStockMonitoring

    Private Sub frmStockMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize ALL filters
            If cboCategory.Items.Count > 0 Then cboCategory.SelectedIndex = 0
            If cboLevel.Items.Count > 0 Then cboLevel.SelectedIndex = 0
            If cboGender.Items.Count > 0 Then cboGender.SelectedIndex = 0
            If cboStatus.Items.Count > 0 Then cboStatus.SelectedIndex = 0
            If cboStockStatus.Items.Count > 0 Then cboStockStatus.SelectedIndex = 0

            ' Initialize date range
            dtpFrom.Value = DateTime.Now.AddMonths(-1)
            dtpTo.Value = DateTime.Now

            ' Setup search placeholder
            SetupSearchPlaceholder()

            ' Format DataGridViews
            FormatDataGridView()

            ' Setup Charts with proper configuration
            SetupCharts()

            ' Load all data
            LoadStockData()
            LoadDashboardStats()
            LoadMovementHistory()
            LoadStockTrendChart()
            LoadCategoryDistributionChart()

        Catch ex As Exception
            MessageBox.Show("Error loading form: " & ex.Message & vbCrLf & vbCrLf &
                          "Stack Trace: " & ex.StackTrace, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupSearchPlaceholder()
        txtSearch.ForeColor = Color.Gray
        txtSearch.Text = "Search products..."
    End Sub

    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearch.Enter
        If txtSearch.Text = "Search products..." Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.FromArgb(64, 64, 64)
        End If
    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearch.Leave
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            txtSearch.Text = "Search products..."
            txtSearch.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub FormatDataGridView()
        ' Format main stock list grid
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .BackColor = Color.FromArgb(250, 250, 250)
            .ForeColor = Color.FromArgb(64, 64, 64)
            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
            .Padding = New Padding(10, 0, 0, 0)
        End With

        With DataGridView1.DefaultCellStyle
            .BackColor = Color.White
            .ForeColor = Color.FromArgb(64, 64, 64)
            .Font = New Font("Segoe UI", 10, FontStyle.Regular)
            .SelectionBackColor = Color.FromArgb(240, 240, 240)
            .SelectionForeColor = Color.FromArgb(64, 64, 64)
            .Padding = New Padding(10, 5, 10, 5)
        End With

        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250)

        ' Format Movement History Grid
        With dgvMovementHistory.ColumnHeadersDefaultCellStyle
            .BackColor = Color.FromArgb(250, 250, 250)
            .ForeColor = Color.FromArgb(64, 64, 64)
            .Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        With dgvMovementHistory.DefaultCellStyle
            .BackColor = Color.White
            .ForeColor = Color.FromArgb(64, 64, 64)
            .Font = New Font("Segoe UI", 9, FontStyle.Regular)
            .SelectionBackColor = Color.FromArgb(240, 240, 240)
            .SelectionForeColor = Color.FromArgb(64, 64, 64)
        End With

        dgvMovementHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250)
    End Sub

    Private Sub SetupCharts()
        ' ===== STOCK TREND CHART (Bar Chart) =====
        With chartStockTrend
            .ChartAreas.Clear()
            .Series.Clear()
            .Legends.Clear()
            .Titles.Clear()

            ' Chart Area Configuration
            Dim chartArea As New ChartArea()
            chartArea.BackColor = Color.White
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray
            chartArea.AxisX.Title = "Date (Last 30 Days)"
            chartArea.AxisX.TitleFont = New Font("Segoe UI", 10, FontStyle.Bold)
            chartArea.AxisY.Title = "Quantity"
            chartArea.AxisY.TitleFont = New Font("Segoe UI", 10, FontStyle.Bold)
            chartArea.AxisX.LabelStyle.Angle = -45
            chartArea.AxisX.Interval = 1
            .ChartAreas.Add(chartArea)

            ' Stock In Series (Green)
            Dim seriesIn As New Series("Stock In (Purchase Orders)")
            seriesIn.ChartType = SeriesChartType.Column
            seriesIn.Color = Color.FromArgb(40, 167, 69)
            seriesIn.IsValueShownAsLabel = True
            seriesIn.LabelFormat = "{0}"
            seriesIn.Font = New Font("Segoe UI", 8, FontStyle.Bold)
            .Series.Add(seriesIn)

            ' Stock Out Series (Red)
            Dim seriesOut As New Series("Stock Out (Issuance/Pullout)")
            seriesOut.ChartType = SeriesChartType.Column
            seriesOut.Color = Color.FromArgb(220, 53, 69)
            seriesOut.IsValueShownAsLabel = True
            seriesOut.LabelFormat = "{0}"
            seriesOut.Font = New Font("Segoe UI", 8, FontStyle.Bold)
            .Series.Add(seriesOut)

            ' Legend
            Dim legend As New Legend("TrendLegend")
            legend.Docking = Docking.Top
            legend.Alignment = StringAlignment.Center
            legend.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            .Legends.Add(legend)

            ' Title
            Dim title As New Title()
            title.Text = "Stock Movement Trend (Last 30 Days)"
            title.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            title.ForeColor = Color.FromArgb(64, 64, 64)
            .Titles.Add(title)
        End With

        ' ===== CATEGORY DISTRIBUTION CHART (Pie Chart) =====
        With chartCategoryDistribution
            .ChartAreas.Clear()
            .Series.Clear()
            .Legends.Clear()
            .Titles.Clear()

            ' Chart Area
            Dim chartArea As New ChartArea()
            chartArea.BackColor = Color.White
            .ChartAreas.Add(chartArea)

            ' Pie Series
            Dim series As New Series("Stock by Category")
            series.ChartType = SeriesChartType.Pie
            series.IsValueShownAsLabel = True
            series.Label = "#PERCENT{P1}" & vbCrLf & "#VALX" & vbCrLf & "(#VAL{N0} pcs)"
            series.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            series.LabelForeColor = Color.White
            series("PieLabelStyle") = "Outside"
            series("PieDrawingStyle") = "SoftEdge"
            .Series.Add(series)

            ' Legend
            Dim legend As New Legend("CategoryLegend")
            legend.Docking = Docking.Bottom
            legend.Alignment = StringAlignment.Center
            legend.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            .Legends.Add(legend)

            ' Title
            Dim title As New Title()
            title.Text = "Stock Distribution by Category"
            title.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            title.ForeColor = Color.FromArgb(64, 64, 64)
            .Titles.Add(title)
        End With
    End Sub

    Public Sub LoadStockData(Optional category As String = "All Categories",
                              Optional level As String = "All Levels",
                              Optional gender As String = "All Gender",
                              Optional status As String = "All Status",
                              Optional stockStatus As String = "All Stock Status",
                              Optional searchText As String = "")
        Try
            con()

            Dim query As String = "SELECT 
                p.ProductID,
                p.productCode AS 'Product Code',
                p.ProductName AS 'Product Name',
                p.Category,
                p.Level,
                p.gender AS Gender,
                p.Unit AS Size,
                CAST(COALESCE(p.StockQuantity, '0') AS SIGNED) AS 'Stock Qty',
                CONCAT('₱', FORMAT(p.UnitPrice, 2)) AS 'Unit Price',
                p.Status AS 'Approval Status',
                CASE 
                    WHEN CAST(COALESCE(p.StockQuantity, '0') AS SIGNED) = 0 THEN 'Out of Stock'
                    WHEN CAST(COALESCE(p.StockQuantity, '0') AS SIGNED) <= 10 THEN 'Low Stock'
                    ELSE 'In Stock'
                END AS 'Stock Status'
                FROM products p
                WHERE 1=1"

            ' Apply Category Filter
            If category <> "All Categories" Then
                query &= " AND p.Category = @category"
            End If

            ' Apply Level Filter
            If level <> "All Levels" Then
                query &= " AND p.Level = @level"
            End If

            ' Apply Gender Filter
            If gender <> "All Gender" Then
                query &= " AND p.gender = @gender"
            End If

            ' Apply Status Filter (Approval Status)
            If status <> "All Status" Then
                query &= " AND p.Status = @status"
            End If

            ' Apply Stock Status Filter
            If stockStatus <> "All Stock Status" Then
                Select Case stockStatus
                    Case "In Stock"
                        query &= " AND CAST(COALESCE(p.StockQuantity, '0') AS SIGNED) > 10"
                    Case "Low Stock"
                        query &= " AND CAST(COALESCE(p.StockQuantity, '0') AS SIGNED) <= 10 AND CAST(COALESCE(p.StockQuantity, '0') AS SIGNED) > 0"
                    Case "Out of Stock"
                        query &= " AND CAST(COALESCE(p.StockQuantity, '0') AS SIGNED) = 0"
                End Select
            End If

            ' Apply Search Filter
            If Not String.IsNullOrEmpty(searchText) AndAlso searchText <> "Search products..." Then
                query &= " AND (p.ProductName LIKE @search 
                             OR CAST(p.productCode AS CHAR) LIKE @search 
                             OR p.Unit LIKE @search
                             OR p.Category LIKE @search)"
            End If

            query &= " ORDER BY p.ProductName, p.Level, p.Unit"

            cmd = New MySqlCommand(query, cn)

            ' Add parameters
            If category <> "All Categories" Then
                cmd.Parameters.AddWithValue("@category", category)
            End If

            If level <> "All Levels" Then
                cmd.Parameters.AddWithValue("@level", level)
            End If

            If gender <> "All Gender" Then
                cmd.Parameters.AddWithValue("@gender", gender)
            End If

            If status <> "All Status" Then
                cmd.Parameters.AddWithValue("@status", status)
            End If

            If Not String.IsNullOrEmpty(searchText) AndAlso searchText <> "Search products..." Then
                cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")
            End If

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            DataGridView1.DataSource = dt
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Hide ProductID
            If DataGridView1.Columns.Contains("ProductID") Then
                DataGridView1.Columns("ProductID").Visible = False
            End If

            ' Color code stock status
            ColorCodeStockLevels()

            cn.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading stock data: " & ex.Message & vbCrLf & vbCrLf &
                          "Stack Trace: " & ex.StackTrace, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub ColorCodeStockLevels()
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                ' Color code Stock Status column
                If DataGridView1.Columns.Contains("Stock Status") Then
                    Dim stockStatusCell = row.Cells("Stock Status")
                    If stockStatusCell.Value IsNot Nothing Then
                        Select Case stockStatusCell.Value.ToString()
                            Case "Out of Stock"
                                stockStatusCell.Style.ForeColor = Color.White
                                stockStatusCell.Style.BackColor = Color.FromArgb(220, 53, 69)
                                stockStatusCell.Style.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                            Case "Low Stock"
                                stockStatusCell.Style.ForeColor = Color.White
                                stockStatusCell.Style.BackColor = Color.FromArgb(255, 193, 7)
                                stockStatusCell.Style.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                            Case "In Stock"
                                stockStatusCell.Style.ForeColor = Color.White
                                stockStatusCell.Style.BackColor = Color.FromArgb(40, 167, 69)
                                stockStatusCell.Style.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                        End Select
                    End If
                End If

                ' Color code Approval Status column
                If DataGridView1.Columns.Contains("Approval Status") Then
                    Dim statusCell = row.Cells("Approval Status")
                    If statusCell.Value IsNot Nothing Then
                        Select Case statusCell.Value.ToString()
                            Case "Approved"
                                statusCell.Style.ForeColor = Color.Green
                                statusCell.Style.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                            Case "Rejected"
                                statusCell.Style.ForeColor = Color.Red
                                statusCell.Style.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                            Case "Pending"
                                statusCell.Style.ForeColor = Color.Orange
                                statusCell.Style.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                        End Select
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub LoadDashboardStats()
        Try
            con()

            ' Total Products
            Dim qryTotalProducts As String = "SELECT COUNT(*) FROM products"
            cmd = New MySqlCommand(qryTotalProducts, cn)
            lblTotalProducts.Text = cmd.ExecuteScalar().ToString()

            ' Total Stock Quantity
            Dim qryTotalStock As String = "SELECT SUM(CAST(COALESCE(StockQuantity, '0') AS SIGNED)) FROM products"
            cmd = New MySqlCommand(qryTotalStock, cn)
            Dim totalStock = cmd.ExecuteScalar()
            lblTotalStock.Text = If(IsDBNull(totalStock) OrElse totalStock Is Nothing, "0", totalStock.ToString())

            ' Low Stock Count
            Dim qryLowStock As String = "SELECT COUNT(*) FROM products 
                WHERE CAST(COALESCE(StockQuantity, '0') AS SIGNED) <= 10 
                AND CAST(COALESCE(StockQuantity, '0') AS SIGNED) > 0"
            cmd = New MySqlCommand(qryLowStock, cn)
            lblLowStock.Text = cmd.ExecuteScalar().ToString()

            ' Out of Stock
            Dim qryOutStock As String = "SELECT COUNT(*) FROM products 
                WHERE CAST(COALESCE(StockQuantity, '0') AS SIGNED) = 0"
            cmd = New MySqlCommand(qryOutStock, cn)
            lblOutOfStock.Text = cmd.ExecuteScalar().ToString()

            ' Total Inventory Value
            Dim qryTotalValue As String = "SELECT SUM(CAST(COALESCE(StockQuantity, '0') AS SIGNED) * UnitPrice) FROM products"
            cmd = New MySqlCommand(qryTotalValue, cn)
            Dim totalValue = cmd.ExecuteScalar()
            lblTotalValue.Text = "₱" & If(IsDBNull(totalValue) OrElse totalValue Is Nothing, "0.00", String.Format("{0:N2}", totalValue))

            ' Movement Stats (Last 30 days)
            Dim qryMovements As String = "SELECT 
                COALESCE(SUM(CASE WHEN t.TransactionType = 'Purchase Order' AND t.Status = 'Approved' THEN pd.Quantity ELSE 0 END), 0) AS TotalPurchased,
                COALESCE(SUM(CASE WHEN t.TransactionType = 'Issuance' AND t.Status = 'Approved' THEN pd.Quantity ELSE 0 END), 0) AS TotalIssued,
                COALESCE(SUM(CASE WHEN t.TransactionType = 'Pullout' AND t.Status = 'Approved' THEN pd.Quantity ELSE 0 END), 0) AS TotalPulledOut
                FROM tbltransactions t
                LEFT JOIN purchase_details pd ON t.TransactionID = pd.TransactionID
                WHERE t.TransactionDate >= DATE_SUB(NOW(), INTERVAL 30 DAY)"

            cmd = New MySqlCommand(qryMovements, cn)
            Dim reader = cmd.ExecuteReader()
            If reader.Read() Then
                lblTotalPurchased.Text = reader("TotalPurchased").ToString()
                lblTotalIssued.Text = reader("TotalIssued").ToString()
                lblTotalPulledOut.Text = reader("TotalPulledOut").ToString()
            End If
            reader.Close()

            cn.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading dashboard stats: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub LoadMovementHistory()
        Try
            con()

            Dim query As String = "SELECT 
                t.TransactionID,
                t.TransactionType AS 'Transaction Type',
                DATE_FORMAT(t.TransactionDate, '%Y-%m-%d %H:%i') AS 'Transaction Date',
                op.ProductName AS 'Product Name',
                COALESCE(pd.Size, '-') AS Size,
                COALESCE(pd.Level, '-') AS Level,
                COALESCE(pd.Gender, '-') AS Gender,
                COALESCE(pd.Quantity, 0) AS Quantity,
                CONCAT('₱', FORMAT(COALESCE(pd.UnitPrice, 0), 2)) AS 'Unit Price',
                CONCAT('₱', FORMAT(COALESCE(pd.TotalPrice, 0), 2)) AS 'Total Price',
                t.Status,
                COALESCE(CONCAT(a.FirstName, ' ', a.LastName), 'N/A') AS 'Processed By',
                COALESCE(CONCAT(ap.FirstName, ' ', ap.LastName), 'N/A') AS 'Approved By'
                FROM tbltransactions t
                LEFT JOIN purchase_details pd ON t.TransactionID = pd.TransactionID
                LEFT JOIN overallproduct op ON pd.productCode = op.productCode
                LEFT JOIN tbladmin_users a ON t.ProcessedBy = a.admin_id
                LEFT JOIN tbladmin_users ap ON t.ApprovedBy = ap.admin_id
                WHERE t.TransactionDate BETWEEN @dateFrom AND @dateTo"

            If cboCategory.SelectedItem IsNot Nothing AndAlso cboCategory.SelectedItem.ToString() <> "All Categories" Then
                query &= " AND op.Category = @category"
            End If

            query &= " ORDER BY t.TransactionDate DESC LIMIT 200"

            cmd = New MySqlCommand(query, cn)
            cmd.Parameters.AddWithValue("@dateFrom", dtpFrom.Value.Date)
            cmd.Parameters.AddWithValue("@dateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

            If cboCategory.SelectedItem IsNot Nothing AndAlso cboCategory.SelectedItem.ToString() <> "All Categories" Then
                cmd.Parameters.AddWithValue("@category", cboCategory.SelectedItem.ToString())
            End If

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            dgvMovementHistory.DataSource = dt
            dgvMovementHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            If dgvMovementHistory.Columns.Contains("TransactionID") Then
                dgvMovementHistory.Columns("TransactionID").Visible = False
            End If

            ' Color code status
            For Each row As DataGridViewRow In dgvMovementHistory.Rows
                If Not row.IsNewRow AndAlso dgvMovementHistory.Columns.Contains("Status") Then
                    Dim statusCell = row.Cells("Status")
                    If statusCell.Value IsNot Nothing Then
                        Select Case statusCell.Value.ToString()
                            Case "Approved"
                                statusCell.Style.ForeColor = Color.White
                                statusCell.Style.BackColor = Color.FromArgb(40, 167, 69)
                                statusCell.Style.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                            Case "Rejected"
                                statusCell.Style.ForeColor = Color.White
                                statusCell.Style.BackColor = Color.FromArgb(220, 53, 69)
                                statusCell.Style.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                            Case "Pending"
                                statusCell.Style.ForeColor = Color.White
                                statusCell.Style.BackColor = Color.FromArgb(255, 193, 7)
                                statusCell.Style.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                        End Select
                    End If
                End If
            Next

            cn.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading movement history: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub LoadStockTrendChart()
        Try
            con()

            Dim query As String = "SELECT 
                DATE(t.TransactionDate) AS TransDate,
                COALESCE(SUM(CASE WHEN t.TransactionType = 'Purchase Order' AND t.Status = 'Approved' THEN pd.Quantity ELSE 0 END), 0) AS Incoming,
                COALESCE(SUM(CASE WHEN t.TransactionType IN ('Issuance', 'Pullout') AND t.Status = 'Approved' THEN pd.Quantity ELSE 0 END), 0) AS Outgoing
                FROM tbltransactions t
                LEFT JOIN purchase_details pd ON t.TransactionID = pd.TransactionID
                WHERE t.TransactionDate >= DATE_SUB(NOW(), INTERVAL 30 DAY)
                GROUP BY DATE(t.TransactionDate)
                ORDER BY DATE(t.TransactionDate)"

            cmd = New MySqlCommand(query, cn)
            Dim reader = cmd.ExecuteReader()

            If chartStockTrend.Series.Count >= 2 Then
                chartStockTrend.Series(0).Points.Clear()
                chartStockTrend.Series(1).Points.Clear()

                While reader.Read()
                    If Not IsDBNull(reader("TransDate")) Then
                        Dim transDate = Convert.ToDateTime(reader("TransDate")).ToString("MM/dd/yyyy")
                        Dim incoming = Convert.ToInt32(reader("Incoming"))
                        Dim outgoing = Convert.ToInt32(reader("Outgoing"))

                        chartStockTrend.Series(0).Points.AddXY(transDate, incoming)
                        chartStockTrend.Series(1).Points.AddXY(transDate, outgoing)
                    End If
                End While
            End If
            reader.Close()

            cn.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading trend chart: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub LoadCategoryDistributionChart()
        Try
            con()

            Dim query As String = "SELECT 
                Category, 
                SUM(CAST(COALESCE(StockQuantity, '0') AS SIGNED)) AS Total
                FROM products
                GROUP BY Category
                HAVING Total > 0"

            cmd = New MySqlCommand(query, cn)
            Dim reader = cmd.ExecuteReader()

            If chartCategoryDistribution.Series.Count > 0 Then
                chartCategoryDistribution.Series(0).Points.Clear()

                ' Define colors for each category
                Dim colors() As Color = {
                    Color.FromArgb(0, 123, 255),
                    Color.FromArgb(40, 167, 69),
                    Color.FromArgb(255, 193, 7),
                    Color.FromArgb(220, 53, 69)
                }
                Dim colorIndex As Integer = 0

                While reader.Read()
                    Dim category = reader("Category").ToString()
                    Dim total = Convert.ToInt32(reader("Total"))
                    Dim point = chartCategoryDistribution.Series(0).Points.AddXY(category, total)
                    chartCategoryDistribution.Series(0).Points(point).Color = colors(colorIndex Mod colors.Length)
                    colorIndex += 1
                End While
            End If
            reader.Close()

            cn.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading category chart: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    ' ===== FILTER EVENT HANDLERS =====
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text = "Search products..." Then Return
        ApplyFilters()
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub cboLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLevel.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub cboGender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGender.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub cboStockStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStockStatus.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        LoadMovementHistory()
        LoadStockTrendChart()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        LoadMovementHistory()
        LoadStockTrendChart()
    End Sub

    Private Sub ApplyFilters()
        Dim category As String = If(cboCategory.SelectedItem IsNot Nothing, cboCategory.SelectedItem.ToString(), "All Categories")
        Dim level As String = If(cboLevel.SelectedItem IsNot Nothing, cboLevel.SelectedItem.ToString(), "All Levels")
        Dim gender As String = If(cboGender.SelectedItem IsNot Nothing, cboGender.SelectedItem.ToString(), "All Gender")
        Dim status As String = If(cboStatus.SelectedItem IsNot Nothing, cboStatus.SelectedItem.ToString(), "All Status")
        Dim stockStatus As String = If(cboStockStatus.SelectedItem IsNot Nothing, cboStockStatus.SelectedItem.ToString(), "All Stock Status")
        Dim searchText As String = txtSearch.Text.Trim()

        LoadStockData(category, level, gender, status, stockStatus, searchText)
        LoadDashboardStats()
        LoadMovementHistory()
        LoadCategoryDistributionChart()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadStockData()
        LoadDashboardStats()
        LoadMovementHistory()
        LoadStockTrendChart()
        LoadCategoryDistributionChart()
        MessageBox.Show("Data refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportToExcel()
    End Sub

    Private Sub ExportToExcel()
        Try
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("No data to export!", "Information",
             MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "CSV Files (*.csv)|*.csv"
            saveDialog.FileName = "StockMonitoring_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                Using writer As New StreamWriter(saveDialog.FileName)
                    ' Write headers
                    Dim headers As New List(Of String)
                    For Each column As DataGridViewColumn In DataGridView1.Columns
                        If column.Visible Then
                            headers.Add(column.HeaderText)
                        End If
                    Next
                    writer.WriteLine(String.Join(",", headers))

                    ' Write data
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        If Not row.IsNewRow Then
                            Dim cells As New List(Of String)
                            For Each cell As DataGridViewCell In row.Cells
                                If DataGridView1.Columns(cell.ColumnIndex).Visible Then
                                    Dim cellValue As String = If(cell.Value?.ToString(), "")
                                    If cellValue.Contains(",") Or cellValue.Contains("""") Then
                                        cellValue = """" & cellValue.Replace("""", """""") & """"
                                    End If
                                    cells.Add(cellValue)
                                End If
                            Next
                            writer.WriteLine(String.Join(",", cells))
                        End If
                    Next
                End Using

                MessageBox.Show("Stock data exported successfully to:" & vbCrLf & saveDialog.FileName,
             "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If MessageBox.Show("Do you want to open the exported file?", "Open File",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo() With {
          .FileName = saveDialog.FileName,
          .UseShellExecute = True
        })

                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error exporting data: " & ex.Message, "Error",
           MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmMain.Show()
        Me.Close()
    End Sub
End Class