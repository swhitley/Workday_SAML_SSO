<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Workday_SAML_SSO.Error" %>

<!doctype>
<html>
<head>

	<!-- Basics -->
	
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	
	<title>Error</title>

	<!-- CSS -->
	
	<link rel="stylesheet" href="css/reset.css">
	<!--<link rel="stylesheet" href="css/animate.css">-->
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
            <p style="margin:10px;"><asp:Literal id="msgError" runat="server"></asp:Literal></p>
		</form>
		
	</div>
	
	
	<!-- End Page Content -->
	
</body>

</html>
	