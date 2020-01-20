using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Overloading : System.Web.UI.Page
{
    protected int i = 0;
    protected static string[] students;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            students = new string[] { "Mary", "Kevin", "Tom", "John", "Bob" };
            gvStudents.DataSource = students;
            gvStudents.DataBind();
        }
    }

    //多載方法一，設定預設的欄位顏色
    protected void formatGrid()
    {
        gvStudents.Columns[0].HeaderStyle.BackColor = Color.Orange;
        gvStudents.Columns[0].ItemStyle.BackColor = Color.Orange;
        gvStudents.Columns[1].HeaderStyle.BackColor = Color.LightGreen;
        gvStudents.Columns[1].ItemStyle.BackColor = Color.LightGreen;
        gvStudents.Caption = "";
    }

    //多載方法二，設定GridView欄位顏色及標題
    protected void formatGrid(string Header)
    {
        gvStudents.Columns[0].HeaderStyle.BackColor = Color.LightPink;
        gvStudents.Columns[0].ItemStyle.BackColor = Color.LightPink;
        gvStudents.Columns[1].HeaderStyle.BackColor = Color.LightBlue;
        gvStudents.Columns[1].ItemStyle.BackColor = Color.LightBlue;
        gvStudents.Caption = "<div style='background:Yellow'>" + Header + "</div>";
    }

    //多載方法三，設定GridView自訂的欄位顏色及標題
    protected void formatGrid(string Header,Color color1, Color color2)
    {
        gvStudents.Columns[0].HeaderStyle.BackColor = color1;
        gvStudents.Columns[0].ItemStyle.BackColor = color1;
        gvStudents.Columns[1].HeaderStyle.BackColor = color2;
        gvStudents.Columns[1].ItemStyle.BackColor = color2;
        gvStudents.Caption = "<div style='background:Yellow'>" + Header + "</div>";
    }

    protected void dwnFormat_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (dwnFormat.SelectedValue)
        {
            case "一":
                formatGrid();
                break;
            case "二":
                formatGrid("學生名單");
                break;
            case "三":
                Color color1 = Color.Maroon;
                Color color2 = Color.Magenta;
                formatGrid("學生名單", color1, color2);
                break;
        }

        gvStudents.DataSource = students;
        gvStudents.DataBind();
    }
}
