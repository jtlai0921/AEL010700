using System;

public partial class ArrayRank : System.Web.UI.Page
{
    int[] myArray1;   //宣告第一個陣列
    int[,] myArray2;   //宣告第二個陣列
    int[,,] myArray3;   //宣告第三個陣列

    protected void Page_Load(object sender, EventArgs e)
    {
        //初始化陣列
        myArray1 = new int[2];
        myArray2 = new int[5,2];
        myArray3 = new int[10,5,2];
    }

    //取得陣列的維度
    protected void btnGetRank_Click(object sender, EventArgs e)
    {
        txtArray1.Text = myArray1.Rank.ToString();
        txtArray2.Text = myArray2.Rank.ToString();
        txtArray3.Text = myArray3.Rank.ToString();
    }
}

