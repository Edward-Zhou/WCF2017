using Microsoft.Web.Services3.Security.Cryptography;
using Microsoft.Web.Services3.Security.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;
using WCFAsync;
using WCFConsoleSelfHost;
using WCFSample;

namespace WCFAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DbOperationbtn_Click(object sender, EventArgs e)
        {
            DbOperationService.DbOperationClient dbOperation = new DbOperationService.DbOperationClient();

            bool isUpdated= dbOperation.UpdateTable(2,"T");
            dbOperation.Close();
            MessageBox.Show(isUpdated.ToString());
        }

        private void TimeOutbtn_Click(object sender, EventArgs e)
        {
            TimeOutService.TimeOutClient timeOut = new TimeOutService.TimeOutClient("BasicHttpBinding_ITimeOut1");
            try
            {
                string result = timeOut.GetData(123);
                string url = timeOut.Endpoint.Address.Uri.ToString();
                MessageBox.Show(url);
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
            
        }

        private void RestServiceOut_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri(@"http://localhost:39668/RestService.svc/CPSendInfo");
            WebRequest wr = WebRequest.Create(uri);
            wr.Method = "POST";
            wr.ContentType = "application/json";
            string json = @"{ ""LstData"": 123 }";
            var requestStream = wr.GetRequestStream();
            byte[] postBytes = Encoding.UTF8.GetBytes(json);
            requestStream.Write(postBytes,0,postBytes.Length);
            requestStream.Close();
            var response = (HttpWebResponse)wr.GetResponse();
            string result;
            using (var rdr = new StreamReader(response.GetResponseStream()))
            {
                result = rdr.ReadToEnd();
            }
            MessageBox.Show(result);
        }

        private void WCFDuplexNetTcpServicebtn_Click(object sender, EventArgs e)
        {
            lib.DuplexCallBack cb = new lib.DuplexCallBack();
            InstanceContext context = new InstanceContext(cb);
            WCFDuplexNetTcpService.WCFDuplexNetTcpClient client = new WCFDuplexNetTcpService.WCFDuplexNetTcpClient(context);
            client.WriteData(123);
            Console.ReadLine();
        }

        private void RestServiceJsonbtn_Click(object sender, EventArgs e)
        {
            //LoginInfo login = new LoginInfo();
            //Headers headers = new Headers() { loginname = "test", password = "tt" };
            //login.headers = headers;
            //string jsonString = JsonConvert.SerializeObject(login);

            //Uri uri = new Uri(@"http://localhost:39668/RestService.svc/LoginRest");
            //WebRequest wr = WebRequest.Create(uri);
            //wr.Method = "POST";
            //wr.ContentType = "application/json";
            //var requestStream = wr.GetRequestStream();
            //byte[] postBytes = Encoding.UTF8.GetBytes(jsonString);
            //requestStream.Write(postBytes, 0, postBytes.Length);
            //requestStream.Close();
            //var response = (HttpWebResponse)wr.GetResponse();
            //string result;
            //using (var rdr = new StreamReader(response.GetResponseStream()))
            //{
            //    result = rdr.ReadToEnd();
            //}
            //MessageBox.Show(result);

            using (HttpClient client = new HttpClient())
            {
                //POST Request
                string requestUrl = "http://localhost:39668/RestService.svc/LoginRest";
                LoginInfo login = new LoginInfo();
                Headers headers = new Headers() { loginname = "test", password = "tt" };
                login.headers = headers;
                string jsonString = JsonConvert.SerializeObject(login);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new StringContent(jsonString, Encoding.UTF8, "application/json");
                //var response = client.PostAsJsonAsync(requestUrl, request).Result;
                var responseObject = client.PostAsJsonAsync(requestUrl, login).Result;
                var resultObject = responseObject.Content.ReadAsStringAsync();
                var response = client.PostAsync(requestUrl, request).Result;
                var result = response.Content.ReadAsStringAsync();
            }
        }

        private void XsdDataContractExporterbtn_Click(object sender, EventArgs e)
        {
            ExportXSD();
        }

        static void ExportXSD()
        {
            XsdDataContractExporter exporter = new XsdDataContractExporter();
            if (exporter.CanExport(typeof(CompositeType)))
            {
                exporter.Export(typeof(CompositeType));
                Console.WriteLine("number of schemas: {0}", exporter.Schemas.Count);
                Console.WriteLine();
                XmlSchemaSet mySchemas = exporter.Schemas;

                XmlQualifiedName XmlNameValue = exporter.GetRootElementName(typeof(CompositeType));
                string EmployeeNameSpace = XmlNameValue.Namespace;

                foreach (XmlSchema schema in mySchemas.Schemas(EmployeeNameSpace))
                {
                    schema.Write(Console.Out);
                }
            }
        }

        static void GetXmlElementName()
        {
            XsdDataContractExporter myExporter = new XsdDataContractExporter();
            XmlQualifiedName xmlElementName = myExporter.GetRootElementName(typeof(CompositeType));
            Console.WriteLine("Namespace: {0}", xmlElementName.Namespace);
            Console.WriteLine("Name: {0}", xmlElementName.Name);
            Console.WriteLine("IsEmpty: {0}", xmlElementName.IsEmpty);
        }

        private void ClientSocketbtn_Click(object sender, EventArgs e)
        {

            StartClient();
        }
        public static void StartClient()
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];

            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // This example uses port 11000 on the local computer.
                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                //IPAddress ipAddress = ipHostInfo.AddressList[0];
                //IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);
                //IPAddress ipAddress = IPAddress.Parse("127.0.0.1"); //ipHostInfo.AddressList[0];
                IPAddress ipAddress = IPAddress.Parse("10.168.197.122");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 814);


                // Create a TCP/IP  socket.
                Socket sender = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.
                    byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

                    // Send the data through the socket.
                    int bytesSent = sender.Send(msg);

                    // Receive the response from the remote device.
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine("Echoed test = {0}",
                        Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    // Release the socket.
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public static void StartListening()
        {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress =ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 814);

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and 
            // listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.
                    Socket handler = listener.Accept();
                    string data = null;

                    // An incoming connection needs to be processed.
                    while (true)
                    {
                        bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }

                    // Show the data on the console.
                    Console.WriteLine("Text received : {0}", data);

                    // Echo the data back to the client.
                    byte[] msg = Encoding.ASCII.GetBytes(data);

                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        private void ServerSocketbtn_Click(object sender, EventArgs e)
        {
            StartListening();
        }

        private void SampleService_Click(object sender, EventArgs e)
        {
            var tasks = new List<Task>();
            var service = new SampleServiceReference.SampleClient();
            tasks.Add(Task.Factory.StartNew(() => service.GetOddNumbers()));
            tasks.Add(Task.Factory.StartNew(() => service.GetEvenNumbers()));
            Task.WaitAll(tasks.ToArray());
        }

        private void WCFBaseServicebtn_Click(object sender, EventArgs e)
        {
            WCFBaseClassService.WCFBaseClassClient client = new WCFBaseClassService.WCFBaseClassClient();
            WCFBaseClass.Fallible<WCFBaseClass.Pet> fall= client.GetFalliblePet(123);
            //WCFBaseClassService.SuccessOfPetQT_PEWyrz success = client.GetSuccessPet(21);

        }

        private void NetTcpBindingSecurity_Click(object sender, EventArgs e)
        {
            //NetTcpBinding binding = new NetTcpBinding();
            //binding.Security.Mode = SecurityMode.None;
            //EndpointAddress myEndpointAddress = new EndpointAddress("net.tcp://vdi-v-tazho.fareast.corp.microsoft.com/WCFNetTcp/WCFNetTcpService.svc");
            //WCFNetTcpService.WCFNetTcpServiceClient client = new WCFNetTcpService.WCFNetTcpServiceClient(binding,myEndpointAddress);
            WCFSecurityModeNoneReference.WCFSecurityModeNoneClient client = new WCFSecurityModeNoneReference.WCFSecurityModeNoneClient();
            //client.Open();
            string result= client.GetData(123);
            MessageBox.Show(result);
        }

        private void SecurityNonebtn_Click(object sender, EventArgs e)
        {
            SecurityNoneService.SecurityNoneClient client = new SecurityNoneService.SecurityNoneClient();
            string result= client.GetData();
            MessageBox.Show(result);
        }

        private void WCFDataTable_Click(object sender, EventArgs e)
        {
            DbOperationService.DbOperationClient client = new DbOperationService.DbOperationClient();
            DataTable dt = client.GetTable();
            MessageBox.Show(dt.Rows.Count.ToString());
        }

        private void HttpListenerbtn_Click(object sender, EventArgs e)
        {
            Server();
            MessageBox.Show("ok");
        }
        private HttpListener httpListener;
        public void Server()
        {
            this.httpListener = new HttpListener();

            if (httpListener.IsListening)
                throw new InvalidOperationException("Server is currently running.");

            httpListener.Prefixes.Clear();
            httpListener.Prefixes.Add("http://*:8080/");

            try
            {
                httpListener.Start(); //Throws Exception
            }
            catch (HttpListenerException ex)
            {
                if (ex.Message.Contains("Access is denied"))
                {
                    return;
                }
                else
                {
                    throw;
                }
            }
        }

        private void DownloadServer_Click(object sender, EventArgs e)
        {
            DownloadServiceReference.DownloadServiceClient client = new DownloadServiceReference.DownloadServiceClient();
            string result = client.GetData();
            var ss =client.ToString();
            var s = client.DownloadDocument();
            System.IO.File.WriteAllBytes
                (@"C:\Users\v-tazho\Desktop\" + s.Name, s.Content);
        }

        private void DownloadServerInCode_Click(object sender, EventArgs e)
        {
            //var b = new BasicHttpContextBinding();

            //b.SendTimeout = new TimeSpan(1, 59, 59);
            //b.ReceiveTimeout = new TimeSpan(1, 59, 59);
            //b.MaxReceivedMessageSize = int.MaxValue;
            //var cf = new ChannelFactory<DownloadServer.IDownloadService>(b);
            //var Addr = new EndpointAddress("http://localhost:8081/DownloadService");

            var b = new NetTcpBinding();

            b.SendTimeout = new TimeSpan(1, 59, 59);
            b.ReceiveTimeout = new TimeSpan(1, 59, 59);
            //b.Security.Mode = SecurityMode.None;
            //b.ReliableSession.Enabled = true;
            //b.ReliableSession.InactivityTimeout = new TimeSpan(1, 59, 59);
            b.MaxReceivedMessageSize = int.MaxValue;
            b.MaxBufferSize = int.MaxValue;
            b.MaxBufferPoolSize = int.MaxValue;
            b.ReaderQuotas.MaxDepth = int.MaxValue;
            b.ReaderQuotas.MaxStringContentLength = int.MaxValue;
            b.ReaderQuotas.MaxArrayLength = int.MaxValue;
            b.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
            b.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;
            var Addr = new EndpointAddress("net.tcp://localhost:8456/DownloadService");
            ChannelFactory<IDownloadService> cf = new ChannelFactory<IDownloadService>(b, Addr);
            //var Addr = new EndpointAddress("net.tcp://localhost:8456/DownloadService");
            IDownloadService mDet = cf.CreateChannel();

            if (mDet != null)
            {
                string result= mDet.GetData();
                var ss = mDet.ToString();
                var s = mDet.DownloadDocument();

                System.IO.File.WriteAllBytes
                    (@"C:\Users\v-tazho\Desktop\" + s.Name, s.Content);
            }
            MessageBox.Show("ok");
        }

        private void DownloadServerInCodebak_Click(object sender, EventArgs e)
        {
            //var b = new BasicHttpContextBinding();

            //b.SendTimeout = new TimeSpan(1, 59, 59);
            //b.ReceiveTimeout = new TimeSpan(1, 59, 59);
            //b.MaxReceivedMessageSize = int.MaxValue;
            //var cf = new ChannelFactory<DownloadServer.IDownloadService>(b);
            //var Addr = new EndpointAddress("http://localhost:8081/DownloadService");

            var b = new NetTcpBinding();

            b.SendTimeout = new TimeSpan(1, 59, 59);
            b.ReceiveTimeout = new TimeSpan(1, 59, 59);
            //b.Security.Mode = SecurityMode.None;
            //b.ReliableSession.Enabled = true;
            //b.ReliableSession.InactivityTimeout = new TimeSpan(1, 59, 59);
            b.MaxReceivedMessageSize = int.MaxValue;
            b.MaxBufferSize = int.MaxValue;
            b.MaxBufferPoolSize = int.MaxValue;
            //b.Security.Mode = SecurityMode.None;
            var Addr = new EndpointAddress("net.tcp://localhost:8456/DownloadService");
            var cf = new ChannelFactory<IDownloadService>(b, Addr);
            //var Addr = new EndpointAddress("net.tcp://localhost:8456/DownloadService");
            var mDet = cf.CreateChannel();

            if (mDet != null)
            {

                var ss = mDet.ToString();
                var s = mDet.DownloadDocument();
                System.IO.File.WriteAllBytes
                    (@"C:\Users\v-tazho\Desktop\" + s.Name, s.Content);
            }
        }

        private void WCFHttp_Click(object sender, EventArgs e)
        {
            try
            {
                WCFAPI.WCFHttp.Service1Client client = new WCFAPI.WCFHttp.Service1Client("BasicHttpBinding_IService1");
                string result = client.GetData(123);
                MessageBox.Show(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void WCFHttps_Click(object sender, EventArgs e)
        {
            WCFAPI.WCFHttp.Service1Client client = new WCFAPI.WCFHttp.Service1Client("BasicHttpBinding_IService11");
            string result = client.GetData(123);
            MessageBox.Show(result);
        }

        private async void WCFAsync_Click(object sender, EventArgs e)
        {
            var _bd = new WSHttpBinding();
            _bd.Security.Mode = SecurityMode.None;
            _bd.ReliableSession.Enabled = true;
            //_bd.ReliableSession.InactivityTimeout = TimeSpan.FromSeconds(3);
            _bd.ReceiveTimeout= TimeSpan.FromSeconds(3);
            var _factory = new ChannelFactory<IWCFAsync>(_bd, "http://localhost:1045/WCFAsync.svc");
            var _conn = _factory.CreateChannel();
            var _icc = _conn as IContextChannel;            
            try
            {
                string result = "";
                _icc.Open();
                
                _bd.ReliableSession.InactivityTimeout = TimeSpan.FromSeconds(3);
                result = await _conn.GetAsync(123);
                MessageBox.Show(result);
            }
            catch(CommunicationException ee)
            {
                //throw;
                MessageBox.Show(ee.Message.ToString());
            }
            finally
            { 
                if (_icc.State == CommunicationState.Opened)
                {
                    try { _icc.Close(); }
                    catch { _icc.Abort(); }
                }
            }
        }

        private void WCFSync_Click(object sender, EventArgs e)
        {
            var _bd = new WSHttpBinding();
            _bd.Security.Mode = SecurityMode.None;
            _bd.ReliableSession.Enabled = true;
            _bd.SendTimeout = TimeSpan.FromSeconds(3);

            var _factory = new ChannelFactory<IWCFAsync>(_bd, "http://localhost:1045/WCFAsync.svc");
            var _conn = _factory.CreateChannel();
            var _icc = _conn as IContextChannel;

            try
            {
                _icc.Open();
                string result = _conn.GetSync(123);
                MessageBox.Show(result);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (_icc.State == CommunicationState.Opened)
                {
                    try { _icc.Close(); }
                    catch { _icc.Abort(); }
                }
            }

        }

        private async void WCFAsyncREF_Click(object sender, EventArgs e)
        {
            WCFAPI.WCFAsyncServiceReference.WCFAsyncClient client = new WCFAsyncServiceReference.WCFAsyncClient();
            string result=await client.GetSyncAsync(123);
            MessageBox.Show(result);
        }

        private void GetSecurityToken_Click(object sender, EventArgs e)
        {
            KerberosToken securityToken = new KerberosToken("host/" + System.Net.Dns.GetHostName(), ImpersonationLevel.Impersonation);
            var key= securityToken.Key;
            
        }
        private WCFAPI.StartStopServiceReference.StartStopServiceClient client;
        private void StartService_Click(object sender, EventArgs e)
        {
            try
            {
                client = new StartStopServiceReference.StartStopServiceClient();
                string result = client.StartService();
                MessageBox.Show(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());                
            }
        }

        private void StopService_Click(object sender, EventArgs e)
        {
            try
            {
                // WCFAPI.StartStopServiceReference.StartStopServiceClient client = new StartStopServiceReference.StartStopServiceClient();
                string result = client.StopService();
                MessageBox.Show(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void WCFTest_Click(object sender, EventArgs e)
        {
            try
            {
                WCFAPI.WCFTestServiceReference.WCFTestClient client = new WCFTestServiceReference.WCFTestClient();
                string result = client.DoWork();
                MessageBox.Show(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void WCFDataTablebtn_Click(object sender, EventArgs e)
        {
            WCFAPI.WCFDataTableService.WCFDataTableClient client = new WCFDataTableService.WCFDataTableClient();
            dataGridView1.DataSource = client.ReturnDataTable();
        }

        private void WCFDebugBehaviorbtn_Click(object sender, EventArgs e)
        {
            //WCFAPI.WCFDebugBehaviorReference.WCFDebugBehaviorClient client = new WCFDebugBehaviorReference.WCFDebugBehaviorClient();
            //ServiceDebugBehavior debugBehavior = client.Endpoint.Behaviors.Find<ServiceDebugBehavior>();
            //if (debugBehavior == null)
            //{
            //    debugBehavior = new ServiceDebugBehavior();
            //    debugBehavior.IncludeExceptionDetailInFaults = true;
            //    client.des
            //    client.Endpoint.Behaviors.Add(debugBehavior);
            //}
        }

        private void ChannelFactory_Click(object sender, EventArgs e)
        {

        }
        public class Order
        {
            public int orderId;
            public DateTime orderTime;
        };
        private void MSMQSendMessage_Click(object sender, EventArgs e)
        {
            // Create a new order and set values.
            Order sentOrder = new Order();
            sentOrder.orderId = 3;
            sentOrder.orderTime = DateTime.Now;
            System.Messaging.MessageQueue[] queueList = System.Messaging.MessageQueue.GetPrivateQueuesByMachine(Environment.MachineName);
            //queueList.Dump();
            //var q = queueList[0];
            // Connect to a queue on the local computer.
            MessageQueue myQueue = queueList[0]; //new MessageQueue(".\\myQueue");

            // Send the Order to the queue.
            myQueue.Send(sentOrder);
        }

        private void MSMQReveiveMessage_Click(object sender, EventArgs e)
        {
            // Connect to the a queue on the local computer.
            System.Messaging.MessageQueue[] queueList = System.Messaging.MessageQueue.GetPrivateQueuesByMachine(Environment.MachineName);
            //queueList.Dump();
            //var q = queueList[0];
            // Connect to a queue on the local computer.
            MessageQueue myQueue = queueList[0]; //new MessageQueue(".\\myQueue");

            // Set the formatter to indicate body contains an Order.
            myQueue.Formatter = new XmlMessageFormatter(new Type[]
                {typeof(Order)});

            try
            {
                // Receive and format the message. 
                System.Messaging.Message myMessage = myQueue.Receive();
                Order myOrder = (Order)myMessage.Body;

                // Display message information.
                Console.WriteLine("Order ID: " +
                    myOrder.orderId.ToString());
                Console.WriteLine("Sent: " +
                    myOrder.orderTime.ToString());
            }

            catch (MessageQueueException)
            {
                // Handle Message Queuing exceptions.
            }

            // Handle invalid serialization format.
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void MSMQDeleteMessage_Click(object sender, EventArgs e)
        {
            // Connect to the a queue on the local computer.
            System.Messaging.MessageQueue[] queueList = System.Messaging.MessageQueue.GetPrivateQueuesByMachine(Environment.MachineName);
            MessageQueue myQueue = queueList[0];
            MessageEnumerator enumerator = myQueue.GetMessageEnumerator2();
            while (enumerator.MoveNext())
            {
                //remove message
                //enumerator.RemoveCurrent();
                System.Messaging.Message mes = enumerator.Current;
                mes.Formatter=new System.Messaging.XmlMessageFormatter(new Type[] { typeof(string) });
                
            }

        }

        private void MSMQListMsg_Click(object sender, EventArgs e)
        {
            System.Messaging.MessageQueue[] queueList = System.Messaging.MessageQueue.GetPrivateQueuesByMachine(Environment.MachineName);
            MessageQueue myQueue = queueList[1];
            List<System.Messaging.Message> messages = myQueue.GetAllMessages().ToList();
            foreach (System.Messaging.Message message in messages)
            {
                message.Formatter = new XmlMessageFormatter(
                                new Type[]{typeof(Order)});
                Order order = message.Body as Order;
                //get message label
                Console.WriteLine(message.Label);
                //get message body
                Console.WriteLine(order.orderId);
                Console.WriteLine(order.orderTime);
            }
        }

        private void GetDataTablePro_Click(object sender, EventArgs e)
        {
            DbOperationService.DbOperationClient client = new DbOperationService.DbOperationClient();
            DataTable dt = client.GetTableFromPro();
            dataGridView1.DataSource = dt;
            //MessageBox.Show(dt.Rows.Count.ToString());
        }

        private void MSMQStringBody_Click(object sender, EventArgs e)
        {
            System.Messaging.MessageQueue[] queueList = System.Messaging.MessageQueue.GetPrivateQueuesByMachine(Environment.MachineName);
            MessageQueue myQueue = queueList[1];
            List<System.Messaging.Message> messages = myQueue.GetAllMessages().ToList();
            foreach (System.Messaging.Message message in messages)
            {
                System.Xml.XmlDocument result = ConvertToXMLDoc(message);     
                MessageBox.Show(result.InnerXml);
            }

        }
        public System.Xml.XmlDocument ConvertToXMLDoc(System.Messaging.Message msg)
        {
            byte[] buffer = new byte[msg.BodyStream.Length];
            msg.BodyStream.Read(buffer, 0, (int)msg.BodyStream.Length);
            int envelopeStart = FindEnvolopeStart(buffer);
            System.IO.MemoryStream stream = new System.IO.MemoryStream(buffer, envelopeStart, buffer.Length - envelopeStart);
            System.ServiceModel.Channels.BinaryMessageEncodingBindingElement elm = new System.ServiceModel.Channels.BinaryMessageEncodingBindingElement();
            System.ServiceModel.Channels.Message msg1 = elm.CreateMessageEncoderFactory().Encoder.ReadMessage(stream, Int32.MaxValue);
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(msg1.GetReaderAtBodyContents());
            msg.BodyStream.Position = 0;
            return doc;
        }
        private int FindEnvolopeStart(byte[] stream)
        {
            int i = 0;
            byte prevByte = stream[i];
            byte curByte = (byte)0;
            for (i = 0; i < stream.Length; i++)
            {
                curByte = stream[i];
                if (curByte == (byte)0x02 &&
                prevByte == (byte)0x56)
                    break;
                prevByte = curByte;
            }
            return i - 1;
        }

        private void WCFCustomBinding_Click(object sender, EventArgs e)
        {
            WCFCusBindingService.Service1Client client = new WCFCusBindingService.Service1Client();
            string result= client.GetData(123);
            MessageBox.Show(result);
        }

        [DllImport("iphlpapi.dll", SetLastError = true)]
        static extern uint GetExtendedTcpTable(IntPtr pTcpTable, ref int dwOutBufLen, bool sort, int ipVersion, TCP_TABLE_CLASS tblClass, uint reserved = 0);
        public const int AF_INET = 2;    // IP_v4 = System.Net.Sockets.AddressFamily.InterNetwork
        public const int AF_INET6 = 23;  // IP_v6 = System.Net.Sockets.AddressFamily.InterNetworkV6
        public enum TCP_TABLE_CLASS
        {
            TCP_TABLE_BASIC_LISTENER,
            TCP_TABLE_BASIC_CONNECTIONS,
            TCP_TABLE_BASIC_ALL,
            TCP_TABLE_OWNER_PID_LISTENER,
            TCP_TABLE_OWNER_PID_CONNECTIONS,
            TCP_TABLE_OWNER_PID_ALL,
            TCP_TABLE_OWNER_MODULE_LISTENER,
            TCP_TABLE_OWNER_MODULE_CONNECTIONS,
            TCP_TABLE_OWNER_MODULE_ALL
        }
        public  List<MIB_TCPROW_OWNER_PID> GetAllTCPConnections()
        {
            return GetTCPConnections<MIB_TCPROW_OWNER_PID, MIB_TCPTABLE_OWNER_PID>(AF_INET);
        }

        //public static List<MIB_TCP6ROW_OWNER_PID> GetAllTCPv6Connections()
        //{
        //    return GetTCPConnections<MIB_TCP6ROW_OWNER_PID, MIB_TCP6TABLE_OWNER_PID>(AF_INET6);
        //}

        private static List<IPR> GetTCPConnections<IPR, IPT>(int ipVersion)//IPR = Row Type, IPT = Table Type
        {
            IPR[] tableRows;
            int buffSize = 0;

            var dwNumEntriesField = typeof(IPT).GetField("dwNumEntries");

            // how much memory do we need?
            uint ret = GetExtendedTcpTable(IntPtr.Zero, ref buffSize, true, ipVersion, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);
            IntPtr tcpTablePtr = Marshal.AllocHGlobal(buffSize);

            try
            {
                ret = GetExtendedTcpTable(tcpTablePtr, ref buffSize, true, ipVersion, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);
                if (ret != 0)
                    return new List<IPR>();

                // get the number of entries in the table
                IPT table = (IPT)Marshal.PtrToStructure(tcpTablePtr, typeof(IPT));
                int rowStructSize = Marshal.SizeOf(typeof(IPR));
                uint numEntries = (uint)dwNumEntriesField.GetValue(table);

                // buffer we will be returning
                tableRows = new IPR[numEntries];

                IntPtr rowPtr = (IntPtr)((long)tcpTablePtr + 4);
                for (int i = 0; i < numEntries; i++)
                {
                    IPR tcpRow = (IPR)Marshal.PtrToStructure(rowPtr, typeof(IPR));
                    tableRows[i] = tcpRow;
                    rowPtr = (IntPtr)((long)rowPtr + rowStructSize);   // next entry
                }
            }
            finally
            {
                // Free the Memory
                Marshal.FreeHGlobal(tcpTablePtr);
            }
            return tableRows != null ? tableRows.ToList() : new List<IPR>();
        }
        private void GetTcpPID_Click(object sender, EventArgs e)
        {
            List<MIB_TCPROW_OWNER_PID> result = GetAllTCPConnections();
        }

        private void CallAsmxService_Click(object sender, EventArgs e)
        {
            ASMXService.WebService1 client = new ASMXService.WebService1();
            
            string result= client.HelloWorld();
            client.Dispose();
        }

        private void WCFClientTimeOut_Click(object sender, EventArgs e)
        {
            WCFTimeOut.TimeOutClient client = new WCFTimeOut.TimeOutClient("BasicHttpBinding_ITimeOut2");
            ////client is generated client proxy
            //client.ClientCredentials.UserName.UserName = "account";
            //client.ClientCredentials.UserName.Password = "password";
            string result= client.GetData(123);
            MessageBox.Show(result);

        }

        private void GetList_Click(object sender, EventArgs e)
        {
            WCFLibService.Service1Client client = new WCFLibService.Service1Client();
            var list = client.LoadStations(new WCFLibService.LoadStationsRequest());
            
            foreach (var item in list.LoadStationsResult)
                System.Diagnostics.Debug.WriteLine(item);
            System.Diagnostics.Debug.WriteLine("finished");
        }

        private void RemoveNode_Click(object sender, EventArgs e)
        {
            XElement root = XElement.Load(@"D:\Edward\Project\WCF2017\WCF2017\WCFAPI\XML.xml"); // or .Parse(string)
            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"D:\Edward\Project\WCF2017\WCF2017\WCFAPI\XML.xml");
            //XmlNode root = doc.FirstChild;
            //foreach (XmlNode xn in root.ChildNodes)
            //{                
            //    if (xn.ChildNodes[0].HasChildNodes)
            //    {
            //        System.Diagnostics.Debug.WriteLine(xn.InnerXml);
            //        xn.ChildNodes[0];
            //        node.AddBeforeSelf(node.Elements());
            //        node.Remove();

            //    }
            //}
            //doc.Save(@"D:\Edward\Project\WCF2017\WCF2017\WCFAPI\XMLOK.xml");
            //Display the contents of the child nodes.
            //if (root.HasChildNodes)
            //{
            //    for (int i = 0; i < root.ChildNodes.Count; i++)
            //    {
            //        Console.WriteLine(root.ChildNodes[i].InnerText);
            //    }
            //}

            foreach (var node in root.Nodes())
            {
                if (((System.Xml.Linq.XElement)node).HasElements)
                {
                    foreach (XElement xe in ((XElement)node).Elements())
                    {
                        ((XElement)node.PreviousNode.NodesBeforeSelf()).AddAfterSelf("<t></t>");
                        //((XElement)node.PreviousNode).AddBeforeSelf(xe.Elements());
                        //xe.Parent.Remove();
                    }
                }
                //System.Diagnostics.Debug.WriteLine(node);
            }
            //var removes = root.XPathSelectElements("//remove[@attribute=\"toRemove\"]");
            //foreach (XElement node in removes.ToArray())
            //{
            //    node.AddBeforeSelf(node.Elements());
            //    node.Remove();
            //}
            root.Save(@"D:\Edward\Project\WCF2017\WCF2017\WCFAPI\XMLOK.xml");
        }

        private void ConvertToJson_Click(object sender, EventArgs e)
        {
            var xml =
        @"<Columns>
          <Column Name=""key1"" DataType=""Boolean"">True</Column>
          <Column Name=""key2"" DataType=""String"">Hello World</Column>
          <Column Name=""key3"" DataType=""Integer"">999</Column>
        </Columns>";
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\Edward\Project\WCF2017\WCF2017\WCFAPI\XML.xml");
            XmlNode root = doc.FirstChild;
            Dictionary<string, dynamic> dic = new Dictionary<string, dynamic>();
            if (root.HasChildNodes)
            {
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    dic.Add(root.ChildNodes[i].Name, Convert.ChangeType(root.ChildNodes[i].InnerText,(GetType(root.ChildNodes[i].Attributes["type"].Value))));
                    Console.WriteLine(root.ChildNodes[i].Name+";"+root.ChildNodes[i].InnerXml);
                }
            }

            var json = new JavaScriptSerializer().Serialize(dic);
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

        private void CustomFault_Click(object sender, EventArgs e)
        {

            try
            {

                var fac = new ChannelFactory<WCFFaultException.IService1>(
                new BasicHttpBinding(),
                "http://localhost:2258/Service1.svc");

                var proxy = fac.CreateChannel();
                string result = proxy.GetData(123);
                //WCFFaultService. client = new WCFFaultService.Service1Client();
                //string result = client.GetData(123);
            }
            catch (FaultException<WCFFaultException.MyCustomException> cf)
            {
                MessageBox.Show(cf.Detail.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }

        private void RunBat_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = @"D:\Edward\Project\WCF2017\WCF2017\WCFRest\Test\Test.bat";
            proc.StartInfo.WorkingDirectory = @"D:\Edward\Project\WCF2017\WCF2017\WCFRest\Test\";
            proc.Start();
            
        }

        private void ClientAuth_Click(object sender, EventArgs e)
        {
            WCFClientAuth.GestioneCheckinV1ImplClient client = new WCFClientAuth.GestioneCheckinV1ImplClient();
            client.inviaMovimentazione(new WCFClientAuth.xmlImportDati() { codice = "test" });
            //WCFAuthAsmx.GestioneCheckinV1ImplService client = new WCFAuthAsmx.GestioneCheckinV1ImplService();
            //client.inviaMovimentazione(new WCFAuthAsmx.xmlImportDati() { codice = "test" });
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCPTABLE_OWNER_PID
    {
        public uint dwNumEntries;
        MIB_TCPROW_OWNER_PID table;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCPROW_OWNER_PID
    {
        public uint state;
        public uint localAddr;
        public byte localPort1;
        public byte localPort2;
        public byte localPort3;
        public byte localPort4;
        public uint remoteAddr;
        public byte remotePort1;
        public byte remotePort2;
        public byte remotePort3;
        public byte remotePort4;
        public int owningPid;

        public ushort LocalPort
        {
            get
            {
                return BitConverter.ToUInt16(
                    new byte[2] { localPort2, localPort1 }, 0);
            }
        }

        public ushort RemotePort
        {
            get
            {
                return BitConverter.ToUInt16(
                    new byte[2] { remotePort2, remotePort1 }, 0);
            }
        }
    }
    public class ShellCommand
    {
        public string command { get; set; }
        public bool cygwin { get; set; }
        public Dictionary<string, string> environmentVariables { get; set; }
    }
    [DataContract]
    public class LoginInfo
    {
        [DataMember]
        public Headers headers { get; set; }
    }

    [DataContract]
    public class Headers
    {
        [DataMember]
        public string loginname { get; set; }

        [DataMember]
        public string password { get; set; }
    }
}
