Imports Microsoft.VisualBasic

Public Class Person
    '定義欄位（Field）
    Public lastName As String
    Public firstName As String
    Public age As Integer      '年齡
    Public height As Decimal   '身高
    Public weight As Decimal   '體重
    Public gender As Boolean   '性別，男為True，女為False

    '預設建構式
    Sub New()
        lastName = "未指定"
        firstName = "未指定"
        age = 1         '設定年齡
        height = 1      '設定身高
        weight = 1      '設定體重
        gender = True  '設定性別
    End Sub
End Class
