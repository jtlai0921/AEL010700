<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server"  >
    '取得伺服器時間之Function
    Function getTime() As DateTime
        Return DateTime.Now.ToLongTimeString()
    End Function
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Inline Code程式</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Inline Code程式撰寫模型</h2>
        現在伺服器時間是：<%= getTime() %>
    </div>
    </form>
</body>
</html>

