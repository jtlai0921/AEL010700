
Partial Class ArrayCloneBasic
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtSource.Text = Nothing
            '排序前的陣列
            Dim sourceArray() As Integer = New Integer(9) {}
            '以亂數建立陣列
            Dim rnd As New Random()
            For i = 0 To 9
                sourceArray(i) = rnd.Next(0, 100)
                txtSource.Text &= CType(sourceArray(i), String) & vbCrLf
            Next
            '保存陣列
            ViewState("sourceArray") = sourceArray
        End If
    End Sub

    'Clone複製陣列
    Protected Sub btnClone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClone.Click
        txtTarget.Text = Nothing
        '從ViewState還原來源陣列資料
        Dim sourceArray() As Integer = CType(ViewState("sourceArray"), Integer())
        'Clone複製來源陣列到目標陣列
        Dim targetArray() As Integer = sourceArray.Clone()
        txtTarget.Text = Nothing

        For i = 0 To 9
            txtTarget.Text &= CType(targetArray(i), String) & vbCrLf
        Next
    End Sub

    'Copy複製陣列，從第一個元素開始複製
    Protected Sub btnCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        txtTarget.Text = Nothing

        '從ViewState還原來源陣列資料
        Dim sourceArray() As Integer = CType(ViewState("sourceArray"), Integer())

        '複製來源陣列前6個元素到目標陣列
        Dim targetArray() As Integer = New Integer(5) {}
        Array.Copy(sourceArray, targetArray, 6)

        For i = 0 To targetArray.Length - 1
            txtTarget.Text &= CType(targetArray(i), String) & vbCrLf
        Next
    End Sub

    'CopyTo複製陣列
    Protected Sub btnCopyTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopyTo.Click
        txtTarget.Text = Nothing
        '從ViewState還原來源陣列資料
        Dim sourceArray() As Integer = CType(ViewState("sourceArray"), Integer())

        Dim targetArray() As Integer = New Integer(12) {}
        targetArray(0) = 1
        targetArray(1) = 2
        targetArray(2) = 3

        '複製來源陣列到目標陣列，並從目標陣列Index索引位置3開始加入
        sourceArray.CopyTo(targetArray, 3)

        For i = 0 To targetArray.Length - 1
            txtTarget.Text &= CType(targetArray(i), String) & vbCrLf
        Next
    End Sub
End Class
