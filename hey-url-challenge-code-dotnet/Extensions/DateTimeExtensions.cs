using System;

namespace HeyUrlChallengeCodeDotnet.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToDefaultDateFormat(this DateTime date) => date.ToString("MMM dd, yyyy");
    }
}
