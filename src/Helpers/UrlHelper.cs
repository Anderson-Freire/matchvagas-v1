using System;

namespace src.Helpers
{
    public static class UrlHelper
    {
        public static string GetLogoUrl(string website)
        {
            if (string.IsNullOrWhiteSpace(website)) return null;
            var domain = new Uri(website).Host;
            return $"https://www.google.com/s2/favicons?domain={domain}&sz=128";
        }
    }
}