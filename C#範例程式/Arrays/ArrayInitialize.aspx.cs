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

public partial class ArrayInitialize : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int[] price;           //int型別陣列宣告
        price = new int[5];    //陣列初始化

        string[] models;        //string型別陣列宣告
        models = new string[5]; //陣列初始化

        int x = 0;
        Response.Write(x);

        //陣列的宣告與初始化
        int[] Height = new int[5] { 182, 170, 165, 174, 152 };
    }
}
