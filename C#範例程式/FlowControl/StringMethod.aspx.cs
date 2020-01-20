using System;
using System.Collections;

public partial class StringＭethod : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //以Split分割字串
        Response.Write(string.Format("<Font Color='Blue'><<{0}>><BR/></Font>", "以Split分割字串"));

        string words = "Today is Sunday. I want to go to shopping!";
        string[] split = words.Split(new Char[] { ' ', ',', '.', '!' });
        foreach (string s in split)
        {
            Response.Write(s );
        }

        //以Compare比較兩個字串
        Response.Write(stringFormat("以Compare比較兩個字串"));

        string word1 = "a";
        string word2 = "b";
        //進行字串比較，並將結果值指定給result
        int result = string.Compare(word1, word2);

        switch (result)
        {
            case -1:
                Response.Write("字串1小於字串2");
                break;
            case 0:
                Response.Write("字串1等於字串2");
                break;
            case 1:
                Response.Write("字串1大於字串2");
                break;
        }

        //以Concat串連陣列中字串
        Response.Write(stringFormat("以concat串連陣列中字串"));

        string[] Models = new string[] {"Mary","Kelly","Cindy","John","Tom" };
        Response.Write(string.Concat(Models));

        //以Contains判斷字串中是否包含特定文字
        Response.Write(stringFormat("以Contains判斷字串中是否包含特定文字"));

        string string1 = "bird dog cow wolf fox fish";
        string string2 = "fox";
        Response.Write(string1.Contains(string2));

        //以Replace替代特定文字
        Response.Write(stringFormat("以Replace替代特定文字"));

        string Message = "大家好！我是聖殿祭司　溪江華";
        string newMessage = Message.Replace("溪江華", "奚江華");
        Response.Write(newMessage+"<BR/>");
        
        //以PadLeft填補字串左側長度
        string s1 = "a";
        string s2 = "ab";
        string s3 = "abc";
        string s4 = "abcd";
        string s5 = "abcde";

        Response.Write(stringFormat("以PadLeft填補字串左側長度"));
        Response.Write(s1.PadLeft(10, '_') + "<BR/>");
        Response.Write(s2.PadLeft(10, '_') + "<BR/>");
        Response.Write(s3.PadLeft(10, '_') + "<BR/>");
        Response.Write(s4.PadLeft(10, '_') + "<BR/>");
        Response.Write(s5.PadLeft(10, '_') + "<BR/>");

        //以Join串連陣列中字串，字串之間並以指定符號連接
        Response.Write(stringFormat("以Join串連陣列中字串"));

        string[] models = new string[] {"Mary","Kelly","Cindy","John","Tom" };
        Response.Write(string.Join("-", models));
        

        //以GetHashCode取得字串之HashCode
        Response.Write(stringFormat("以GetHashCode取得字串之HashCode"));

        string name = "Kevin";
        Response.Write(name.GetHashCode());

        //以GetEnumerator反覆讀取字串字元
        Response.Write(stringFormat("以GetEnumerator反覆讀取字串字元"));

        string Msg = "Hello...My name is Kevin Costner.";
        IEnumerator ienum = Msg.GetEnumerator();

        while (ienum.MoveNext())
        {
            Response.Write(ienum.Current + "<BR/>");
        }
    }

    //自訂字串格式化方法
    protected string stringFormat(string txtString)
    {
        string param = "<BR/><BR/><Font Color='Blue'><<{0}>><BR/></Font>";
        return string.Format(param, txtString);
    }
}
