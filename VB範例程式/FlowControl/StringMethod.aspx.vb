
Partial Class StringMethod
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '以Split分割字串
        Response.Write(String.Format("<Font Color='Blue'><<{0}>><BR/></Font>", "以Split分割字串"))

        Dim words As String = "Today is Sunday. I want to go to shopping!"
        Dim split As String() = words.Split(New Char() {" ", ",", ".", "!"})

        For Each s As String In split
            Response.Write(s & "<BR/>")
        Next

        '以Compare比較兩個字串
        Response.Write(stringFormat("以Compare比較兩個字串"))
        Dim word1 As String = "a"
        Dim word2 As String = "b"

        '進行字串比較，並將結果值指定給result
        Dim result As Integer = String.Compare(word1, word2)

        Select Case result
            Case -1
                Response.Write("字串1小於字串2")
            Case 0
                Response.Write("字串1等於字串2")
            Case 1
                Response.Write("字串1大於字串2")
        End Select

        '以Concat串連陣列中字串
        Response.Write(stringFormat("以concat串連陣列中字串"))
        Dim Models As String() = New String() {"Mary", "Kelly", "Cindy", "John", "Tom"}
        Response.Write(String.Concat(Models))

        '以Contains判斷字串中是否包含特定文字
        Response.Write(stringFormat("以Contains判斷字串中是否包含特定文字"))
        Dim string1 As String = "bird dog cow wolf fox fish"
        Dim string2 As String = "fox"
        Response.Write(string1.Contains(string2))

        '以Replace替代特定文字
        Dim Message As String = "大家好！我是聖殿祭司　溪江華"
        Dim newMessage As String = Message.Replace("溪江華", "奚江華")
        Response.Write(newMessage & "<BR/>")

        '以PadLeft填補字串左側長度
        Dim s1 As String = "a"
        Dim s2 As String = "ab"
        Dim s3 As String = "abc"
        Dim s4 As String = "abcd"
        Dim s5 As String = "abcde"

        Response.Write(stringFormat("以PadLeft填補字串左側長度"))
        Response.Write(s1.PadLeft(10, "_") & "<BR/>")
        Response.Write(s2.PadLeft(10, "_") & "<BR/>")
        Response.Write(s3.PadLeft(10, "_") & "<BR/>")
        Response.Write(s4.PadLeft(10, "_") & "<BR/>")
        Response.Write(s5.PadLeft(10, "_") & "<BR/>")

        '以Join串連陣列中字串，字串之間並以指定符號連接
        Response.Write(stringFormat("以Join串連陣列中字串"))
        Response.Write(String.Join("-", Models))

        '以GetHashCode取得字串之HashCode
        Response.Write(stringFormat("以GetHashCode取得字串之HashCode"))

        Dim name As String = "Kevin"
        Response.Write(name.GetHashCode())

        '以GetEnumerator反覆讀取字串字元
        Response.Write(stringFormat("以GetEnumerator反覆讀取字串字元"))

        Dim msg As String = "Hello...My name is Kevin Costner."
        Dim ienum As IEnumerator = msg.GetEnumerator()

        While ienum.MoveNext()
            Response.Write(ienum.Current + "<BR/>")
        End While
    End Sub

    '自訂字串格式化方法
    Public Function stringFormat(ByVal txtString As String) As String
        Dim param As String = "<BR/><BR/><Font Color='Blue'><<{0}>><BR/></Font>"
        Return String.Format(param, txtString)
    End Function
End Class
