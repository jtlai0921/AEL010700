
Partial Class LinqDataSetTyped
    Inherits System.Web.UI.Page

    Protected Sub btnRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRead.Click
        '實體化強型別DataSet
        Dim myDs As New dsNorthwind()
        '透過EmployeesTableAdapter將資料載入myDs.Employees的DataTable中
        Dim adapter As New dsNorthwindTableAdapters.EmployeesTableAdapter()
        adapter.Fill(myDs.Employees)

        '以LINQ查詢員工基本資料
        Dim Emps = From p In myDs.Employees _
                   Where p.EmployeeID < 10 _
                   Select New With {p.EmployeeID, p.LastName, p.FirstName, p.City, p.Address}

        '將資料顯示在GridView之中
        gvEmployees.DataSource = Emps
        gvEmployees.DataBind()
    End Sub
End Class
