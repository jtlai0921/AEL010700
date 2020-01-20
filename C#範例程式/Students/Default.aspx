<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/ui-lightness/jquery-ui-1.8.1.custom.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-ui-1.8.1.custom.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
        傑出校友照片公告
    </p>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">林志玲</a></li>
            <li><a href="#tabs-2">劉德華</a></li>
            <li><a href="#tabs-3">黃曉明</a></li>
            <li><a href="#tabs-4">系統說明</a></li>
        </ul>
        <div id="tabs-1">
            <p>
                <img src="Photos/林志玲.jpg" />
            </p>
        </div>
        <div id="tabs-2">
            <p>
                <img src="Photos/劉德華.jpg" />
            </p>
        </div>
        <div id="tabs-3">
            <p>
                <img src="Photos/黃曉明.jpg" />
            </p>
        </div>
        <div id="tabs-4">
            <p>
                事項一：本系統需具備帳號／密碼人員才能操作及瀏覽。
            </p>
            <p>
                事項二：因帳號CRUD權限的不同，所能操作的功能也不同。
            </p>
            <p>
                事項三：預設管理者登入帳號為admin，密碼亦為admin。
            </p>
        </div>
    </div>
    <script type="text/javascript">
        $("#tabs").tabs()
    </script>
</asp:Content>

