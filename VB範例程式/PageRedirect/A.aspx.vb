
Partial Class A
    Inherits System.Web.UI.Page

    Public Speaker As String = "聖殿祭司"

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Server.Transfer("readForm.aspx", True)
    End Sub
End Class
