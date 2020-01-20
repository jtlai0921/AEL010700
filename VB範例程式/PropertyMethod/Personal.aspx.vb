
Partial Class Personal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Mary As New People()
        With Mary
            .LName = "Mary"
            .FName = "Could"
            .theHeight = 165
            .theWeight = 50
            .theAge = 18
            .theGender = False
        End With

        '以建構函式初始化物件
        'Dim Mary As New People("Mary", "Could", 165, 50, 18, False)

        '將Mary的資料顯示出來
        Response.Write("<H2>Mary的屬性資料</H2>")
        Response.Write(String.Format("LastName：{0}<BR/>", Mary.LName))
        Response.Write(String.Format("FirstName：{0}<BR/>", Mary.FName))
        Response.Write(String.Format("身高：{0}cm<BR/>", Mary.theHeight))
        Response.Write(String.Format("體重：{0}Kg<BR/>", Mary.theWeight))
        Response.Write(String.Format("年齡：{0}歲<BR/>", Mary.theAge))
        Response.Write(String.Format("性別：{0}<BR/>", IIf(Mary.theGender, "男", "女")))

        Dim Cindy As New People()

        With Cindy
            .LName = "Cindy"
            .FName = ""
            .theHeight = -168
            .theWeight = -50
            .theAge = 0
            .theGender = False
        End With

        '將Cindy的資料顯示出來
        Response.Write("<span style='color:red'><BR/>")
        Response.Write("<H2>修正後的Cindy屬性資料</H2>")
        Response.Write(String.Format("LastName：{0}<BR/>", Cindy.LName))
        Response.Write(String.Format("FirstName：{0}<BR/>", Cindy.FName))
        Response.Write(String.Format("身高：{0}cm<BR/>", Cindy.theHeight))
        Response.Write(String.Format("體重：{0}Kg<BR/>", Cindy.theWeight))
        Response.Write(String.Format("年齡：{0}歲<BR/>", Cindy.theAge))
        Response.Write(String.Format("性別：{0}<BR/>", IIf(Cindy.theGender, "男", "女")))
        Response.Write("</span>")
    End Sub
End Class
