using System;

public partial class ArrayCloneBasic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtSource.Text = null;
            //排序前的陣列
            int[] sourceArray = new int[10];
            //以亂數建立陣列
            Random rnd = new Random();
            for (int i = 0; i <= 9; i++)
            {
                sourceArray[i] = rnd.Next(0, 100);
                txtSource.Text += Convert.ToString(sourceArray[i]) + "\n";
            }

            ViewState["sourceArray"] = sourceArray; //保存陣列
        }
    }

    //Clone複製陣列
    protected void btnClone_Click(object sender, EventArgs e)
    {
        txtTarget.Text = null;
        //從ViewState還原來源陣列資料
        int[] sourceArray = (int[])ViewState["sourceArray"];
        //Clone複製來源陣列到目標陣列
        int[] targetArray = (int[])sourceArray.Clone();
        txtTarget.Text = null;
        for (int i = 0; i <= 9; i++)
        {
            txtTarget.Text += Convert.ToString(targetArray[i]) + "\n";
        }
    }

    //Copy複製陣列，從第一個元素開始複製
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        txtTarget.Text = null;
        //從ViewState還原來源陣列資料
        int[] sourceArray = (int[])ViewState["sourceArray"];
        //複製來源陣列前6個元素到目標陣列
        int[] targetArray=new int[6];
        Array.Copy(sourceArray, targetArray, 6);

        for (int i = 0; i < targetArray.Length; i++)
        {
            txtTarget.Text += Convert.ToString(targetArray[i]) + "\n";
        }
    }

    //CopyTo複製陣列
    protected void btnCopyTo_Click(object sender, EventArgs e)
    {
        txtTarget.Text = null;
        //從ViewState還原來源陣列資料
        int[] sourceArray = (int[])ViewState["sourceArray"];
        
        int[] targetArray = new int[13];
        targetArray[0] = 1;
        targetArray[1] = 2;
        targetArray[2] = 3;

        //複製來源陣列到目標陣列，並從目標陣列Index索引位置3開始加入
        sourceArray.CopyTo(targetArray,3);

        for (int i = 0; i < targetArray.Length; i++)
        {
            txtTarget.Text += Convert.ToString(targetArray[i]) + "\n";
        }
    }
}
