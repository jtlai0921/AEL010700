using System;

public partial class InputData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    //導向另一個網頁
    protected void btnOK_Click(object sender, EventArgs e)
    {
        //傳統寫法
        Response.Redirect("ShowData.aspx?ID=" + txtID.Text + "&Password=" + txtPassword.Text + "&Msg=" + txtMsg.Text);
        //使用字串參數的型式
        Response.Redirect(string.Format("ShowData.aspx?ID={0}&Password={1}&Msg={2}", txtID.Text, txtPassword.Text, txtMsg.Text));
    }
}
