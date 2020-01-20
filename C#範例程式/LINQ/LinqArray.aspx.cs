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

public partial class LinqArray : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Step 1：定義集合Array
        //int[] students = new int[] { 180, 165, 174, 152, 183, 177, 175, 188, 168, 170, 173, 174 };

        //或者你也可以用隱含型別陣列宣告
        var students = new[] { 180, 165, 174, 152, 183, 177, 175, 188, 168, 170, 173, 174 };

        //Step 2：定義LINQ查詢語法
        var tall = from s in students
                   where s > 172 
                   select s;

        //Step 3:以foreach讀取集合資料
        Response.Write("<h2>以LINQ查詢陣列資料</h2>");
        Response.Write(string.Format("身高大於172cm的學生人數有{0}人，身高資料如下：<BR/>",tall.Count()));
        foreach (var t in tall)
        {
            Response.Write(t + " ");
        }
    }
}
