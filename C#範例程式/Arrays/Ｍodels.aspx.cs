using System;

public partial class Ｍodels : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string型別陣列，儲存模特兒名字
        string[] models = new string[5] { "Mary", "Kelly", "Cindy", "Rose", "Landy" };

        //int型別陣列，儲存模特兒身高
        int[] height = new int[5] { 180, 182, 178, 175, 182 };

        Response.Write("<H2>以一維陣列儲存模特兒名字及身高資料</H2>");
        Response.Write("模特兒的名字如下：");
        //以for陳述式讀取陣列元素
        for (int i = 0; i < models.Length; i++)
        {
            Response.Write(string.Format("<li>{0}</li>",models[i]));
        }

        Response.Write("<BR/><BR/>");
        Response.Write("模特兒的身高如下：");

        //以foreach陳述式讀取陣列元素
        foreach (int h in height)
        {
            Response.Write(string.Format("<li>{0}</li>", h));
        }
    }
}
