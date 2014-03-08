﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Workday_SAML_SSO.Setup
{
    public partial class Default : System.Web.UI.Page
    {
        protected string sUsername = "";
        protected string login_file = "";
        protected string bypass_file = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            sUsername = User.Identity.Name.Split('\\')[1].ToLower();

            //If this file exists, the user is required to login using a network id and password.
            login_file = Server.MapPath(".") + "\\UserFiles\\" + sUsername + "_login.txt";

            //If this file exists, the user will be redirected to Workday.
            bypass_file = Server.MapPath(".") + "\\UserFiles\\" + sUsername + "_bypass.txt";

            if (!IsPostBack)
            {
                saml.Checked = true;
                if (File.Exists(login_file))
                {
                    login.Checked = true;
                }

                if (File.Exists(bypass_file))
                {
                    bypass.Checked = true;
                }
            }


        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (File.Exists(login_file))
            {
                File.Delete(login_file);
            }
            if (File.Exists(bypass_file))
            {
                File.Delete(bypass_file);
            }


            if (login.Checked)
            {
                File.WriteAllText(login_file, "");
            }
            if(bypass.Checked)
            {
                File.WriteAllText(bypass_file, "");
            }

            Response.Redirect("../");

        }
    }
}