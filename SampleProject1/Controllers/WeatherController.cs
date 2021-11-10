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
    public class WeatherController : Controller
    {
        // GET: Weather
        public ActionResult Weather(string citySearch)
        {

            double tempinC;
            var responseString = "";
            string apikey = "1e50af40ec67ff3758ad7c9b252d84b8";
            var response2String = "";
            string api2key = "b6683ec766af0607561a3147c2b7f783aec7eeabc95c32f427224e41cb15ac35";


            if (citySearch == "" || citySearch == null) citySearch = "Plovdiv";
            string url = "https://api.openweathermap.org/data/2.5/weather?q=" + citySearch + "&appid=" + apikey;


            var webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            responseString = webClient.DownloadString(url);


            JObject obj = JObject.Parse(responseString);
            Console.WriteLine(obj.ToString());
            responseString = obj.ToString();
            tempinC = (double)obj["main"]["temp"];
            tempinC -= 273.15;
            tempinC = Math.Round(tempinC, 2);


            string url2 = "https://serpapi.com/search.json?q=" + obj["weather"][0]["description"] + "%20weather&tbm=isch&ijn=0&api_key=" + api2key;

            var webClient2 = new WebClient();
            webClient2.Encoding = Encoding.UTF8;
            response2String = webClient2.DownloadString(url2);


            JObject obj2 = JObject.Parse(response2String);
            Console.WriteLine(obj2.ToString());
            response2String = obj2.ToString();




            ViewBag.temperature = tempinC;
            ViewBag.rain = obj["weather"][0]["description"];
            ViewBag.cityname = obj["name"];
            ViewBag.image = obj2["images_results"][0]["thumbnail"];
            ViewBag.response = response2String;

            return View();
        }
    }
}