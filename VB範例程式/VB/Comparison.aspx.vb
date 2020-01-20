
Partial Class Comparison
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim x As Integer = 10
        Dim y As Integer = 5
        Dim z As Integer = 10

        Response.Write("<H2>比較運算子的運用</H2>")
        Response.Write(String.Format("x={0}，y={1}，z={2}<BR/><BR/>", x, y, z))

        '判斷x是否大於y
        If x > y Then
            Response.Write("x > y為True<BR/>")
        Else
            Response.Write("x > y為False<BR/>")
        End If

        '判斷z是否小於y
        If z < y Then
            Response.Write("z < y為True<BR/>")
        Else
            Response.Write("z < y為False<BR/>")
        End If

        '判斷x是否大於等於z
        If x >= z Then
            Response.Write("x >= z為True<BR/>")
        Else
            Response.Write("x >= z為False<BR/>")
        End If

        '使用IIf語法更精簡
        Response.Write("<H2>更精簡的語法，使用IIf</H2>")
        Response.Write(IIf(x > y, "x > y為True<BR/>", "x > y為False<BR/>"))
        Response.Write(IIf(z < y, "z < y為True<BR/>", "z < y為False<BR/>"))
        Response.Write(IIf(x >= z, "x >= z為True<BR/>", "x >= z為False<BR/>"))

        Dim myName = "Kevin"
        'Like運算子的使用
        Dim match As Boolean = myName Like "K*"
        Response.Write("是否myName Like ""K*""的模式比對成立？" & match.ToString())
    End Sub
End Class
