
Partial Class TreeViewChecked
    Inherits System.Web.UI.Page

    'TreeView控制項的CheckBox狀態改變時所引發的事件
    Protected Sub tvProduct_TreeNodeCheckChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.TreeNodeEventArgs) Handles tvProduct.TreeNodeCheckChanged
        txtMsg.Text = "您選擇的電腦產品有: <br>"
        Response.Write("<ul>")

        '檢查Node節點是否被勾選
        For Each nodeChecked As TreeNode In tvProduct.CheckedNodes
            txtMsg.Text &= "<li>" & nodeChecked.Text & "</li>"
        Next
        Response.Write("</ul>")
    End Sub

End Class
