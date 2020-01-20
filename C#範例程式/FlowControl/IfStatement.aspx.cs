using System;
using System.Web.UI;
using System.Drawing;

public partial class IfStatement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //判斷成績是否及格
    protected void btnOK_Click(object sender, EventArgs e)
    {
        int score = 0;
        bool result;

        //判斷TextBox中的英文成績是否為Null或空白
        if (!string.IsNullOrEmpty(txtScore.Text))
        {
            //將英文成績由字串型別轉為int型別，成功會回傳true，失敗會回傳false
            result = int.TryParse(txtScore.Text, out score);

            //字串轉型為int型別成功
            if (result)
            {
                //判斷英文成績是否大於60分
                if (score >= 60)
                {
                    txtMsg.Text = "英文成績及格！";
                    txtMsg.BackColor = Color.Aqua;
                }
                else
                {
                    txtMsg.Text = "英文成績不及格！";
                    txtMsg.BackColor = Color.Red;
                }
            }
            else
            {
                //字串轉型為int型別失敗
                Response.Write("<script>alert('成績限輸入阿拉伯數字，不得為英文字母或其他符號！')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('英文成績不得為空白！')</script>");
        }
    }
}
