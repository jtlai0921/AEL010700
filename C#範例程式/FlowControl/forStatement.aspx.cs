using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class forStatement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<h1>For...Next陳述式</h1>");
        //遞增，動態加入Label控制項
        Label increase = new Label();
        increase.Text = "遞增：";
        //設定Label控制項字型大小
        increase.Font.Size = FontUnit.Point(36);
        //指定Label控制項前景顏色
        increase.ForeColor = Color.Red;
        //將Label控制項加入form1
        this.form1.Controls.Add(increase);
        //以for迴圈遞增字型大小
        for (int i = 0; i <= 10; i++)
        {
            Label label = new Label();
            label.Text = i + "  ";
            label.Font.Size = FontUnit.Point(16 + i * 4);
            label.ForeColor = Color.Blue;
            this.form1.Controls.Add(label);
        }

        //換行
        Label newLine=new Label();
        newLine.Text = "<BR/>";
        this.form1.Controls.Add(newLine);

        //遞減，動態加入Label控制項
        Label decrease = new Label();
        decrease.Text = "遞減：";
        //設定Label控制項字型大小
        decrease.Font.Size = FontUnit.Point(36);
        //指定Label控制項前景顏色
        decrease.ForeColor = Color.Red;
        //將Label控制項加入form1
        this.form1.Controls.Add(decrease);
        //以for迴圈遞減字型大小
        for (int i = 10; i >=0; i--)
        {
            Label label = new Label();
            label.Text = i + "  ";
            label.Font.Size = FontUnit.Point(16 + i * 4);
            label.ForeColor = Color.Blue;
            this.form1.Controls.Add(label);
        }
    }
}
