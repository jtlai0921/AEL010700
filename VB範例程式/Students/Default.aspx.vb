
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("Permission").ToString().Contains("R") Then
            Response.Redirect("Message.aspx?Reason=必須具備讀取權限")
        End If
    End Sub
End Class
