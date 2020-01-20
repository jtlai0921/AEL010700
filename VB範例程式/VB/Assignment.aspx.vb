
Partial Class Assignment
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '指派運算子
        Dim x As Integer = 3    '使用=運算子，指派3給變數x
        Dim y As Integer = 5
        Dim z As Integer = 7
        Dim a As Decimal = 9
        Dim b As Decimal = 11
        Dim string1 = "Hello"
        Dim string2 = " My Friends!"

        Response.Write("<H2>指派運算子的運用</H2>")
        Dim str = "x={0}，y={1}，z={2}，a={3}，b={4}，string1={5}，string2={6}<BR/><BR/>"
        Response.Write(String.Format(str, x, y, z, a, b, string1, string2))

        x += 5   '使用+=運算子
        Response.Write(String.Format("x += 5結果是：{0}</BR>", x))
        y -= 1   '使用-=運算子
        Response.Write(String.Format("y -= 1結果是：{0}</BR>", y))
        z ^= 2   '使用^=運算子
        Response.Write(String.Format("z ^= 2結果是：{0}</BR>", z))
        a /= 2    '使用/=運算子
        Response.Write(String.Format("a /= 2結果是：{0}</BR>", a))
        b \= 2    '使用\=運算子
        Response.Write(String.Format("b \= 2結果是：{0}</BR>", b))
        string1 &= string2  '使用&=運算子
        Response.Write(String.Format("string1 &= string2結果是：{0}</BR>", string1))
    End Sub
End Class
