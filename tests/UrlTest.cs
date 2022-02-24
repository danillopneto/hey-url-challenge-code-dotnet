using HeyUrlChallengeCodeDotnet.Models;
using NUnit.Framework;
using System.Linq;

namespace tests
{
    public class UrlTest
    {
        [Test]
        [TestCase("http://www.google.com.br", 5)]
        [TestCase("http://www.fullstacklabs.com", 10)]
        public void GenerateShortUrl_ShouldGenerateUrl_WhenOriginalUrlIsProvided(string originalUrl, int size)
        {
            var url = new Url { OriginalUrl = originalUrl };

            url.GenerateShortUrl(size);

            Assert.IsNotEmpty(url.ShortUrl);
            Assert.AreEqual(size, url.ShortUrl.Length);
            Assert.IsTrue(url.ShortUrl.ToCharArray().All(x => char.IsLetter(x)));
        }

        [Test]
        public void GenerateShortUrl_ShouldNotGenerateUrl_WhenOriginalUrlIsEmpty()
        {
            var url = new Url();

            url.GenerateShortUrl(5);

            Assert.IsEmpty(url.ShortUrl);
            Assert.Zero(url.ShortUrl.Length);
        }
    }
}
