using System.Collections.Generic;
using HeyUrlChallengeCodeDotnet.Models;

namespace HeyUrlChallengeCodeDotnet.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Url> Urls { get; set; }
        public Url NewUrl { get; set; }
    }
}
