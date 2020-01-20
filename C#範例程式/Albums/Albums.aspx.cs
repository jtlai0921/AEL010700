using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Albums : System.Web.UI.Page 
{
    private string albumID = "1";
    private string activePage = "";
    private DataRowView drv = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        //取得URL中QueryString的AlbumID代號
        albumID = Request.QueryString["AlbumID"];

        //取得Active Page號碼
        activePage = Request.QueryString["Page"] == null ? "1" : Request.QueryString["Page"];

        //檢查使用者是否通過身份驗證，才顯示這些控制項
        showControls();

    }


    protected void sqlAlbums_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        if (e.AffectedRows >= 1)
        {
            //Pager必須動態計算相本數
            addAlbumPager();
        }
    }


    //動態加入Pager分頁按鈕
    protected void addAlbumPager()
    {
        //計算所有相本數
        decimal albums = new BLL().getAlbums();

        //第一頁
        ImageButton btnFirst = new ImageButton();
        btnFirst.ImageUrl = "~/Images/first.gif";
        btnFirst.PostBackUrl = string.Format("Albums.aspx?AlbumID={0}&Page={1}", albumID, 1);
        plPager.Controls.Add(btnFirst);

        //每個頁面最多有15照片，依此計算共有多少分頁
        decimal pages;
        decimal pageSize = 15;

        pages = albums / pageSize;

        if (albums <= 15)
        {
            pages = 1;
        }
        else
        {
            if (pages > Math.Truncate(pages))
            {
                pages = Math.Truncate(pages) + 1;
            }
            else
            {
                pages = albums / pageSize;
            }
        }

        //動態加入分頁
        for (int i = 1; i <= pages; i++)
        {
            LinkButton link = new LinkButton();
            link.ID = "link" + i;
            link.CssClass = "pager";
            //設定active page背景為紫色
            if (i.ToString() == activePage)
            {
                link.BackColor = System.Drawing.Color.Purple;
            }
            link.Text = i.ToString();
            link.PostBackUrl = string.Format("Albums.aspx?AlbumID={0}&Page={1}", albumID, i);
            plPager.Controls.Add(link);
        }

        //最末頁
        /** */
        Literal blank = new Literal();
        blank.Text = " ";
        plPager.Controls.Add(blank);
        ImageButton btnLast = new ImageButton();
        btnLast.ImageUrl = "~/Images/Last.gif";
        btnLast.PostBackUrl = string.Format("Albums.aspx?AlbumID={0}&Page={1}", albumID, pages);
        plPager.Controls.Add(btnLast);
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

    //比對DataList的資料繫結中，若相簿沒有封面照片的話，
    //則以預設的圖檔名稱取代
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        switch(e.Item.ItemType)
        {
            case ListItemType.Item:
                drv = (DataRowView)e.Item.DataItem;
                if (string.IsNullOrEmpty(drv["DefaultPhotoGUID"] as string))
                {
                    drv["DefaultPhotoGUID"] = "DefalutPic.png";
                    e.Item.DataBind();
                }
                break;
            case ListItemType.AlternatingItem:
                drv = (DataRowView)e.Item.DataItem;
                if (string.IsNullOrEmpty(drv["DefaultPhotoGUID"] as string))
                {
                    drv["DefaultPhotoGUID"] = "DefalutPic.png";
                    e.Item.DataBind();
                } 
                break;
        }

        /*或是你可以這樣寫更精簡
        switch (e.Item.ItemType)
        {
            case ListItemType.Item:
            case ListItemType.AlternatingItem:
                drv = (DataRowView)e.Item.DataItem;
                if (string.IsNullOrEmpty(drv["DefaultPhotoGUID"] as string))
                {
                    drv["DefaultPhotoGUID"] = "DefalutPic.png";
                    e.Item.DataBind();
                }
                break;
        }
         * */
    }
}
