using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;

namespace MVC2WCFSecurity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ServiceReference.Service1Client test = new ServiceReference.Service1Client();

            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(OnValidationCallback);

            test.ClientCredentials.UserName.UserName = "test";
            test.ClientCredentials.UserName.Password = "test";

            ViewBag.Message = test.GetData(10);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public static bool OnValidationCallback(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }
}
