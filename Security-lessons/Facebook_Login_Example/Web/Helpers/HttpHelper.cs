using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Web.Helpers
{
    public class HttpHelper
    {
        public static string GetJson(string url)
        {
            var jsonString = string.Empty;

            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //myHttpWebRequest.UserAgent = "arbitrary_test_user_agent";
            //myHttpWebRequest.Method = "GET";
            //myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";

            //ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            try
            {

                using (var myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse())
                {
                    // Display the contents of the page to the console.
                    using (var streamResponse = myHttpWebResponse.GetResponseStream())
                    {
                        using (var streamRead = new StreamReader(streamResponse))
                        {
                            jsonString = streamRead.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                //response.Error = true;
                //response.StatusMessage = ex.Status.ToString();                
            }

            return jsonString;
        }

        public static async Task<string> GetJsonAsync(string url)
        {
            var jsonString = string.Empty;

            var myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //myHttpWebRequest.UserAgent = "arbitrary_test_user_agent";
            //myHttpWebRequest.Method = "GET";
            //myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";

            //ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            try
            {

                using (var myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse())
                {
                    // Display the contents of the page to the console.
                    using (var streamResponse = myHttpWebResponse.GetResponseStream())
                    {
                        using (var streamRead = new StreamReader(streamResponse))
                        {
                            jsonString = await streamRead.ReadToEndAsync();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                //response.Error = true;
                //response.StatusMessage = ex.Status.ToString();                
            }

            return jsonString;
        }
    }
}