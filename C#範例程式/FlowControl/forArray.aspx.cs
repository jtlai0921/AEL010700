using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class forArray : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //建立陣列元素
        string[] Models = new string[] { "Mary", "Tom", "John", "Kelly", "David" };

        //將陣列元素加入到DropDownList控制項中
        for (int i = 0; i <= Models.Length - 1; i++)
        {
            dwnModels.Items.Add(Models[i]);
        }
    }
}
