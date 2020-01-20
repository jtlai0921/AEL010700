Imports System.Data

Partial Class Albums
    Inherits System.Web.UI.Page

    Dim albumID As String = "1"
    Dim activePage As String = ""
    Dim drv As DataRowView = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '取得URL中QueryString的AlbumID代號
        albumID = Request.QueryString("AlbumID")

        '取得Active Page號碼
        activePage = IIf(IsNothing(Request.QueryString("Page")), "1", Request.QueryString("Page"))

        '檢查使用者是否通過身份驗證，才顯示這些控制項
        showControls()
    End Sub

    '如果使用者通過身份驗證，才顯示這些控制項
    Protected Sub showControls()
        If User.Identity.IsAuthenticated Then
            '登入後顯示
            txtAdmin.Visible = True
            txtUpload.Visible = True
        Else
            txtAdmin.Visible = False
            txtUpload.Visible = False
        End If
    End Sub



    Protected Sub sqlAlbums_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceStatusEventArgs) Handles sqlAlbums.Selected
        If e.AffectedRows >= 1 Then
            'Pager必須動態計算相本數
            addAlbumPager()
        End If
    End Sub

    '動態加入Pager分頁按鈕
    Protected Sub addAlbumPager()
        '計算所有相本數
        Dim albums As Decimal = New BLL().getAlbums()

        '第一頁
        Dim btnFirst As New ImageButton()
        btnFirst.ImageUrl = "~/Images/first.gif"
        btnFirst.PostBackUrl = String.Format("Albums.aspx?AlbumID={0}&Page={1}", albumID, 1)
        plPager.Controls.Add(btnFirst)

        '每個頁面最多有15照片，依此計算共有多少分頁
        Dim pages As Decimal
        Dim pageSize As Decimal = 15

        pages = albums / pageSize

        If albums <= 15 Then
            pages = 1
        Else
            If pages > Math.Truncate(pages) Then
                pages = Math.Truncate(pages) + 1
            Else
                pages = albums / pageSize
            End If
        End If

        '動態加入分頁
        For i As Integer = 1 To CInt(pages)
            Dim link As New LinkButton()
            link.ID = "link" + i.ToString()
            link.CssClass = "pager"

            '設定active page背景為紫色
            If i.ToString() = activePage Then
                link.BackColor = System.Drawing.Color.Purple
            End If

            link.Text = i.ToString()
            link.PostBackUrl = String.Format("Albums.aspx?AlbumID={0}&Page={1}", albumID, i)
            plPager.Controls.Add(link)
        Next

        '最末頁
        Dim blank As New Literal()
        blank.Text = " "
        plPager.Controls.Add(blank)
        Dim btnLast As New ImageButton()
        btnLast.ImageUrl = "~/Images/Last.gif"
        btnLast.PostBackUrl = String.Format("Albums.aspx?AlbumID={0}&Page={1}", albumID, pages)
        plPager.Controls.Add(btnLast)
    End Sub

    Protected Sub LoginStatus1_LoggedOut(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginStatus1.LoggedOut
        '登出時，將授權瀏覽密碼保護相簿取消
        Session("AllowAlbumID") = Nothing
    End Sub

    '比對DataList的資料繫結中，若相簿沒有封面照片的話，
    '則以預設的圖檔名稱取代
    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound
        Select Case e.Item.ItemType
            Case ListItemType.Item
                drv = CType(e.Item.DataItem, DataRowView)
                If String.IsNullOrEmpty(TryCast(drv("DefaultPhotoGUID"), String)) Then
                    drv("DefaultPhotoGUID") = "DefalutPic.png"
                    e.Item.DataBind()
                End If
            Case ListItemType.AlternatingItem
                drv = CType(e.Item.DataItem, DataRowView)
                If String.IsNullOrEmpty(TryCast(drv("DefaultPhotoGUID"), String)) Then
                    drv("DefaultPhotoGUID") = "DefalutPic.png"
                    e.Item.DataBind()
                End If
        End Select
    End Sub
End Class
