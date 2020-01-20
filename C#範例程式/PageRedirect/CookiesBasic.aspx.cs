using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class CookiesBasic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //儲存資料到Cookie
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtBlood.Text) && !string.IsNullOrEmpty(txtHobby.Text))
        {
            //加入Cookies集合
            //設定UserName的Cookie值
            Response.Cookies["Name"].Value = txtName.Text;
            //設定Cookie逾時作廢時間為1天
            Response.Cookies["Name"].Expires = DateTime.Now.AddDays(1);
            Response.Cookies["Blood"].Value = txtBlood.Text;
            Response.Cookies["Blood"].Expires = DateTime.Now.AddDays(1);
            Response.Cookies["Hobby"].Value = txtHobby.Text;
            Response.Cookies["Hobby"].Expires = DateTime.Now.AddDays(1);
            txtMsg.Text = "Cookie資料儲存成功！";
        }
        else
        {
            txtMsg.Text = "TextBox不得為空白或null";
        }
    }

    //讀取Cookie資料
    protected void btnRead_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["Name"] != null && Request.Cookies["Blood"] != null && Request.Cookies["Hobby"] != null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("姓名：" + Server.HtmlEncode(Request.Cookies["Name"].Value) + "<BR/>");
            sb.Append("血型：" + Server.HtmlEncode(Request.Cookies["Blood"].Value) + "<BR/>");
            sb.Append("興趣：" + Server.HtmlEncode(Request.Cookies["Hobby"].Value) + "<BR/>");
            txtMsg.Text = sb.ToString();
        }
        else
        {
            txtMsg.Text = "Cookie為null.";
        }
    }
}
