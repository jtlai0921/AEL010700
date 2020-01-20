<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AMD.aspx.cs" Inherits="AMD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server" OnItemCreated="SiteMapPath1_ItemCreated">
        </asp:SiteMapPath>
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server" ForeColor="Red"></asp:Label></div>
    </form>
</body>
</html>
