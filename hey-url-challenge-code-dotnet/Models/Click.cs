using HeyUrlChallengeCodeDotnet.Models.Base;
using System;

namespace HeyUrlChallengeCodeDotnet.Models
{
    public class Click : BaseModel
    {
        public Click()
        {
        }

        public Click(string platform, string browser)
        {
            Platform = platform;
            Browser = browser;
        }

        public string Platform { get; set; }

        public string Browser { get; set; }

        public Guid UrlId { get; set; }

        public Url Url { get; set; }
    }
}
