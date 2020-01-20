
Partial Class MultiVar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '於一行陳述式中宣告並設定多個變數
        'Dim lastName = "聖殿祭司", age = 99, gender = True
        'Dim deposit = 1000000D, rate = 0.035D

        '或是先宣告變數，後續再指定變數值
        '於一行陳述式中宣告多個不同型別變數
        Dim lastName As String, age As Integer, gender As Boolean
        '於一行陳述式中宣告多個相同型別變數
        Dim savings, rate As Decimal
        '將數個陳述式置於同一行
        lastName = "聖殿祭司" : age = 99 : gender = True : savings = 1000000 : rate = 0.035

        Response.Write("<H2>一行陳述式宣告多個變數</H2>")
        Response.Write("名字：" & lastName & "<BR/>")
        Response.Write("年齡：" & age & "<BR/>")
        Response.Write("性別：" & IIf(gender = True, "男", "女") & "<BR/>")
        Response.Write("銀行存款：" & savings & "<BR/>")
        Response.Write("利率：" & rate * 100 & "%<BR/>")
        Response.Write("一年存款利息：" & savings * rate & "<BR/>")
    End Sub
End Class
