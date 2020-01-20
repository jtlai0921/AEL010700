
Partial Class DwnControl
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim item As New ListItem("===請先選擇區域===", "0")
            dwnCity.Items.Add(item)
            dwnCity.Items(0).Selected = True
            dwnCity.Enabled = False
        End If
    End Sub

    '區域DropDownList選擇改變時，動態建立相對應之城市DropDownList項目
    Protected Sub dwnRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dwnRegion.SelectedIndexChanged
        '清除DropDownList控制項之所有項目
        dwnCity.Items.Clear()

        Select Case dwnRegion.SelectedValue
            Case "0"
                '加入項目到DropDownList控制項
                dwnCity.Items.Add(New ListItem("===請先選擇區域===", "0"))
                dwnCity.Enabled = False
            Case "1"
                dwnCity.Items.Add(New ListItem("===請選擇城市===", "0"))
                dwnCity.Items.Add(New ListItem("紐約", "1"))
                dwnCity.Items.Add(New ListItem("芝加哥", "2"))
                dwnCity.Items.Add(New ListItem("拉斯維加斯", "3"))
                dwnCity.Enabled = True
            Case "2"
                dwnCity.Items.Add(New ListItem("===請選擇城市===", "0"))
                dwnCity.Items.Add(New ListItem("北京", "1"))
                dwnCity.Items.Add(New ListItem("上海", "2"))
                dwnCity.Items.Add(New ListItem("香港", "3"))
                dwnCity.Enabled = True
            Case "3"
                dwnCity.Items.Add(New ListItem("===請選擇城市===", "0"))
                dwnCity.Items.Add(New ListItem("台北", "1"))
                dwnCity.Items.Add(New ListItem("台中", "2"))
                dwnCity.Items.Add(New ListItem("高雄", "3"))
                dwnCity.Enabled = True
        End Select
    End Sub

    '顯示居住所在地區及城市
    Protected Sub dwnCity_SelectedIndexChanged(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles dwnCity.SelectedIndexChanged
        If dwnCity.SelectedValue <> 0 Then
            txtMsg.Text = String.Format("您居住的地點為{0}，{1}", _
              dwnRegion.SelectedItem.Text, dwnCity.SelectedItem.Text)
        Else
            txtMsg.Text = ""
        End If
    End Sub
End Class
