using System;

public partial class MethodParam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //計算斜邊c的長度
    private double getLength(string a, string b)
    {
        double valueA = Convert.ToDouble(a);
        double valueB = Convert.ToDouble(b);
        double valueC = Math.Sqrt(Math.Pow(valueA, 2) + Math.Pow(valueB, 2));
        /*較為嚴謹的驗證程式
        double valueA;
        double valueB;
        double valueC;
        if (double.TryParse(a, out valueA) && double.TryParse(b, out valueB))
        {
            //計算a+b的平方根
            valueC = Math.Sqrt(Math.Pow(valueA, 2) + Math.Pow(valueB, 2));

        }
        else
        {
            valueC = -1;
        }
         * */

        return valueC;
    }


    //計算斜邊c的長度
    protected void btnCal_Click(object sender, EventArgs e)
    {
        string a = txtA.Text;
        string b = txtB.Text;
        txtMsg.Text = "斜邊c的長度為：" + getLength(a, b).ToString();

        /*較為嚴謹的驗證程式
        string a = txtA.Text;
        string b = txtB.Text;
        if (!string.IsNullOrEmpty(a) && !string.IsNullOrEmpty(b))
        {
            double c=getLength(a, b);
            if (c != -1)
            {
                txtMsg.Text = "斜邊c的長度為：" + c;
            }
            else
            {
                txtMsg.Text = "字串輸入格式不正確！";
            }
        }
        else
        {
            txtMsg.Text = "請輸入字串！";
        }
         * */
    }
}
