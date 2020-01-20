using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ArraySync : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int[] students = new int[] { 180,175,168,152,173 };
        Response.Write("是否為同步："+students.IsSynchronized+"<BR/>");
        lock (students.SyncRoot)
        {
            Response.Write("是否為同步：" + students.IsSynchronized + "<BR/>");
            foreach (int s in students)
            {
                Response.Write(s + "<BR/>");
            }
        }

    }
}
