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

public partial class TreeViewChecked : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	
	protected void btnMsg_Click(object sender, EventArgs e)
	{
	}

	//TreeView控制項的CheckBox狀態改變時所引發的事件
	protected void tvProduct_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
	{
		txtMsg.Text = "<ul>您選擇的電腦產品有：";

        //檢查Node節點是否被勾選
		foreach (TreeNode nodeChecked in tvProduct.CheckedNodes)
		{
            txtMsg.Text += "<li>" + nodeChecked.Text + "</li>";
		}

        txtMsg.Text += "</ul>";
	}

}
