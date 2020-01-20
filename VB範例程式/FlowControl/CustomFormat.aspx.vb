
Partial Class CustomFormat
    Inherits System.Web.UI.Page

    Dim date1 As DateTime

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        date1 = New DateTime(2010, 4, 12)

        Response.Write("原始日期格式：<Font Color='Blue'>" & date1 & "</Font><BR/>")
        '自訂日期格式
        Response.Write("<BR/><Font Color='Blue'><<直接指定日期格式>></Font><BR/>")
        Response.Write("自訂格式參數yyyy/MM/dd-->" & date1.ToString("yyyy/MM/dd") & "<BR/>")
        Response.Write("自訂格式參數yyyy-MM-dd-->" & date1.ToString("yyyy-MM-dd") & "<BR/>")
        Response.Write("自訂格式參數MM.dd.yyyy-->" & date1.ToString("MM.dd.yyyy") & "<BR/>")
        Response.Write("自訂格式參數dd.MM.yyyy-->" & date1.ToString("dd.MM.yyyy") & "<BR/>")
    End Sub
End Class
