<%@ Page Language="C#" AutoEventWireup="true" CodeFile="arrayScores.aspx.cs" Inherits="arrayScores" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
            計算二維陣列中，每位同學的國文、英文與數學之考試總分</h2>
        <asp:Button ID="btnCalculate" runat="server" OnClick="btnCalculate_Click" Text="計算每位同學之考試總分" />
        <br />
        <br />
        <asp:Label ID="capA" runat="server" Text="A同學總分："></asp:Label>
        <asp:TextBox ID="txtA" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="capB" runat="server" Text="B同學總分："></asp:Label>
        <asp:TextBox ID="txtB" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="capC" runat="server" Text="C同學總分："></asp:Label>
        <asp:TextBox ID="txtC" runat="server" ReadOnly="True"></asp:TextBox>
    </div>
    </form>
</body>
</html>
