using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Xml.Linq;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/{controller}/{action}/{id?}")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            #region WeatherApi
            //string apiKey = "270ee2e1d2e397c5b0fd607ec6b1b5ca";
            //string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + apiKey;
            //XDocument document = XDocument.Load(connection);
            //var response = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            //var response1 = document.Descendants("clouds").ElementAt(0).Attribute("name").Value;
            //var response2 = document.Descendants("city").ElementAt(0).Attribute("name").Value;

            //// API'den gelen tarih/saat dizgesi
            ////string lastUpdateString = document.Descendants("lastupdate").ElementAt(0).Attribute("value").Value;
            //// Tarih/saat dizesini DateTime nesnesine dönüştürme
            ////DateTime lastUpdate = DateTime.Parse(lastUpdateString);

            //// String'i ondalık sayıya dönüştür
            //double temperature = double.Parse(response.Replace(".", ","));

            //// Ondalık sayıyı tamsayıya dönüştür
            //int roundedTemperature = (int)Math.Round(temperature, MidpointRounding.AwayFromZero);

            //ViewBag.tempreture = roundedTemperature;
            ////ViewBag.lastUpdateDate = lastUpdate.ToString("dd MMM yyyy");
            ////ViewBag.lastUpdateTime = lastUpdate.ToString("HH:mm");
            //ViewBag.cityName = response2;
            #endregion

            return View();
        }
    }
}
