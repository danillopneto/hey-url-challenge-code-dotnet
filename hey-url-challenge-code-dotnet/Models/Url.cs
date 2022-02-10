using System;
using System.Text;
using System.Text.RegularExpressions;

namespace HeyUrlChallengeCodeDotnet.Models
{
    public class Url
    {
        public Guid Id { get; set; }

        public string OriginalUrl { get; set; }

        public string ShortUrl { get; set; }

        public int Count { get; set; }

        public void GenerateShortUrl(int size)
        {
            if (string.IsNullOrWhiteSpace(OriginalUrl))
            {
                ShortUrl = string.Empty;
                return;
            }

            var shortUrl = new StringBuilder();
            var onlyLetters = Regex.Replace(OriginalUrl, "[^a-z]", string.Empty, RegexOptions.IgnoreCase);
            var random = new Random();

            do
            {
                var randomChar = onlyLetters[random.Next(0, onlyLetters.Length)];
                shortUrl.Append(randomChar.ToString().ToUpperInvariant());
            } while (shortUrl.Length < size);

            ShortUrl = shortUrl.ToString();
        }
    }
}
