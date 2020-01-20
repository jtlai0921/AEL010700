
Partial Class StandardFormat
    Inherits System.Web.UI.Page

    Dim date1 As DateTime

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim date1 As DateTime = New DateTime(2010, 4, 12)

        '使用標準日期及時間格式參數
        Response.Write("<Font Color='Blue'><<使用標準日期及時間格式參數>></Font><BR/>")
        Response.Write(stringFormat("d"))
        Response.Write(stringFormat("D"))
        Response.Write(stringFormat("f"))
        Response.Write(stringFormat("F"))
        Response.Write(stringFormat("g"))
        Response.Write(stringFormat("G"))
        Response.Write(stringFormat("m"))
        Response.Write(stringFormat("M"))
        Response.Write(stringFormat("o"))
        Response.Write(stringFormat("O"))
        Response.Write(stringFormat("r"))
        Response.Write(stringFormat("R"))
        Response.Write(stringFormat("s"))
        Response.Write(stringFormat("t"))
        Response.Write(stringFormat("T"))
        Response.Write(stringFormat("u"))
        Response.Write(stringFormat("U"))
        Response.Write(stringFormat("y"))
        Response.Write(stringFormat("Y"))
    End Sub

    '自訂字串格式化方法，無指定CultureInfo文化特性，但預設台灣使用zh-TW
    Public Function stringFormat(ByVal specifier As String) As String
        Dim param As String = "標準格式化參數{0}-->{1}<BR/>"
        Return String.Format(param, specifier, date1.ToString(specifier))
    End Function
End Class
