<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AppBox.Verify.WebForm1" %>
<%@ Register Src="~/Verify/SafeVerify.ascx" TagPrefix="uc1" TagName="SafeVerify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <uc1:SafeVerify ID="SafeVerify" runat="server"></uc1:SafeVerify>

    </div>
    </form>
</body>
</html>
