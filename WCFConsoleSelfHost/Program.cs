using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WCFConsoleSelfHost
{
    class Program
    {
        //global Service Host
        public static ServiceHost host;
        static void Main(string[] args)
        {
            //host = new ServiceHost(typeof(WCFTest));
            //ServiceHost sh = new ServiceHost(typeof(SecurityNone));
            //sh.Open();
            
            //ConfigureWCFInCode();
            //DownloadServiceFun();
            //StartStopServiceFun();
            //WCFHostedAzure();
            WCFCustomBindingInCode();
            Console.WriteLine("Service is open");
            Console.ReadLine();
        }
        public static void WCFHostedAzure()
        {
            ServiceHost host = new ServiceHost(typeof(WCFInAzure));
            host.Open();
            Console.WriteLine("service is open");
        }
        public static void WCFDebugBehavior()
        {
            ServiceHost host = new ServiceHost(typeof(WCFDebugBehavior));
            ServiceDebugBehavior sdb = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            if (sdb == null)
            {
                sdb = new ServiceDebugBehavior()
                {
                    HttpHelpPageEnabled = true,
                    IncludeExceptionDetailInFaults = true
                };
                host.Description.Behaviors.Add(sdb);
            }
            else
            {
                sdb.HttpHelpPageEnabled = true;
                sdb.IncludeExceptionDetailInFaults = true;                
            }
            host.Open();
            foreach (Uri uri in host.BaseAddresses)
            {
                Console.WriteLine(uri.ToString());
            }
            Console.WriteLine("Host started @ " + DateTime.Now.ToString());
            Console.ReadLine();
        }
        public static void ConfigureWCFInCode()
        {
            Uri serviceURL = new Uri("https://localhost:5555/");            
            EndpointAddress oEndpoint = new EndpointAddress(serviceURL);

            WebHttpBinding oBinding = new WebHttpBinding();
            oBinding.Name = "BasicHttpBinding_IConfidentialInterview";
            oBinding.CloseTimeout = System.TimeSpan.Parse("00:10:00");

            oBinding.OpenTimeout = System.TimeSpan.Parse("00:10:00");
            oBinding.ReceiveTimeout = System.TimeSpan.Parse("00:10:00");
            oBinding.SendTimeout = System.TimeSpan.Parse("00:10:00");

            oBinding.HostNameComparisonMode = System.ServiceModel.HostNameComparisonMode.StrongWildcard;
            oBinding.MaxBufferPoolSize = 2147483647;

            oBinding.MaxReceivedMessageSize = 2147483647;
            oBinding.ReaderQuotas.MaxDepth = 32;
            oBinding.ReaderQuotas.MaxStringContentLength = 2147483647;

            oBinding.ReaderQuotas.MaxArrayLength = 16384;
            oBinding.ReaderQuotas.MaxBytesPerRead = 4096;
            oBinding.ReaderQuotas.MaxNameTableCharCount = 16384;
            oBinding.Security.Mode = WebHttpSecurityMode.Transport;

            //host wcf service
            ServiceHost host = new ServiceHost(typeof(WCFInCode), serviceURL);
            //add service endpoint
            ServiceEndpoint serviceEndpoint= host.AddServiceEndpoint(typeof(IWCFInCode),oBinding, "WCFInCode");
            //add webHttp endpoint Behavior
            serviceEndpoint.EndpointBehaviors.Add(new WebHttpBehavior());
            host.Open();
            host.Close();
            
            Console.WriteLine("web service is open");
            //getdata is the method name
            Console.WriteLine("access wcf rest service from "+ serviceURL+ @"/WCFInCode/getdata");
        }
        public static void WCFCustomBindingInCode()
        {
            //CustomBinding customBinding = new CustomBinding();
            //SecurityBindingElement sbe = SecurityBindingElement.CreateUserNameOverTransportBindingElement();
            //sbe.MessageSecurityVersion = MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11;
            //sbe.SecurityHeaderLayout = SecurityHeaderLayout.Strict;
            //sbe.IncludeTimestamp = false;
            //sbe.SetKeyDerivation(true);
            //sbe.KeyEntropyMode = System.ServiceModel.Security.SecurityKeyEntropyMode.ServerEntropy;
            //customBinding.Elements.Add(sbe);
            //CustomBinding customBinding = new CustomBinding() {
            //    CloseTimeout = new TimeSpan(0, 1, 0),
            //    OpenTimeout = new TimeSpan(0, 1, 0),
            //    ReceiveTimeout = new TimeSpan(0, 10, 0),
            //    SendTimeout = new TimeSpan(0, 1, 0),
            //};
            Uri serviceURL = new Uri("https://localhost:5555/");
            EndpointAddress endpoint = new EndpointAddress("https://localhost:8735/WCFConsoleSelfHost/WCFCustomBinding/");

            SecurityBindingElement sbe = SecurityBindingElement.CreateUserNameOverTransportBindingElement();
            sbe.MessageSecurityVersion = MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11;
            sbe.SecurityHeaderLayout = SecurityHeaderLayout.Strict;
            sbe.IncludeTimestamp = false;
            sbe.SetKeyDerivation(true);
            sbe.KeyEntropyMode = System.ServiceModel.Security.SecurityKeyEntropyMode.ServerEntropy;
            CustomBinding customBinding = new CustomBinding();
            customBinding.Elements.Add(sbe);
            customBinding.Elements.Add(new TextMessageEncodingBindingElement(MessageVersion.Soap11, System.Text.Encoding.UTF8));
            customBinding.Elements.Add(new HttpsTransportBindingElement());

            //CreateMTOMInterfaceClient client = new CreateMTOMInterfaceClient(customBinding, endpoint);
            //client.ClientCredentials.UserName.UserName = userName;
            //client.ClientCredentials.UserName.Password = password;

            ServiceHost serviceHost = new ServiceHost(typeof(WCFCustomBinding), serviceURL);
            //add service endpoint
            ServiceEndpoint serviceEndpoint = serviceHost.AddServiceEndpoint(typeof(IWCFCustomBinding), customBinding, "WCFInCode");
            //add webHttp endpoint Behavior
            
            serviceHost.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });            
            serviceHost.Open();
        }
        public static void DownloadServiceFun()
        {
            using (System.ServiceModel.ServiceHost host = new
                 System.ServiceModel.ServiceHost(typeof(DownloadService)))
            {
                host.Open();
                foreach (Uri uri in host.BaseAddresses)
                {
                    Console.WriteLine(uri.ToString());
                }
                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
        public static void StartStopServiceFun() {
            //host wcf service
            ServiceHost host = new ServiceHost(typeof(StartStopService));
            host.Open();
            Console.WriteLine("web service is open");

        }
    }
}
