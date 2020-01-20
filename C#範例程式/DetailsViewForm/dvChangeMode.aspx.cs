using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dvChangeMode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //將DetailsView變換為Edit模式
            dvEmp.ChangeMode(DetailsViewMode.Edit);
        }
    }

    //檢查分頁功能若為編輯模式，則不准換頁
    protected void dvEmp_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {
        //判斷DetailsView目前的模式是否為Edit
        if (dvEmp.CurrentMode == DetailsViewMode.Edit)
        {
            e.Cancel = true;    //取消換頁
            WebMessageBox.MessageBox.Show("編輯模式下禁止換頁！");
        }
    }

    //取消刪除資料
    protected void dvEmp_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        e.Cancel = true;
        WebMessageBox.MessageBox.Show("已觸發刪除命令，但為確保原始資料故取消刪除命令！");
    }
}

