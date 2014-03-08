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
using System.IO;
using System.Text;
using System.Xml;
using System.Configuration;

namespace Workday_SAML_SSO
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tenant = "";
            string sUsername = User.Identity.Name.Split('\\')[1].ToLower();

            //Default Tenant Override
            if (Request["tenant"] != null)
            {
                tenant = Request["tenant"].ToString() + "_";
                if (tenant.Length > 25)
                {
                    tenant = "";
                }
            }

            //Check for Bypass file - Redirect to Workday
            if (File.Exists(Server.MapPath(".") + "\\Setup\\UserFiles\\" + sUsername + "_bypass.txt"))
            {
                string url = ConfigurationManager.AppSettings[tenant + "target"];
                if (Request["link"] != null)
                {
                    url = Request["link"];
                }
                Response.Redirect(url);
                return;
            }

            //Check for login file - Login Required
            if (File.Exists(Server.MapPath(".") + "\\Setup\\UserFiles\\" + sUsername + "_login.txt"))
            {
                string url = "login.aspx";
                if (Request["link"] != null)
                {
                    url += "?link=" + Request["link"];
                }
                Response.Redirect(url);
                return;
            }


            //Access is Restricted 
            if (ConfigurationManager.AppSettings[tenant + "allowed"] != null)
            {
                string[] allowed = ConfigurationManager.AppSettings[tenant + "allowed"].Split(',');
                bool found = false;
                foreach (string username in allowed)
                {
                    if (sUsername == username)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    throw new Exception("Your username must be added to the allowed users list.");
                }
            }


            //Admin impersonation 
            if (Request["i"] != null)
            {
                string[] admins = ConfigurationManager.AppSettings[tenant + "admins"].Split(',');
                foreach (string admin in admins)
                {
                    if (sUsername == admin)
                    {
                        sUsername = Request["i"].ToString();
                    }
                }
            }


            //Input Validation
            if (sUsername.Length > 25)
            {
                sUsername = sUsername.Substring(0, 25);
            }

            //************************************************************************************
            //Create a SAML 2.0 Response with the network username of the authenticating user.
            //************************************************************************************
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
        }
    }
}

