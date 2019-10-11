using System;
using System.Text;

namespace Khaos.Core.Cryptography.Pem
{
    internal static class StringExtensions
    {
        internal static string WrapHardByCharsCount(this string @string, int charsCountOnLine)
        {
            if (@string.Length <= charsCountOnLine)
            {
                return @string;
            }

            var wrapsCount = (int) Math.Floor(@string.Length / (float) charsCountOnLine);
            var sb = new StringBuilder(@string, @string.Length + wrapsCount);

            for (var i = 1; i <= wrapsCount; i++)
            {
                sb.Insert(i * charsCountOnLine - 1, '\n');
            }

            return sb.ToString();
        }
    }
}