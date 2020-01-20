using System;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class LabelControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //透過C#程式設定控制項屬性
            txtPrg.Text = "這是以程式動態設定Label控制項的屬性";
            txtPrg.ToolTip = "程式動態設定Label控制項";
            txtPrg.ForeColor = Color.Aqua;
            txtPrg.BackColor = Color.Orange;
            txtPrg.Font.Name = "標楷體";
            txtPrg.Font.Size = FontUnit.XLarge;
        }
    }
}
