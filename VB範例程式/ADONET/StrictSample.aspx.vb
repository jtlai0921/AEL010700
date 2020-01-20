﻿Option Strict On

Partial Class StrictSample
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim smallValue As Short = 32767     '資料容量較小的Short型別變數
        Dim BigValue As Integer = 99999999  '資料容量較大的Integer型別變數

        '隱含轉換
        BigValue = smallValue   '合法，擴展轉換，小->大
        'smallValue = BigValue   '不合法，縮小轉換，大->小
    End Sub
End Class
