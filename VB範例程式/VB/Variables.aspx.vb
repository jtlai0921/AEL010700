
Partial Class Variables
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '宣告變數與指派變數值
        Dim lastName As String = "聖殿祭司"
        Dim age As Integer = 99
        Dim gender As Boolean = True  '男性為True，女性為False
        Dim savings As Decimal = 1000000  '存款金額
        Dim rate = 0.035D    '存款利率

        Response.Write("<H2>變數宣告、設定與使用</H2>")
        Response.Write("名字：" & lastName & "<BR/>")
        Response.Write("年齡：" & age & "<BR/>")
        Response.Write("性別：" & IIf(gender = True, "男", "女") & "<BR/>")
        Response.Write("銀行存款：" & savings & "<BR/>")
        Response.Write("利率：" & rate * 100 & "%<BR/>")
        Response.Write("一年存款利息：" & savings * rate & "<BR/>")
    End Sub
End Class
