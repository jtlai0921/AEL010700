
Partial Class ApplicationState
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write("Blog名稱：" & Application("Blog") & "<BR/>")
        Response.Write("管理者：" & Application("Administrator") & "<BR/>")
        Response.Write("Tel：" & Application("Tel") & "<BR/>")
        Response.Write("目前訪客人數為：" & Application("Counter") & "<BR/>")
    End Sub
End Class
