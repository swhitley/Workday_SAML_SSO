
Workday* SAML SSO
==================


General
-------

This is an ASP.NET (C#) starter project for creating a SAML solution for Workday.  The code is fully functional, but you may need to add additional error handling and adapt the look-and-feel for your environment.  It works for internal connections only (not over the Internet).  The project features multi-tenant access, impersonation, and user-configurable options for network password authentication. 

Although this was designed to work with Workday, it should be a suitable project for other applications that use SAML 2.0. 


Installation
------------

The project should be ready to run following the creation of your keys and web.config updates.  It can be run successfully from within Visual Studio.

Update Web.config with your Workday tenant information.  The sample values are setup for the Portland data center, so you may need to alter the domain as well.

Look in the /keys directory for information on generating the required public/private key information.

It is very important to import the certificate into the local machine certificate store (not the current user's).  This is further addressed in the /keys readme file.

Enable SAML in your Workday tenant. -- https://community.workday.com/doc/sec/dan1370796470811

Windows Authentication is used by default and should be enabled on the web site where this application is installed.


Operations
----------

Once running, a user who visits the web site will be redirected to Workday and will automatically log in.
Each user can visit the /setup page of the website and configure the login as needed.  Some users
may want to login using a password rather than go straight into Workday. 



<nowiki>*</nowiki> This code has not been endorsed by Workday and no Workday developers contribute to this code...although they are welcome to.
