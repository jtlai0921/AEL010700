Imports System.Globalization

Partial Class CultureInfoFormat
    Inherits System.Web.UI.Page

    Dim date1 As DateTime

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        date1 = New DateTime(2010, 4, 12)

        '使用標準日期及時間格式參數，並結合文化特性
        Response.Write("<Font Color='Blue'><<使用標準日期及時間格式參數，並結合文化特性>></Font><BR/>")
        Response.Write(FormatCulture("d"))
        Response.Write(FormatCulture("D"))
        Response.Write(FormatCulture("f"))
        Response.Write(FormatCulture("F"))
        Response.Write(FormatCulture("g"))
        Response.Write(FormatCulture("G"))
        Response.Write(FormatCulture("m"))
        Response.Write(FormatCulture("M"))
        Response.Write(FormatCulture("o"))
        Response.Write(FormatCulture("O"))
        Response.Write(FormatCulture("r"))
        Response.Write(FormatCulture("R"))
        Response.Write(FormatCulture("s"))
        Response.Write(FormatCulture("t"))
        Response.Write(FormatCulture("T"))
        Response.Write(FormatCulture("u"))
        Response.Write(FormatCulture("U"))
        Response.Write(FormatCulture("y"))
        Response.Write(FormatCulture("Y"))
    End Sub

    Public Function FormatCulture(ByVal specifier As String) As String
        Dim param As String = "標準格式化參數{0}-->{1}<BR/>"
        Return String.Format(param, specifier, date1.ToString(specifier, CultureInfo.CreateSpecificCulture("en-US")))
    End Function
End Class
