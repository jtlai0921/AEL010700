Imports System.Data

Partial Class dvDataItemCode
    Inherits System.Web.UI.Page

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        '以程式動態設定PagerSetting分頁圖片
        dvEmployee.PagerSettings.Mode = PagerButtons.NextPreviousFirstLast
        dvEmployee.PagerSettings.Position = PagerPosition.Bottom
        dvEmployee.PagerSettings.FirstPageImageUrl = "~/Images/First.gif"
        dvEmployee.PagerSettings.LastPageImageUrl = "~/Images/Last.gif"
        dvEmployee.PagerSettings.PreviousPageImageUrl = "~/Images/Previous.gif"
        dvEmployee.PagerSettings.NextPageImageUrl = "~/Images/Next.gif"
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dvEmployee.DataBind() '為了自訂分頁數字按鈕的繫結

        '建立DropDownList控制項頁碼
        If Not IsPostBack Then
            If dvEmployee.DataItemCount > 0 Then
                Dim myListItem As ListItem
                myListItem = New ListItem("請選擇", "0")
                dwnPageIndex.Items.Add(myListItem)
                '依資料來源資料筆數建立DropDownList中的頁碼
                For j As Integer = 1 To dvEmployee.DataItemCount
                    myListItem = New ListItem(j.ToString(), j.ToString())
                    dwnPageIndex.Items.Add(myListItem)
                Next
            End If
        End If
    End Sub

    Protected Sub dvEmployee_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvEmployee.DataBound
        Dim drView As DataRowView = CType(dvEmployee.DataItem, DataRowView)
        '將英文國家名稱轉換成中文名稱
        Select Case drView("Country").ToString().ToUpper()
            Case "USA"
                drView("Country") = "美國"
            Case "UK"
                drView("Country") = "英國"
            Case "TAIWAN"
                drView("Country") = "台灣"
        End Select

        '上面將Country由英文替換成中文國家後必須再繫結一次
        dvEmployee.Rows(4).DataBind()

        AddPagerIndex()

        Dim bottomPagerRow As DetailsViewRow = dvEmployee.BottomPagerRow
        '動態建立分頁按鈕
        Dim I As Integer
        For I = 0 To dvEmployee.PageCount - 1
            Dim PageNo As New LinkButton()
            PageNo.Text = Convert.ToString(I + 1)
            PageNo.ID = (PageNo.ToString() & I.ToString())
            PageNo.CommandArgument = I.ToString()
            AddHandler PageNo.Click, AddressOf PageNo_Click
            bottomPagerRow.Cells(0).Controls.Add(PageNo)
            Dim blank As New Literal()
            blank.Text = " "
            bottomPagerRow.Cells(0).Controls.Add(blank)
        Next
    End Sub

    '建立及取得DetailsView的HeaderRow及HeaderRow
    Protected Sub AddPagerIndex()
        '目的是為了加入Page參考索引筆數
        Dim headerRow As DetailsViewRow = dvEmployee.HeaderRow
        Dim bottomPagerRow As DetailsViewRow = dvEmployee.BottomPagerRow

        Dim txtPagerNo1 As New Label()
        Dim txtPagerNo2 As New Label()
        txtPagerNo1.Text = "員工基本資料維護( " & (dvEmployee.DataItemIndex + 1) & "/" & dvEmployee.DataItemCount & " )"
        txtPagerNo2.Text = "資料項目索引( " & (dvEmployee.DataItemIndex + 1) & "/" & dvEmployee.DataItemCount & ")"
        headerRow.Cells(0).Controls.Add(txtPagerNo1)
        bottomPagerRow.Cells(0).Controls.Add(txtPagerNo2)

        Dim blank As New Literal()
        blank.Text = "<BR/>"
        bottomPagerRow.Cells(0).Controls.Add(blank)

        '讀取欄位標題及資訊內容
        '方法一
        txtMsg1.Text = "<Font Color='Red'>這是Rows.Cell</Font><BR>"
        txtMsg1.Text &= headerRow.Cells(0).Text & "<br/>"
        txtMsg1.Text &= dvEmployee.Rows(0).Cells(0).Text & "：" & dvEmployee.Rows(0).Cells(1).Text & "<br/>"
        txtMsg1.Text &= dvEmployee.Rows(1).Cells(0).Text & "：" & dvEmployee.Rows(1).Cells(1).Text & "<br/>"
        txtMsg1.Text &= dvEmployee.Rows(2).Cells(0).Text & "：" & dvEmployee.Rows(2).Cells(1).Text & "<br/>"
        txtMsg1.Text &= dvEmployee.Rows(3).Cells(0).Text & "：" & dvEmployee.Rows(3).Cells(1).Text & "<br/>"
        txtMsg1.Text &= dvEmployee.Rows(4).Cells(0).Text & "：" & dvEmployee.Rows(4).Cells(1).Text & "<br/>"

        '方法二
        Dim drView As DataRowView = CType(dvEmployee.DataItem, DataRowView)
        txtMsg2.Text = "<Font Color='Red'>這是DataRowView</Font><BR>"
        txtMsg2.Text &= drView("EmployeeID") & "<BR>"
        txtMsg2.Text &= drView("LastName") & "<BR>"
        txtMsg2.Text &= drView("FirstName") & "<BR>"
        txtMsg2.Text &= drView("City") & "<BR>"
        txtMsg2.Text &= drView("Country") & "<BR>"
    End Sub

    '建立分頁按鈕事件
    Protected Sub PageNo_Click(ByVal sender As Object, ByVal e As EventArgs)
        dvEmployee.PageIndex = CType(CType(sender, LinkButton).CommandArgument, Int16)
    End Sub

    '前往選擇的頁碼
    Protected Sub dwnPageIndex_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dwnPageIndex.SelectedIndexChanged
        dvEmployee.PageIndex = dwnPageIndex.SelectedIndex - 1
    End Sub

End Class
