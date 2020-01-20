
Partial Class FormatStrings
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim x As Double = 2005.5
        Dim y As Integer = 128
        Dim z As Double = 0.25

        Response.Write("<H2>標準數值格式化字串</H2>")
        Dim stringX As String = x.ToString().PadLeft(6, "*")
        Dim stringY As String = y.ToString().PadLeft(6, "*")
        Dim stringZ As String = z.ToString().PadLeft(6, "*")

        Response.Write(stringX & "　以C2格式化之後　" & String.Format("{0:C2}", x) & "<BR>")
        Response.Write(stringY & "　以D格式化之後　" & String.Format("{0:D}", y) & "<BR>")
        Response.Write(stringX & "　以E2格式化之後　" & String.Format("{0:E2}", x) & "<BR>")
        Response.Write(stringX & "　以F4格式化之後　" & String.Format("{0:F4}", x) & "<BR>")
        Response.Write(stringX & "　以G格式化之後　" & String.Format("{0:G}", x) & "<BR>")
        Response.Write(stringX & "　以N3格式化之後　" & String.Format("{0:N3}", x) & "<BR>")
        Response.Write(stringZ & "　以P格式化之後　" & String.Format("{0:P}", z) & "<BR>")
        Response.Write(stringY & "　以X格式化之後　" & String.Format("{0:X}", y) & "<BR>")
        Response.Write(stringX & "　以00####.00格式化之後　" & String.Format("{0:00####.00}", x) & "<BR>")
    End Sub
End Class
