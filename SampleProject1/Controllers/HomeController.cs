using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult About()
        {
            return View("About");
        }
        public ActionResult Contact()
        {
            return View("Contact");
        }
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}