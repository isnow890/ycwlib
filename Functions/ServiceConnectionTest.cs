using System;
using System.Net;

namespace ChanWooLib.Functions
{
    public static class ServiceConnectionTest
    {

        public static bool ServiceExists(string _url)
        {
            try
            {
                // try accessing the web service directly via it's URL
                HttpWebRequest request =
                    WebRequest.Create(_url) as HttpWebRequest;
                request.Timeout = 5000;

                using (HttpWebResponse response =
                           request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        return false;
                }

                // try getting the WSDL?
                // asmx lets you put "?wsdl" to make sure the URL is a web service
                // could parse and validate WSDL here

            }
            catch (WebException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}