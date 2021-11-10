using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SampleProject1.Controllers
{
    public class JokeController : Controller
    {
        // GET: Joke
        public ActionResult JokeEndpoint()
        {
            var jokeApiEndpoint = "https://v2.jokeapi.dev/joke/Any";
            var webClient = new WebClient();
            var response = webClient.DownloadString(jokeApiEndpoint);
            var jsonResponseObject = JObject.Parse(response);

            string joke = "";
            string setup = "";
            string delivery = "";

            if (jsonResponseObject.ContainsKey("delivery") && jsonResponseObject.ContainsKey("setup"))
            {
                setup = jsonResponseObject.GetValue("setup").ToString();
                delivery = jsonResponseObject.GetValue("delivery").ToString();
            }

            if (jsonResponseObject.ContainsKey("joke"))
            {
                joke = jsonResponseObject.GetValue("joke").ToString();
            }

            ViewBag.Setup = setup;
            ViewBag.Joke = joke;
            ViewBag.Delivery = delivery;

            return View("Jokes");

        }
    }
}