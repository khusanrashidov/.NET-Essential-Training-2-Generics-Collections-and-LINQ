using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essentials2.Library.Extensions
{
    public static class StringExtensions
    {
        public static string Right(string input, int numChars)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            if (input.Length < numChars)
            {
                return $"Error: {input.Length} < {numChars}";
            }
            return input.Substring(input.Length - numChars); // or return input[^numChars..];
        }
    }
}