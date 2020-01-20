
Partial Class ShowData
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write("帳號：" & Request.QueryString("ID") & "<BR/>")
        Response.Write("密碼：" & Request.QueryString("Password") & "<BR/>")
        Response.Write("輸入訊息：" & Request.QueryString("Msg") & "<BR/>")
    End Sub
End Class
