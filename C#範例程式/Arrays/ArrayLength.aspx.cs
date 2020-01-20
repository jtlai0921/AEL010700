using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ArrayLength : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //以亂數動態建立不固定長度陣列
    protected void btnArray_Click(object sender, EventArgs e)
    {
        txtLength.Text = "陣列的長度為：";
        txtArray.Text = null;           //將TextBox控制項清空

        Random rnd = new Random();      //建立亂數rnd instance
        int len = rnd.Next(1, 10);      //產生一個介於1~10之間的亂數值
        int[] myArray = new int[len];	//建立一個以len為長度的陣列

        for (int i = 0; i < len; i++)
        {
            myArray[i] = rnd.Next(1, 50);   //以隨機亂數指定陣列元素值
            //將陣列元素值加到TextBox之中
            txtArray.Text += Convert.ToString(myArray[i]) + "\n";
        }

        //讀取得陣列的長度，取得陣列元素總數目
        txtLength.Text += Convert.ToString(myArray.Length);	
    }
}
