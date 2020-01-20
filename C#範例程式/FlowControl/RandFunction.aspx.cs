using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class RandFunction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRand_Click(object sender, EventArgs e)
    {
        //建立並初始化亂數產生器
        Random rnd = new Random();

        //以亂數產生12~36的字型大小
        int size = rnd.Next(12, 36);
        txtTitle.Font.Size = FontUnit.Point(size);

        //以亂數產生0~255前景色數值
        int r = rnd.Next(0, 255);   //Red紅色
        int g = rnd.Next(0, 255);   //Green綠色
        int b = rnd.Next(0, 255);   //Blue藍色

        //以亂數設定標題前景色（Red , Green , Blue）
        txtTitle.ForeColor = Color.FromArgb(r, g, b);

        //以亂數產生0~255背景色數值
        int r1 = rnd.Next(0, 255);   //Red紅色
        int g1 = rnd.Next(0, 255);   //Green綠色
        int b1 = rnd.Next(0, 255);   //Blue藍色

        //以亂數設定標題背景色（Red , Green , Blue）
        txtTitle.BackColor = Color.FromArgb(r1, g1, b1);

        txtMsg.Text = "字型大小為：" + size + "<BR/>";
        txtMsg.Text += String.Format("前景色：Red：{0} , Green：{1} , Blue：{2}", r, g, b);
        txtMsg.Text += "<BR/>" + String.Format("背景色：Red：{0} , Green：{1} , Blue：{2}", r1, g1, b1);
    }
}