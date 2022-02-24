using FluentAssertions;
using HeyUrlChallengeCodeDotnet.Controllers;
using HeyUrlChallengeCodeDotnet.Models;
using HeyUrlChallengeCodeDotnet.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Shyjus.BrowserDetection;
using System.Threading;
using System.Threading.Tasks;

namespace tests
{
    public class UrlsControllerTest
    {
        private Mock<ILogger<UrlsController>> _logger;

        private Mock<IBrowserDetector> _browserDetector;

        private Mock<IConfiguration> _configuration;

        private Mock<IUrlRepository> _urlRepository;

        private UrlsController _urlsController;

        [SetUp]
        public void Setup()
        {
            _logger = new();
            _browserDetector = new();
            _configuration = new();
            _urlRepository = new();
            _urlsController = new UrlsController(
                                                 _logger.Object,
                                                 _browserDetector.Object,
                                                 _configuration.Object,
                                                 _urlRepository.Object);
        }

        [Test]
        public async Task Show_ShouldReturnNotFoundView_WhenThereIsNoUrl()
        {
            _urlRepository
                .Setup(u => u.GetByShortUrlAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(It.IsAny<Url>());

            var result = await _urlsController.Show(It.IsAny<string>(), It.IsAny<CancellationToken>());

            result.Should().NotBeNull()
                  .And.BeOfType<ViewResult>();
            _urlRepository.Verify(u => u.GetByShortUrlAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task Show_ShouldReturnShowView_WhenThereIsUrl()
        {
            _urlRepository
                .Setup(u => u.GetByShortUrlAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Url());

            var result = await _urlsController.Show(It.IsAny<string>(), It.IsAny<CancellationToken>());

            result.Should().NotBeNull()
                  .And.BeOfType<ViewResult>();
            _urlRepository.Verify(u => u.GetByShortUrlAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
