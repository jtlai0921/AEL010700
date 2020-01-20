using System;
using System.Web.UI.WebControls;

/// <summary>
/// PageUtility 的摘要描述
/// </summary>
public class PageUtility
{
	public PageUtility()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    /// <summary>
    /// 動態加入Pager控制項分頁按鈕
    /// </summary>
    /// <param name="plPager">Page控制項</param>
    /// <param name="albumID">相簿代號</param>
    /// <param name="activePage">Active Page代號</param>
    #region 動態加入Album的Pager控制項分頁按鈕
    public void addAlbumPager(Panel plPager, string albumID, string activePage, string apName)
    {
        //第一頁
        /** */
        ImageButton btnFirst = new ImageButton();
        btnFirst.ImageUrl = "~/Images/first.gif";
        string strUrl = apName + "?AlbumID={0}&Page={1}";
        btnFirst.PostBackUrl = string.Format(strUrl, albumID, 1);
        plPager.Controls.Add(btnFirst);

        //計算所有相本數
        decimal albums = new BLL().getAlbums();
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
        btnLast.PostBackUrl = string.Format("Albums.aspx?AlbumID={0}&Page={1}", albumID, pages);
        plPager.Controls.Add(btnLast);
    }
    #endregion

    //動態加入Photo的Pager控制項分頁按鈕
    public void addPhotoPager(Panel plPager, string albumID, string activePage, string apName)
    {
        //第一頁
        /** */
        ImageButton btnFirst = new ImageButton();
        btnFirst.ImageUrl = "~/Images/first.gif";
        string strUrl = apName + "?AlbumID={0}&Page={1}";
        btnFirst.PostBackUrl = string.Format(strUrl, albumID, 1);
        plPager.Controls.Add(btnFirst);

        //計算所有相片數
        decimal photos = new BLL().getPhotos(albumID);

        //每個頁面最多有15照片，依此計算共有多少分頁
        decimal pages;
        decimal pageSize = 15;

        pages = photos / pageSize;

        if (photos <= 15)
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
                pages = photos / pageSize;
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
