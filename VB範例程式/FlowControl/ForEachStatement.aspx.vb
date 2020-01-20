
Partial Class ForEachStatement
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write("<h1>For Each陳述式</h1>")

        Dim Models As String() = New String() {"Kelly", "Mary", "Tom", "Bob", "John"}

        Response.Write("<UL>模特兒成員如下:")
        '以For Each執行陣列資料的讀取
        For Each m As String In Models
            Response.Write("<Li>" + m + "</Li>")
        Next
        Response.Write("</UL>")
    End Sub
End Class
