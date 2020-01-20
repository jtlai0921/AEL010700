
Partial Class MenuItemDataBound
    Inherits System.Web.UI.Page

    '資料繫結時所發生事件
    Protected Sub Menu1_MenuItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemDataBound
        Select Case e.Item.Text
            Case "INTEL處理器"
                e.Item.Text = "英代爾處理器"
            Case "AMD處理器"
                e.Item.Text = "超微處理器"
        End Select
    End Sub
End Class
