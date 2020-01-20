
Partial Class MathMethod
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '以Abs計算絕對值
        Response.Write(String.Format("<Font Color='Blue'><<{0}>><BR/></Font>", "以Abs計算絕對值"))

        Dim a As Decimal = -1.3549D
        Response.Write(String.Format("{0}的{1}為：{2}", a, "Abs絕對值", Math.Abs(a)))

        '以Max傳回最大的數值
        Dim value1 As Decimal = 3939889
        Dim value2 As Decimal = 8825252

        Response.Write(stringFormat("以Max傳回最大的數值"))
        Response.Write(String.Format("{0}與{1}二者以Max計算最大值為：{2}", value1, value2, Math.Max(value1, value2)))

        '以Min傳回最小的數值
        Response.Write(stringFormat("以Min傳回最小的數值"))
        Response.Write(String.Format("{0}與{1}二者以Min計算最小值為：{2}", value1, value2, Math.Min(value1, value2)))

        '以DivRem計算商數及餘數
        Response.Write(stringFormat("以DivRem計算商數"))
        Dim x As Integer = 8
        Dim y As Integer = 3
        Dim quotient As Integer     '商數
        Dim remainder As Integer    '餘數

        quotient = Math.DivRem(x, y, remainder)
        Response.Write(String.Format("{0}除以{1}的商數為：{2}，餘數為：{3}", x, y, quotient, remainder))

        '以Round進行四捨五入計算
        Response.Write(stringFormat("以Round進行四捨五入計算"))
        Response.Write(Math.Round(4.4) & "<BR/>")
        Response.Write(Math.Round(4.5) & "<BR/>")
        Response.Write(Math.Round(4.6) & "<BR/>")
        Response.Write(Math.Round(5.5) & "<BR/>")

        Response.Write(Math.Round(4.445, 2, MidpointRounding.ToEven) & "<BR/>")
        Response.Write(Math.Round(4.445, 2, MidpointRounding.AwayFromZero) & "<BR/>")
    End Sub

    '自訂字串格式化方法
    Public Function stringFormat(ByVal txtString As String) As String
        Dim param As String = "<BR/><BR/><Font Color='Blue'><<{0}>><BR/></Font>"
        Return String.Format(param, txtString)
    End Function
End Class
