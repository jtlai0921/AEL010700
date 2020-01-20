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

public partial class TreeViewExpanded : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


	//摺疊TreeNode節點
	protected void tvProduct_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
	{
		if (e.Node.Expanded == false)
		{
			WebMessageBox.MessageBox.Show("Hi...您摺疊了" + e.Node.Text + "節點！");
		}
	}

	//展開TreeNode節點
	protected void tvProduct_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
	{
		if (IsPostBack)
		{
			if (e.Node.Expanded==true)
			{
                WebMessageBox.MessageBox.Show("Hi...您展開了" + e.Node.Text + "節點！");
			}
		}
	}
}
