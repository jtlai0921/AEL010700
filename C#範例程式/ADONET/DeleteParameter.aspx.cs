using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class DeleteParameter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showProducts();
        }
    }

    //刪除產品資料記錄
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //判斷TextBox控制項中是否有輸入產品編號
        if (!string.IsNullOrEmpty(txtProductID.Text))
        {
            //建立資料庫連線
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test");
            SqlCommand cmd = null;
            int? rows = null;

            try
            {
                conn.Open();    //開啓資料庫連線

                //建立SqlCommand查詢命令
                cmd = new SqlCommand("Delete From myProducts Where ProductID=@paramPID", conn);
                //於SqlCommand中加入SqlParameter參數，並設定參數值
                cmd.Parameters.Add("@paramPID", SqlDbType.NVarChar, 10).Value = txtProductID.Text;

                rows = cmd.ExecuteNonQuery();   //執行命令
            }
            catch (Exception ex)
            {
                txtMsg.Text = ex.ToString();
            }
            finally
            {
                //釋放物件及連線資源
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }

            if (rows > 0)
            {
                txtMsg.Text = string.Format("刪除產品資料記錄{0}筆成功！", rows);
            }
            else
            {
                txtMsg.Text = "無任何產品資料被刪除！";
            }
        }
        else
        {
            txtMsg.Visible = true;
            txtMsg.Text = "產品編號不得為空白！";
        }

        showProducts();
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
