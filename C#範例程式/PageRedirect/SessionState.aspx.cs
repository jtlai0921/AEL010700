using System;
using System.Web.UI;

public partial class SessionState : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    //儲存Session狀態資料
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtTel.Text))
        {
            Session["Name"] = txtName.Text;
            Session["Tel"] = txtTel.Text;
            txtMsg.Text = "Session狀態儲存成功！";
        }
        else
        {
            txtMsg.Text = "不得為空白或null!";
        }
    }

    //讀取Session狀態資料
    protected void btnRead_Click(object sender, EventArgs e)
    {
        txtMsg.Text = "";
        if (Session["Name"] != null && Session["Tel"] != null)
        {
            txtMsg.Text = "Session狀態資料如下：<BR/>";
            txtMsg.Text += "姓名：" + Session["Name"] + "<BR/>";
            txtMsg.Text += "Tel：" + Session["Tel"];
        }
        else
        {
            txtMsg.Text = "Session狀態值為null";
        }
    }
}
