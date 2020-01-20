<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Range.aspx.cs" Inherits="Range" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>RangeValidator控制項</h2>
        存款總額：
         
        <asp:Label ID="txtDeposit" runat="server"></asp:Label>
        <br />
        <br />
        轉帳金額： 
        <asp:TextBox ID="txtWithDraw" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" 
            ControlToValidate="txtWithDraw" EnableClientScript="False" Type="Integer" 
            ForeColor="Red"></asp:RangeValidator>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="確定" 
            Width="100px" />
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
