﻿using System;
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

public partial class LinqArray : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] Models = new string[] { "Tom", "Mary" };

        var female = from m in Models
                     select m;

        foreach (string f in female)
        {
            Response.Write(f + "<BR/>");
        }
    }
}
