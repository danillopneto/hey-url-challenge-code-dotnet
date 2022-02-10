using HeyUrlChallengeCodeDotnet.Models;
using HeyUrlChallengeCodeDotnet.Repositories;
using HeyUrlChallengeCodeDotnet.Validators;
using HeyUrlChallengeCodeDotnet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shyjus.BrowserDetection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HeyUrlChallengeCodeDotnet.Controllers
{
    [Route("/")]
    public class UrlsController : Controller
    {
        private readonly ILogger<UrlsController> _logger;

        private readonly IBrowserDetector _browserDetector;

        private readonly IConfiguration _configuration;

        private readonly IUrlRepository _urlRepository;

        public UrlsController(
                              ILogger<UrlsController> logger,
                              IBrowserDetector browserDetector,
                              IConfiguration configuration,
                              IUrlRepository urlRepository)
        {
            _browserDetector = browserDetector ?? throw new ArgumentNullException(nameof(browserDetector));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _urlRepository = urlRepository ?? throw new ArgumentNullException(nameof(urlRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        public async Task<IActionResult> Create(HomeViewModel viewModel, CancellationToken ct)
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

                do
                {
                    url.GenerateShortUrl(size);
                } while (await _urlRepository.GetByShortUrlAsync(url.ShortUrl, ct) is not null);

                await _urlRepository.SaveAsync(url, ct);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var model = new HomeViewModel();
            model.Urls = await _urlRepository.GetAllAsync(ct);
            return View(model);
        }

        [Route("/{shortUrl}")]
        public async Task<IActionResult> Visit(string shortUrl, CancellationToken ct)
        {
            var url = await _urlRepository.GetByShortUrlAsync(shortUrl, ct);
            if (url is null)
            {
                return View("NotFound");
            }

            await _urlRepository.AddClicksToUrlAsync(url, _browserDetector.Browser.OS, _browserDetector.Browser.Name, ct);

            return Redirect(url.OriginalUrl);
        }

        [Route("urls/{shortUrl}")]
        public async Task<IActionResult> Show(string shortUrl, CancellationToken ct)
        {
            var url = await _urlRepository.GetByShortUrlAsync(shortUrl, ct);
            if (url is null)
            {
                return View("NotFound");
            }

            return View(new ShowViewModel(url));
        }
    }
}
