
Partial Class TypeCalc
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write("<H2>Double和Decimal型別的數學運算</H2>")

        'Single和Double型別計算都是有誤差的
        Dim x = 10000.0     '若沒指定型別，帶有小數點的數字，系統預設為Double
        Dim y = 9999.9

        '計算x-y
        Response.Write("x-y = " & x - y & "<BR/><BR/>")
        '顯示x與y的資料型別
        Response.Write("x的型別是：" & x.GetType().ToString() & "<BR/>")
        Response.Write("y的型別是：" & x.GetType().ToString() & "<BR/>")

        Response.Write("<BR/>")

        '以Decimal做精確數字計算
        Dim a = 10000D      'D代表Decimal
        Dim b = 9999.9D
        '計算a-b
        Response.Write("a-b = " & a - b & "<BR/><BR/>")
        '顯示a與b的資料型別
        Response.Write("a的型別是：" & a.GetType().ToString() & "<BR/>")
        Response.Write("b的型別是：" & b.GetType().ToString() & "<BR/>")
    End Sub
End Class
