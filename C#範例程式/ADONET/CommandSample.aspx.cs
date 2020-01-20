using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class CommandSample : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Command();
    }

    protected void Command()
    {
        //建立SqlConnection資料庫連線
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString);
        //建立SqlDataAdapter
        SqlDataAdapter adapter = new SqlDataAdapter();
        //建立DataSet
        DataSet dsCustomer=new DataSet();
        

        //建立Select的SqlCommand
        SqlCommand command = new SqlCommand("SELECT * FROM Customers WHERE Country = @Country AND City = @City", conn);
        //指令參數
        command.Parameters.Add("@Country", SqlDbType.NVarChar, 15).Value="USA";
        command.Parameters.Add("@City", SqlDbType.NVarChar, 15).Value = "Seattle";
        adapter.SelectCommand = command;    //指定SelectCommand
        adapter.Fill(dsCustomer);
        gvCustomer.DataSource = dsCustomer;
        gvCustomer.DataBind();

        //建立INSERT的SqlCommand
        command = new SqlCommand("INSERT INTO Customers (CustomerID, CompanyName) VALUES (@CustomerID, @CompanyName)", conn);
        //指令參數
        command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID");
        command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName");
        adapter.InsertCommand = command;    //指定InsertCommand

        //建立UPDATE的SqlCommand
        command = new SqlCommand("UPDATE Customers SET CustomerID = @CustomerID, CompanyName = @CompanyName WHERE CustomerID = @oldCustomerID", conn);
        command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID");
        command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName");
        SqlParameter parameter = command.Parameters.Add("@oldCustomerID", SqlDbType.NChar, 5, "CustomerID");
        parameter.SourceVersion = DataRowVersion.Original;
        adapter.UpdateCommand = command;    //指定UpdateCommand

        //建立DELETE的SqlCommand
        command = new SqlCommand("DELETE FROM Customers WHERE CustomerID = @CustomerID", conn);
        // 指令參數
        parameter = command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID");
        parameter.SourceVersion = DataRowVersion.Original;
        adapter.DeleteCommand = command;    //指定DeleteCommand

    }
}
