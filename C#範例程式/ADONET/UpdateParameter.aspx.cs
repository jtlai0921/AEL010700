using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UpdateParameter : System.Web.UI.Page
{
    string info = "";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //更新產品記錄
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (checkInputValid())
        {
            //建立資料庫連線
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test");
            SqlCommand cmd = null;
            try
            {
                
                conn.Open();    //開啓資料庫連線

                //建立SqlCommand查詢命令
                cmd = new SqlCommand("Update myProducts Set ProductName=@paramPN,Quantity=@paramQuantity,Price=@paramPrice Where ProductID=@paramPID ", conn);
                cmd.Parameters.Add("@paramPID", SqlDbType.NVarChar, 10).Value = txtProductID.Text;
                cmd.Parameters.Add("@paramPN", SqlDbType.NVarChar, 50).Value = txtProductName.Text;
                cmd.Parameters.Add("@paramQuantity", SqlDbType.Int, 4).Value = txtQuantity.Text;
                cmd.Parameters.Add("@paramPrice", SqlDbType.SmallMoney, 4).Value = txtPrice.Text;
                int rows = cmd.ExecuteNonQuery();

                txtMsg.Text = string.Format("更新產品資料記錄{0}筆成功！", rows);
            }
            catch (Exception ex)
            {
                txtMsg.Text = ex.ToString();  //顯示錯誤訊息
            }
            finally
            {
                //釋放物件及連線資源
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
        else
        {
            txtMsg.Text = info;
        }
    }

    //檢查TextBox控制項輸入內容是否合法
    protected bool checkInputValid()
    {
        bool ValidStatus = true;
        //檢查產品編號是否有輸入
        if (string.IsNullOrEmpty(txtProductID.Text))
        {
            ValidStatus = false;
            info = "*產品編號不得為空白！<BR/>";
        }

        //檢查產品名稱是否有輸入
        if (string.IsNullOrEmpty(txtProductName.Text))
        {
            ValidStatus = false;
            info += "*產品名稱不得為空白！<BR/>";
        }

        //檢查產品數量是否有輸入，並且為數字
        int i;
        if (!int.TryParse(txtQuantity.Text, out i))
        {
            ValidStatus = false;
            info += "*產品數量不得為空白，且必須為數字！<BR/>";
        }
        //檢查產品價格是否有輸入，並且為數字
        if (!int.TryParse(txtPrice.Text, out i))
        {
            ValidStatus = false;
            info += "*產品價格不得為空白，且必須為數字！<BR/>";
        }

        return ValidStatus;
    }
}
