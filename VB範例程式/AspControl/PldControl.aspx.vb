Imports System.Drawing

Partial Class PldControl
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        AddControls()  '呼叫AddControls()方法
    End Sub

    '動態加入控制項到PlaceHolder之中
    Protected Sub AddControls()
        '動態建立使用者姓名控制項
        Dim capName As New Label()
        capName.Text = "姓名："

        Dim txtName As New TextBox
        txtName.ID = "UserName"

        '將控制項加入到PlaceHolder1之中
        PlaceHolder1.Controls.Add(capName)
        PlaceHolder1.Controls.Add(txtName)
        PlaceHolder1.Controls.Add(New LiteralControl("<BR/>"))

        '動態建立使用者國家控制項
        Dim capCountry As New Label()
        capCountry.Text = "國家："

        Dim txtCountry As New TextBox()
        txtCountry.ID = "Country"
        '將控制項加入到PlaceHolder1之中
        PlaceHolder1.Controls.Add(capCountry)
        PlaceHolder1.Controls.Add(txtCountry)
        PlaceHolder1.Controls.Add(New LiteralControl("<BR/>"))

        '動態建立使用者城市控制項
        Dim capCity As New Label()
        capCity.Text = "城市："

        Dim txtCity As New TextBox()
        txtCity.ID = "City"
        '將控制項加入到PlaceHolder1之中
        PlaceHolder1.Controls.Add(capCity)
        PlaceHolder1.Controls.Add(txtCity)
        PlaceHolder1.Controls.Add(New LiteralControl("<BR>"))

        '建立確定按鈕
        Dim btnOK As New Button()
        btnOK.Text = "確定"

        PlaceHolder1.Controls.Add(btnOK)
        PlaceHolder1.Controls.Add(New LiteralControl("<BR>"))

        '動態建立Button的Click事件委派程式
        AddHandler btnOK.Click, AddressOf btnOK_Click
    End Sub

    '顯示使用者輸入資料
    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtMsg As New Label()
        txtMsg.Text = "<BR/>"
        txtMsg.ForeColor = Color.Blue
        txtMsg.Text &= "您輸入的個人資料是：<BR/>"
        txtMsg.Text &= CType(form1.FindControl("UserName"), TextBox).Text & "<BR/>"
        txtMsg.Text &= CType(form1.FindControl("Country"), TextBox).Text & "<BR/>"
        txtMsg.Text &= CType(form1.FindControl("City"), TextBox).Text & "<BR/>"
        PlaceHolder1.Controls.Add(txtMsg)
    End Sub
End Class
