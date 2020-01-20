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

public partial class MenuItemDataBound : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //資料繫結時所發生事件
    protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
    {
        switch (e.Item.Text)
        {
            case "INTEL處理器":
                e.Item.Text = "英代爾處理器";
                break;
            case "AMD處理器":
                e.Item.Text = "超微處理器";
                break;
        }
    }
}
