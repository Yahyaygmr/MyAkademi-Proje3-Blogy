using Blogy.BusinessLayer.Abstaract;
using Blogy.EntityLayer.Concrete;
using Blogy.WebUI.Areas.Writer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.Xml.Linq;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    [Route("Writer/{controller}/{action}/{id?}")]
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(IHttpClientFactory httpClientFactory, IServiceManager serviceManager, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _serviceManager = serviceManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            #region Statistics
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            int myBlogsCount = _serviceManager.ArticleService.TGetArticlesByArticleByWriter(user.Id).Count();
            Article? myLastBlog = _serviceManager.ArticleService.TGetArticlesByArticleByWriter(user.Id)?
                .FirstOrDefault();
            string? myLastBlogDate = myLastBlog?.CreatedDate.ToString("dd MMM yyyy");
            string? myLastBlogName = myLastBlog?.Title;
            int blogCount = _serviceManager.ArticleService.GetTContext().Count();
            int commentCount = _serviceManager.CommentService.TGetListAll().Count;
            string? mostUsedCategoy = _serviceManager.CategoryService
                .GetTContext()
                .OrderByDescending(c => c.Articles.Count)
                .FirstOrDefault()?
                .Name;

            ViewBag.myBlogsCount = myBlogsCount;
            ViewBag.commentCount = commentCount;
            ViewBag.blogCount = blogCount;
            ViewBag.myLastBlogName = myLastBlogName;
            ViewBag.myLastBlogDate = myLastBlogDate;
            ViewBag.mostUsedCategoy = mostUsedCategoy;

            #endregion





            #region WeatherApi1
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://yahoo-weather5.p.rapidapi.com/weather?location=istanbul&format=json&u=c"),
                Headers =
            {
                { "X-RapidAPI-Key", "38c011d3demsh877633ef4ae234ap1fae70jsn5f63793d31a2" },
                { "X-RapidAPI-Host", "yahoo-weather5.p.rapidapi.com" },
            },
            };
            using (var response5 = await client.SendAsync(request))
            {
                response5.EnsureSuccessStatusCode();
                var body = await response5.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<WeatherApiViewModel>(body);

                #endregion
                #region WeatherApi2
                string apiKey = "270ee2e1d2e397c5b0fd607ec6b1b5ca";
                string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + apiKey;
                XDocument document = XDocument.Load(connection);
                var response = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                var response1 = document.Descendants("clouds").ElementAt(0).Attribute("name").Value;
                var response2 = document.Descendants("city").ElementAt(0).Attribute("name").Value;

                // API'den gelen tarih/saat dizgesi
                string lastUpdateString = document.Descendants("lastupdate").ElementAt(0).Attribute("value").Value;
                // Tarih/saat dizesini DateTime nesnesine dönüştürme
                DateTime lastUpdate = DateTime.Parse(lastUpdateString);

                // String'i ondalık sayıya dönüştür
                double temperature = double.Parse(response.Replace(".", ","));

                // Ondalık sayıyı tamsayıya dönüştür
                int roundedTemperature = (int)Math.Round(temperature, MidpointRounding.AwayFromZero);

                ViewBag.tempreture = roundedTemperature;

                TextInfo textInfo = new CultureInfo("tr-TR", false).TextInfo;
                string response1Result = textInfo.ToTitleCase(response1);
                ViewBag.clouds = response1Result;

                ViewBag.lastUpdateDate = lastUpdate.ToString("dd MMM yyyy");
                ViewBag.lastUpdateTime = lastUpdate.ToString("HH:mm");
                ViewBag.cityName = response2;
                #endregion
                return View(value);
            }
        }
    }
}