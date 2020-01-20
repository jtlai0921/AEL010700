using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class LinqDataSetTyped : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRead_Click(object sender, EventArgs e)
    {
        //實體化強型別DataSet
        dsNorthwind myDs = new dsNorthwind();
        //透過EmployeesTableAdapter將資料載入myDs.Employees的DataTable中
        dsNorthwindTableAdapters.EmployeesTableAdapter adapter = new dsNorthwindTableAdapters.EmployeesTableAdapter();
        adapter.Fill(myDs.Employees);

        //以LINQ查詢員工基本資料
        var Emps = from p in myDs.Employees
                   where p.EmployeeID < 10
                   select new { p.EmployeeID, p.LastName, p.FirstName, p.City, p.Address };

        GridView1.DataSource = Emps;
        GridView1.DataBind();
    }
}
