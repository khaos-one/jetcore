using System;

namespace Khaos.Core.Cryptography.Pem
{
    public class PemFormatException : ArgumentException
    {
        public string RawContent { get; }

        public PemFormatException(string rawContent)
        {
            RawContent = rawContent;
        }

        public PemFormatException(string rawContent, string message)
            : base(message)
        {
            RawContent = rawContent;
        }

        public PemFormatException(string rawContent, string message, Exception innerException)
            : base(message, innerException)
        {
            RawContent = rawContent;
        }

        public PemFormatException(string rawContent, string message, string paramName)
            : base(message, paramName)
        {
            RawContent = rawContent;
        }

        public PemFormatException(string rawContent, string message, string paramName, Exception innerException)
            : base(message, paramName, innerException)
        {
            RawContent = rawContent;
        }
    }
}