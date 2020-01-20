using System;

public partial class MyWebForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //顯示TextBox輸入文字資料
    protected void btnOK_Click(object sender, EventArgs e)
    {
        Response.Write("您輸入的文字是：" + txtMsg.Text);
    }
}
