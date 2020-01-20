using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PldControl : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        AddControls();  //呼叫AddControls()方法
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    //動態加入控制項到PlaceHolder之中
    protected void AddControls()
    {
        //動態建立使用者姓名控制項
        Label capName = new Label();
        capName.Text = "姓名：";

        TextBox txtName = new TextBox();
        txtName.ID = "UserName";

        //將控制項加入到PlaceHolder1之中
        PlaceHolder1.Controls.Add(capName);
        PlaceHolder1.Controls.Add(txtName);
        PlaceHolder1.Controls.Add(new LiteralControl("<BR/>"));

        //動態建立使用者國家控制項
        Label capCountry = new Label();
        capCountry.Text = "國家：";

        TextBox txtCountry = new TextBox();
        txtCountry.ID = "Country";
        //將控制項加入到PlaceHolder1之中
        PlaceHolder1.Controls.Add(capCountry);
        PlaceHolder1.Controls.Add(txtCountry);
        PlaceHolder1.Controls.Add(new LiteralControl("<BR>"));
       
        //動態建立使用者城市控制項
        Label capCity = new Label();
        capCity.Text = "城市：";

        TextBox txtCity = new TextBox();
        txtCity.ID = "City";
        //將控制項加入到PlaceHolder1之中
        PlaceHolder1.Controls.Add(capCity);
        PlaceHolder1.Controls.Add(txtCity);
        PlaceHolder1.Controls.Add(new LiteralControl("<BR>"));

        //建立確定按鈕
        Button btnOK = new Button();
        btnOK.Text = "確定";

        PlaceHolder1.Controls.Add(btnOK);
        PlaceHolder1.Controls.Add(new LiteralControl("<BR/>"));

        //動態建立Button的Click事件委派程式
        btnOK.Click += new EventHandler(btnOK_Click);
    }

    //顯示使用者輸入資料
    void btnOK_Click(object sender, EventArgs e)
    {
        Label txtMsg = new Label();
        txtMsg.Text = "<BR/>";
        txtMsg.ForeColor = Color.Blue;
        txtMsg.Text += "<BR/>您輸入的個人資料是：<BR/>";
        txtMsg.Text += ((TextBox)form1.FindControl("UserName")).Text + "<BR/>";
        txtMsg.Text += ((TextBox)form1.FindControl("Country")).Text + "<BR/>";
        txtMsg.Text += ((TextBox)form1.FindControl("City")).Text + "<BR/>";
        PlaceHolder1.Controls.Add(txtMsg);
    }
}
