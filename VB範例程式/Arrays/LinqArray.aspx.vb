
Partial Class LinqArray
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Models() As String = New String() {"Tom", "Mary"}

        Dim female = From m In Models _
                     Select m

        For Each f As String In female
            Response.Write(f & "<BR/>")
        Next
    End Sub
End Class
