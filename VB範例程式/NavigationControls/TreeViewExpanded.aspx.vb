
Partial Class TreeViewExpanded
    Inherits System.Web.UI.Page

    '摺疊TreeNode節點
    Protected Sub tvProduct_TreeNodeCollapsed(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.TreeNodeEventArgs) Handles tvProduct.TreeNodeCollapsed
        If e.Node.Expanded.Value = False Then
            WebMessageBox.MessageBox.Show("Hi...您摺疊了" & e.Node.Text & "節點！")
        End If
    End Sub

    '展開TreeNode節點
    Protected Sub tvProduct_TreeNodeExpanded(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.TreeNodeEventArgs) Handles tvProduct.TreeNodeExpanded
        If IsPostBack And e.Node.Expanded.Value = True Then
            WebMessageBox.MessageBox.Show("Hi...您展開了" & e.Node.Text & "節點！")
        End If
    End Sub
End Class
