using System.Text.RegularExpressions;

namespace MudBlazorAsaasBilling.Extensions
{
    public static class StringExtensions
    {
        public static string CharactersOnly(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string pattern = @"[-\.\(\)\s]";

            string result = Regex.Replace(input, pattern, string.Empty);

            return result;
        }
    }
}
