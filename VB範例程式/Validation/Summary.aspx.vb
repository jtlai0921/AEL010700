
Partial Class Summary
    Inherits System.Web.UI.Page

    '驗證及顯示使用者輸入資料
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Page.IsValid Then
            txtMsg.Text = "您輸入的基本資料如下：<BR/>"
            txtMsg.Text &= "姓名：" & Server.HtmlEncode(txtName.Text) & "<BR/>"
            txtMsg.Text &= "電子郵件：" & Server.HtmlEncode(txtMail.Text) & "<BR/>"
            txtMsg.Text &= "地址：" & Server.HtmlEncode(txtAddress.Text) & "<BR/>"
        End If
    End Sub
End Class
