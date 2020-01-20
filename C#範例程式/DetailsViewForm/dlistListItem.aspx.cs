using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dlistListItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	//讀取DataList資料項目
	protected void dlEmployees_ItemDataBound(object sender, DataListItemEventArgs e)
	{
		string txtEmpInfo;
		switch(e.Item.ItemType)
		{
			case ListItemType.Header:
				dlEmployees.HeaderStyle.BackColor = Color.Red;
				break;
			case ListItemType.Item:
				txtEmpInfo = "";
				txtEmpInfo += (((LiteralControl)e.Item.Controls[0]).Text);
				txtEmpInfo += (((Label)e.Item.Controls[1]).Text) + "：";
				txtEmpInfo += (((Label)e.Item.Controls[3]).Text) + "  ";
				txtEmpInfo += (((Label)e.Item.Controls[5]).Text) + ", ";
				txtEmpInfo += (((Label)e.Item.Controls[7]).Text) + ", ";
				txtEmpInfo += (((Label)e.Item.Controls[9]).Text) ;
				Response.Write(txtEmpInfo + "<br/>");  //顯示DataList中Item資料內容
				break;
			case ListItemType.AlternatingItem:
				txtEmpInfo = "";
				txtEmpInfo += (((LiteralControl)e.Item.Controls[0]).Text);
				txtEmpInfo += ((Label)e.Item.FindControl("txtEmployeeID")).Text + "： ";
				txtEmpInfo += ((Label)e.Item.FindControl("txtLastName")).Text + " ";
				txtEmpInfo += ((Label)e.Item.FindControl("txtFirstName")).Text + " ";
				txtEmpInfo += ((Label)e.Item.FindControl("txtCity")).Text + ", ";
				txtEmpInfo += ((Label)e.Item.FindControl("txtCountry")).Text + " ";
				Response.Write(txtEmpInfo + "<br/>");  //顯示DataList中Item資料內容
				break;
			case ListItemType.Footer:
				dlEmployees.FooterStyle.BackColor = Color.LightBlue;
				break;
		}
	}
}
