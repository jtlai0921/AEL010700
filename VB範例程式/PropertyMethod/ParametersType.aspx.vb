
Partial Class ParametersType
    Inherits System.Web.UI.Page

    Dim a As Integer = 3, b As Integer = 4
  
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            showResult()    '第一次執行時顯示初值
        End If
    End Sub

    '使用傳值方式傳遞參數
    Protected Sub btnValue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnValue.Click
        Operate(a, b)   '傳入a與b參數到Operate方法中做數學計算
        showResult()
    End Sub

    '使用傳址方式傳遞參數
    Protected Sub btnReference_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReference.Click
        '傳入a與b參數到Operate方法中做數學計算
        Operate((CSng(a)), CSng(b))
        showResult()
    End Sub

    '傳值參數程序，Operate為多載型式
    Overloads Sub Operate(ByVal a As Integer, ByVal b As Integer)
        a = a * 2 + 1   '這裡的a與b參數是複本
        b = b + 5
    End Sub

    '傳址參數程序，Operate為多載型式
    Overloads Sub Operate(ByRef x As Single, ByRef y As Single)
        a = a * 2 + 1   '這裡的a與b參數是本尊的記憶體位址
        b = b + 5
    End Sub

    Public Sub showResult()
        'Response.Write("變數a的值為：" & a & "<BR/>")
        'Response.Write("變數b的值為：" & b & "<BR/>")
        Dim msg As String = "變數a的值為：" & a & "<BR/>"
        msg &= "變數b的值為：" & b & "<BR/>"

        Dim txtMsg As New Label()
        txtMsg.Text = msg
        form1.Controls.Add(txtMsg)
    End Sub
End Class
