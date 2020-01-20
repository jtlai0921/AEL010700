using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class HttpCookieObject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //儲存資料到Cookie
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtBlood.Text) && !string.IsNullOrEmpty(txtHobby.Text))
        {
            //以HttpCookie加入與儲存Cookie資料
            HttpCookie userCookie = new HttpCookie("userInfo");
            userCookie.Name = "userInfo";
            userCookie.Values["Name"] = txtName.Text;
            userCookie.Values["Blood"] = txtBlood.Text;
            userCookie.Values["Hobby"] = txtHobby.Text;
            userCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(userCookie);

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
        //讀取userInfo的Cookies集合
        HttpCookie userCookies = Request.Cookies["userInfo"];

        if (userCookies != null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("姓名：" + Server.HtmlEncode(userCookies["Name"]) + "<BR/>");
            sb.Append("血型：" + Server.HtmlEncode(userCookies["Blood"]) + "<BR/>");
            sb.Append("興趣：" + Server.HtmlEncode(userCookies["Hobby"]) + "<BR/>");
            txtMsg.Text = sb.ToString();
        }
        else
        {
            txtMsg.Text = "Cookie為null";
        }
    }

    //讀取Cookies集合中的資料
    protected void btnReadAll_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        HttpCookieCollection cookies = Request.Cookies; //取得Cookies集合

        //以迴圈讀取HttpCookieCollection物件中的Cookis集合
        for (int i = 0; i < cookies.Count; i++)
        {
            sb.Append("Name：" + cookies[i].Name + "<BR/>");
            sb.Append("Value：" + cookies[i].Value + "<BR/>");
            sb.Append("Expires：" + cookies[i].Expires.ToLocalTime() + "<BR/><BR/>");
        }

        txtMsg.Text = sb.ToString();
    }
}
