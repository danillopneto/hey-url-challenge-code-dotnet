using System;
using System.Collections.Generic;
using hey_url_challenge_code_dotnet.Models;
using hey_url_challenge_code_dotnet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HeyUrlChallengeCodeDotnet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly Random getrandom = new Random();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();
            model.Urls = new List<Url>
            {
                new Url()
                {
                    ShortUrl = "ABCDE",
                    Count = getrandom.Next(1, 10)
                },
                new Url()
                {
                    ShortUrl = "ABCDE",
                    Count = getrandom.Next(1, 10)
                },
                new Url()
                {
                    ShortUrl = "ABCDE",
                    Count = getrandom.Next(1, 10)
                },
            };
            return View(model);
        }
    }
}
