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

public partial class intArray : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //第一種，初始化明確指定陣列的大小為5
        int[] myArray1 = new int[5] { 1, 3, 5, 7, 9 };

        //第二種，初始化省略陣列的大小
        int[] myArray2 = new int[] { 1, 3, 5, 7, 9 };

        //第三種，初始化省略掉new int[]的陳述式
        int[] myArray3 = { 1, 3, 5, 7, 9 };

        //第四種，先宣告及初始化陣列，稍後再指定陣列元素的值
        int[] myArray4 = new int[5];
        myArray4[0] = 1;
        myArray4[1] = 3;
        myArray4[2] = 5;
        myArray4[3] = 7;
        myArray4[4] = 9;

        //顯示myArray1~myArray4陣列的元素值
        Response.Write("<H2>一維的int型別陣列之四種初始化方式</H2>");
        Response.Write(String.Format("myArray1的元素值：{0}<BR/>", myArray1[0]));
        Response.Write(String.Format("myArray2的元素值：{0}<BR/>", myArray1[1]));
        Response.Write(String.Format("myArray3的元素值：{0}<BR/>", myArray1[3]));
        Response.Write(String.Format("myArray4的元素值：{0}<BR/>", myArray1[4]));
    }
}
