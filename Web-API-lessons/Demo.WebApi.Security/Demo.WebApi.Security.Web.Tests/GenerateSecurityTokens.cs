using System;
using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.WebApi.Security.Web.Tests
{
    [TestClass]
    public class GenerateSecurityTokens
    {
        [TestMethod]
        public void RSAparameters()
        {
            var rsa = new RSACryptoServiceProvider();

            //Write the RSA xml to the output window...
            Debug.WriteLine(rsa.ToXmlString(true));
            Debug.WriteLine(rsa.ToXmlString(false));
        }
    }
}
