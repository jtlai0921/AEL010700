
Partial Class ArrayGetLength
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write("<H2>計算陣列維度之長度</H2>")
        '取得一維陣列的長度（Length）
        Dim names() As String = New String() {"Kevin", "Mary", "Bob", "Cindy"}
        Response.Write("一維陣列第一個維度的長度為：" & names.GetLength(0) & "<BR/><BR/>")

        '取得二維陣列的長度（Length）
        Dim myArray(,) As Integer = New Integer(8, 4) {}
        Response.Write("二維陣列第一個維度的長度為：" & myArray.GetLength(0) & "<BR/>")
        Response.Write("二維陣列第二個維度的長度為：" & myArray.GetLength(1) & "<BR/>")
    End Sub
End Class
