
Partial Class ArrayClear
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '以下陣列為學生姓名、身高與姓別之資料
        'String型別陣列
        Dim names() As String = New String() {"Kevin", "Mary", "Bob", "Cindy"}
        Dim height() As Integer = New Integer() {180, 168, 172, 165}
        Dim gender() As Boolean = New Boolean() {True, False, True, False}

        Response.Write("<H2>陣列清除</H2>")
        '學生資料
        Response.Write("學生姓名、身高與資料如下：<DIR>")
        For i = 0 To names.Length - 1
            Response.Write("<li>" & names(i) & " , " & height(i) & " , " & gender(i) & "</li>")
        Next

        Response.Write("</DIR>")

        '清除陣列
        System.Array.Clear(names, 0, 4)
        System.Array.Clear(height, 0, height.Length)
        System.Array.Clear(gender, 0, gender.Length)

        '顯示清除後陣列
        Response.Write("陣列清除後的學生姓名、身高與資料如下：<DIR>")
        For i = 0 To names.Length - 1
            Response.Write("<li>" & IIf(names(i) Is Nothing, "Nothing", names(i)) & " , " & height(i) & " , " & gender(i) & "</li>")
        Next
        Response.Write("</DIR>")
    End Sub
End Class
