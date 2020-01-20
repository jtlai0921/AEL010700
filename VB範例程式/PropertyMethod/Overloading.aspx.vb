Imports System.Drawing

Partial Class Overloading
    Inherits System.Web.UI.Page

    Public i As Integer = 0
    Protected Shared students As String()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            students = New String() {"Mary", "Kevin", "Tom", "John", "Bob"}
            gvStudents.DataSource = students
            gvStudents.DataBind()
        End If
    End Sub

    Protected Sub dwnFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dwnFormat.SelectedIndexChanged
        Select Case dwnFormat.SelectedValue
            Case "一"
                formatGrid()
            Case "二"
                formatGrid("學生名單")
            Case "三"
                Dim color1 As Color = Color.Maroon
                Dim color2 As Color = Color.Magenta
                formatGrid("學生名單", color1, color2)
        End Select
    End Sub

    '多載方法一，呼叫預設的欄位樣式設定
    Overloads Sub formatGrid()
        gvStudents.Columns(0).HeaderStyle.BackColor = Color.Orange
        gvStudents.Columns(0).ItemStyle.BackColor = Color.Orange
        gvStudents.Columns(1).HeaderStyle.BackColor = Color.LightGreen
        gvStudents.Columns(1).ItemStyle.BackColor = Color.LightGreen
        gvStudents.Caption = ""
    End Sub

    '多載方法二，設定GridView欄位顏色及標題
    Overloads Sub formatGrid(ByVal Header As String)
        gvStudents.Columns(0).HeaderStyle.BackColor = Color.LightPink
        gvStudents.Columns(0).ItemStyle.BackColor = Color.LightPink
        gvStudents.Columns(1).HeaderStyle.BackColor = Color.LightBlue
        gvStudents.Columns(1).ItemStyle.BackColor = Color.LightBlue
        gvStudents.Caption = "<div style='background:Yellow'>" & Header & "</div>"
    End Sub

    '多載方法三，設定GridView自訂的欄位顏色及標題
    Overloads Sub formatGrid(ByVal Header As String, ByVal color1 As Color, ByVal color2 As Color)
        gvStudents.Columns(0).HeaderStyle.BackColor = color1
        gvStudents.Columns(0).ItemStyle.BackColor = color1
        gvStudents.Columns(1).HeaderStyle.BackColor = color2
        gvStudents.Columns(1).ItemStyle.BackColor = color2
        gvStudents.Caption = "<div style='background:Yellow'>" & Header & "</div>"
    End Sub
End Class
