Imports System.Drawing

Partial Class LabelControl
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '透過VB程式設定控制項屬性
            With txtPrg
                .Text = "這是以程式動態設定Label控制項的屬性"
                .ToolTip = "程式動態設定Label控制項"
                .ForeColor = Color.Aqua
                .BackColor = Color.Orange
                .Font.Name = "標楷體"
                .Font.Size = FontUnit.XLarge
            End With
        End If
    End Sub
End Class
