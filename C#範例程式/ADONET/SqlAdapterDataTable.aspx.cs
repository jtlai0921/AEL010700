using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class SqlAdapterDataTable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //以SqlDataAdapter注入資料到DataSet
    protected void btnFill_Click(object sender, EventArgs e)
    {
        //取得Web.config中的資料庫連線字串設定
        string connString = WebConfigurationManager.ConnectionStrings["myDBConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();

        //建立SqlDataAdapter
        SqlDataAdapter da = new SqlDataAdapter("Select * From myProducts",conn);
        DataTable dtProducts=new DataTable("Products");   //建立DataTable資料表
        da.Fill(dtProducts);    //將資料注入到DataTable之中

        conn.Close();   //資料在Fill到DataTable之後，即可關閉資料庫連線
        conn.Dispose();

        gvProducts.DataSource = dtProducts;
        gvProducts.DataBind();
    }
}
