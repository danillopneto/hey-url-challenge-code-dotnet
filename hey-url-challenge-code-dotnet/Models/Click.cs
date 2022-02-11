using HeyUrlChallengeCodeDotnet.Models.Base;
using JsonApiDotNetCore.Resources.Annotations;
using System;

namespace HeyUrlChallengeCodeDotnet.Models
{
    [Resource(nameof(Click))]
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

        [Attr]
        public string Platform { get; set; }

        [Attr]
        public string Browser { get; set; }

        public Guid UrlId { get; set; }

        public Url Url { get; set; }
    }
}
