<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #search
        {
            margin-top: 15px;
            margin-left: 15px;
        }
        
        input[type=submit]
        {
            margin: 5px 0px 5px 0px;
        }
        
        select
        {
            margin: 5px 0px 5px 0px;
        }
        
        input[type=text]:hover
        {
            background-color: pink;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="search">
        <p>
            請輸入查詢資料：</p>
        學號：<asp:TextBox ID="txtID" runat="server" TabIndex="1"></asp:TextBox>
        <br />
        <asp:DropDownList ID="dwnAndOr" runat="server" Width="85px" TabIndex="5" 
            Height="17px">
            <asp:ListItem>AND</asp:ListItem>
            <asp:ListItem>OR</asp:ListItem>
        </asp:DropDownList>
        <br />
        姓名：<asp:TextBox ID="txtName" runat="server" TabIndex="2"></asp:TextBox><br />
        <asp:Button ID="btnSearch" runat="server" Text="查詢" Width="80px" TabIndex="3" 
            onclick="btnSearch_Click" />
        <br />
        <asp:Label ID="txtMsg" runat="server" ForeColor="Blue"></asp:Label>
        <hr />
        <br />
        <asp:GridView ID="gvStudents" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" DataKeyNames="ID" DataSourceID="sqlStudents" Font-Size="10pt"
            ForeColor="#333333" PageSize="5" onrowdatabound="gvStudents_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID學號" ReadOnly="True" SortExpression="ID">
                    <ItemStyle Width="70px" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name">
                    <ItemStyle Width="60px" Wrap="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="性別" SortExpression="Gender">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Gender") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="txtGender" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="40px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Birthday" HeaderText="生日" SortExpression="Birthday">
                    <ItemStyle Width="70px" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Blood" HeaderText="血型" SortExpression="Blood">
                    <ItemStyle Width="30px" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="City" HeaderText="縣市" SortExpression="City">
                    <ItemStyle Width="30px" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address">
                    <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="Tel" HeaderText="電話" SortExpression="Tel">
                    <ItemStyle Width="50px" Wrap="False" />
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="PhotoUrl" DataImageUrlFormatString="Photos/{0}"
                    HeaderText="照片">
                    <ControlStyle Height="30px" Width="30px" />
                    <ItemStyle Height="30px" Width="30px" Wrap="False" />
                </asp:ImageField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerSettings Mode="NumericFirstLast" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="sqlStudents" runat="server" ConnectionString="<%$ ConnectionStrings:SchoolConnectionString %>"
            
            SelectCommand="SELECT [ID], [Name], [Gender],  CAST(Birthday AS Nvarchar(10)) AS Birthday, [Blood], [Height], [Weight], [City], [Address], [Tel], [PhotoUrl] FROM [Students]" 
            onselecting="sqlStudents_Selecting">
        </asp:SqlDataSource>
    </div>
</asp:Content>

