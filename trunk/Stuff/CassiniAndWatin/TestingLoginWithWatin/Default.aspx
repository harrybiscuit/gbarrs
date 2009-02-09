<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestingLoginWithWatin._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <label for="loginId" >Login Id : </label>
        <input id="loginId" type="text" runat="server"/>        
        <label for="password" >Password : </label>
        <input id="password" type="password" runat="server"/>
        <input id="submitLoginDetails" type="submit" value="submit" onclick="return submitLoginDetails_onclick()" runat="server" />
    </div>
    
    <asp:Literal ID="errorText" runat="server"></asp:Literal>
    
    </form>
</body>
</html>
