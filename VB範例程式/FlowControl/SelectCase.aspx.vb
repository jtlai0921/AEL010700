
Partial Class SelectCase
    Inherits System.Web.UI.Page

    '當DropDownList選擇項目變換時之事件處理
    Protected Sub dwnJob_SelectedIndexChanged(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles dwnJob.SelectedIndexChanged
        '第一種方式，SelectedItem.Value來判斷，可以達到唯一識別
        Select Case dwnJob.SelectedItem.Value
            Case "1"
                txtSalary.Text = "每月薪資100,000元"
            Case "2"
                txtSalary.Text = "每月薪資60,000元"
            Case "3"
                txtSalary.Text = "每月薪資35,000元"
            Case "4"
                txtSalary.Text = "每月薪資20,000元"
            Case Else
                txtSalary.Text = ""
        End Select

        '第二種方式，以SelectedItem.Text來判斷，Text不一定有唯一識別
        'Select Case dwnJob.SelectedItem.Value
        '    Case "總經理"
        '        txtSalary.Text = "每月薪資100,000元"
        '    Case "經理"
        '        txtSalary.Text = "每月薪資60,000元"
        '    Case "工程師"
        '        txtSalary.Text = "每月薪資35,000元"
        '    Case "助理"
        '        txtSalary.Text = "每月薪資20,000元"
        '    Case Else
        '        txtSalary.Text = ""
        'End Select
    End Sub
End Class
