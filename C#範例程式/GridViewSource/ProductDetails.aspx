<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>產品資料明細</h2>
        <asp:DetailsView ID="dvProduct" runat="server" BackColor="White" BorderColor="#E7E7FF"
            BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="sqldsNorthwind"
            Height="50px">
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <CommandRowStyle Wrap="False" />
            <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" Wrap="False" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" Wrap="False" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="sqldsNorthwind" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
            SelectCommand="select * from Products where ProductName=@paramProductName and CategoryID=@paramCategoryID and  SupplierID=@paramSupplierID">
            <SelectParameters>
                <asp:QueryStringParameter Name="paramProductName" QueryStringField="ProductName" />
                <asp:QueryStringParameter Name="paramCategoryID" QueryStringField="CategoryID" />
                <asp:QueryStringParameter Name="paramSupplierID" QueryStringField="SupplierID" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="回上一頁" /></div>
    </form>
</body>
</html>
