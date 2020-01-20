using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Custom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //Server端驗證
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //台灣的郵遞區號長度必須為3或5碼
        if (txtZipCode.Text.Length == 3 || txtZipCode.Text.Length == 5)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    //驗證及顯示使用者輸入資料
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            txtMsg.Text = "您輸入的基本資料如下：<BR/>";
            txtMsg.Text += "姓名：" + Server.HtmlEncode(txtName.Text) + "<BR/>";
            txtMsg.Text += "郵遞區號：" + Server.HtmlEncode(txtZipCode.Text) + "<BR/>";
            txtMsg.Text += "地址：" + Server.HtmlEncode(txtAddress.Text) + "<BR/>";
        }
        else
        {
            txtMsg.Text = "您輸入的資料沒有通過驗證！";
        }
    }
}
