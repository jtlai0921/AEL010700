using System;

public partial class MathMethod : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //以Abs計算絕對值
        Response.Write(string.Format("<Font Color='Blue'><<{0}>><BR/></Font>", "以Abs計算絕對值"));

        decimal a = -1.3549M;
        Response.Write(string.Format("{0}的{1}為：{2}",a,"Abs絕對值",Math.Abs(a)));

        //以Max傳回最大的數值
        decimal value1 = 3939889;
        decimal value2 = 8825252;

        Response.Write(stringFormat("以Max傳回最大的數值"));
        Response.Write(string.Format("{0}與{1}二者以Max計算最大值為：{2}", value1, value2, Math.Max(value1, value2)));

        //以Min傳回最小的數值
        Response.Write(stringFormat("以Min傳回最小的數值"));
        Response.Write(string.Format("{0}與{1}二者以Min計算最小值為：{2}", value1, value2, Math.Min(value1, value2)));

        //以DivRem計算商數及餘數
        Response.Write(stringFormat("以DivRem計算商數"));
        int x=8;
        int y=3;
        int quotient;   //商數
        int remainder;  //餘數
        quotient=Math.DivRem(x, y, out remainder);
        Response.Write(string.Format("{0}除以{1}的商數為：{2}，餘數為：{3}", x, y, quotient, remainder));

        //以Round進行四捨五入計算
        Response.Write(stringFormat("以Round進行四捨五入計算"));
        Response.Write(Math.Round(4.4) + "<BR/>");
        Response.Write(Math.Round(4.5) + "<BR/>");
        Response.Write(Math.Round(4.6) + "<BR/>");
        Response.Write(Math.Round(5.5) + "<BR/>");

        Response.Write(Math.Round(4.445, 2, MidpointRounding.ToEven) + "<BR/>");
        Response.Write(Math.Round(4.445, 2, MidpointRounding.AwayFromZero) + "<BR/>");
    }

    //自訂字串格式化方法
    protected string stringFormat(string txtString)
    {
        string param = "<BR/><BR/><Font Color='Blue'><<{0}>><BR/></Font>";
        return string.Format(param, txtString);
    }
}
