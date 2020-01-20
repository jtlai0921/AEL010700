using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CommandField : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //取消刪除資料列
    protected void gvProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        e.Cancel = true;    //取消資料列刪除
        WebMessageBox.MessageBox.Show("資料列刪除取消!");
    }
}
