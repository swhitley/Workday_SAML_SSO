<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Workday_SAML_SSO._Default" %>
<!doctype>
<html>
<head>

	<!-- Basics -->
	
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	
	<title>Login</title>

	<!-- CSS -->
	
	<link rel="stylesheet" href="css/reset.css">
	<!--<link rel="stylesheet" href="css/animate.css">-->
	<link rel="stylesheet" href="css/styles.css?1=1">
	
</head>

	<!-- Main HTML -->
	
<body onload='setTimeout("document.getElementById(\"form1\").submit()",0);'>
	
	<!-- Begin Page Content -->
    <h1>
        <img src="img/signon.png" />
    </h1>
	
	<div id="container">
	
		<form id="form1" runat="server">
            <div style="margin:25px 25px 25px 25px;">
        <input type="hidden" id="RelayState" name="RelayState" value="" runat="server" /> 
        <input type="hidden" name="SAMLResponse" id="SAMLResponse" runat="server"  />

            <p>You will be redirected to Workday in a few seconds.
            </p>
            <br /><br />
            <p>
                Go to <a href="setup">/setup</a> to change your login settings.
            </p>
                </div>
		</form>
		
	</div>
	
	
	<!-- End Page Content -->
	
</body>

</html>
	
	
	

