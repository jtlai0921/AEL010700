using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dvBasic : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //取消刪除資料
    protected void dvEmps_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        e.Cancel = true;
        WebMessageBox.MessageBox.Show("已觸發刪除命令，但為確保原始資料故取消刪除命令！");
    }
}

