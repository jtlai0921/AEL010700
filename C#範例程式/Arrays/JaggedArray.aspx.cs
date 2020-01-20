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

public partial class JaggedArray : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //宣告不規則陣列
        int[][] myJaggedArray = new int[3][];

        //設定陣列元素
        myJaggedArray[0] = new int[2] { 3, 5 };
        myJaggedArray[1] = new int[3] { 1, 2, 4 };
        myJaggedArray[2] = new int[4] { 5, 2, 4, 3 };

        //存取不規則陣列元素資料
        Response.Write(myJaggedArray[0][1] + "<BR/>");
        Response.Write(myJaggedArray[1][2] + "<BR/>");
        Response.Write(myJaggedArray[2][3] + "<BR/>");
    }
}
