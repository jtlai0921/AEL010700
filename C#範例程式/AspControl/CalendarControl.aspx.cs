using System;

public partial class CalendarControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //將Calendar日曆控制項之被選取日期指定到TextBox之中
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtDate.Text = Calendar1.SelectedDate.ToLongDateString();
    }
}
