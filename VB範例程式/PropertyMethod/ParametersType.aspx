﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ParametersType.aspx.vb"
    Inherits="ParametersType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>參數以傳值與傳址方式的差異比較</h2>
        <asp:Button ID="btnValue" runat="server" Text="傳值參數運算" />
        <br />
        <br />
        <asp:Button ID="btnReference" runat="server" Text="傳址參數運算" />
        <br />
        <br />
    </div>
    </form>
</body>
</html>
