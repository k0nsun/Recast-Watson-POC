using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConnectorOutlookRecast
{
    public class WatsonContact
    {
        public static string WatsonBot = @"https://gateway.watsonplatform.net/conversation/api/v1/workspaces/ad860efb-5e29-4ecf-9c27-ebe3c8cba8f8/message";
        public static string version = @"2017-06-23";
        public static string username = @"cf7be21e-8ade-4525-8ba6-42fd448bb661";
        public static string password = @"zd5Lw7FJGt3e";
        public static string workspace_id = @"ad860efb-5e29-4ecf-9c27-ebe3c8cba8f8";
        public static string version_date = @"2017-06-23";


        public ReponseWatson sendText(string Text)
        {
            ReponseWatson respond;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(WatsonBot + "?version=" + version);
            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            
            httpWebRequest.MaximumResponseHeadersLength = int.MaxValue;
            httpWebRequest.MaximumAutomaticRedirections = int.MaxValue;
            httpWebRequest.Timeout = int.MaxValue;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{"+
                            "\"username\": \""+ username + "\"," +
                            "\"password\": \"" + password + "\"," +
                            "\"workspace_id\": \"" + workspace_id + "\"," +
                            "\"version_date\": \"" + version_date + "\"," +
                            "\"input\" : { \"text\": \"" + Text + "\" }" +
                            "}";
            streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //   reponse = streamReader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = streamReader.ReadToEnd();
                respond = (ReponseWatson)js.Deserialize(objText, typeof(ReponseWatson));
            }
            return respond;
        }
    }
}
