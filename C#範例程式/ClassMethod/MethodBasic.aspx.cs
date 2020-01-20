using System;

public partial class MethodBasic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    //將阿拉伯數字轉換為中文字
    public string ToChineseNum(string number)
    {
        string letter;
        string ChineseNum = "";
        int value;

        //檢查是否為數字
        if (int.TryParse(number, out value))
        {
            for (int i = 0; i < number.Length; i++)
            {
                letter = number.Substring(i, 1);
                switch (letter)
                {
                    case "0":
                        ChineseNum += "零";
                        break;
                    case "1":
                        ChineseNum += "壹";
                        break;
                    case "2":
                        ChineseNum += "貳";
                        break;
                    case "3":
                        ChineseNum += "參";
                        break;
                    case "4":
                        ChineseNum += "肆";
                        break;
                    case "5":
                        ChineseNum += "伍";
                        break;
                    case "6":
                        ChineseNum += "陸";
                        break;
                    case "7":
                        ChineseNum += "柒";
                        break;
                    case "8":
                        ChineseNum += "捌";
                        break;
                    case "9":
                        ChineseNum += "玖";
                        break;
                }
            }
        }
        else
        {
            ChineseNum = "必須為數字，不可以其他文字或空白！";
        }

        return ChineseNum;
    }

    //呼叫ToChinese方法，進行阿拉伯數字轉換為中文字
    protected void btnConvert_Click(object sender, EventArgs e)
    {
        //檢查TextBox是為否Null或空白
        if (!string.IsNullOrEmpty(txtNumber.Text))
        {
            //呼叫ToChineseNum方法
            string Nums = "轉換後的中文數字為：" + ToChineseNum(txtNumber.Text);
            txtMsg.Text = Nums;
        }
        else
        {
            txtMsg.Text="必須輸入阿拉伯數字，不可為空白！";
        }
    }
}
