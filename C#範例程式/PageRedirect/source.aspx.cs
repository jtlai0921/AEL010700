using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class source : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //進行網頁導向切換，及使用者資料傳遞
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = "Name=" + Server.HtmlEncode(txtName.Text);
        string tel = "Tel=" + Server.HtmlEncode(txtTel.Text);
        string city = "City=" + Server.HtmlEncode(dwnCity.SelectedItem.Text);
        string param = name + "&" + tel + "&" + city;
        //使用Redirect方法
        Response.Redirect("target.aspx?"+param);
        //使用Transfer方法
        //Server.Transfer("target.aspx?" + param);
    }
}
