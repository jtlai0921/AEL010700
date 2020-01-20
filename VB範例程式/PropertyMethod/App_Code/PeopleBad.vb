Imports Microsoft.VisualBasic

Public Class PeopleBad
    '定義欄位
    Dim lastName As String
    Dim firstName As String
    Dim age As Integer
    Dim height As Integer
    Dim weight As Integer
    Private gender As Boolean   '性別

    '預設建構函式
    Public Sub New()
        lastName = Nothing
        firstName = Nothing
        age = 0
        height = 0
        weight = 0
        gender = True
    End Sub

    '建構函式一
    Public Sub New(ByVal LastName As String, ByVal FirstName As String, ByVal Height As Integer, ByVal Weight As Integer, ByVal Age As Integer, ByVal Gender As Boolean)
        Me.lastName = LastName
        Me.firstName = FirstName
        Me.age = Age
        Me.height = Height
        Me.weight = Weight
        Me.gender = Gender
    End Sub

    '建構函式二
    Public Sub New(ByVal LastName As String, ByVal Gender As Boolean)
        Me.lastName = LastName
        Me.gender = Gender
    End Sub


    '定義Property屬性程序（Property Procedure）
    'LastName屬性，定義Set & Get屬性程序
    Public Property LName() As String
        'Set屬性程序
        Set(ByVal value As String)
            lastName = value    '設定lastName
        End Set
        'Get屬性程序
        Get
            Return lastName     '回傳lastName
        End Get
    End Property

    'FirstName屬性
    Public Property FName() As String
        Set(ByVal value As String)
            firstName = value   '設定firstName
        End Set
        Get
            Return firstName    '回傳firstName
        End Get
    End Property

    '年齡屬性
    Public Property theAge() As Integer
        Set(ByVal value As Integer)
            age = value     '設定age
        End Set
        Get
            Return age      '回傳age
        End Get
    End Property

    '身高屬性
    Public Property theHeight() As Decimal
        Set(ByVal value As Decimal)
            height = value  '設定height
        End Set
        Get
            Return height   '回傳height
        End Get
    End Property

    '體重屬性
    Public Property theWeight() As Decimal
        Set(ByVal value As Decimal)
            weight = value  '設定weight
        End Set
        Get
            Return weight   '回傳weight
        End Get
    End Property

    '性別屬性
    Public Property theGender() As Boolean
        Set(ByVal value As Boolean)
            gender = value  '設定gender
        End Set
        Get
            Return gender   '回傳gender
        End Get
    End Property
End Class
