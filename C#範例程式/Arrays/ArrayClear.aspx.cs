using System;

public partial class ArrayClear : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //以下陣列為學生姓名、身高與姓別之資料
        string[] names = new string[] {"Kevin","Mary","Bob","Cindy" };  //string型別陣列
        int[] height = new int[] { 180, 168, 172, 165 };                //int型別陣列
        bool[] gender = new bool[] { true, false, true, false };        //bool型別陣列

        Response.Write("<H2>陣列清除</H2>")
        //學生資料
        Response.Write("學生姓名、身高與資料如下：<DIR>");
        for (int i = 0; i < names.Length; i++)
        {
            Response.Write("<li>" + names[i] + " , " + height[i] + " , " + gender[i] + "</li>");
        }
        Response.Write("</DIR>");

        //清除陣列
        System.Array.Clear(names, 0, 4);
        System.Array.Clear(height, 0, height.Length);
        System.Array.Clear(gender, 0, gender.Length);

        //顯示清除後陣列
        Response.Write("陣列清除後的學生姓名、身高與資料如下：<DIR>");
        for (int i = 0; i < names.Length; i++)
        {
            Response.Write("<li>" + (names[i] == null ? "null" : names[i]) + " , " + height[i] + " , " + gender[i] + "</li>");
        }
        Response.Write("</DIR>");
    }
}
