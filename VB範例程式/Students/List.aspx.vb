Imports System.Data

Partial Class List
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("Permission").ToString().Contains("R") Then
            Response.Redirect("Message.aspx?Reason=必須具備讀取權限")
        End If
    End Sub

    '如果沒有編輯或刪除權限，則將對應的Button按鈕隱藏
    Protected Sub gvStudents_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvStudents.DataBound
        Dim permission = Session("Permission").ToString()
        If Not permission.Contains("U") Or Not permission.Contains("D") Then
            Dim btnEdit As Button
            Dim btnDelete As Button
            For i = 0 To gvStudents.Rows.Count - 1
                If Not permission.Contains("U") Then
                    btnEdit = CType(gvStudents.Rows(i).Cells(0).Controls(1), Button) '編輯按鈕
                    If btnEdit.Text = "編輯" Then
                        btnEdit.Enabled = False
                    End If
                End If
                If Not permission.Contains("D") Then
                    btnDelete = CType(gvStudents.Rows(i).Cells(0).Controls(3), Button) '刪除按鈕
                    If btnDelete.Text = "刪除" Then
                        btnDelete.Enabled = False
                    End If
                End If
            Next
        End If
    End Sub

    '將Gender性別的Boolean，由True或False轉換成男或女
    Protected Sub gvStudents_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvStudents.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim view As DataRowView = CType(e.Row.DataItem, DataRowView)
            If view IsNot Nothing Then
                '取得Gender欄位資料
                If Not String.IsNullOrEmpty(view.Item(2)) Then
                    Dim gender As Boolean = view.Item(2)
                    Dim txtGender = CType(e.Row.Cells(3).FindControl("txtGender"), Label)
                    If txtGender IsNot Nothing Then
                        If gender = True Then
                            txtGender.Text = "男"
                        Else
                            txtGender.Text = "女"
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    '編輯模式時，設定欄位的寬度
    Protected Sub gvStudents_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvStudents.RowEditing
        gvStudents.Columns(2).ControlStyle.Width = 55
        gvStudents.Columns(4).ControlStyle.Width = 65
        gvStudents.Columns(6).ControlStyle.Width = 50
        gvStudents.Columns(7).ControlStyle.Width = 50
        gvStudents.Columns(10).ControlStyle.Width = 50
    End Sub

    '替身高的DropDownList加入項目
    Protected Sub dwnHeight_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dwnHeight = CType(sender, DropDownList)
        dwnHeight.Items.Add("==")
        For i = 155 To 185
            dwnHeight.Items.Add(i)
        Next
    End Sub

    '替體重的DropDownList加入項目
    Protected Sub dwnWeight_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dwnWeight = CType(sender, DropDownList)
        dwnWeight.Items.Add("==")
        For i = 50 To 90
            dwnWeight.Items.Add(i)
        Next
    End Sub

    'ToolTips屬性會Bind("Blood")，故選擇索引改變時，
    '設定ToolTip內容為選取文字，然後自動繫結回寫資料庫
    Protected Sub dwnBlood_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dwnBlood As DropDownList = CType(sender, DropDownList)
        If dwnBlood.SelectedValue <> 0 Then
            dwnBlood.ToolTip = dwnBlood.SelectedItem.Text
        End If
    End Sub

    'ToolTips屬性會Bind("Height")，故選擇索引改變時，
    '設定ToolTip內容為選取文字，然後自動繫結回寫資料庫
    Protected Sub dwnHeight_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dwnHeight = CType(sender, DropDownList)
        dwnHeight.ToolTip = dwnHeight.SelectedItem.Text
    End Sub

    'ToolTips屬性會Bind("Weight")，故選擇索引改變時，
    '設定ToolTip內容為選取文字，然後自動繫結回寫資料庫
    Protected Sub dwnWeight_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dwnWeight = CType(sender, DropDownList)
        dwnWeight.ToolTip = dwnWeight.SelectedItem.Text
    End Sub

    'ToolTips屬性會Bind("City")，故選擇索引改變時，
    '設定ToolTip內容為選取文字，然後自動繫結回寫資料庫
    Protected Sub dwnCity_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dwnCity = CType(sender, DropDownList)
        dwnCity.ToolTip = dwnCity.SelectedItem.Text
    End Sub
End Class
