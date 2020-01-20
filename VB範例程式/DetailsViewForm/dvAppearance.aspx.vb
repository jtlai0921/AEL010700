Imports System.Drawing

Partial Class dvAppearance
    Inherits System.Web.UI.Page

    Protected Sub dvEmp_ModeChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewModeEventArgs) Handles dvEmp.ModeChanging
        '依不同模式顯示Headertext及背景色
        Select Case e.NewMode
            Case DetailsViewMode.Edit
                dvEmp.HeaderText = "編輯員工基本資料"
                dvEmp.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                dvEmp.HeaderStyle.BackColor = Color.Red
                '若為編輯模式，則改變其背景色及各個Fields設定其寬度為100
                dvEmp.EditRowStyle.BackColor = Color.LightPink
                For I As Integer = 0 To dvEmp.Fields.Count - 1
                    dvEmp.Fields(I).ControlStyle.Width = 150
                Next
            Case DetailsViewMode.Insert
                dvEmp.HeaderText = "新增員工基本資料"
                dvEmp.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                dvEmp.HeaderStyle.BackColor = Color.DeepSkyBlue
                '若為新增模式，則改變其背景色及各個Fields設定其寬度為100
                dvEmp.InsertRowStyle.BackColor = Color.LightCyan
                For I As Integer = 0 To dvEmp.Fields.Count - 1
                    dvEmp.Fields(I).ControlStyle.Width = 150
                    dvEmp.Fields(I).ControlStyle.Height = 35
                Next
            Case Else
                dvEmp.HeaderStyle.BackColor = Color.Tan
        End Select
    End Sub

    '改變TextBox為MultiLine及改變背景顏色
    Protected Sub dvEmp_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvEmp.DataBound
        '在編輯及新增模式下將TextBox改為MultiLine及改變背景顏色
        If (dvEmp.Rows(1).Cells(1).Controls.Count > 0) Then
            CType(dvEmp.Rows(1).Cells(1).Controls(0), TextBox).TextMode = TextBoxMode.MultiLine
            CType(dvEmp.Rows(1).Cells(1).Controls(0), TextBox).BackColor = Color.LightBlue
            CType(dvEmp.Rows(2).Cells(1).Controls(0), TextBox).TextMode = TextBoxMode.MultiLine
            CType(dvEmp.Rows(2).Cells(1).Controls(0), TextBox).BackColor = Color.LightCoral
            CType(dvEmp.Rows(3).Cells(1).Controls(0), TextBox).TextMode = TextBoxMode.MultiLine
            CType(dvEmp.Rows(3).Cells(1).Controls(0), TextBox).BackColor = Color.LightGreen
            CType(dvEmp.Rows(4).Cells(1).Controls(0), TextBox).TextMode = TextBoxMode.MultiLine
            CType(dvEmp.Rows(4).Cells(1).Controls(0), TextBox).BackColor = Color.LightYellow
        End If
    End Sub

    '判斷使用者所按下的命令欄位按鈕
    Protected Sub dvEmp_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewCommandEventArgs) Handles dvEmp.ItemCommand
        Select Case e.CommandName
            Case "Edit"
                WebMessageBox.MessageBox.Show("您按下的是編輯按鈕!")
            Case "New"
                WebMessageBox.MessageBox.Show("您按下的是新增按鈕!")
            Case "Delete"
                WebMessageBox.MessageBox.Show("您按下的是刪除按鈕!")
            Case "Cancel"
                WebMessageBox.MessageBox.Show("您按下的是取消按鈕!")
            Case Else
                txtMsg.Text = ""
        End Select
    End Sub

    '取消刪除
    Protected Sub dvEmp_ItemDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewDeleteEventArgs) Handles dvEmp.ItemDeleting
        e.Cancel = True
        WebMessageBox.MessageBox.Show("已觸發刪除命令，但為確保原始資料故取消刪除命令！")
    End Sub
End Class
