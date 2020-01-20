
Partial Class AMD
    Inherits System.Web.UI.Page

    'ItemCreated事件
    Protected Sub SiteMapPath1_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SiteMapNodeItemEventArgs) Handles SiteMapPath1.ItemCreated
        If e.Item.ItemType = SiteMapNodeItemType.Current Then
            Select Case e.Item.SiteMapNode.Description
                Case "INTEL"
                    txtMsg.Text = "買" & e.Item.SiteMapNode.Title & "就可進行國外旅遊抽獎"
                Case "AMD"
                    txtMsg.Text = e.Item.SiteMapNode.Title & "正在進行降價25%大促銷"
            End Select
        End If
    End Sub
End Class
