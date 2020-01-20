using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class CookiesAdvanced : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //儲存資料到Cookie
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtBlood.Text) && !string.IsNullOrEmpty(txtHobby.Text))
        {
            //單一Cookie使用SubKey加入多重Key-Value資料值
            Response.Cookies["UserInfo"]["Name"] = txtName.Text;
            Response.Cookies["UserInfo"]["Blood"] = txtBlood.Text;
            Response.Cookies["UserInfo"]["Hobby"] = txtHobby.Text;
            Response.Cookies["UserInfo"].Expires = DateTime.Now.AddDays(1);
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
        if (Request.Cookies["UserInfo"] != null)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("姓名：" + Server.HtmlEncode(Request.Cookies["UserInfo"]["Name"]) + "<BR/>");
            sb.Append("血型：" + Server.HtmlEncode(Request.Cookies["UserInfo"]["Blood"]) + "<BR/>");
            sb.Append("興趣：" + Server.HtmlEncode(Request.Cookies["UserInfo"]["Hobby"]) + "<BR/>");

            /*另一種讀取的語法
            sb.Append("Name：" + Server.HtmlEncode(Request.Cookies["UserInfo"].Values["Name"]) + "<BR/>");
            sb.Append("Blood：" + Server.HtmlEncode(Request.Cookies["UserInfo"].Values["Blood"]) + "<BR/>");
            sb.Append("Hobby：" + Server.HtmlEncode(Request.Cookies["UserInfo"].Values["Hobby"]) + "<BR/>");
             * */
            
            txtMsg.Text = sb.ToString();

            //顯示單一Cookie中所有的Key-Value資料值
            //txtMsg.Text += "<BR/>" + Request.Cookies["UserInfo"].Value;
        }
        else
        {
            txtMsg.Text = "Cookie為null";
        }
    }
}
