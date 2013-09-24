using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.WebApi.Security.Web.Tests
{
    /// <summary>
    /// Summary description for RSAUtilityTest
    /// </summary>
    [TestClass]
    public class RSAUtilityTest
    {
        [TestMethod]
        public void VerifyToken()
        {
            var token = "User1";
            var encryptedToken = RSAUtility.Encrypt(token);
            var decryptedToken = RSAUtility.Decrypt(encryptedToken);

            Assert.AreEqual(token, decryptedToken);
        }
    }
}
