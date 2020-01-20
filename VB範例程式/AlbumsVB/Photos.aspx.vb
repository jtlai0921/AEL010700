Imports System.Data

Partial Class Photos
    Inherits System.Web.UI.Page

    Dim albumID As String = Nothing
    Dim rawUrl As String = ""
    Dim activePage As String = ""

    Dim drv As DataRowView = Nothing
    Dim buttonID As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '取得URL中QueryString的AlbumID代號
        albumID = Request.QueryString("AlbumID")
        txtAlbumName.Text = New BLL().getAlbumName(albumID)

        '如果AlbumID為Null，則導向錯誤網頁
        If String.IsNullOrEmpty(albumID) Then
            Response.Redirect("Error404.aspx")
        End If

        '取得Active Page號碼
        activePage = IIf(Request.QueryString("Page") = Nothing, "1", Request.QueryString("Page"))

        '保存上一頁之資料
        '如果是由瀏覽器直接Bookmark，Request.UrlReferrer會沒有初始化，
        '以致會造成例外當掉，故需要Try..catch進行例外處理
        Try
            rawUrl = Request.UrlReferrer.AbsolutePath
        Catch ex As Exception
            rawUrl = ""
        End Try

        '如果是管理者，直接授權瀏覽之權限
        If User.Identity.IsAuthenticated Then
            Session("AllowAlbumID") = albumID
        Else
            If Session("AllowAlbumID") = Nothing Then
                Session("AllowAlbumID") = ""
            End If
        End If

        '檢查相簿是否有設定保護
        checkPermission()

        '檢查使用者是否通過身份驗證，才顯示這些控制項
        showControls()
    End Sub

    '檢查相簿是否有設定保護，若沒保護可直接觀看，有保護會導向密碼輸入頁
    Protected Sub checkPermission()
        If Session("AllowAlbumID") = Nothing Or Session("AllowAlbumID").ToString() <> albumID Then
            sqlProtect.Select(DataSourceSelectArguments.Empty)
        End If

        '若允許閱許相簿的Session("AllowAlbumID")仍為Protected保護狀態
        '則導向密碼驗證網頁
        If Session("AllowAlbumID").ToString() = "Protected" Then
            Response.Redirect(("Password.aspx?AlbumID=" + albumID))
        End If
    End Sub

    '檢查相簿是否有保護，若有保護則需要密碼才能觀看
    'SQL之過濾回傳條件是以Protection='False'為基準
    '可指定Session("AllowAlbumID")之AlbumID值
    Protected Sub sqlProtect_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceStatusEventArgs) Handles sqlProtect.Selected
        If e.AffectedRows >= 1 Then
            '無保護相簿，指定可觀看之相簿ID
            Session("AllowAlbumID") = albumID
        Else
            '查不到任何無保護相簿資料，所以相簿為保護狀態
            Session("AllowAlbumID") = "Protected"
            Session("AlbumName") = ""
        End If
    End Sub

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

    '登出時，將授權瀏覽密碼保護相簿取消
    Protected Sub LoginStatus1_LoggedOut(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginStatus1.LoggedOut
        Session("AllowAlbumID") = Nothing
    End Sub

    Protected Sub sqlPhotoData_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceStatusEventArgs) Handles sqlPhotoData.Selected
        If e.AffectedRows >= 1 Then
            '如果有相片的話，才加入分頁按鈕
            addPhotoPager()
        Else
            imgNo.Visible = True
            txtMsg.Visible = True
            btnBack.Visible = True
            txtAlbumName.Text = ""
            btnBack.PostBackUrl = rawUrl
        End If
    End Sub

    Protected Sub dlPhotos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlPhotos.ItemDataBound
        Select Case e.Item.ItemType
            Case ListItemType.Item
                If User.Identity.IsAuthenticated Then
                    '顯示可預設圖片的Button
                    showButton(e.Item)
                End If
            Case ListItemType.AlternatingItem
                If User.Identity.IsAuthenticated Then
                    '顯示可預設圖片的Button
                    showButton(e.Item)
                End If
        End Select
    End Sub

    '如果管理者登入，則顯示可預設圖片的Button，及編輯相片說明按鈕
    Protected Sub showButton(ByVal myItem As DataListItem)
        If User.Identity.IsAuthenticated Then
            Dim myButton As Button = Nothing
            For i = 0 To myItem.Controls.Count - 1
                If myItem.Controls(i).GetType().Name = "Button" Then
                    myButton = CType(myItem.Controls(i), Button)
                    myButton.Visible = True
                End If
            Next
        End If
    End Sub

    '設定為預設相片
    Protected Sub btnDefault_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '預設相片名稱
        Dim fileName As String = CType(sender, Button).CommandArgument
        '將預設相片之名稱寫入到AlbumData資料表中
        If (Not String.IsNullOrEmpty(albumID) And Not String.IsNullOrEmpty(fileName)) Then
            Dim myBll As New BLL()
            myBll.saveDefaultPic(albumID, fileName)
        End If
    End Sub

    '動態加入Photo的Pager控制項分頁按鈕
    Protected Sub addPhotoPager()
        '計算所有相片數
        Dim photos As Decimal = New BLL().getPhotos(albumID)
        Dim pageSize As Decimal = 15

        If photos > pageSize Then
            '第一頁
            Dim btnFirst As New ImageButton()
            btnFirst.ImageUrl = "~/Images/first.gif"
            Dim strUrl As String = "Photos.aspx?AlbumID={0}&Page={1}"
            btnFirst.PostBackUrl = String.Format(strUrl, albumID, 1)
            plPager.Controls.Add(btnFirst)

            '每個頁面最多有15照片，依此計算共有多少分頁
            Dim pages As Decimal = photos / pageSize

            If pages > Math.Truncate(pages) Then
                pages = Math.Truncate(pages) + 1
            Else
                pages = photos / pageSize
            End If

            For i As Integer = 1 To CInt(pages)
                Dim link As New LinkButton()
                link.ID = "link" & i
                link.CssClass = "pager"

                '設定active page背景為紫色
                If i.ToString() = activePage Then
                    link.BackColor = System.Drawing.Color.Purple
                End If

                link.Text = i.ToString()
                link.PostBackUrl = String.Format(strUrl, albumID, i)
                plPager.Controls.Add(link)
            Next

            '最末頁
            Dim blank As New Literal()
            blank.Text = " "
            plPager.Controls.Add(blank)
            Dim btnLast As New ImageButton()
            btnLast.ImageUrl = "~/Images/Last.gif"
            btnLast.PostBackUrl = String.Format("Photos.aspx?AlbumID={0}&Page={1}", albumID, pages)
            plPager.Controls.Add(btnLast)
        End If
    End Sub

    '進入DataList編輯模式
    Protected Sub dlPhotos_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlPhotos.EditCommand
        dlPhotos.EditItemIndex = e.Item.ItemIndex
        dlPhotos.DataBind()
    End Sub

    '更新DataList控制項的項目資料
    Protected Sub dlPhotos_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlPhotos.UpdateCommand
        Dim photoGUID As String = CType(e.Item.FindControl("btnUpdate"), Button).CommandArgument
        Dim txtDesc As String = CType(e.Item.FindControl("txtDesc"), TextBox).Text
        sqlPhotoData.UpdateParameters("paramPhotoGUID").DefaultValue = photoGUID
        sqlPhotoData.UpdateParameters("paramDescription").DefaultValue = txtDesc
        sqlPhotoData.Update()
        dlPhotos.EditItemIndex = -1
        dlPhotos.DataBind()
    End Sub
End Class
