using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SelectParameter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //以產品編號查詢產品資料
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        /*第一種寫法，於一行程式中完成SqlParameter之宣告與設定值*/
        //判斷TextBox控制項中是否有輸入產品名稱
        if (!string.IsNullOrEmpty(txtProductID.Text))
        {
            //建立資料庫連線
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test");
            conn.Open();    //開啓資料庫連線

            //建立SqlCommand查詢命令
            SqlCommand cmd = new SqlCommand("Select * From myProducts Where ProductID=@paramPID", conn);
            //於SqlCommand中加入SqlParameter參數，並設定參數值
            cmd.Parameters.Add("@paramPID", SqlDbType.NVarChar, 10).Value = txtProductID.Text;

            SqlDataReader dr = cmd.ExecuteReader(); //執行查詢

            //確定SqlDataReader是否含有回傳之資料記錄
            if (dr.HasRows)
            {
                //將資料記錄顯示在Details View控制項上
                gvProducts.Visible = true;
                txtMsg.Visible = false;
                gvProducts.DataSource = dr;
                gvProducts.DataBind();
            }
            else
            {
                //顯示查不到之訊息
                gvProducts.Visible = false;
                txtMsg.Visible = true;
                txtMsg.Text = "查無該項產品之資料記錄！";
            }

            //釋放物件及連線資源
            dr.Dispose();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }
        else
        {
            txtMsg.Visible = true;
            txtMsg.Text = "產品名稱不得為空白！";
        }

        //SelectQuery()     //呼叫執行第二種SqlParameter參數的程式

    }

    protected void SelectQuery()
    {
        //第二種寫法，將SqlParameter之宣告與設定值分成數段完成
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test");
        conn.Open();    //開啓資料庫連線

        //建立SqlCommand查詢命令
        SqlCommand cmd = new SqlCommand("Select * From myProducts Where ProductID=@paramPID", conn);

        //建立並定義SqlParameter
        SqlParameter p1 = new SqlParameter("@paramPID", SqlDbType.NVarChar, 10);
        p1.Value = txtProductID.Text;
        cmd.Parameters.Add(p1);

        SqlDataReader dr = cmd.ExecuteReader(); //執行查詢

        gvProducts.DataSource = dr; //指定GridView控制項之資料來源
        gvProducts.DataBind();  //資料繫結

        dr.Dispose();
        cmd.Dispose();
        conn.Close();
        conn.Dispose();
    }
}
