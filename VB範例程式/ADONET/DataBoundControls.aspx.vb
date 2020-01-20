
Partial Class DataBoundControls
    Inherits System.Web.UI.Page

    '進行ASP.NET控制項的ADO.NET DataTable資料繫結
    Protected Sub btnDataBound_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDataBound.Click
        '呼叫getNames方法，將員工資料讀進DataTable
        Dim dtEmployees As DataTable = getNames()

        '1.DropDownList控制項繫結DataTable資料
        dwnEmps.DataSource = dtEmployees
        '指定DropDownList控制項之Text文字
        dwnEmps.DataTextField = dtEmployees.Columns("LastName").ToString()
        '指定DropDownList控制項之Value數值
        dwnEmps.DataValueField = dtEmployees.Columns("EmployeeID").ToString()
        dwnEmps.DataBind() '進行資料繫結

        '2.RadioButtonList控制項繫結DataTable資料
        rdoEmps.DataSource = dtEmployees
        '指定RadioButtonList控制項之Text文字
        rdoEmps.DataTextField = dtEmployees.Columns("LastName").ToString()
        '指定RadioButtonList控制項之Value數值
        rdoEmps.DataValueField = dtEmployees.Columns("EmployeeID").ToString()
        rdoEmps.RepeatDirection = RepeatDirection.Horizontal
        rdoEmps.DataBind() '進行資料繫結

        '3.CheckBoxList控制項繫結DataTable資料
        cbxEmps.DataSource = dtEmployees
        '指定CheckBoxList控制項之Text文字
        cbxEmps.DataTextField = dtEmployees.Columns("LastName").ToString()
        '指定CheckBoxList控制項之Value數值
        cbxEmps.DataValueField = dtEmployees.Columns("EmployeeID").ToString()
        cbxEmps.RepeatDirection = RepeatDirection.Horizontal
        cbxEmps.DataBind() '進行資料繫結

        '4.BulletList控制項繫結DataTable資料
        blEmps.DataSource = dtEmployees
        '指定BulletList控制項之Text文字
        blEmps.DataTextField = dtEmployees.Columns("LastName").ToString()
        '指定BulletList控制項之Value數值
        blEmps.DataValueField = dtEmployees.Columns("EmployeeID").ToString()
        blEmps.DataBind()  '進行資料繫結
    End Sub

    '取得員工LastName,並以DataTable型式回傳
    Protected Function getNames() As DataTable
        '取得Web.config中的資料庫連線字串設定
        Dim connString As String = WebConfigurationManager.ConnectionStrings("NorthwindConnection").ConnectionString
        Dim conn As New SqlConnection(connString)
        conn.Open()

        '建立SqlDataAdapter
        Dim da As New SqlDataAdapter("Select EmployeeID,LastName From Employees", conn)
        Dim dtEmp As New DataTable() '建立DataTable資料集
        da.Fill(dtEmp) '將資料注入到DataTable之中

        da.Dispose()
        conn.Close()
        conn.Dispose()

        Return dtEmp   '回傳員工DataTable資料
    End Function
End Class
