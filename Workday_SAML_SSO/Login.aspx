<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Workday_SAML_SSO.Login" %>

<!doctype>
<html>
<head>

	<!-- Basics -->
	
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	
	<title>Login</title>

	<!-- CSS -->
	
	<link rel="stylesheet" href="css/reset.css">
	<link rel="stylesheet" href="css/animate.css">
	<link rel="stylesheet" href="css/styles.css?1=1">
	
</head>

	<!-- Main HTML -->
	
<body>
	
	<!-- Begin Page Content -->
    <h1>
        <img src="img/signon.png" />
    </h1>
	
	<div id="container">
	
		<form id="form1" runat="server">
        <input type="hidden" id="RelayState" name="RelayState" value="" runat="server" /> 
        <input type="hidden" name="SAMLResponse" id="SAMLResponse" runat="server"  />

		
		<label for="txtUsername">Username:</label>
		<input type="text" id="txtUsername" name="txtUsername" runat="server" />
		
		<label for="txtPassword">Password:</label>
		<input id="txtPassword" type="password" name="txtPassword" runat="server" />
		
		<div id="lower">
		<asp:Button ID="btnGo" Text="Go" OnClick="btnGo_Click" runat="server" />
        <div style="margin: 25px 10px 10px 10px">
                <p>
		            <a href="setup">Login Setup</a>
                </p>
		</div>
		
		</div>
		
		</form>
		
	</div>
	
	
	<!-- End Page Content -->
	
</body>

</html>
	
	
	

