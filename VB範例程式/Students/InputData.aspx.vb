
Partial Class InputData
    Inherits System.Web.UI.Page

    Dim InputMsg As String = ""  '欄位輸入驗證之訊息

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '檢查是否具有學生資料讀取權限
        Dim permission As String = Session("Permission")
        If Not (permission.Contains("R") And permission.Contains("C")) Then
            Response.Redirect("Message.aspx?Reason=必須同時具備讀取與新增權限")
        End If

        '產生控制項資料
        Dim dwnHeight As DropDownList = dvStudent.FindControl("dwnHeight")
        Dim dwnWeight As DropDownList = dvStudent.FindControl("dwnWeight")
        dwnHeight.Items.Add("=請選擇=")
        For i = 155 To 185
            dwnHeight.Items.Add(i)
        Next
        dwnWeight.Items.Add("=請選擇=")
        For i = 50 To 90
            dwnWeight.Items.Add(i)
        Next

        Dim rdo = CType(dvStudent.FindControl("rdoGender"), RadioButtonList)

    End Sub

    Protected Sub dvStudent_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewInsertEventArgs) Handles dvStudent.ItemInserting
        'Dim txtBirthday = CType(dvStudent.FindControl("txtBirthday"), TextBox)
        '檢查是否有新增資料之權限
        If Not Session("Permission").ToString().Contains("C") Then
            e.Cancel = True     '若沒有新增權限，則取消插入動作
        Else
            '新增資料前，進行輸入資料之檢查
            If CheckInput() = False Then
                txtMsg.Text = "<ul>" & InputMsg & "</ul>"
                e.Cancel = True
            End If
        End If
    End Sub

    Protected Sub dvStudent_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewInsertedEventArgs) Handles dvStudent.ItemInserted
        If e.AffectedRows > 0 Then
            txtMsg.Text = "新增資料成功！"
        Else
            txtMsg.Text = "新增資料失敗！"
        End If
    End Sub

    Protected Function CheckInput() As Boolean
        'Input輸入合法性檢查,預設為True
        Dim status As Boolean = True

        '檢查ID帳號不得為空白
        If String.IsNullOrEmpty(CType(dvStudent.FindControl("txtID"), TextBox).Text.Trim()) Then
            status = False
            InputMsg &= "<li>＊請輸入ID帳號</li>"
        End If
        '檢查姓名不得為空白
        If String.IsNullOrEmpty(CType(dvStudent.FindControl("txtName"), TextBox).Text.Trim()) Then
            status = False
            InputMsg &= "<li>＊請輸入姓名</li>"
        End If

        '檢查性別是否有選取
        Dim rdoGender = CType(dvStudent.FindControl("rdoGender"), RadioButtonList)
        If rdoGender.SelectedIndex = -1 Then
            status = False
            InputMsg &= "<li>＊請輸入性別</li>"
        End If

        '檢查血型是否有選擇
        Dim rdoBlood = CType(dvStudent.FindControl("rdoBlood"), RadioButtonList)
        If rdoBlood.SelectedIndex = -1 Then
            status = False
            InputMsg &= "<li>＊請選擇血型</li>"
        End If

        '身高
        If CType(dvStudent.FindControl("dwnHeight"), DropDownList).SelectedIndex = 0 Then
            status = False
            InputMsg &= "<li>＊請輸入身高</li>"
        End If

        '體重
        If CType(dvStudent.FindControl("dwnWeight"), DropDownList).SelectedIndex = 0 Then
            status = False
            InputMsg &= "<li>＊請輸入體重</li>"
        End If

        '縣市
        If CType(dvStudent.FindControl("dwnCity"), DropDownList).SelectedIndex = 0 Then
            status = False
            InputMsg &= "<li>＊請輸入縣市</li>"
        End If


        '檢查地址不得為空白
        If String.IsNullOrEmpty(CType(dvStudent.FindControl("txtAddress"), TextBox).Text.Trim()) Then
            status = False
            InputMsg &= "<li>＊請輸入地址</li>"
        End If

        '檢查電話不得為空白
        If String.IsNullOrEmpty(CType(dvStudent.FindControl("txtTel"), TextBox).Text.Trim()) Then
            status = False
            InputMsg &= "<li>＊請輸入電話</li>"
        End If

        Return status
    End Function

    '性別,ToolTip屬性與資料來源欄位是Bind雙向繫結
    Protected Sub rdoGender_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        '故將DropDownList選取項目指定給ToolTip屬性
        '在Insert到資料庫時，它會自動寫入到欄位
        Dim rdoGender = CType(dvStudent.FindControl("rdoGender"), RadioButtonList)
        rdoGender.ToolTip = IIf(rdoGender.SelectedItem.Text = "男", True, False)
    End Sub

    '血型
    Protected Sub rdoBlood_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim rdoBlood = CType(dvStudent.FindControl("rdoBlood"), RadioButtonList)
        rdoBlood.ToolTip = rdoBlood.SelectedItem.Text
    End Sub

    '身高
    Protected Sub dwnHeight_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dwnHeight = CType(sender, DropDownList)
        dwnHeight.ToolTip = dwnHeight.SelectedItem.Text
    End Sub

    '體重
    Protected Sub dwnWeight_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dwnWeight = CType(sender, DropDownList)
        dwnWeight.ToolTip = dwnWeight.SelectedItem.Text
    End Sub

    Protected Sub dwnCity_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dwnCity = CType(sender, DropDownList)
        dwnCity.ToolTip = dwnCity.SelectedItem.Text
    End Sub
End Class
