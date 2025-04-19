using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essentials2.Library.Extensions
{
    public static class StringExtensions
    {
        // C# extension method is a static method of a static class, where
        // the "this" modifier is applied to the first parameter. The type
        // of the first parameter will be the type that is extended.

        /*
         * An extension method with the same name and signature as an instance method will not be called.
         * Extension methods cannot be used to override existing methods.
         * The concept of extension methods cannot be applied to fields, properties, or events.
         */

        public static string Right(this string input, int numChars)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            if (input.Length < numChars)
            {
                return $"Error: {input.Length} < {numChars}";
            }
            return input[^numChars..]; // or return input.Substring(input.Length - numChars);
        }
        public static string Left(string input, int numChars)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            if (input.Length < numChars)
            {
                return $"Error: {input.Length} < {numChars}";
            }
            return input[..numChars]; // or return input.Substring(0, numChars);
        }
    }
}