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

public partial class INTEL : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    //ItemCreated事件
    protected void SiteMapPath1_ItemCreated(object sender, SiteMapNodeItemEventArgs e)
    {
        if (e.Item.ItemType.ToString() == SiteMapNodeItemType.Current.ToString())
        {
            switch (e.Item.SiteMapNode.Description)
            {
                case "INTEL":
                    txtMsg.Text = "買" + e.Item.SiteMapNode.Title + "就可進行國外旅遊抽獎";
                    break;
                case "AMD":
                    txtMsg.Text = e.Item.SiteMapNode.Title + "正在進行降價25%大促銷";
                    break;
            }
        }
    }
}
