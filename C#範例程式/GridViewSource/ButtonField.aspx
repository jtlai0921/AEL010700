<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ButtonField.aspx.cs" Inherits="ButtonField" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>ButtonField按鈕欄位的運用</h2>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" 
                        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                        CellPadding="2" DataKeyNames="ProductID" DataSourceID="SqlDataSource1" 
                        Font-Size="10pt" ForeColor="Black" onrowcommand="gvProducts_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="ProductID" HeaderText="ProductID" 
                                InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                            <asp:BoundField DataField="ProductName" HeaderText="ProductName" 
                                SortExpression="ProductName" />
                            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" 
                                SortExpression="UnitPrice" />
                            <asp:ButtonField ButtonType="Button" CommandName="Order" Text="訂購" />
                            <asp:ButtonField ButtonType="Button" CommandName="CancelOrder" Text="取消" />
                        </Columns>
                        <FooterStyle BackColor="Tan" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                            HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
                        SelectCommand="SELECT [ProductID], [ProductName], [UnitPrice] FROM [Products]">
                    </asp:SqlDataSource>
                </td>
                <td valign="top">
                    您訂購的產品如下：<br />
                    <asp:ListBox ID="lbOrders" runat="server" Height="200px" Width="200px">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
