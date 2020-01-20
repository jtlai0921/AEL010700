
Partial Class Models
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'String型別陣列，儲存模特兒名字
        Dim models() As String = New String(4) {"Mary", "Kelly", "Cindy", "Rose", "Landy"}

        'Integer型別陣列，儲存模特兒身高
        Dim height() As Integer = New Integer(4) {180, 182, 178, 175, 182}

        Response.Write("<H2>以一維陣列儲存模特兒名字及身高資料</H2>")
        Response.Write("模特兒的名字如下：")
        '以For陳述式讀取陣列元素
        For i = 0 To models.Length - 1
            Response.Write(String.Format("<li>{0}</li>", models(i)))
        Next

        Response.Write("<BR/><BR/>")
        Response.Write("模特兒的身高如下：")

        '以For Each陳述式讀取陣列元素
        For Each h As Integer In height
            Response.Write(String.Format("<li>{0}</li>", h))
        Next
    End Sub
End Class
