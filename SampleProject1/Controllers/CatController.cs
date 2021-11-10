using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SampleProject1.Controllers
{
    public class CatController : Controller
    {
        // GET: Meme
        public ActionResult factsGenerator(string meme, string topText, string bottomText)
        {


            var factEndpoint = "https://cat-fact.herokuapp.com/facts/random?animal_type=cat";
            var webClient = new WebClient();
            var response = webClient.DownloadString(factEndpoint);
            var jsonResponseObject = JObject.Parse(response);

            string fact = "";
            

            if (jsonResponseObject.ContainsKey("text") )
            {
                fact = jsonResponseObject.GetValue("text").ToString();
                
            }

        

            ViewBag.Fact = fact;
            

            return View("Cat");


        }
    }
}