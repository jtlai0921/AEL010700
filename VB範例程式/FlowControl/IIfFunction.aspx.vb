﻿
Partial Class IIfFunction
    Inherits System.Web.UI.Page

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim score As Integer = CType(txtScore.Text, Integer)
        txtMsg.Text = "分數" & score & "分，"
        txtMsg.Text &= IIf(score >= 60, "成績及格!", "不及格!")
    End Sub
End Class
