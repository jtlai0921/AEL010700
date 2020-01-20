using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;


public partial class DataViewBasic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //DataView資料檢視的運用
    protected void btnDataView_Click(object sender, EventArgs e)
    {
        //取得Web.config中的資料庫連線字串設定
        string connString = WebConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();

        //建立SqlDataAdapter
        SqlDataAdapter da = new SqlDataAdapter("Select EmployeeID,LastName,FirstName,City,Country From Employees", conn);
        DataSet ds = new DataSet();     //建立DataSet資料集
        da.Fill(ds, "Employees");    //將資料注入到DataSet之中

        conn.Close();   
        conn.Dispose();

        //建立DataView資料檢視，篩選Country為USA的員工
        //並依City,LastName二個欄位排序
        DataView dvUSA = new DataView(ds.Tables["Employees"], "Country='USA'", "City,LastName", DataViewRowState.CurrentRows);
        //顯示USA美國員工資料
        GridView1.DataSource = dvUSA;
        GridView1.DataBind();

        //建立DataView資料檢視，篩選Country為UK的員工
        //並依EmployeeID,LastName二個欄位排序
        DataView dvUK = new DataView(ds.Tables["Employees"], "Country='UK'", "EmployeeID,LastName", DataViewRowState.CurrentRows);
        //顯示UK英國員工資料
        GridView2.DataSource = dvUK;
        GridView2.DataBind();
    }
}
