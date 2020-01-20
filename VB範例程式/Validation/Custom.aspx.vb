
Partial Class Custom
    Inherits System.Web.UI.Page

    'Server端驗證
    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        '台灣的郵遞區號長度必須為3或5碼
        If txtZipCode.Text.Length = 3 Or txtZipCode.Text.Length = 5 Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If

    End Sub

    '驗證及顯示使用者輸入資料
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Page.IsValid Then
            txtMsg.Text = "您輸入的基本資料如下：<BR/>"
            txtMsg.Text &= "姓名：" & Server.HtmlEncode(txtName.Text) & "<BR/>"
            txtMsg.Text &= "郵遞區號：" & Server.HtmlEncode(txtZipCode.Text) & "<BR/>"
            txtMsg.Text &= "地址：" & Server.HtmlEncode(txtAddress.Text) & "<BR/>"
        Else
            txtMsg.Text = "您輸入的資料沒有通過驗證！"
        End If
    End Sub
End Class
