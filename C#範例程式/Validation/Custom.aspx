<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Custom.aspx.cs" Inherits="Custom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
        //Client端驗證地址
        function checkAddress(sender, args) {
            if (args.Value.search("號") == -1) {
                args.IsValid=false;
            }
        }

        //清除Message訊息文字
        function clearMessage() {
            document.getElementById("txtMsg").innerHTML = "";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>CustomValidator控制項</h2>
     姓　　名：
      
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtName" ErrorMessage="*姓名不得為空白" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        郵遞區號：<asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator1" runat="server" 
            ControlToValidate="txtZipCode" 
            ErrorMessage="*郵遞區號不得為空白，且長度必須為3或5碼" 
            onservervalidate="CustomValidator1_ServerValidate" 
            ValidateEmptyText="True" EnableClientScript="False" ForeColor="Red"></asp:CustomValidator>
        <br />
        <br />
        地　　址： 
        <asp:TextBox ID="txtAddress" runat="server" Width="440px"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator2" runat="server" 
            ControlToValidate="txtAddress" ErrorMessage="*地址不得為空白，且必須包含門牌號碼" 
            ClientValidationFunction="checkAddress" ValidateEmptyText="True" 
            ForeColor="Red"></asp:CustomValidator>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="確定" Width="100px" 
            onclick="btnSubmit_Click" onclientclick="clearMessage()" />
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
