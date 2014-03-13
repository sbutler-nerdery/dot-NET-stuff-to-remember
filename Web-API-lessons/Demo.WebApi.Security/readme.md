How to Use this Project
========================
Here are the key elements of this project:
 1. the creation of an RSA key pair
 2. custom filter attributes used to enforece security
 3. registering the custom attributes to enforece security
 4. the controller that are using them

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
 
Note: if you were to register the IPHostValidationAttribute you would prohibit any IP address except 127.0.0.1 from executing a request.
 
Controllers
--------------
There are two controllers on this project:
 * HomeController - this is a plain old controller used to display HTML to a user. However, because of the EnforceHttpsForApiAttribute being registered globally, you won't be able to get to get to the index untless you use an https url. If you go to the properties for the Demo.WebApi.Security.Web project, you will see SSL Url, which you can use to test this.
 * PersonController - this is the Web API controller. Right now, only the Get methods work. If you open up postman or fiddler, you can test these endpoints at {url}/api/person/get/1 or {url}/api/person/get. Make sure to add the Authorization-Token header to the request and debug the  Demo.WebApi.Security.Web.Tests.RSAUtilityTest.VerifyToken() unit test to get the appropriate token to pass in.

