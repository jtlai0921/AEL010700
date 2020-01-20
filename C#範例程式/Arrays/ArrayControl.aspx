<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArrayControl.aspx.cs" Inherits="ArrayControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>陣列結合ASP.NET控制項的應用</h2>
        <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" 
            Text="將陣列資料加入到控制項之中" Width="250px" />
        <br />
        <br />
        請選擇產品項目：<asp:DropDownList ID="dwnProducts" runat="server" Width="150px" 
            AppendDataBoundItems="True" AutoPostBack="True" 
            onselectedindexchanged="dwnProducts_SelectedIndexChanged">
            <asp:ListItem>===請選擇===</asp:ListItem>
        </asp:DropDownList>
    
        <br />
        <br />
        請選擇產品項目：<asp:DropDownList ID="dwnProducts1" runat="server" Width="150px" 
            AppendDataBoundItems="True" AutoPostBack="True" 
            onselectedindexchanged="dwnProducts1_SelectedIndexChanged">
            <asp:ListItem>===請選擇===</asp:ListItem>
        </asp:DropDownList>
    
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server" ForeColor="Blue"></asp:Label>
    
        <br />
        <br />
        <asp:GridView ID="gvProducts" runat="server" BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" Font-Size="10pt" 
            ForeColor="Black" AutoGenerateColumns="False" Width="257px">
            <FooterStyle BackColor="Tan" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:TemplateField HeaderText="產品項目">
                    <ItemTemplate>
                        <%# Container.DataItem.ToString() %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
