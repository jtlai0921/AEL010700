using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class fvCommandButton : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    //故取消刪除命令
    protected void fvEmp_ItemDeleting(object sender, FormViewDeleteEventArgs e)
	{
		e.Cancel=true;	
        WebMessageBox.MessageBox.Show("為防止誤刪Employee資料表，故取消刪除命令!");
	}

	protected void btnEdit_Click(object sender, EventArgs e)
	{
		WebMessageBox.MessageBox.Show("您按下了編輯按鈕");
	}

	protected void btnDelete_Click(object sender, EventArgs e)
	{
        WebMessageBox.MessageBox.Show("您按下了刪除按鈕");
	}

	protected void btnInsert_Click(object sender, ImageClickEventArgs e)
	{
        WebMessageBox.MessageBox.Show("您按下了新增按鈕");
	}

}
