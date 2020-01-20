<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SessionState.aspx.cs" Inherits="SessionState"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/C#" runat="server">
        void Page_PreLoad(object sender, EventArgs e)
        {
            Response.Write("<Img Src='Images/Session.jpg' /><BR/>");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        姓名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        電話：<asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
        <br />
        <br />
    
    </div>
    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" 
        Text="儲存Session到狀態之中" />
&nbsp;<asp:Button ID="btnRead" runat="server" onclick="btnRead_Click" 
        style="height: 27px" Text="讀取Session狀態資料" />
    <br />
    <br />
    <asp:Label ID="txtMsg" runat="server" ForeColor="#FF3300"></asp:Label>
    </form>
</body>
</html>
