<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Workday_SAML_SSO.Setup.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    	<!-- CSS -->
	
	<!--<link rel="stylesheet" href="../css/reset.css">-->
	<link rel="stylesheet" href="../css/animate.css">
	<link rel="stylesheet" href="../css/setup.css">
</head>
<body>
    <h1>
        <img src="../img/signon.png" />
    </h1>
    <div id="container">
    <form id="form1" runat="server">
    <div style="margin:25px 25px 25px 25px;">
        <h2>Workday Login Setup</h2><br />
        <p>Select an option below to change how you log in to Workday. </p> 
            <ul>
            <li><strong>Log In Automatically</strong> -&nbsp; Allows you to log in to Workday without entering a user ID or password.</li>
            <li><strong>Require My Network Password</strong> - Each time you log in to Workday, you will be required to enter your network ID and network password.</li>
          </ul>
        <input id="saml" type="radio" name="setup" value="saml" runat="server" /> Log In Automatically<br />
        <input id="login" type="radio" name="setup" value="login" runat="server" /> Require My Network Password<br />
        <!--<input id="bypass" type="radio" name="setup" value="bypass" runat="server"  /> Use the Workday Login Page<br />-->
        <asp:Button ID="btnGo" Text="Go" OnClick="btnGo_Click" runat="server" /><br />
        <!--<div style="margin-top:50px;">
            <p>
		       <a href="../">Login Now</a>
            </p>
        </div> -->
    </div>
    </form>
        </div>
</body>
</html>
