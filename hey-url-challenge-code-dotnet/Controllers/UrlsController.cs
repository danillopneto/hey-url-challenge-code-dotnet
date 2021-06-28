using System;
using System.Collections.Generic;
using hey_url_challenge_code_dotnet.Models;
using hey_url_challenge_code_dotnet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shyjus.BrowserDetection;

namespace HeyUrlChallengeCodeDotnet.Controllers
{
    [Route("/")]
    public class UrlsController : Controller
    {
        private readonly ILogger<UrlsController> _logger;
        private static readonly Random getrandom = new Random();
        private readonly IBrowserDetector browserDetector;

        public UrlsController(ILogger<UrlsController> logger, IBrowserDetector browserDetector)
        {
            this.browserDetector = browserDetector;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();
            model.Urls = new List<Url>
            {
                new()
                {
                    ShortUrl = "ABCDE",
                    Count = getrandom.Next(1, 10)
                },
                new()
                {
                    ShortUrl = "ABCDE",
                    Count = getrandom.Next(1, 10)
                },
                new()
                {
                    ShortUrl = "ABCDE",
                    Count = getrandom.Next(1, 10)
                },
            };
            model.NewUrl = new();
            return View(model);
        }

        [Route("/{url}")]
        public IActionResult Visit(string url) => new OkObjectResult($"{url}, {this.browserDetector.Browser.OS}, {this.browserDetector.Browser.Name}");

        [Route("urls/{url}")]
        public IActionResult Show(string url) => View(new ShowViewModel
        {
            Url = new Url {ShortUrl = url, Count = getrandom.Next(1, 10)},
            DailyClicks = new Dictionary<string, int>
            {
                {"1", 13},
                {"2", 2},
                {"3", 1},
                {"4", 7},
                {"5", 20},
                {"6", 18},
                {"7", 10},
                {"8", 20},
                {"9", 15},
                {"10", 5}
            },
            BrowseClicks = new Dictionary<string, int>
            {
                { "IE", 13 },
                { "Firefox", 22 },
                { "Chrome", 17 },
                { "Safari", 7 },
            },
            PlatformClicks = new Dictionary<string, int>
            {
                { "Windows", 13 },
                { "macOS", 22 },
                { "Ubuntu", 17 },
                { "Other", 7 },
            }
        });
    }
}