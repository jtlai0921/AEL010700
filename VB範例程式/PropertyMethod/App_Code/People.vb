Imports Microsoft.VisualBasic

Public Class People
    '定義欄位
    Dim lastName As String
    Dim firstName As String
    Dim age As Integer
    Dim height As Integer
    Dim weight As Integer
    Private gender As Boolean   '性別

    '以建構函式設定欄位初值
    Sub New()
        lastName = Nothing
        firstName = Nothing
        age = 0
        height = 0
        weight = 0
        gender = True
    End Sub

    '建構函式一
    Sub New(ByVal LastName As String, ByVal FirstName As String, ByVal Height As Integer, ByVal Weight As Integer, ByVal Age As Integer, ByVal Gender As Boolean)
        Me.lastName = LastName
        Me.firstName = FirstName
        Me.age = Age
        Me.height = Height
        Me.weight = Weight
        Me.gender = Gender
    End Sub

    '建構函式二
    Sub New(ByVal LastName As String, ByVal Gender As Boolean)
        Me.lastName = LastName
        Me.gender = Gender
    End Sub

    '定義Property屬性程序（Property Procedure）
    'LastName屬性，定義Set & Get屬性程序
    Public Property LName() As String
        'Set屬性程序
        Set(ByVal value As String)
            '判斷LName是否為空字串
            If Not String.IsNullOrEmpty(value) Then
                lastName = value
            End If
        End Set
        'Get屬性程序
        Get
            If String.IsNullOrEmpty(lastName) Then
                lastName = "LastName尚未指定"
            End If
            Return lastName
        End Get
    End Property

    'FirstName屬性
    Public Property FName() As String
        Set(ByVal value As String)
            '判斷FName是否為空字串
            If Not String.IsNullOrEmpty(value) Then
                firstName = value   '設定firstName
            End If
        End Set
        Get
            If String.IsNullOrEmpty(firstName) Then
                firstName = "FirstName尚未指定"
            End If
            Return firstName    '回傳firstName
        End Get
    End Property

    '年齡屬性
    Public Property theAge() As Integer
        Set(ByVal value As Integer)
            'age設定值必須大於等於1
            If value >= 1 Then
                age = value
            End If
        End Set
        Get
            '如果age為0或負值，則設定為1歲
            If age <= 0 Then
                age = 1
            End If
            Return age
        End Get
    End Property

    '身高屬性
    Public Property theHeight() As Decimal
        Set(ByVal value As Decimal)
            '判斷height身高設定值是否大於等於1
            If value >= 1 Then
                height = value
            End If
        End Set
        Get
            '如果height為0或負值，則設定為1
            If height <= 0 Then
                height = 1
            End If
            Return height
        End Get
    End Property

    '體重屬性
    Public Property theWeight() As Decimal
        Set(ByVal value As Decimal)
            If value >= 1 Then
                weight = value
            End If
        End Set
        Get
            If weight <= 0 Then
                weight = 1
            End If
            Return weight
        End Get
    End Property

    '性別屬性
    Public Property theGender() As Boolean
        Set(ByVal value As Boolean)
            gender = value
        End Set
        Get
            Return gender
        End Get
    End Property
End Class
