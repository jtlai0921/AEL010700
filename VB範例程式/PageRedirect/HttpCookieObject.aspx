<%@ Page Language="VB" AutoEventWireup="false" CodeFile="HttpCookieObject.aspx.vb"
    Inherits="HttpCookieObject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/VB" runat="server">
        Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
            Response.Write("<Img Src='Images/Cookie.jpg' /><BR/>")
        End Sub
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        請輸入基本資料<br />
        姓名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        血型：<asp:TextBox ID="txtBlood" runat="server"></asp:TextBox>
        <br />
        興趣：<asp:TextBox ID="txtHobby" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="儲存到Cookie"
            Width="150px" />
        &nbsp;<asp:Button ID="btnRead" runat="server" OnClick="btnRead_Click" Text="讀取Cookie"
            Width="150px" />
        &nbsp;<asp:Button ID="btnReadAll" runat="server" Text="讀取Cookies集合" OnClick="btnReadAll_Click" />
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
