/*
Workday_SAML_SSO - http://voiceoftech.com
LICENSED UNDER THE  MIT LICENSE (MIT)

Copyright (c) 2014 Shannon Whitley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices.AccountManagement;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;

namespace Workday_SAML_SSO
{
    public partial class Login : System.Web.UI.Page
    {
        protected string tenant = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUsername.Value = User.Identity.Name.Split('\\')[1].ToLower();
            }
            //Default Tenant Override
            if (Request["tenant"] != null)
            {
                tenant = Request["tenant"].ToString() + "_";
                if (tenant.Length > 25)
                {
                    tenant = "";
                }
            }
        }

    
        protected void btnGo_Click(object sender, EventArgs e)
        {
            bool isValid = false;
            string domain = ConfigurationManager.AppSettings["network_domain"];

            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain))
            {
                isValid = pc.ValidateCredentials(txtUsername.Value, txtPassword.Value, ContextOptions.Negotiate);
            }

            if (isValid)
            {
                string sUsername = txtUsername.Value;

                //Create a SAML 2.0 Response with the network username of the authenticating user.
                var samlResponse = SamlResponse.CreateSamlResponse(
                  ConfigurationManager.AppSettings[tenant + "recipient"]
                , ConfigurationManager.AppSettings[tenant + "issuer"]
                , ConfigurationManager.AppSettings[tenant + "domain"]
                , sUsername
                , ConfigurationManager.AppSettings[tenant + "cert_issuer_name"]
                , ConfigurationManager.AppSettings[tenant + "target"]);

                form1.Action = ConfigurationManager.AppSettings[tenant + "recipient"];
                RelayState.Value = ConfigurationManager.AppSettings[tenant + "target"];
                SAMLResponse.Value = samlResponse;

                if (Request["link"] != null)
                {
                    RelayState.Value = Request["link"];
                }

                String scriptText = "";
                scriptText += "function submitForm(){";
                scriptText += "   document.getElementById('form1').submit(); ";
                scriptText += "}";
                scriptText += "submitForm();";
                ClientScript.RegisterStartupScript(this.GetType(),
                   "SubmitScript", scriptText, true);
            }

        }
    }
}