Imports System.Web.Configuration

Partial Class ReadAppSettings
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim txtCompany As String = WebConfigurationManager.AppSettings("Company")
        Response.Write("公司名稱：" & txtCompany & "<br>")

        Dim txtServiceTel As String = WebConfigurationManager.AppSettings("客服專線")
        Response.Write("客服專線：" & txtServiceTel & "<br>")
    End Sub
End Class
