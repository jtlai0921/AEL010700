using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class InsertProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showProducts();
        }
    }

    //新增產品資料
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        /*簡化的ADO.NET程式
        //建立資料庫連線
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test");
        conn.Open();    //開啓資料庫連線

        //建立SqlCommand查詢命令
        SqlCommand cmd = new SqlCommand("Insert Into myProducts (ProductID,ProductName,Quantity,Price) Values ('M0001','芒果汁',100,25) ", conn);
        cmd.ExecuteReader();

        //釋放物件及連線資源
        cmd.Dispose();
        conn.Close();
        conn.Dispose();
         * */

        //較為嚴謹及防止例外錯誤產生
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test");
        SqlCommand cmd=null;

        try
        {
            conn.Open();    //開啓資料庫連線

            //建立SqlCommand查詢命令
            cmd = new SqlCommand("Insert Into myProducts (ProductID,ProductName,Quantity,Price) Values ('M0001','芒果汁',100,25) ", conn);
            cmd.ExecuteNonQuery();
        }
        catch(Exception ex)
        {
            txtMsg.Text=ex.ToString();  //顯示錯誤訊息
        }
        finally
        {
            //釋放物件及連線資源
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }

        showProducts(); //顯示產品資料
    }

    //顯示產品資料
    protected void showProducts()
    {
                //建立資料庫連線
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test");
        conn.Open();    //開啓資料庫連線

        //建立SqlCommand查詢命令
        SqlCommand cmd = new SqlCommand("Select * From myProducts ", conn);
        SqlDataReader dr = cmd.ExecuteReader(); //執行查詢

        gvProducts.DataSource = dr; //指定GridView控制項之資料來源
        gvProducts.DataBind();  //資料繫結

        //釋放物件及連線資源
        dr.Dispose();
        cmd.Dispose();
        conn.Close();
        conn.Dispose();
    }
}
