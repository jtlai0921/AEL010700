
Partial Class Regular
    Inherits System.Web.UI.Page

    '驗證並顯示使用者資料
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Page.IsValid Then
            txtMsg.Text = "您輸入的基本資料如下：<BR/>"
            txtMsg.Text &= "姓名：" & Server.HtmlEncode(txtName.Text) & "<BR/>"
            txtMsg.Text &= "Mail：" & Server.HtmlEncode(txtMail.Text) & "<BR/>"
        Else
            txtMsg.Text = "您輸入的資料沒有通過驗證！"
        End If
    End Sub
End Class
