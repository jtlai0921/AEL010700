
Partial Class LinqArray
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Step 1：定義集合Array
        Dim students As Integer() = New Integer() {180, 165, 174, 152, 183, 177, 175, 188, 168, 170, 173, 174}

        'Step 2：定義LINQ查詢語法
        Dim tall = From s In students _
                   Where s > 172 _
                   Select s

        'Step 3:以For Each讀取集合資料
        Response.Write("<h2>以LINQ查詢陣列資料</h2>")
        Response.Write(String.Format("身高大於172cm的學生人數有{0}人，身高資料如下：<BR/>", tall.Count()))
        For Each t In tall
            Response.Write(t & " ")
        Next
    End Sub
End Class
