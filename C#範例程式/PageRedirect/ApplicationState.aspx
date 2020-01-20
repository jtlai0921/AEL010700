<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplicationState.aspx.cs" Inherits="ApplicationState" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/C#" runat="server">
        void Page_PreLoad(object sender, EventArgs e)
        {
            Response.Write("<Img Src='Images/Application.jpg' /><BR/>");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
