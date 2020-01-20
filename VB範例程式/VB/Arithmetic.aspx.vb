
Partial Class Arithmetic
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim x As Decimal = 3
        Dim y As Decimal = 5
        Dim z As Decimal = 9

        Response.Write("<H2>算術運算子的運用</H2>")
        Response.Write(String.Format("x={0}，y={1}，z={2}<BR/><BR/>", x, y, z))

        '加法運算子
        Response.Write(String.Format("x + 5 = {0}<BR/>", x + 5))

        '減法運算子
        Response.Write(String.Format("y - 2 = {0}<BR/>", y - 2))

        '乘法運算子
        Response.Write(String.Format("x * 3 = {0}<BR/>", x * 3))

        '除法運算子
        Response.Write(String.Format("z / 2 = {0}<BR/>", z / 2))
        Response.Write(String.Format("z \ 2 = {0}<BR/>", z \ 2))

        '餘數運算子
        Response.Write(String.Format("y Mod 2 = {0}<BR/>", y Mod 2))

        '乘冪運算子
        Response.Write("2的十次方 = " & 2 ^ 10 & "<BR/>")
        Response.Write("y的平方 = " & y ^ 2 & "<BR/>")
        Response.Write("x的立方再乘以三次方 = " & x ^ 3 ^ 3 & "<BR/>")
    End Sub
End Class
