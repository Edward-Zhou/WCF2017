using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFHttpListenerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(HttpListenerService));
            sh.Open();
            Console.WriteLine("Service is open");
            Console.ReadLine();
        }
        private HttpListener httpListener;
        public void Server()
        {
            this.httpListener = new HttpListener();

            if (httpListener.IsListening)
                throw new InvalidOperationException("Server is currently running.");

            httpListener.Prefixes.Clear();
            httpListener.Prefixes.Add("http://*:4444/");

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

    }
}
