using System;

namespace GildedRose
{
    public static class StringExtensions
    {
        public static bool ContainsInsensitive(this string stringToSearch, string value)
        {
            return stringToSearch.Contains(value, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
