using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class arrayScores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //計算每位學生考試分數
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        //建立3列3行之二維陣列
        int[,] products = new int[3, 3] { { 78, 92, 85 }, { 85, 87, 90 }, { 82, 100, 88 } };

        //計算每位學生之考試總分
        txtA.Text = Convert.ToString(products[0, 0] + products[0, 1] + products[0, 2]);
        txtB.Text = Convert.ToString(products[1, 0] + products[1, 1] + products[1, 2]);
        txtC.Text = Convert.ToString(products[2, 0] + products[2, 1] + products[2, 2]);
    }
}