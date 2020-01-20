
Partial Class ClassObject
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Tom As Person = New Person()
        '設定Tom欄位值基本資料
        Tom.lastName = "Tom"
        Tom.firstName = "Hans"
        Tom.height = 175
        Tom.weight = 65
        Tom.age = 40
        Tom.gender = True

        Response.Write("<H2>Tom的基本資料</H2>")
        Response.Write(String.Format("LastName：{0}<BR/>", Tom.lastName))
        Response.Write(String.Format("FirstName：{0}<BR/>", Tom.firstName))
        Response.Write(String.Format("年齡：{0}歲<BR/>", Tom.age))
        Response.Write(String.Format("身高：{0}cm<BR/>", Tom.height))
        Response.Write(String.Format("體重：{0}Kg<BR/>", Tom.weight))
        Response.Write(String.Format("性別：{0}<BR/>", IIf(Tom.gender, "男", "女")))
    End Sub
End Class
