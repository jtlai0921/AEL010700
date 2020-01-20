
Partial Class Constructors
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '使用建構函式一來初始化Mary物件
        Dim Mary As New People("Mary", "Could", 165, 50, 18, False)

        '將Mary的資料顯示出來
        Response.Write("<H2>以建構函式一設定Mary物件初始值</H2>")
        Response.Write("LastName：" & Mary.LName & "<BR/>")
        Response.Write("FirstName：" & Mary.FName & "<BR/>")
        Response.Write("身高：" & Mary.theHeight & "<BR/>")
        Response.Write("體重：" & Mary.theWeight & "<BR/>")
        Response.Write("年齡：" & Mary.theAge & "<BR/>")
        Response.Write("性別：" & IIf(Mary.theGender = True, "男", "女") & "<BR/>")

        '使用建構函式二來初始化Clare物件
        Dim Claire As New People("Claire", False)
        '將Clare的資料顯示出來
        Response.Write("<H2>使用建構函式二初始化Clare物件</H2>")
        Response.Write("LastName：" & Claire.LName & "<BR/>")
        Response.Write("性別：" & IIf(Claire.theGender = True, "男", "女") & "<BR/>")
    End Sub
End Class
