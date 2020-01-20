using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ArraySearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<H2>陣列元素的比對與搜尋</H2>");
        string[] names = new string[] { "Kevin", "Mary", "Bob", "Cindy","Larry","David","Joe","Cathy","Rose","Michael" };
        //列出陣列中所有的名字
        Response.Write("陣列中所有的名字：");
        foreach(string n in names)
        {
            Response.Write(n + " , ");
        }
        Response.Write("<BR/><BR/>");

        //Exists
        Response.Write("陣列中是否有名字的字元長度等於5：" + Array.Exists(names, getNameLength));
        Response.Write("<BR/><BR/>");

        //Find
        Response.Write("陣列中第一個名字字元長度等於5的是：" + Array.Find(names, getNameLength));
        Response.Write("<BR/><BR/>");

        //FindLast
        Response.Write("陣列中最後一個名字字元長度等於5的是：" + Array.FindLast(names, getNameLength));

        //FindAll
        Response.Write("<BR/><BR/>");
        Response.Write("陣列中名字字元長度等於5的所有名字如下：<UL>");

        string[] allNames = Array.FindAll(names, getNameLength);

        foreach (string n in allNames)
        {
            Response.Write("<Li>" + n);
        }
        Response.Write("</UL>");

        //Index
        Response.Write("Cindy於陣列中的索引值為：" + Array.IndexOf(names, "Cindy"));
        Response.Write("<BR/><BR/>");

        //BinarySearch
        System.Array.Sort(names);   //陣列必須先排序才能呼叫BinarySearch方法
        object person = "Mary";

        int index = System.Array.BinarySearch(names, person);

        if (index > 0)
        {
            Response.Write(string.Format("尋找{0}的名字位於陣列的索引位置為：{1}", person, index));
        }
    }

    //判斷陣列中名字的字元長度是否有等於5
    protected static bool getNameLength(string name)
    {
        if (name.Length == 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
