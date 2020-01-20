using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

public partial class DataBoundControls : System.Web.UI.Page
{
    //進行ASP.NET控制項的ADO.NET DataTable資料繫結
    protected void btnDataBound_Click(object sender, EventArgs e)
    {
        //呼叫getNames方法，將員工資料讀進DataTable
        DataTable dtEmployees=getNames();
        //1.DropDownList控制項繫結DataTable資料
        dwnEmps.DataSource = dtEmployees;
        //指定DropDownList控制項之Text文字
        dwnEmps.DataTextField = dtEmployees.Columns["LastName"].ToString();
        //指定DropDownList控制項之Value數值
        dwnEmps.DataValueField = dtEmployees.Columns["EmployeeID"].ToString();
        dwnEmps.DataBind(); //進行資料繫結

        //2.RadioButtonList控制項繫結DataTable資料
        rdoEmps.DataSource = dtEmployees;
        //指定RadioButtonList控制項之Text文字
        rdoEmps.DataTextField = dtEmployees.Columns["LastName"].ToString();
        //指定RadioButtonList控制項之Value數值
        rdoEmps.DataValueField = dtEmployees.Columns["EmployeeID"].ToString();
        rdoEmps.RepeatDirection = RepeatDirection.Horizontal;
        rdoEmps.DataBind(); //進行資料繫結

        //3.CheckBoxList控制項繫結DataTable資料
        cbxEmps.DataSource = dtEmployees;
        //指定CheckBoxList控制項之Text文字
        cbxEmps.DataTextField = dtEmployees.Columns["LastName"].ToString();
        //指定CheckBoxList控制項之Value數值
        cbxEmps.DataValueField = dtEmployees.Columns["EmployeeID"].ToString();
        cbxEmps.RepeatDirection = RepeatDirection.Horizontal;
        cbxEmps.DataBind(); //進行資料繫結

        //4.BulletList控制項繫結DataTable資料
        blEmps.DataSource = dtEmployees;
        //指定BulletList控制項之Text文字
        blEmps.DataTextField = dtEmployees.Columns["LastName"].ToString();
        //指定BulletList控制項之Value數值
        blEmps.DataValueField = dtEmployees.Columns["EmployeeID"].ToString();
        blEmps.DataBind();  //進行資料繫結
    }

    //取得員工LastName,並以DataTable型式回傳
    protected DataTable getNames()
    {
        //取得Web.config中的資料庫連線字串設定
        string connString = WebConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();

        //建立SqlDataAdapter
        SqlDataAdapter da = new SqlDataAdapter("Select EmployeeID,LastName From Employees", conn);
        DataTable dtEmp = new DataTable();     //建立DataTable資料表
        da.Fill(dtEmp);    //將資料注入到DataTable之中

        da.Dispose();
        conn.Close();
        conn.Dispose();

        return dtEmp;   //回傳員工DataTable資料
    }
}
