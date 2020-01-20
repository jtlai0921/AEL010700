using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Photos : System.Web.UI.Page 
{
    private string albumID=null;
    private string rawUrl = "";
    private string activePage = "";

    public DataRowView drv = null;
    public int buttonID=0;

    protected void Page_Load(object sender, EventArgs e)
    {
        //取得URL中QueryString的AlbumID代號
        albumID = Request.QueryString["AlbumID"];
        txtAlbumName.Text = new BLL().getAlbumName(albumID);

        //如果AlbumID為Null，則導向錯誤網頁
        if (string.IsNullOrEmpty(albumID))
        {
            Response.Redirect("Error404.aspx");
        }

        //取得Active Page號碼
        activePage = Request.QueryString["Page"] == null ? "1" : Request.QueryString["Page"];


        //保存上一頁之資料
        //如果是由瀏覽器直接Bookmark，Request.UrlReferrer會沒有初始化，
        //以致會造成例外當掉，故需要Try..catch進行例外處理
        try
        {
            rawUrl = Request.UrlReferrer.AbsolutePath;
        }
        catch
        {
            rawUrl = "";
        }

        //如果是管理者，直接授權瀏覽之權限
        if (User.Identity.IsAuthenticated)
        {
            Session["AllowAlbumID"] = albumID;
        }

        //檢查相簿是否有設定保護
        checkPermission();


        //檢查使用者是否通過身份驗證，才顯示這些控制項
        showControls();
    }

    //檢查相簿是否有設定保護，若沒保護可直接觀看，有保護會導向密碼輸入頁
    protected void checkPermission()
    {
        //執行檢查相簿是否有設定保護
        if (Session["AllowAlbumID"] == null || Session["AllowAlbumID"].ToString() != albumID)
        {
            sqlProtect.Select(DataSourceSelectArguments.Empty);
        }

        //若允許閱許相簿的Session["AllowAlbumID"]仍為Protected保護狀態，
        //則導向密碼驗證網頁
        if (Session["AllowAlbumID"].ToString() == "Protected")
        {
            Response.Redirect(("Password.aspx?AlbumID=" + albumID));
        }
    }

    //檢查相簿是否有保護，若有保護則需要密碼才能觀看
    //SQL之過濾回傳條件是以Protection='False'為基準
    //可指定Session["AllowAlbumID"]之AlbumID值
    protected void sqlProtect_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        if (e.AffectedRows>=1)
        {
            //無保護相簿，指定可觀看之相簿ID
            Session["AllowAlbumID"] = albumID;
        }
        else
        {
            //查不到任何無保護相簿資料，所以相簿為保護狀態
            Session["AllowAlbumID"] = "Protected";
            Session["AlbumName"] = "";
        }
    }

    //登出時，將授權瀏覽密碼保護相簿取消
    protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
    {
        Session["AllowAlbumID"] = null;
        //Response.Redirect("Albums.aspx");
    }

    //
    protected void sqlPhotoData_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        if (e.AffectedRows >= 1)
        {
            //如果有相片的話，才加入分頁按鈕
            addPhotoPager();
        }
        else
        {
            imgNo.Visible = true;
            txtMsg.Visible = true;
            btnBack.Visible = true;
            txtAlbumName.Text = "";
            btnBack.PostBackUrl = rawUrl;
        }
    }


    //如果使用者通過身份驗證，才顯示這些控制項
    protected void showControls()
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


    protected void dlPhotos_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        switch (e.Item.ItemType)
        {
            case ListItemType.Item:
                if (User.Identity.IsAuthenticated)
                {
                    //顯示可預設圖片的Button
                    showButton(e.Item);
                }
                break;
            case ListItemType.AlternatingItem:
                if (User.Identity.IsAuthenticated)
                {
                    //顯示可預設圖片的Button
                    showButton(e.Item);
                } 
                break;
        }
    }


    //如果管理者登入，則顯示可預設圖片的Button，及編輯相片說明按鈕
    protected void showButton(DataListItem myItem)
    {
        if (User.Identity.IsAuthenticated)
        {
            Button myButton;

            for (int i = 0; i < myItem.Controls.Count; i++)
            {
                if (myItem.Controls[i].GetType().Name == "Button")
                {
                    myButton = (Button)myItem.Controls[i];
                    myButton.Visible = true;
                }
            }
        }
    }

    //設定為預設相片
    protected void btnDefault_Click(object sender, EventArgs e)
    {
        //預設相片名稱
        string fileName = ((Button)sender).CommandArgument;
        //將預設相片之名稱寫入到AlbumData資料表中
        if (!string.IsNullOrEmpty(albumID) && !string.IsNullOrEmpty(fileName))
        {
            new BLL().saveDefaultPic(albumID, fileName);
        }
    }

    //動態加入Photo的Pager控制項分頁按鈕
    public void addPhotoPager()
    {
        //計算所有相片數
        decimal photos = new BLL().getPhotos(albumID);
        decimal pageSize = 15;
        if (photos > pageSize)
        {
            //第一頁
            /** */
            ImageButton btnFirst = new ImageButton();
            btnFirst.ImageUrl = "~/Images/first.gif";
            string strUrl = "Photos.aspx?AlbumID={0}&Page={1}";
            btnFirst.PostBackUrl = string.Format(strUrl, albumID, 1);
            plPager.Controls.Add(btnFirst);

            //每個頁面最多有15照片，依此計算共有多少分頁
            decimal pages;
            pages = photos / pageSize;


            if (pages > Math.Truncate(pages))
            {
                pages = Math.Truncate(pages) + 1;
            }
            else
            {
                pages = photos / pageSize;
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
                link.PostBackUrl = string.Format(strUrl, albumID, i);
                plPager.Controls.Add(link);
            }

            //最末頁
            /** */
            Literal blank = new Literal();
            blank.Text = " ";
            plPager.Controls.Add(blank);
            ImageButton btnLast = new ImageButton();
            btnLast.ImageUrl = "~/Images/Last.gif";
            btnLast.PostBackUrl = string.Format("Photos.aspx?AlbumID={0}&Page={1}", albumID, pages);
            plPager.Controls.Add(btnLast);
        }
    }

    //進入DataList編輯模式
    protected void dlPhotos_EditCommand(object source, DataListCommandEventArgs e)
    {
        dlPhotos.EditItemIndex = e.Item.ItemIndex;
        dlPhotos.DataBind();
    }

    //更新DataList控制項的項目資料
    protected void dlPhotos_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        string photoGUID = ((Button)e.Item.FindControl("btnUpdate")).CommandArgument;
        string txtDesc = ((TextBox)e.Item.FindControl("txtDesc")).Text;
        sqlPhotoData.UpdateParameters["paramPhotoGUID"].DefaultValue = photoGUID;
        sqlPhotoData.UpdateParameters["paramDescription"].DefaultValue = txtDesc;
        sqlPhotoData.Update();
        dlPhotos.EditItemIndex = -1;
        dlPhotos.DataBind();
    }
}
