using System.Reflection;
using System.Text.RegularExpressions;

namespace WebCalculator.Extensions
{
    public static class StringExtensions
    {
        public static string SanitizeInput(this string input)
        {
            input = input.Replace(" ", "");
            input = input.Replace(",", ".");
            return input;
        }
    }
}
