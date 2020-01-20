
Partial Class CookiesBasic
    Inherits System.Web.UI.Page

    '儲存資料到Cookie
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Not String.IsNullOrEmpty(txtName.Text) And Not String.IsNullOrEmpty(txtBlood.Text) And Not String.IsNullOrEmpty(txtHobby.Text)) Then
            '加入Cookies集合
            '設定UserName的Cookie值
            Response.Cookies("Name").Value = txtName.Text
            '設定Cookie逾時作廢時間為1天
            Response.Cookies("Name").Expires = DateTime.Now.AddDays(1)
            Response.Cookies("Blood").Value = txtBlood.Text
            Response.Cookies("Blood").Expires = DateTime.Now.AddDays(1)
            Response.Cookies("Hobby").Value = txtHobby.Text
            Response.Cookies("Hobby").Expires = DateTime.Now.AddDays(1)
            txtMsg.Text = "Cookie資料儲存成功！"
        Else
            txtMsg.Text = "TextBox不得為空白或Nothing"
        End If
    End Sub

    '讀取Cookie資料
    Protected Sub btnRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRead.Click
        If (Request.Cookies("Name") IsNot Nothing And Request.Cookies("Blood") IsNot Nothing And Request.Cookies("Hobby") IsNot Nothing) Then
            Dim sb As New StringBuilder
            sb.Append("姓名：" & Server.HtmlEncode(Request.Cookies("Name").Value) & "<BR/>")
            sb.Append("血型：" & Server.HtmlEncode(Request.Cookies("Blood").Value) & "<BR/>")
            sb.Append("興趣：" & Server.HtmlEncode(Request.Cookies("Hobby").Value) + "<BR/>")
            txtMsg.Text = sb.ToString()
        Else
            txtMsg.Text = "Cookie為Nothing"
        End If
    End Sub
End Class
