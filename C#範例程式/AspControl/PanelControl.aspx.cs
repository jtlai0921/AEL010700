using System;
using System.Drawing;
using System.Web.UI.WebControls;

public partial class PanelControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AddControls();  //呼叫AddControls()方法
    }

    //動態建立TextBox程式，並加入到Panel之中
    protected void AddControls()
    {
        TextBox t1 = new TextBox();
        t1.Text = "動態加入第一個TextBox";
        t1.BackColor = Color.LightBlue;

        TextBox t2 = new TextBox();
        t2.Text = "動態加入第二個TextBox";
        t2.BackColor = Color.LightPink;

        TextBox t3 = new TextBox();
        t3.Text = "動態加入第三個TextBox";
        t3.BackColor = Color.LightGreen;

        TextBox t4 = new TextBox();
        t4.Text = "動態加入第四個TextBox";
        t4.BackColor = Color.LightSalmon;

        Panel1.Controls.Add(t1);    //將TextBox控制項加入到Panel之中
        Panel1.Controls.Add(t2);
        Panel1.Controls.Add(t3);
        Panel1.Controls.Add(t4);
    }

}
