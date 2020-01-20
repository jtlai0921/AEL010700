
Partial Class Explicit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '字串型別的日期
        Dim dateString As String = "April 12 , 2010"
        'x與y為兩種不同的數值型別
        Dim x As Single = 10000.8
        Dim y As Double = 9999.3
        '將字串轉換成Date
        Response.Write("<H2>以CDate()將String轉換成Date型別</H2>")
        Dim today As Date = CDate(dateString)
        Response.Write("今天是：" & today.ToLongDateString() & "<BR/>")
        Response.Write(String.Format("x={0} , y={1}", x, y))

        '進行x與y的數學計算
        Response.Write("<H2>未明確轉換，x及y仍維持原來Single與Double型別（有誤差）</H2>")
        Response.Write("x - y = " & x - y & "<BR/>")
        Response.Write("x * y = " & x * y & "<BR/>")

        Response.Write("<H2>明確轉換，將x及y以CDec()轉換成Decimal型別（精確）</H2>")
        Response.Write("x - y = " & CDec(x) - CDec(y) & "<BR/>")
        Response.Write("x * y = " & CDec(x) * CDec(y) & "<BR/>")

        Response.Write("<H2>明確轉換，將x及y以CType()轉換成Decimal型別（精確）</H2>")
        Response.Write("x - y = " & CType(x, Decimal) - CType(y, Decimal) & "<BR/>")
        Response.Write("x * y = " & CType(x, Decimal) * CType(y, Decimal) & "<BR/>")
    End Sub
End Class
