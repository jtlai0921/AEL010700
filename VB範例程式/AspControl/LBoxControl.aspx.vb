
Partial Class LBoxControl
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '加入ListBox之項目
            lbxSource.Items.Add("CPU處理器")
            lbxSource.Items.Add("主機板")
            lbxSource.Items.Add("記憶體")
            lbxSource.Items.Add("顯示卡")
            lbxSource.Items.Add("硬碟")
            lbxSource.Items.Add("DVD燒錄器")
            lbxSource.Items.Add("滑鼠")
            lbxSource.Items.Add("LCD夜晶螢幕")
            lbxSource.Items.Add("電源延長線插座")
            lbxSource.Items.Add("散熱風扇")
            lbxSource.Items.Add("喇叭")
            lbxSource.Items.Add("投影機")

            '同時指定Text與Value之寫法
            'lbxSource.Items.Add(New ListItem("CPU處理器", "0"))
            'lbxSource.Items.Add(New ListItem("主機板", "1"))
            'lbxSource.Items.Add(New ListItem("記憶體", "2"))
            'lbxSource.Items.Add(New ListItem("顯示卡", "3"))
            'lbxSource.Items.Add(New ListItem("硬碟", "4"))
            'lbxSource.Items.Add(New ListItem("DVD燒錄器", "5"))
            'lbxSource.Items.Add(New ListItem("滑鼠", "6"))
            'lbxSource.Items.Add(New ListItem("LCD夜晶螢幕", "7"))
            'lbxSource.Items.Add(New ListItem("電源延長線插座", "8"))
            'lbxSource.Items.Add(New ListItem("散熱風扇", "9"))
            'lbxSource.Items.Add(New ListItem("喇叭", "10"))
            'lbxSource.Items.Add(New ListItem("投影機", "11"))

        End If
    End Sub

    '將商品加入選購清單之中
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdd.Click
        '將商品加入選購清單之中
        For i = 0 To lbxSource.Items.Count - 1
            If lbxSource.Items(i).Selected = True Then
                lbxTarget.Items.Add(lbxSource.Items(i).Text)
                lbxSource.Items(i).Enabled = False
            End If
        Next

        '移除已加入之商品，從最後一筆Item向前移除
        For i = lbxSource.Items.Count - 1 To 0
            If lbxSource.Items(i).Enabled = False Then
                lbxSource.Items.RemoveAt(i)
            End If
        Next
    End Sub

    '將所有商品加入選購清單之中
    Protected Sub btnAddAll_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddAll.Click
        If lbxSource.Items.Count > 0 Then
            For i = 0 To lbxSource.Items.Count - 1
                If lbxSource.Items(i).Enabled = True Then
                    lbxTarget.Items.Add(lbxSource.Items(i).Text)
                End If
            Next
        End If

        lbxSource.Items.Clear()    '清除所有項目
    End Sub

    '將商品自選購清單中移除
    Protected Sub btnRemove_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRemove.Click
        '將商品自選購清單中移除
        For i = 0 To lbxTarget.Items.Count - 1
            If lbxTarget.Items(i).Selected = True Then
                lbxSource.Items.Add(lbxTarget.Items(i).Text)
                lbxTarget.Items(i).Enabled = False
            End If
        Next

        '移除選購清單之商品，從最後一筆Item向前移除
        For i = lbxTarget.Items.Count - 1 To 0
            If lbxTarget.Items(i).Enabled = False Then
                lbxTarget.Items.RemoveAt(i)
            End If
        Next
    End Sub

    '將所有商品自選購清單中移除
    Protected Sub btnRemoveAll_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRemoveAll.Click
        If lbxTarget.Items.Count > 0 Then
            For i = 0 To lbxTarget.Items.Count - 1
                If lbxTarget.Items(i).Enabled = True Then
                    lbxSource.Items.Add(lbxTarget.Items(i).Text)
                End If
            Next
        End If

        lbxTarget.Items.Clear()    '清除所有項目
    End Sub

    '顯示最後確定購買之商品項目
    Protected Sub btnBuy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuy.Click
        If lbxTarget.Items.Count > 0 Then
            Dim i As Integer = 1
            For Each item As ListItem In lbxTarget.Items
                txtMsg.Text &= String.Format("{0:00}.{1}<BR/>", i, item.Text)
                i += 1
            Next
        Else
            Response.Write("<script>alert('請先選購商品！')</script>")
        End If
    End Sub
End Class
