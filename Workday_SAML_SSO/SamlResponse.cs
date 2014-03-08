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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Protocols.WSTrust;
using Microsoft.IdentityModel.SecurityTokenService;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Saml2;
using SecurityTokenTypes = Microsoft.IdentityModel.Tokens.SecurityTokenTypes;

namespace Workday_SAML_SSO
{
    public static class SamlResponse
    {
        public static string CreateSamlResponse(string recipient, string issuer, string domain, string subject, string certFindKey, string target)
        {
            return CreateSamlResponse(recipient, issuer, domain, subject, StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByIssuerName, null, null, certFindKey, new Dictionary<string, string>(), target);
        }
        /// <summary>
        /// Call the Saml Helper Class and get the "Post" value, which can then be posted to the web page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static string CreateSamlResponse(string recipient, string issuer, string domain, string subject, StoreLocation storeLocation, StoreName storeName, X509FindType findType, string certLocation, string certPassword, string certFindKey, Dictionary<string, string> attributes, string target)
        {

            string postData = "";

            // Set Parameters to the method call to either the configuration value or a default value
            SigningHelper.SignatureType signatureType = SigningHelper.SignatureType.Response;

            postData = SamlHelper.GetPostSamlResponse(recipient,
                        issuer, domain, subject,
                        storeLocation, storeName, findType,
                        certLocation, certPassword, certFindKey,
                        attributes, signatureType);

            return postData;

        }
    }
}