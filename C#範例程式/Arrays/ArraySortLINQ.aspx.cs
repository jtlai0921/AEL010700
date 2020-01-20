using System;
using System.Linq;

public partial class ArraySortLINQ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //方法一，傳統之陣列排序，適用於.NET 1.0,1.1,2.0,3.0,3.5,4.0
        //int型別陣列，陣列中元素為學生身高
        int[] heights = new int[] { 172, 168, 175, 165, 160, 152, 183, 167, 180, 174 };

        Response.Write("<H2>原始陣列元素資料：</H2>");
        foreach (int h in heights)
        {
            Response.Write(h + " ");
        }

        //使用Array.Sort()方法來進行排序
        Array.Sort(heights);
        //顯示學生身高
        Response.Write("<H2>傳統的學生身高排序（ascending）如下：</H2>");
        foreach (int h in heights)
        {
            Response.Write(h + " ");
        }

        //方法二，以LINQ語法進行陣列元素之查詢與排序,ascending
        //僅適用於.NET Framework 3.5以上之LINQ
        Response.Write("<H2>以LINQ語法進行陣列元素之查詢與排序（ascending）</H2>");

        var students = from h in heights
                       orderby h ascending
                       select h;

        foreach (var s in students)
        {
            Response.Write(s + " ");
        }

        //以LINQ語法進行陣列元素之查詢與排序,descending
        Response.Write("<H2>以LINQ語法進行陣列元素之查詢與排序（descending）</H2>");

        var students2 = from h in heights
                        orderby h descending
                        select h;

        foreach (var s in students2)
        {
            Response.Write(s + " ");
        }

        //方法三，以C# 3.0的Lambda表示式來進行排序
        //僅適用於.NET Framework 3.5以上的C# 3.0語法
        Response.Write("<H2>以C#的Lambda表示式來進行排序（ascending）</H2>");
        var students3 = heights.OrderBy(x => x);

        foreach (var s in students3)
        {
            Response.Write(s + " ");
        }  
    }
}
