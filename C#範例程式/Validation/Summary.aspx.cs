using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Summary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //驗證及顯示使用者輸入資料
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            txtMsg.Text = "您輸入的基本資料如下：<BR/>";
            txtMsg.Text += "姓名：" + Server.HtmlEncode(txtName.Text) + "<BR/>";
            txtMsg.Text += "電子郵件：" + Server.HtmlEncode(txtMail.Text) + "<BR/>";
            txtMsg.Text += "地址：" + Server.HtmlEncode(txtAddress.Text) + "<BR/>";
        }
    }
}
