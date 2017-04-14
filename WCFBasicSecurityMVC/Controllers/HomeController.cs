using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WCFBasicSecurityMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //WCFBasicServiceReference.Service1Client client = new WCFBasicServiceReference.Service1Client();
            //string result= client.GetData(123);
            BasicWebService.WebService1 client = new BasicWebService.WebService1();
            client.Credentials = new System.Net.NetworkCredential("v-tazho", "Edward0214","fareast");
            string result = client.HelloWorld();
            ViewBag.Message = result;//"Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            WebServiceEx client = new WebServiceEx();
            string result = client.HelloWorld();
            ViewBag.Message = result;// "Your contact page.";

            return View();
        }
    }
}