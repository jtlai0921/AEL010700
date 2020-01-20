using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ErrorPage : System.Web.UI.Page
{
    private void Page_Error(object sender, EventArgs e)
    {
        //取得Server最後一個錯誤訊息
        if (Server.GetLastError() != null)
        {
            Exception ex = Server.GetLastError();
            Response.Write(ex.ToString());
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //檢查使用者是否通過身份驗證，才顯示這些控制項
        showControls();
    }

    //登出時，將授權瀏覽密碼保護相簿取消
    protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
    {
        Session["AllowAlbumID"] = null;
    }

    //如果使用者通過身份驗證，才顯示這些控制項
    private void showControls()
    {
        if (User.Identity.IsAuthenticated)
        {
            //登入後顯示
            txtAdmin.Visible = true;
            txtUpload.Visible = true;
        }
        else
        {
            txtAdmin.Visible = false;
            txtUpload.Visible = false;
        }
    }
}
