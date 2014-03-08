This process is designed to produce a PFX file and the corresponding PEM file for use with Workday SAML SSO.

The process requires makecert.exe, which is part of the Windows SDK and can be downloaded from Microsoft.
(You may already have this file from Visual Studio or a previous SDK install.)

http://msdn.microsoft.com/en-us/library/windows/desktop/aa386968(v=vs.85).aspx


Common makecert.exe location:  %ProgramFiles% or %ProgramFiles(x86) \Windows Kits\{version}\bin\{processor}


**Copy makecert.exe into the /keys directory**


Sample files have been created and exist in this directory.  They should not be used with your Workday tenant as you would be vulnerable to anyone else with this code.  Create your own files using the instructions below.

Once you create your own files:

1) The .pfx file must be imported into the certificate store (Local Computer)\Personal\Certificates (see details below). 
2) The text from the PEM file between -----BEGIN CERTIFICATE----- and -----END CERTIFICATE----- must be added to Workday.

See the Workday documentation for enabling SAML.  Screenshots are included in this directory.




-- Create a new Certificate and PFX file --

1) Edit MakeCertAndPFX.ps1.  Change the Subject and Secret.

2) Run the powershell script, MakeCertAndPFX.ps1.  You should end up with a new certificate in your certificate store and a PFX file in the directory where the script resides.

3) Use SSLShopper.com's tool to convert the PFX file to a PEM file.

	https://www.sslshopper.com/ssl-converter.html



Although the certificate is created under the current user's certificate store, the application requires that the
certificate be loaded to the machine's certificate store.

1) Open MMC and add the certificates snap-in.
2) Select Computer Account.
3) Import the PFX file into (Local Computer)\Personal\Certificates



When the web application is run, it will look for the certificate in the (Local Computer)\Personal\Certificates.
The corresponding public key (in the PEM file) must be loaded to Workday under "Edit Tenant Setup - Security" (see the included screenshots).