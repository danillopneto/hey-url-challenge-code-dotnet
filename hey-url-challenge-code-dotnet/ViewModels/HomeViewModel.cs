using System.Collections.Generic;
using hey_url_challenge_code_dotnet.Models;

namespace hey_url_challenge_code_dotnet.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Url> Urls { get; set; }
        public Url NewUrl { get; set; }
    }
}
