using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace WCFBasicSecurityMVC
{
    public class WebServiceEx:BasicWebService.WebService1
    {
        protected override System.Net.WebRequest GetWebRequest(Uri uri)
        {

            HttpWebRequest request;
            request = (HttpWebRequest)base.GetWebRequest(uri);

            //if (PreAuthenticate)
            //{
            //NetworkCredential networkCredentials = Credentials.GetCredential(uri, "Basic");
            //if (networkCredentials != null)
            //{

            //    byte[] credentialBuffer = new UTF8Encoding().GetBytes(networkCredentials.UserName + ":" + networkCredentials.Password);

            //    request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(credentialBuffer);
            //}
            //else
            //{
            //    throw new ApplicationException("No network credentials");
            //}
            //}
            byte[] credentialBuffer = new UTF8Encoding().GetBytes("fareast\v-tazho"+ ":" + "Edward0214");

            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(credentialBuffer);
            return request;
        }

    }
}