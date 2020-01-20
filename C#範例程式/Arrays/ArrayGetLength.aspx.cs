using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ArrayGetLength : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<H2>計算陣列維度之長度</H2>");
        //取得一維陣列的長度（Length）
        string[] names = new string[] { "Kevin", "Mary", "Bob", "Cindy" };
        //指定參數0，可取得陣列的長度為4
        Response.Write("一維陣列第一個維度的長度為：" + names.GetLength(0) + "<BR/><BR/>");

        //取得二維陣列的長度（Length）
        int[,] myArray = new int[9, 5];
        Response.Write("二維陣列第一個維度的長度為：" + myArray.GetLength(0) + "<BR/>");
        Response.Write("二維陣列第二個維度的長度為：" + myArray.GetLength(1) + "<BR/>");
    }
}
