<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Compare.aspx.cs" Inherits="Compare" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>CompareValidator驗證控制項</h2>
        信用卡累積紅利點數：<asp:TextBox ID="txtTotalBonus" runat="server" ReadOnly="True" 
            ToolTip="目前累積紅利點數"></asp:TextBox>
        <br />
        兌換現金之紅利點數：<asp:TextBox ID="txtBonus" runat="server" 
            style="margin-bottom: 0px" ToolTip="請輸入欲兌換之紅利點數"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToValidate="txtBonus" ErrorMessage="*兌換的紅利不得超過累積點數，或格式輸入錯誤" 
            Operator="LessThanEqual" Type="Integer" 
            ControlToCompare="txtTotalBonus" EnableClientScript="False" 
            ForeColor="Red"></asp:CompareValidator>
        <br />
        <br />
        <asp:Button ID="btnConvert" runat="server" Text="兌換成現金" 
            onclick="btnConvert_Click" Height="27px" />
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
