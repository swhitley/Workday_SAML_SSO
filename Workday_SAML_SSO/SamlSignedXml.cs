﻿/*
LICENSED UNDER THE Code Project Open License (CPOL)

Copyright (c) 2010 David W Speight

http://www.codeproject.com/info/cpol10.aspx
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Security.Cryptography.Xml;

namespace Workday_SAML_SSO
{
    /// <summary>
    /// SamlSignedXml - Class is used to sign xml, basically the when the ID is retreived the correct ID is used.  
    /// without this, the id reference would not be valid.
    /// </summary>
    public class SamlSignedXml : SignedXml
    {
        private string _referenceAttributeId = "";
        public SamlSignedXml(XmlDocument document, string referenceAttributeId)
            : base(document)
        {
            _referenceAttributeId = referenceAttributeId;
        }
        public override XmlElement GetIdElement(
            XmlDocument document, string idValue)
        {
            return (XmlElement)
                document.SelectSingleNode(
                    string.Format("//*[@{0}='{1}']",
                    _referenceAttributeId, idValue));

        }

    }
}
