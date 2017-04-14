using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Script.Serialization;
using System.Xml;

namespace WCFRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class RestService : IRestService
    {
        private bool IsSetValue { get; set; }
        public string PostJsonBody()
        {
            //using (var reader = OperationContext.Current.RequestContext.RequestMessage.GetReaderAtBodyContents())
            //{
            //    if (reader.Read())
            //        return new string(Encoding.ASCII.GetChars(reader.ReadContentAsBase64()));

            //}
            string result = OperationContext.Current.RequestContext.RequestMessage.ToString();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            XmlNode root = doc.FirstChild;
            Dictionary<string, dynamic> dic = new Dictionary<string, dynamic>();
            if (root.HasChildNodes)
            {
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    dic.Add(root.ChildNodes[i].Name, Convert.ChangeType(root.ChildNodes[i].InnerText, (GetType(root.ChildNodes[i].Attributes["type"].Value))));
                    Console.WriteLine(root.ChildNodes[i].Name + ";" + root.ChildNodes[i].InnerXml);
                }
            }

            var json = new JavaScriptSerializer().Serialize(dic);
            //var result=WebOperationContext.Current.IncomingRequest;
            var inputStream = OperationContext.Current.RequestContext.RequestMessage.GetBo‌​dy<Stream>();
            var sr = new StreamReader(inputStream, Encoding.UTF8);
            var str = sr.ReadToEnd();
            //string body = Encoding.UTF8.GetString(OperationContext.Current.RequestContext.RequestMessage.GetBody<byte[]>());

            //string xml = OperationContext.Current.RequestContext.RequestMessage.GetBody<byte[]>();
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(xml);
            //string jsonText = JsonConvert.SerializeXmlNode(doc);
            return "Hello JSON Body";
        }
        private Type GetType(string type)
        {
            switch (type)
            {
                case "number":
                    return typeof(int);
                case "string":
                    return typeof(string);
                case "Boolean":
                    return typeof(bool);
                // TODO: add any other types that you want to support
                default:
                    throw new NotSupportedException(
                        string.Format("The type {0} is not supported", type)
                    );
            }
        }

        public string GetUserName(int id)
        {
            SqlConnection con = new SqlConnection(@"Server=tcp:serverstarain.database.windows.net,1433;Initial Catalog=sqlstarain1;Persist Security Info=False;User ID=starain;Password=user@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            DataTable dt = new DataTable();
            string vw = "select * from UserInfo where id=" +id;
            SqlCommand cmd = new SqlCommand(vw, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            DataRow dr = dt.Rows[0];
            string UserName = dt.Rows[0]["UserName"].ToString();
            return UserName;
        }
        public RestService()
        {
            if (!IsSetValue)
            {
                IsSetValue = true;
                //you could read file content here
            }
            Global.value += Global.value;
            System.Diagnostics.Debug.WriteLine(Global.value);
        }
        public string GetValue(int value)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = @"D:\Edward\Project\WCF2017\WCF2017\WCFRest\Test\Test.bat";
            proc.StartInfo.WorkingDirectory = @"D:\Edward\Project\WCF2017\WCF2017\WCFRest\Test\";
            proc.Start();

            //Thread.Sleep(2000);
            //access the data in Global
            System.Diagnostics.Debug.WriteLine(Global.value);
            return value.ToString();
        }
        public string GetData(int value,out string returnValue)
        {
            returnValue = "Hello";
            ServiceController[] scServices;
            scServices = ServiceController.GetServices("v-tinmo-12r2");
            foreach (ServiceController scTemp in scServices)
            {
                System.Diagnostics.Debug.WriteLine(scTemp.ServiceName);
            }

            return string.Format("You entered: {0}", value);
        }
        public int COSendTubeInfo(int LstData, out string ErrMsg)            
        {
            ErrMsg = "Error";
            return 123;
        }
        public LoginInfo LoginRest(LoginInfo login)
        {
            return login;
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
       
        public StreamResultModel DownloadFile(string pDate, string pMD5)
        {
            StreamResultModel mResult = new StreamResultModel();
            mResult.code = "200";
            mResult.message = "OK";
            mResult.byteData = ReadFully(File.OpenRead(@"D:\WCF\Test.txt"));
            return mResult;
        }
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        public Stream Download()
        {
            String headerInfo = "attachment; code='200';message='OK'";
            WebOperationContext.Current.OutgoingResponse.Headers["Content-Disposition"] = headerInfo;

            WebOperationContext.Current.OutgoingResponse.ContentType = "application/octet-stream";
            return File.OpenRead(@"D:\WCF\Test.txt");
        }
        public string PostJson(Headers headers)
        {
            return headers.loginname;
        }
        public string PutJson(Headers headers)
        {
            return headers.loginname;
        }

        public Headers GetJson()
        {
            Headers h = new Headers {  loginname="test", password="123"};
            return h;
        }
    }
}
