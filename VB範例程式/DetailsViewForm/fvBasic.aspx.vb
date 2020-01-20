Imports System.Data
Imports System.Drawing

Partial Class fvBasic
    Inherits System.Web.UI.Page

    '在資料FormView完成資料繫結後存取其內容資料
    Protected Sub fvEmployee_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles fvEmployee.DataBound
        If (fvEmployee.CurrentMode = FormViewMode.ReadOnly) Then
            '透過DataRowView來讀取資料欄位，這方法也適用於DetailsView
            Dim drView As DataRowView = CType(fvEmployee.DataItem, DataRowView)
            txtMsg1.Text = "<Font Color='Red'>這是DataRowView</Font><BR>"
            txtMsg1.Text &= drView("EmployeeID") & "<BR>"
            txtMsg1.Text &= drView("LastName") & "<BR>"
            txtMsg1.Text &= drView("FirstName") & "<BR>"
            txtMsg1.Text &= drView("City") & "<BR>"
            txtMsg1.Text &= drView("Country") & "<BR>"

            '透過尋找Label控制項的方式來達成
            Dim Row As FormViewRow = fvEmployee.Row
            txtMsg2.Text = "<Font Color='Red'>這是FormViewRow</Font><BR>"
            txtMsg2.Text &= CType(Row.FindControl("txtEmployeeID"), Label).Text & "<BR>"
            txtMsg2.Text &= CType(Row.FindControl("txtLastName"), Label).Text & "<BR>"
            txtMsg2.Text &= CType(Row.FindControl("txtFirstName"), Label).Text & "<BR>"
            txtMsg2.Text &= CType(Row.FindControl("txtCity"), Label).Text & "<BR>"
            txtMsg2.Text &= CType(Row.FindControl("txtCountry"), Label).Text & "<BR>"
        End If

        AddPagerIndex() '加入Page索引
    End Sub

    '建立及取得FormView的HeaderRow及HeaderRow
    Protected Sub AddPagerIndex()
        '目的是為了加入Page參考索引筆數
        Dim headerRow As FormViewRow = fvEmployee.HeaderRow
        Dim footerRow As FormViewRow = fvEmployee.FooterRow
        Dim bottomPagerRow As FormViewRow = fvEmployee.BottomPagerRow
        headerRow.BackColor = Color.Red
        footerRow.BackColor = Color.LightBlue

        Dim txtPagerNo1 As New Label()
        Dim txtPagerNo2 As New Label()
        txtPagerNo1.Text = "員工基本資料維護( " & (fvEmployee.DataItemIndex + 1) & "/" & fvEmployee.DataItemCount.ToString() & " )"
        txtPagerNo2.Text = "資料項目索引( " & (fvEmployee.DataItemIndex + 1) & "/" & fvEmployee.DataItemCount.ToString() & ")"
        headerRow.Cells(0).Controls.Add(txtPagerNo1)
        bottomPagerRow.Cells(0).Controls.Add(txtPagerNo2)
    End Sub

    Protected Sub fvEmployee_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fvEmployee.PageIndexChanged
        AddPagerIndex() '加入Page索引
    End Sub

    '取消刪除作業
    Protected Sub fvEmployee_ItemDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewDeleteEventArgs) Handles fvEmployee.ItemDeleting
        e.Cancel = True
        WebMessageBox.MessageBox.Show("已觸發刪除命令，但為確保原始資料故取消刪除命令！")
    End Sub

    Protected Sub fvEmployee_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles fvEmployee.ItemCommand
        Select Case e.CommandName
            Case "Edit"
                WebMessageBox.MessageBox.Show("您按下的是編輯按鈕!")
            Case "New"
                WebMessageBox.MessageBox.Show("您按下的是新增按鈕!")
            Case "Delete"
                WebMessageBox.MessageBox.Show("您按下的是刪除按鈕!")
            Case "Cancel"
                WebMessageBox.MessageBox.Show("您按下的是取消按鈕!")
        End Select
    End Sub
End Class
