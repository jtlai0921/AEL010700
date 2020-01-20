
Partial Class BreakStatement
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim x As Integer = 3
        Dim y As Integer = 6
        Dim z As Integer = 9

        Response.Write("<H2>VB程式的斷行</H2>")
        '原始的VB一行程式
        Response.Write(String.Format("x={0}，y={1}，z={2}<BR/><BR/>", x, y, z))
        '以空隔+底線符號進行斷行,分成兩行較好閱讀
        Response.Write(String.Format("x={0}，y={1}，z={2}<BR/><BR/>", _
                                     x, y, z))

    End Sub
End Class
