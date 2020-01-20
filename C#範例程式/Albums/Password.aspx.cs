using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page 
{
    protected DataView dv = null;
    protected string albumID = null;
    protected string albumName = null;
    protected string url = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        //如果缺少AlbumID相片代號，則導回Albums.aspx網頁
        if (Request.QueryString["AlbumID"] == null)
        {
            Response.Redirect("~/Albums.aspx");
        }

        //檢查使用者是否通過身份驗證，才顯示這些控制項
        showControls();
    }

    //執行密碼查詢
    protected void btnPassword_Click(object sender, ImageClickEventArgs e)
    {
        txtMsg.Text = "";
        txtMsg.Visible = false;
        if (!string.IsNullOrEmpty(txtPassword.Text))
        {
            dv = sqlAlbumPwd.Select(DataSourceSelectArguments.Empty) as DataView;
            if (dv.Count>0)
            {
                //指定相簿名稱到Session中
                albumName=dv.Table.DataSet.Tables[0].Rows[0]["AlbumName"] as string;
                //導回呼叫的url網頁
                Response.Redirect(url);
            }
        }
        else
        {
            txtMsg.Text = "*密碼不得為空白!";
            txtMsg.Visible = true;
        }
    }


    //驗證密碼是否正確
    protected void sqlAlbumPwd_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        //如果等於1，表示密碼正確，並導回Photos.aspx或Browse.aspx網頁的url值
        if (e.AffectedRows == 1)
        {
            albumID = Request.QueryString["AlbumID"];
            Session["AllowAlbumID"] = albumID;
            string pageName = Request.QueryString["PageName"];
            switch (pageName)
            {
                case "Browse":
                    url = string.Format("Browse.aspx?PhotoGUID={0}", Request.QueryString["PhotoGUID"]);
                    break;
                case "Photos":
                    url = "Photos.aspx?AlbumID=" + albumID + "&Page=1";
                    break;
                default:
                    url = "Photos.aspx?AlbumID=" + albumID + "&Page=1";
                    break;
            }           
        }
        else
        {
            Session["AllowAlbumID"] = "Protected";
            txtMsg.Text = "*密碼錯誤!!!";
            txtMsg.Visible = true;
        }
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
