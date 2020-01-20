using System;

public partial class TryCatch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //無例外狀況處理
    protected void btnDiv1_Click(object sender, EventArgs e)
    {
        decimal a;  //被除數
        decimal b;  //除數

        //判斷TextBox輸入是否為阿拉伯字
        if (decimal.TryParse(txtNumerator.Text, out a) && decimal.TryParse(txtDenominator.Text, out b))
        {
            txtResult.Text = (a / b).ToString();　//除法計算
        }
        else
        {
            Response.Write("<script>alert('輸入的數字格式錯誤，限輸入阿拉伯數字！')</script>");
        }
    }


    //有例外狀況處理
    protected void btnDiv2_Click(object sender, EventArgs e)
    {
        decimal a;
        decimal b;

        //判斷TextBox輸入是否為阿拉伯字
        if (decimal.TryParse(txtNumerator.Text, out a) && decimal.TryParse(txtDenominator.Text, out b))
        {
            try
            {
                txtResult.Text = (a / b).ToString();　//除法計算
            }
            catch (Exception ex)
            {
                //錯誤發生時顯示ex之錯誤訊息
                txtResult.Text = "<BR/>" + ex.ToString();
            }
        }
        else
        {
            Response.Write("<script>alert('輸入的數字格式錯誤，限輸入阿拉伯數字！')</script>");
        }
    }

}
