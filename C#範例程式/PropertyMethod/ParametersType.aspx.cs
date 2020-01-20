using System;

public partial class ParametersType : System.Web.UI.Page
{
    int a = 3;
    int b = 4;
    int c, d;
    string x = "Kevin";

    //使用傳值參數
    protected void btnValue_Click(object sender, EventArgs e)
    {
        Operate(a, b);
        showResult();
    }

    //使用傳值參數
    protected void btnReference_Click(object sender, EventArgs e)
    {
        Operate(ref a, ref b);
        showResult();
    }

    //使用傳出參數
    protected void btnOut_Click(object sender, EventArgs e)
    {
        setValue(out c, out d);
        txtMsg.Text = "原始的變數值，c=null，d=null" + "<BR/>";
        txtMsg.Text += "變數c的值為：" + c + "<BR/>";
        txtMsg.Text += "變數d的值為：" + d + "<BR/>";
    }

    //傳值參數
    protected void Operate(int a, int b)
    {
        a = a * 2 + 1;  //這裡的a與b參數是複本
        b = b + 5;
    }

    //傳址參數
    protected void Operate(ref int a, ref int b)
    {
        a = a * 2 + 1;  //這裡的a與b參數是本尊的記憶體位址
        b = b + 5;
    }

    //傳出參數
    protected void setValue(out int c, out int d)
    {
        c = 100;  //這裡的a與b參數是本尊的記憶體位址
        d = 200;
    }

    //顯示a與b的結果
    void showResult()
    {
        txtMsg.Text = "原始的變數值，a=3，b=4" + "<BR/>";
        txtMsg.Text += "變數a的值為：" + a + "<BR/>";
        txtMsg.Text += "變數b的值為：" + b + "<BR/>";
    }
}
