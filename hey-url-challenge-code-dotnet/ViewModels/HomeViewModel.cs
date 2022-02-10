using HeyUrlChallengeCodeDotnet.Models;
using System.Collections.Generic;

namespace HeyUrlChallengeCodeDotnet.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Url> Urls { get; set; }

        public string NewUrl { get; set; }
    }
}
