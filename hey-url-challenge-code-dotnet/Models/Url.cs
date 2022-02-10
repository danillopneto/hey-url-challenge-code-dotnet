using HeyUrlChallengeCodeDotnet.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HeyUrlChallengeCodeDotnet.Models
{
    public class Url : BaseModel
    {
        public Url()
        {
            Clicks = new List<Click>();
        }

        public string OriginalUrl { get; set; }

        public string ShortUrl { get; set; }

        public int Count => Clicks.Count;

        public IList<Click> Clicks { get; set; }

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
