using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class ViewStateBasic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //儲存ViewState狀態資料
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtBlood.Text) && !string.IsNullOrEmpty(txtHobby.Text))
        {
            ViewState["Name"] = txtName.Text;
            ViewState["Blood"] = txtBlood.Text;
            ViewState["Hobby"]=txtHobby.Text;
            txtMsg.Text = "ViewState狀態儲存成功！";
        }
        else
        {
            txtMsg.Text = "TextBox不得為空白或null!";
        }
    }

    //讀取ViewStaten狀態資料
    protected void btnRead_Click(object sender, EventArgs e)
    {
        txtMsg.Text = "";
        if (ViewState["Name"] != null && ViewState["Blood"] != null && ViewState["Hobby"] != null)
        {
            txtMsg.Text = "ViewState狀態資料如下：<BR/>";
            txtMsg.Text += "姓名：" + ViewState["Name"] + "<BR/>";
            txtMsg.Text += "血型：" + ViewState["Blood"] + "<BR/>";
            txtMsg.Text += "興趣：" + ViewState["Hobby"] + "<BR/>";
        }
        else
        {
            txtMsg.Text = "ViewState狀態值為null";
        }
    }
}
