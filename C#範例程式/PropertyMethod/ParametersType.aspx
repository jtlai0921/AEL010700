<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ParametersType.aspx.cs" Inherits="ParametersType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>參數以傳值/傳址/傳出方式的差異比較</h2>
        <asp:Button ID="btnValue" runat="server" onclick="btnValue_Click" Text="傳值參數" />
        <br />
        <br />
        <asp:Button ID="btnReference" runat="server" onclick="btnReference_Click" 
            Text="傳址參數" />
        <br />
        <br />
        <asp:Button ID="btnOut" runat="server" onclick="btnOut_Click" Text="傳出參數" />
        <br /><br />
        <asp:Label ID="txtMsg" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
