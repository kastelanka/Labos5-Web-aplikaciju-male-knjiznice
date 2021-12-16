<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMain.aspx.cs" Inherits="labos5.WebFormMain" %>

<%@ Register src="Login.ascx" tagname="Login" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Login ID="Login1" runat="server" />
        </div>
    </form>
</body>
</html>
