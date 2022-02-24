using HeyUrlChallengeCodeDotnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeyUrlChallengeCodeDotnet.ViewModels
{
    public class ShowViewModel
    {
        public Dictionary<string, int> BrowseClicks => Url.Clicks.GroupBy(x => x.Browser).ToDictionary(b => b.Key, b => b.Count());

        public Dictionary<string, int> DailyClicks => GetDailyClicks();

        public Dictionary<string, int> PlatformClicks => Url.Clicks.GroupBy(x => x.Platform).ToDictionary(b => b.Key, b => b.Count());

        public Url Url { get; set; }

        public ShowViewModel(Url url)
        {
            Url = url;
        }

        private Dictionary<string, int> GetDailyClicks()
        {
            var dailyClicks = new Dictionary<string, int>();
            var currentDay = DateTime.Now.Day;

            var clicksGroupedByDate = Url.Clicks.Where(x => x.CreatedAt.Year == DateTime.Now.Year && x.CreatedAt.Month == DateTime.Now.Month)
                                                .GroupBy(x => x.CreatedAt.Day).ToDictionary(b => b.Key, b => b.Count());
            for (var day = 1; day <= currentDay; day++)
            {
                var dailyClick = clicksGroupedByDate.ContainsKey(day) ? clicksGroupedByDate[day] : 0;
                dailyClicks.Add(day.ToString(), dailyClick);
            }

            return dailyClicks;
        }
    }
}
