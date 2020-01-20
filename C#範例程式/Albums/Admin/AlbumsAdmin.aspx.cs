using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AlbumsAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    //編輯相簿
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        gvAlbums.DataBind();
    }
    //新增相簿
    protected void btnInsert_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }

    //編輯相片
    protected void btnEditPhotos_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        gvPhotos.DataBind();
    }

    //登出
    protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
    {
        Session["AllowAlbumID"] = null;
        Response.Redirect("~/Albums.aspx");
    }

    protected void dvAlbum_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        /*
        if (e.AffectedRows >= 1)
        {
            alert("成功!");
        }
        else
        {
            alert("失敗!");
        }
        **/
    }

    //執行新增
    protected void btnInsertDetail_Click(object sender, EventArgs e)
    {
            sqlDetail.Insert();
    }

    //刪除資料列
    protected void gvAlbums_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //預設為取消
        //e.Cancel = true;
    }

    protected void gvAlbums_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        gvAlbums.DataBind();
        MultiView1.DataBind();
    }

    //顯示訊息
    protected void alert(string Status)
    {
        string alert = "<script>alert('{0}')</script>";
        Literal txtMsg = new Literal();
        txtMsg.Text = string.Format(alert, Status);
        Page.Form.Controls.Add(txtMsg);
    }

}
