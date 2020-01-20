using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ArraySortBasic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //建立陣列，並排序
    protected void btnSort_Click(object sender, EventArgs e)
    {
        txtBefore.Text = null;
        //排序前的陣列
        int[] myArray = new int[10];

        //以亂數產生陣列
        Random rnd = new Random();
        for (int i = 0; i <= 9; i++)
        {
            myArray[i] = rnd.Next(0, 100);
            txtBefore.Text += Convert.ToString(myArray[i]) + "\n";
        }

        txtAfter.Text = null;
        //排序後的陣列
        System.Array.Sort(myArray);
        for (int i = 0; i <= 9; i++)
        {
            txtAfter.Text += Convert.ToString(myArray[i]) + "\n";
        }
    }
}
