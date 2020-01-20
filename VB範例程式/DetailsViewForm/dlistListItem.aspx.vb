Imports System.Drawing

Partial Class dlistListItem
    Inherits System.Web.UI.Page

    '讀取DataList資料項目
    Protected Sub dlistEmployees_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlistEmployees.ItemDataBound
        Dim txtEmpInfo As String
        Select Case e.Item.ItemType
            Case ListItemType.Header
                dlistEmployees.HeaderStyle.BackColor = Color.Red
            Case ListItemType.Item
                txtEmpInfo = ""
                txtEmpInfo &= CType(e.Item.Controls(0), LiteralControl).Text
                txtEmpInfo &= CType(e.Item.Controls(1), Label).Text & "："
                txtEmpInfo &= CType(e.Item.Controls(3), Label).Text & "  "
                txtEmpInfo &= CType(e.Item.Controls(5), Label).Text & ", "
                txtEmpInfo &= CType(e.Item.Controls(7), Label).Text & ", "
                txtEmpInfo &= CType(e.Item.Controls(9), Label).Text
                '顯示DataList中Item資料內容
                Response.Write(txtEmpInfo & "<br/>")
            Case ListItemType.AlternatingItem
                txtEmpInfo = ""
                txtEmpInfo &= CType(e.Item.Controls(0), LiteralControl).Text
                txtEmpInfo &= CType(e.Item.FindControl("txtEmployeeID"), Label).Text & "： "
                txtEmpInfo &= CType(e.Item.FindControl("txtLastName"), Label).Text & " "
                txtEmpInfo &= CType(e.Item.FindControl("txtFirstName"), Label).Text & " "
                txtEmpInfo &= CType(e.Item.FindControl("txtCity"), Label).Text & ", "
                txtEmpInfo &= CType(e.Item.FindControl("txtCountry"), Label).Text & " "
                '顯示DataList中Item資料內容
                Response.Write(txtEmpInfo & "<br/>")
            Case ListItemType.Footer
                dlistEmployees.FooterStyle.BackColor = Color.LightBlue
        End Select
    End Sub
End Class
