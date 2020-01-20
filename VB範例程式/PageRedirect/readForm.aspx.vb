﻿
Partial Class readForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim displayValues As New System.Text.StringBuilder()
        Dim postedValues As System.Collections.Specialized.NameValueCollection = Request.Form
        Dim nextKey As String

        For i = 0 To postedValues.AllKeys.Length - 1
            nextKey = postedValues.AllKeys(i)
            If nextKey.Substring(0, 2) <> "__" Then
                displayValues.Append("<br>")
                displayValues.Append(nextKey)
                displayValues.Append(" = ")
                displayValues.Append(postedValues(i))
            End If
            Label1.Text = displayValues.ToString()
        Next
    End Sub
End Class
