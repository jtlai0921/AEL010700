using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DropDownValid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //顯示使用者輸入資料
    protected void btnSumbit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            txtMsg.Text = "您輸入的基本資料如下：<BR/>";
            txtMsg.Text += "姓名：" + Server.HtmlEncode(txtName.Text) + "<BR/>";
            txtMsg.Text += "縣市：" + Server.HtmlEncode(dwnCity.SelectedValue) + "<BR/>";
        }
        else
        {
            txtMsg.Text = "您輸入的資料沒有通過驗證！";
        }
    }
}
