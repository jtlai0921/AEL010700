
Partial Class CalendarControl
    Inherits System.Web.UI.Page

    '將Calendar日曆控制項之被選取日期指定到TextBox之中
    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        txtDate.Text = Calendar1.SelectedDate.ToLongDateString()
    End Sub
End Class
