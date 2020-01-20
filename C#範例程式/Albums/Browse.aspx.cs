using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Browse : System.Web.UI.Page 
{
    protected string albumID = "";
    protected string albumName = null;
    protected string PhotoGUID = null;
    //主照片之Image控制項
    System.Web.UI.WebControls.Image imgHead = new System.Web.UI.WebControls.Image();
    System.Web.UI.WebControls.Literal txtHeadDesc = new Literal();
    protected int totalRows = 0;  //相簿之總筆數
    protected int currentIndex = 0; //主照片所在RowNumber，計全部照片數為計算基準

    protected string fileName = null;   //主照片之檔名
    protected string Desc = "";  //主照片之說明

    protected int offsetLength;   //導覽列相片長度
    protected int leftOffset;   //主相片之左側相片數（位移）
    private int rightOffset;  //主相片之右側相片數（位移）

    protected int counter = 1;

    public enum MoveType { First, Forward, Next, Last }; //移動的型態

    private void Page_Load(object sender, EventArgs e)
    {
        
        //取得相片之GUID
        PhotoGUID = Request.QueryString["PhotoGUID"] as string;
        if (string.IsNullOrEmpty(PhotoGUID))
        {
            //引發錯誤，導向例外網頁
            throw new Exception();
        }

        //查詢設定albumID
        albumID = new BLL().getAlbumID(PhotoGUID);

        //如果是管理者，直接授權瀏覽之權限
        if (User.Identity.IsAuthenticated)
        {
            Session["AllowAlbumID"] = albumID;
        }

        checkPermission();
        

        //計算相簿之Rows總筆數，及相關資料
        countRows();    

        //如果使用者通過身份驗證，才顯示這些控制項
        showControls();

    }

    //檢查相簿是否有設定保護，若沒保護可直接觀看，有保護會導向密碼輸入頁
    protected void checkPermission()
    {

        //若允許閱許相簿的Session["AllowAlbumID"]仍為Protected保護狀態，
        //則導向密碼驗證網頁
        if (Session["AllowAlbumID"] == null || Session["AllowAlbumID"].ToString() != albumID)
        {
            checkProtection();
        }

        if (Session["AllowAlbumID"].ToString() == "Protected")
        {
            string url = string.Format("Password.aspx?AlbumID={0}&PageName=Browse&PhotoGUID={1}", albumID, PhotoGUID);
            Response.Redirect(url);
        }

        //設定相簿名稱
        if (!string.IsNullOrEmpty(Session["AlbumName"] as string))
        {
            txtAlbumName.Text = Session["AlbumName"].ToString();
        }
    }

    protected void checkProtection()
    {
        //以PhotoGUID查詢相簿是否有保護，回傳值-1則有保護
        bool protection = true;   //保護狀態

        protection=new BLL().checkAlbumProtection(PhotoGUID);

        if (protection == true)
        {
            Session["AllowAlbumID"] = "Protected";
        }
        else
        {
            Session["AllowAlbumID"] = albumID;
        }
    }

    //計算相簿之Rows總筆數，及相關資料
    private void countRows()
    {
        if (string.IsNullOrEmpty(txtCurrentIndex.Text) && string.IsNullOrEmpty(txtTotalRows.Text))
        {
            if (!string.IsNullOrEmpty(Request.QueryString["PhotoGUID"]))
            {
                //計算相簿之Rows總筆數及相關資料，會回傳兩個查詢
                DataView dv = sqlRowsCount.Select(DataSourceSelectArguments.Empty) as DataView;
                if (dv != null)
                {
                    txtSeperator.Visible = true;
                    txtTotalRows.Text = dv.Table.DataSet.Tables[0].Rows[0]["TotalRows"].ToString();

                    //設定相簿名稱
                    albumName = Session["albumName"] as string;
                    if (!string.IsNullOrEmpty(albumName))
                    {
                        txtAlbumName.Text = string.Format("({0})",albumName);
                    }
                    else
                    {
                        txtAlbumName.Text = "";
                    }


                    txtCurrentIndex.Text = dv.Table.DataSet.Tables[1].Rows[0]["RowNumber"].ToString();
                    fileName = dv.Table.DataSet.Tables[1].Rows[0]["PhotoGUID"].ToString();
                    Desc = dv.Table.DataSet.Tables[1].Rows[0]["Description"].ToString();

                    //設定相簿名稱
                    albumID = dv.Table.DataSet.Tables[1].Rows[0]["albumID"].ToString();
                    if (!string.IsNullOrEmpty(albumID))
                    {
                        albumName = new BLL().getAlbumName(albumID);
                        if (!string.IsNullOrEmpty(albumName))
                        {
                            txtAlbumName.Text=string.Format("({0})",albumName);
                        }
                    }
         
                    //計算並設定主相片左右Offset值
                    indexOffset();
                }
            }
        }
    }

    //以目前主照片index索引為基準，計算左右需要取幾張照片之位移值
    private void indexOffset()
    {
        totalRows = Convert.ToInt16(txtTotalRows.Text);
        currentIndex = Convert.ToInt16(txtCurrentIndex.Text);
        //扣除主相片之導覽列相片長度
        if (totalRows >= 7)
        {
            offsetLength = 6;
        }
        else
        {
            offsetLength = totalRows - 1;
        }

        //計算主相片之左右相片位移
        if (currentIndex <= 3)
        {
            //如果主照片索引是靠近左側
            leftOffset = currentIndex - 1;
            rightOffset = offsetLength - leftOffset;
        }
        else if (totalRows - currentIndex <= 3)
        {
            //如果主照片索引是靠近右側
            rightOffset = totalRows - currentIndex;
            leftOffset = offsetLength - rightOffset;
        }
        else
        {
            //如果位居中間地帶，則左右皆為3
            leftOffset = 3;
            rightOffset = 3;
        }

        //設定主相片之左右位移值
        sqlPhotoData.SelectParameters["leftOffset"].DefaultValue = leftOffset.ToString();
        sqlPhotoData.SelectParameters["rightOffset"].DefaultValue = rightOffset.ToString();
    }


    //設定主相片之url
    protected void dlPhotos_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        //取得DataList Header中的Image控制項
        switch (e.Item.ItemType)
        {
            case ListItemType.Header:
                imgHead = (System.Web.UI.WebControls.Image)e.Item.FindControl("fullImage");
                txtHeadDesc = (System.Web.UI.WebControls.Literal)e.Item.FindControl("txtDesc");
                if (imgHead != null)
                {
                    imgHead.ImageUrl = String.Format("Photos/{0}", fileName);
                    txtHeadDesc.Text = Desc;
                }

                break;
            case ListItemType.Item:
                if (counter == leftOffset + 1)
                {
                    ImageButton imgActive = (ImageButton)e.Item.Controls[1];
                    imgActive.CssClass = "PhotoActive";
                }

                counter++;

                break;
            case ListItemType.AlternatingItem:
                if (counter == leftOffset + 1)
                {
                    ImageButton imgActive = (ImageButton)e.Item.Controls[1];

                    imgActive.CssClass = "PhotoActive";
                }
                counter++;
                break;
        }
    }


    //按下主照片之事件
    protected void fullImage_Click(object sender, ImageClickEventArgs e)
    {
        //主照片Index加1移動
        MovePhotoIndex(MoveType.Next);
        //由於MovePhotIndex方法有使SqlDataSource重新執行Select命令,
        //所以會接著觸發DataList控制項之ItemDataBound事件,
        //由ItemDataBound事件中再設定新的Image url及Description
    }

    //移動照片Index索引,移動方式根據其移動型態而定
    protected void MovePhotoIndex(MoveType moveType)
    {
        //取得目前主照片之Index索引值，還有Rows總筆數
        currentIndex = Convert.ToInt16(txtCurrentIndex.Text);
        totalRows = Convert.ToInt16(txtTotalRows.Text);

        switch (moveType)
        {
            case MoveType.First:
                currentIndex = 1;
                break;
            case MoveType.Forward:
                if (currentIndex > 1 )
                {
                    currentIndex--;
                }
                break;
            case MoveType.Next:
                //如果totalRows >7，主照片Index才有往下移動1個的必要
                //且currentIndex必須比totalRows總筆數小於1
                if (currentIndex < totalRows)
                {
                    currentIndex++;
                }

                break;
            case MoveType.Last:
                currentIndex = totalRows;
                break;
        }

        //根據新的Index值，設定到Label控制項上
        txtCurrentIndex.Text = currentIndex.ToString();

        indexOffset();  //根據主照片計算左右之相片數位移

        //照片導覽列
        DataView dv = sqlPhotoData.Select(DataSourceSelectArguments.Empty) as DataView;

        if (dv != null)
        {
            //leftOffset就是dv七筆資料中之主照片索引
            fileName = dv.Table.DataSet.Tables[0].Rows[leftOffset]["PhotoGUID"].ToString();
            Desc = dv.Table.DataSet.Tables[0].Rows[leftOffset]["Description"].ToString();
        }
    }

    //點選導覽列相片時，必須重新進行導向
    protected void btnNavi_Click(object sender, ImageClickEventArgs e)
    {
        string photoGuid = (((ImageButton)sender).ImageUrl).Remove(0, 7);
        Response.Redirect("Browse.aspx?PhotoGUID=" + photoGuid);
    }

    //點選第一張按鈕時
    protected void btnFirst_Click(object sender, ImageClickEventArgs e)
    {
        MovePhotoIndex(MoveType.First);
    }

    //點選前一張按鈕時
    protected void btnPrevious_Click(object sender, ImageClickEventArgs e)
    {
        MovePhotoIndex(MoveType.Forward);
    }

    //點選下一張按鈕時
    protected void btnNext_Click(object sender, ImageClickEventArgs e)
    {
        MovePhotoIndex(MoveType.Next);
    }

    //點選最末張按鈕時
    protected void btnLast_Click(object sender, ImageClickEventArgs e)
    {
        MovePhotoIndex(MoveType.Last);
    }
    
    //回相片瀏覽
    protected void btnAlbum_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Photos.aspx?AlbumID=" + Session["AllowAlbumID"]);
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
    
}
