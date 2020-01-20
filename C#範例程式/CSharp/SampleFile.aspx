<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SampleFile.aspx.cs" Inherits="SampleFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtMsg" runat="server" Width="300px"></asp:TextBox>
        <asp:Button ID="btnOK" runat="server" onclick="btnOK_Click" Text="確定" 
            Width="80px" />
    
    </div>
    </form>
</body>
</html>
