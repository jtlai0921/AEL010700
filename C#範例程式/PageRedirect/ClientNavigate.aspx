<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #btnLocation {
            width: 170px;
        }
        #btnNavigate
        {
            width: 170px;
        }
        #btnOpen
        {
            width: 170px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" 
            ImageUrl="~/Images/Client.jpg" />
        <br />
        <br />
        <input id="btnLocation" onclick="location.href='http://www.sina.com.tw'" type="button" value="location.href" /><br />
        <br />
        <input id="btnNavigate" onclick="window.navigate('http://www.pchome.com.tw')" type="button" value="window.navigate" /><br />
        <br />
        <input id="btnOpen" onclick="window.open('http://tw.yahoo.com')" type="button" value="window.open" />
        <br /><br />
        <a href="http://www.microsoft.com">微軟網站</a>
        </div>
    <br />
    <br />
    </form>
</body>
</html>
