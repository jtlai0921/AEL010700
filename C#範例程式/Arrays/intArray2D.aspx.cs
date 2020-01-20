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

public partial class intArray2D : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //第一種，明確指定陣列大小
		int[,] myArray1=new int[4,2]{{1,2},{3,4},{5,6},{7,8}};

        //第二種，省略陣列大小
		int[,] myArray2=new int[,] {{1,2},{3,4},{5,6},{7,8}};

        //第三種，省略掉new int [,]
		int[,] myArray3={{1,2},{3,4},{5,6},{7,8}};

        //第四種，先宣告陣列，稍後再指定陣列元素的值
		int[,] myArray4=new int[4,2];
		myArray4[0,0]=1;
		myArray4[0,1]=2;
		myArray4[1,0]=3;
		myArray4[1,1]=4;
		myArray4[2,0]=5;
		myArray4[2,1]=6;
		myArray4[3,0]=7;
		myArray4[3,1]=8;

        //顯示myArray1~myArray4陣列的元素值
        Response.Write("<H2>二維的int型別陣列之四種初始化方式</H2>");
        Response.Write(String.Format("myArray1[0, 1]的元素值：{0}<BR/>", myArray1[0, 1]));
        Response.Write(String.Format("myArray2[1, 1]的元素值：{0}<BR/>", myArray2[1, 1]));
        Response.Write(String.Format("myArray3[2, 0]的元素值：{0}<BR/>", myArray3[2, 0]));
        Response.Write(String.Format("myArray4[3, 1]的元素值：{0}<BR/>", myArray4[3, 1]));
    }
}
