<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArrayRank.aspx.cs" Inherits="ArrayRank" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        input
        {
            text-align: right;
        }
        
        .ButtonStyle
        {
        	text-align: center;
        }
    </style>
     
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>計算陣列維度</h2>
        <asp:Button ID="btnGetRank" runat="server" onclick="btnGetRank_Click" 
            Text="讀取陣列維度" CssClass="ButtonStyle" />
    
    </div>
    <asp:Label ID="capArray1" runat="server" Text="第一個陣列維度："></asp:Label>
    <asp:TextBox ID="txtArray1" runat="server" ></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="capArray2" runat="server" Text="第二個陣列維度："></asp:Label>
    <asp:TextBox ID="txtArray2" runat="server" ></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="capArray3" runat="server" Text="第三個陣列維度："></asp:Label>
    <asp:TextBox ID="txtArray3" runat="server" ></asp:TextBox>
    </form>
</body>
</html>
