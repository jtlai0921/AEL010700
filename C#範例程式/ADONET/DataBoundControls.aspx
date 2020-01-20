<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataBoundControls.aspx.cs" Inherits="DataBoundControls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            color: #0000FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>ASP.NET資料繫結控制項與ADO.NET程式搭配運用</h2>
        <asp:Button ID="btnDataBound" runat="server" Text="執行ASP.NET控制項資料繫結" 
            onclick="btnDataBound_Click" />
        <br />
        <BR />
        <span class="style1">DropDownList控制項：</span><asp:DropDownList ID="dwnEmps" runat="server" Width="177px">
        </asp:DropDownList>
    
        <br />
        <br />
        <span class="style1">RadioButtonList控制項：</span><asp:RadioButtonList ID="rdoEmps" runat="server">
        </asp:RadioButtonList>
        <br />
        <br />
        <span class="style1">CheckBoxList控制項：</span><br />
        <asp:CheckBoxList ID="cbxEmps" runat="server">
        </asp:CheckBoxList>
    
        <br />
        <span class="style1">BulletedList控制項：</span><asp:BulletedList ID="blEmps" runat="server">
        </asp:BulletedList>
    
    </div>
    </form>
</body>
</html>
