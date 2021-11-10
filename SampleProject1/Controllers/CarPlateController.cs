using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace SampleProject1.Controllers
{
    public class CarPlateController : Controller
    {
        // GET: First
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string searchNumber)
        {
            // подготвяме променливи
            var responseString = "";

            // адрес към който изпращаме заявка
            if (searchNumber == "" || searchNumber == null) searchNumber = "empty";
            //if (string.IsNullOrEmpty(searchNumber)) same as above
            string url = "https://check.bgtoll.bg/check/vignette/plate/BG/" + searchNumber;

            // уеб клиент за изпращане на заявка
            var webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            responseString = webClient.DownloadString(url);

            // трансформация на JSON в обект
            JObject obj = JObject.Parse(responseString);
            // Console.WriteLine(obj.ToString());
            // responseString = obj["ok"].ToString();
            responseString = obj.ToString();

            string ok = obj["ok"].ToString();
            string statusCode = obj["status"]["code"].ToString();

            // връщане на резултати
            ViewBag.searchNumber = searchNumber;
            ViewBag.response = responseString;
            ViewBag.ok = ok;
            ViewBag.statusCode = statusCode;



            // винетка данни
            if (statusCode == "200")
            {
                ViewBag.vignetteNumber = obj["vignette"]["vignetteNumber"];
                ViewBag.vehicleClass = obj["vignette"]["vehicleClass"];
                ViewBag.validityDateFromFormated = obj["vignette"]["validityDateFromFormated"];
                ViewBag.validityDateToFormated = obj["vignette"]["validityDateToFormated"];
            }

            return View();
        }

        

       

       


    }
}