How to Use this Project
========================
Here are the key elements of this project:
1. the creation of an RSA key pair
2. custom filter attributes used to enforece security
3. registering the custom attributes to enforece security

RSA Encryption
--------------
Use the Demo.WebApi.Security.Web.Tests project to create and validate the security tokens.
 * Debug GenerateSecurityTokens.cs to get the private and public keys
 * Update Demo.WebApi.Security.Web.RSAUtility with the new private and public keys
 * Test RSAUtility with RSAUtilityTest.cs

Custom Filters
--------------
We are doing a couple of things here:
 * EnforceHttpsForApiAttribute -- enforces https on each request
 * TokenValidationAttribute -- looks for the Authorization-Token header and ensures that it decrypts to the expected value

One or both of these attributes are regestered globally in the following locations:
 * Demo.WebApi.Security.Web.WebApiConfig
 * Demo.WebApi.Security.Web.FilterConfig

