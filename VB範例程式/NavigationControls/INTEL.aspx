<%@ Page Language="VB" AutoEventWireup="false" CodeFile="INTEL.aspx.vb" Inherits="INTEL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
    <script src="Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:SiteMapPath ID="SiteMapPath1" runat="server" ToolTip="64位元四核心最搶手" 
                PathSeparator="&gt;">
                <PathSeparatorStyle BorderWidth="0px" />
            </asp:SiteMapPath>
            <br />
            <br />
            <asp:Label ID="txtMsg" runat="server" ForeColor="Red"></asp:Label></div>
    </div>
    </form>
    <script type="text/javascript">

        /*將分隔符號以圖片替代*/
        $(function () {
            //方法1
            //$("#SiteMapPath1 span:contains('>')").html("<img src='Images/Separator.gif' />")
            //方法2
            //$("span span:contains('>')").html("<img src='Images/Separator.gif' />")
        })
    </script>
</body>
</html>
