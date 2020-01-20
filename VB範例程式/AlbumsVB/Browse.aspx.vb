Imports System.Data

Partial Class Browse
    Inherits System.Web.UI.Page

    Dim albumID As String = ""
    Dim albumName As String = Nothing
    Dim PhotoGUID As String = Nothing

    '主照片之Image控制項
    Dim imgHead As New Image()
    Dim txtHeadDesc As New Literal()
    Dim totalRows As Integer = 0 '相簿之總筆數
    '主照片所在RowNumber，計全部照片數為計算基準
    Dim currentIndex As Integer = 0

    Dim fileName As String = Nothing    '主照片之檔名
    Dim Desc As String = "" '主照片之說明

    Dim offsetLength As Integer '導覽列相片長度
    Dim leftOffset As Integer '主相片之左側相片數（位移）
    Dim rightOffset As Integer '主相片之右側相片數（位移）

    Dim counter As Integer = 1

    Public Enum MoveType
        First
        Forward
        Nxt
        Last
    End Enum

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '取得相片之GUID
        PhotoGUID = TryCast(Request.QueryString("PhotoGUID"), String)

        If String.IsNullOrEmpty(PhotoGUID) Then
            '引發錯誤，導向例外網頁
            Throw New Exception()
        End If

        '查詢設定albumID
        albumID = New BLL().getAlbumID(PhotoGUID)

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

        '計算相簿之Rows總筆數，及相關資料
        countRows()

        '檢查使用者是否通過身份驗證，才顯示這些控制項
        showControls()
    End Sub

    '檢查相簿是否有設定保護，若沒保護可直接觀看，有保護會導向密碼輸入頁
    Protected Sub checkPermission()
        '若允許閱許相簿的Session("AllowAlbumID")仍為Protected保護狀態，
        '則導向密碼驗證網頁
        If Session("AllowAlbumID") = Nothing Or Session("AllowAlbumID").ToString() <> albumID Then
            checkProtection()
        End If

        If Session("AllowAlbumID").ToString() = "Protected" Then
            Dim url = String.Format("Password.aspx?AlbumID={0}&PageName=Browse&PhotoGUID={1}", albumID, PhotoGUID)
            Response.Redirect(url)
        End If

        '設定相簿名稱
        If Not String.IsNullOrEmpty(TryCast(Session("AlbumName"), String)) Then
            txtAlbumName.Text = Session("AlbumName").ToString()
        End If
    End Sub

    Protected Sub checkProtection()
        '以PhotoGUID查詢相簿是否有保護，回傳值-1則有保護
        Dim protection As Boolean = True    '保護狀態

        protection = New BLL().checkAlbumProtection(PhotoGUID)

        If protection = True Then
            Session("AllowAlbumID") = "Protected"
        Else
            Session("AllowAlbumID") = albumID
        End If
    End Sub

    '計算相簿之Rows總筆數，及相關資料
    Protected Sub countRows()
        If String.IsNullOrEmpty(txtCurrentIndex.Text) And String.IsNullOrEmpty(txtTotalRows.Text) Then
            If Not String.IsNullOrEmpty(Request.QueryString("PhotoGUID")) Then
                '計算相簿之Rows總筆數及相關資料，會回傳兩個查詢
                Dim dv As DataView = TryCast(sqlRowsCount.Select(DataSourceSelectArguments.Empty), DataView)
                If Not IsNothing(dv) Then
                    txtSeperator.Visible = True
                    txtTotalRows.Text = dv.Table.DataSet.Tables(0).Rows(0)("TotalRows").ToString()

                    '設定相簿名稱
                    albumName = TryCast(Session("albumName"), String)

                    If Not String.IsNullOrEmpty(albumName) Then
                        txtAlbumName.Text = String.Format("({0})", albumName)
                    Else
                        txtAlbumName.Text = ""
                    End If

                    txtCurrentIndex.Text = dv.Table.DataSet.Tables(1).Rows(0)("RowNumber").ToString()
                    fileName = dv.Table.DataSet.Tables(1).Rows(0)("PhotoGUID").ToString()
                    Desc = dv.Table.DataSet.Tables(1).Rows(0)("Description").ToString()

                    '設定相簿名稱
                    albumID = dv.Table.DataSet.Tables(1).Rows(0)("albumID").ToString()
                    If Not String.IsNullOrEmpty(albumID) Then
                        albumName = New BLL().getAlbumName(albumID)
                        If Not String.IsNullOrEmpty(albumName) Then
                            txtAlbumName.Text = String.Format("({0})", albumName)
                        End If
                    End If

                    '計算並設定主相片左右Offset值
                    indexOffset()
                End If
            End If
        End If
    End Sub

    '以目前主照片index索引為基準，計算左右需要取幾張照片之位移值
    Protected Sub indexOffset()
        totalRows = Convert.ToInt16(txtTotalRows.Text)
        currentIndex = Convert.ToInt16(txtCurrentIndex.Text)

        '扣除主相片之導覽列相片長度
        If totalRows >= 7 Then
            offsetLength = 6
        Else
            offsetLength = totalRows - 1
        End If

        '計算主相片之左右相片位移
        If currentIndex <= 3 Then
            '如果主照片索引是靠近左側
            leftOffset = currentIndex - 1
            rightOffset = offsetLength - leftOffset
        ElseIf totalRows - currentIndex <= 3 Then
            '如果主照片索引是靠近右側
            rightOffset = totalRows - currentIndex
            leftOffset = offsetLength - rightOffset
        Else
            '如果位居中間地帶，則左右皆為3
            leftOffset = 3
            rightOffset = 3
        End If

        '設定主相片之左右位移值
        sqlPhotoData.SelectParameters("leftOffset").DefaultValue = leftOffset.ToString()
        sqlPhotoData.SelectParameters("rightOffset").DefaultValue = rightOffset.ToString()

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

    '設定主相片之url
    Protected Sub dlPhotos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlPhotos.ItemDataBound
        '取得DataList Header中的Image控制項
        Select Case e.Item.ItemType
            Case ListItemType.Header
                imgHead = CType(e.Item.FindControl("fullImage"), Image)
                txtHeadDesc = CType(e.Item.FindControl("txtDesc"), Literal)
                If imgHead IsNot Nothing Then
                    imgHead.ImageUrl = String.Format("Photos/{0}", fileName)
                    txtHeadDesc.Text = Desc
                End If
            Case ListItemType.Item
                If counter = leftOffset + 1 Then
                    Dim imgActive As ImageButton = CType(e.Item.Controls(1), ImageButton)
                    imgActive.CssClass = "PhotoActive"
                End If
                counter += 1
            Case ListItemType.AlternatingItem
                If counter = leftOffset + 1 Then
                    Dim imgActive As ImageButton = CType(e.Item.Controls(1), ImageButton)
                    imgActive.CssClass = "PhotoActive"
                End If
                counter += 1
        End Select
    End Sub

    '按下主照片之事件
    Protected Sub fullImage_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        '主照片Index加1移動
        MovePhotoIndex(MoveType.Nxt)
        '由於MovePhotIndex方法有使SqlDataSource重新執行Select命令,
        '所以會接著觸發DataList控制項之ItemDataBound事件,
        '由ItemDataBound事件中再設定新的Image url及Description
    End Sub

    '點選導覽列相片時，必須重新進行導向
    Protected Sub btnNavi_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim photoGuid As String = (CType(sender, ImageButton).ImageUrl).Remove(0, 7)
        Response.Redirect("Browse.aspx?PhotoGUID=" & photoGuid)
    End Sub

    '點選第一張按鈕時
    Protected Sub btnFirst_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnFirst.Click
        MovePhotoIndex(MoveType.First)
    End Sub

    '點選前一張按鈕時
    Protected Sub btnPrevious_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnPrevious.Click
        MovePhotoIndex(MoveType.Forward)
    End Sub

    '點選下一張按鈕時
    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNext.Click
        MovePhotoIndex(MoveType.Nxt)
    End Sub


    '點選最末張按鈕時
    Protected Sub btnLast_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLast.Click
        MovePhotoIndex(MoveType.Last)
    End Sub

    '移動照片Index索引,移動方式根據其移動型態而定
    Protected Sub MovePhotoIndex(ByVal moveType As MoveType)
        '取得目前主照片之Index索引值，還有Rows總筆數
        currentIndex = Convert.ToInt16(txtCurrentIndex.Text)
        totalRows = Convert.ToInt16(txtTotalRows.Text)

        Select Case moveType
            Case moveType.First
                currentIndex = 1
            Case moveType.Forward
                If currentIndex > 1 Then
                    currentIndex -= 1
                End If
            Case moveType.Nxt
                '如果totalRows >7，主照片Index才有往下移動1個的必要
                '且currentIndex必須比totalRows總筆數小於1
                If currentIndex < totalRows Then
                    currentIndex += 1
                End If
            Case moveType.Last
                currentIndex = totalRows
        End Select

        '根據新的Index值，設定到Label控制項上
        txtCurrentIndex.Text = currentIndex.ToString()

        indexOffset()  '根據主照片計算左右之相片數位移

        '照片導覽列
        Dim dv As DataView = TryCast(sqlPhotoData.Select(DataSourceSelectArguments.Empty), DataView)

        If dv IsNot Nothing Then
            'leftOffset就是dv七筆資料中之主照片索引
            fileName = dv.Table.DataSet.Tables(0).Rows(leftOffset)("PhotoGUID").ToString()
            Desc = dv.Table.DataSet.Tables(0).Rows(leftOffset)("Description").ToString()
        End If
    End Sub

    '回相片瀏覽
    Protected Sub btnPhotos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnPhotos.Click
        Response.Redirect("Photos.aspx?AlbumID=" & Session("AllowAlbumID"))
    End Sub
End Class
