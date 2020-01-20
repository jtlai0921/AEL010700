<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rdoDegree.aspx.cs" Inherits="rdoDegree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>請選擇您的最高學歷:</h2>
        <asp:RadioButton ID="rdoSenior" runat="server" GroupName="Degree" Text="高中" />
        <br />
        <asp:RadioButton ID="rdoUniversity" runat="server" GroupName="Degree" 
            Text="大學/專科" />
        <br />
        <asp:RadioButton ID="rdoMaster" runat="server" GroupName="Degree" Text="碩士" />
        <br />
        <asp:RadioButton ID="rdoDoctor" runat="server" GroupName="Degree" Text="博士" />
        <br />
        <asp:Button ID="btnSumbit" runat="server" onclick="btnSumbit_Click" Text="確定" 
            Width="100px" />
        <br /><br />
        <asp:Label ID="txtMsg" runat="server" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
