<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Accounts.aspx.cs" Inherits="Accounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #content Table
        {
            margin-top: 15px;
            margin-left: 15px;
        }
        #content Table tr td
        {
            padding: 5px;
        }
        
        #content Table tr td input[type=checkbox]
        {
            padding: 0 5px 0 5px;
        }
        
        #NewAccount
        {
            padding-left: 10px;
            padding-top: 10px;
        }
        
        #message
        {
            width: 250px;
            margin-left: auto;
            margin-right: auto;
            background-color: lightgreen;
        }
        
        input[type=text]:hover
        {
            background-color: pink;
        }
        
        input[type=password]:hover
        {
            background-color: pink;
        }
        
        input[type=submit]
        {
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="gvAccount" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="sqlAccount"
        Font-Size="10pt" ForeColor="#333333" ClientIDMode="Static" Caption="&lt;div style=&quot;background-color:orange&quot;&gt;系統使用者帳號維護&lt;/div&gt;"
        PageSize="6" onrowdatabound="gvAccount_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="ID" HeaderText="使用者帳號" ReadOnly="True" SortExpression="ID">
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="讀寫權限" SortExpression="permission">
                <EditItemTemplate>
                    <asp:CheckBoxList ID="cbxPermission" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow" OnSelectedIndexChanged="cbxPermission_SelectedIndexChanged">
                        <asp:ListItem Value="R">讀</asp:ListItem>
                        <asp:ListItem Value="U">寫</asp:ListItem>
                        <asp:ListItem Value="D">刪除</asp:ListItem>
                        <asp:ListItem Value="C">新增</asp:ListItem>
                    </asp:CheckBoxList>
                    <asp:Label ID="txtPermission" runat="server" Text='<%# Bind("Permission") %>' Visible="False"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBoxList ID="cbxPermission" runat="server" Enabled="False" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="R">讀</asp:ListItem>
                        <asp:ListItem Value="U">寫</asp:ListItem>
                        <asp:ListItem Value="D">刪除</asp:ListItem>
                        <asp:ListItem Value="C">新增</asp:ListItem>
                    </asp:CheckBoxList>
                </ItemTemplate>
                <ItemStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="角色群組" SortExpression="Role">
                <EditItemTemplate>
                    <asp:DropDownList ID="dwnRole" runat="server" OnSelectedIndexChanged="dwnRole_SelectedIndexChanged1"
                        ToolTip='<%# Bind("Role") %>'>
                        <asp:ListItem Value="0">==請選擇==</asp:ListItem>
                        <asp:ListItem Value="1">Admin</asp:ListItem>
                        <asp:ListItem Value="2">Operator</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Role") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:CheckBoxField DataField="Active" HeaderText="啓用狀態" SortExpression="Active" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <asp:SqlDataSource ID="sqlAccount" runat="server" ConnectionString="<%$ ConnectionStrings:SchoolConnectionString %>"
        DeleteCommand="DELETE FROM [UserAccount] WHERE [ID] = @ID" InsertCommand="INSERT INTO [UserAccount] ([ID],[Password], [Permission], [Role], [Active]) VALUES (@ID, @Password, @Permission, @Role , @Active )"
        SelectCommand="SELECT [ID], [Permission], [Role],[Active] FROM [UserAccount]"
        
        UpdateCommand="UPDATE [UserAccount] SET [Permission] = @Permission, [Role] = @Role, [Active]= @Active WHERE [ID] = @ID" 
        oninserted="sqlAccount_Inserted" onselecting="sqlAccount_Selecting">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ID" Type="String" />
            <asp:Parameter Name="Password" />
            <asp:Parameter Name="permission" Type="String" />
            <asp:Parameter Name="Role" Type="String" />
            <asp:Parameter Name="Active" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="permission" Type="String" />
            <asp:Parameter Name="Role" Type="String" />
            <asp:Parameter Name="Active" />
            <asp:Parameter Name="ID" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    <asp:Panel ID="plAccount" runat="server">
        <hr />
        <div id="NewAccount">
            ＊帳號：<asp:TextBox ID="txtID" runat="server" MaxLength="12" Width="100px"></asp:TextBox>
            ＊密碼：<asp:TextBox ID="txtPassword" runat="server" MaxLength="12" Width="100px" TextMode="Password"></asp:TextBox>
            ＊權限：<asp:CheckBoxList ID="cblPermission" runat="server" RepeatDirection="Horizontal"
                RepeatLayout="Flow">
                <asp:ListItem Value="R" Selected="True">讀</asp:ListItem>
                <asp:ListItem Value="U">寫</asp:ListItem>
                <asp:ListItem Value="D">刪除</asp:ListItem>
                <asp:ListItem Value="C">新增</asp:ListItem>
            </asp:CheckBoxList>
            ＊群組：<asp:DropDownList ID="dwnRole" runat="server" OnSelectedIndexChanged="dwnRole_SelectedIndexChanged"
                ToolTip='<%# Bind("Role") %>'>
                <asp:ListItem Value="0">==請選擇==</asp:ListItem>
                <asp:ListItem Value="1">Admin</asp:ListItem>
                <asp:ListItem Value="2">Operator</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnNew" runat="server" Text="新增帳號" onclick="btnNew_Click" />
            <br />
            <asp:Label ID="txtResult" runat="server" ForeColor="Blue"></asp:Label>
        </div>
    </asp:Panel>
    <div id="message">
        <asp:Label ID="txtMsg" runat="server" Visible="False" ClientIDMode="Static"></asp:Label>
    </div>
    <script type="text/javascript">
        $(function () {
            //讀取Page內容的高度
            var x = $("#page").height();
            //讀取Login控制項的高度
            var y = $("#message").height();
            //計算Offset
            var offsetTop = (x - y) / 2 - 30;
            //設定Login控制項Offset位移
            $("#message").css("margin-top", offsetTop);
        })
    </script>
</asp:Content>
