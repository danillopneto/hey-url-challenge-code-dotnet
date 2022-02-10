using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using HeyUrlChallengeCodeDotnet.Models;
using HeyUrlChallengeCodeDotnet.Validators;
using HeyUrlChallengeCodeDotnet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shyjus.BrowserDetection;

namespace HeyUrlChallengeCodeDotnet.Controllers
{
    [Route("/")]
    public class UrlsController : Controller
    {
        private readonly ILogger<UrlsController> _logger;
        private static readonly Random getrandom = new Random();
        private readonly IBrowserDetector _browserDetector;
        private readonly IConfiguration _configuration;

        public UrlsController(
                              ILogger<UrlsController> logger, 
                              IBrowserDetector browserDetector,
                              IConfiguration configuration)
        {
            _browserDetector = browserDetector ?? throw new ArgumentNullException(nameof(browserDetector));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        public IActionResult Create(HomeViewModel viewModel, CancellationToken ct)
        {
            var url = new Url { OriginalUrl = viewModel.NewUrl };

            var result = new UrlValidator().Validate(url);
            if (!result.IsValid)
            {
                var messages = string.Join(Environment.NewLine, result.Errors.Select(x => x.ErrorMessage));
                TempData["Notice"] = messages;
            }
            else
            {
                var size = _configuration.GetValue<int>("ShortUrlSize");
                url.GenerateShortUrl(size);
            }

            return RedirectToAction(nameof(Index));
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
            return View(model);
        }

        [Route("/{url}")]
        public IActionResult Visit(string url) => new OkObjectResult($"{url}, {this._browserDetector.Browser.OS}, {this._browserDetector.Browser.Name}");

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