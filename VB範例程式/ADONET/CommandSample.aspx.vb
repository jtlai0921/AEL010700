
Partial Class CommandSample
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Command()
    End Sub

    Protected Sub command()
        '建立SqlConnection資料庫連線
        Dim conn As New SqlConnection(WebConfigurationManager.ConnectionStrings("NorthwindConnection").ConnectionString)
        conn.Open()
        '建立SqlDataAdapter
        Dim adapter As New SqlDataAdapter()
        '建立DataSet
        Dim dsCustomer As New DataSet()

        '建立Select的SqlCommand
        Dim command As New SqlCommand("SELECT * FROM Customers WHERE Country = @Country AND City = @City", conn)
        '命令參數
        command.Parameters.Add("@Country", SqlDbType.NVarChar, 15).Value = "USA"
        command.Parameters.Add("@City", SqlDbType.NVarChar, 15).Value = "Seattle"
        adapter.SelectCommand = command     '指定SelectCommand
        adapter.Fill(dsCustomer)
        gvCustomer.DataSource = dsCustomer
        gvCustomer.DataBind()

        '建立INSERT的SqlCommand
        command = New SqlCommand("INSERT INTO Customers (CustomerID, CompanyName) VALUES (@CustomerID, @CompanyName)", conn)
        '命令參數
        command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID")
        command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName")
        adapter.InsertCommand = command     '指定InsertCommand

        '建立UPDATE的SqlCommand
        command = New SqlCommand("UPDATE Customers SET CustomerID = @CustomerID, CompanyName = @CompanyName WHERE CustomerID = @oldCustomerID", conn)
        command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID")
        command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName")
        Dim p1 As SqlParameter = command.Parameters.Add("@oldCustomerID", SqlDbType.NChar, 5, "CustomerID")
        p1.SourceVersion = DataRowVersion.Original
        adapter.UpdateCommand = command     '指定UpdateCommand

        '建立DELETE的SqlCommand
        command = New SqlCommand("DELETE FROM Customers WHERE CustomerID = @CustomerID", conn)
        p1 = command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID")
        p1.SourceVersion = DataRowVersion.Original
        adapter.DeleteCommand = command     '指定DeleteCommand
    End Sub
End Class
