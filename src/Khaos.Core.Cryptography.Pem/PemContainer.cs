using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Khaos.Core.Extensions;

namespace Khaos.Core.Cryptography.Pem
{
    public class PemContainer : IPemContainer
    {
        private static readonly Regex PemRegex =
            new Regex(@"-----BEGIN (.*?)-----(.*?)-----END (.*?)-----", RegexOptions.Compiled | RegexOptions.Singleline);

        private string _stringRepresentation;
        
        public PemContainer(string content)
        {
            Check.NotNullOrWhiteSpace(content, nameof(content));
            
            (Format, Content) = ParsePem(content);
        }

        public PemContainer(byte[] content, Encoding encoding = null)
        {
            Check.NotNull(content, nameof(content));

            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            var stringContent = encoding.GetString(content);
            (Format, Content) = ParsePem(stringContent);
        }

        public PemContainer(string format, byte[] innerContent)
        {
            Check.NotNullOrWhiteSpace(format, nameof(format));
            Check.NotNull(innerContent, nameof(innerContent));

            Format = format.ToUpperInvariant();
            Content = innerContent;
        }
        
        public string Format { get; }
        public byte[] Content { get; }

        public override string ToString()
        {
            if (_stringRepresentation == null)
            {
                var innerContentString = Convert.ToBase64String(Content);
                var sb = new StringBuilder();

                sb.Append("-----BEGIN ").Append(Format).Append("-----").AppendLine();
                sb.Append(innerContentString.WrapHardByCharsCount(65)).AppendLine();
                sb.Append("-----END ").Append(Format).Append("-----").AppendLine();

                _stringRepresentation = sb.ToString();
            }

            return _stringRepresentation;
        }

        public static IEnumerable<PemContainer> FromCollection(string collectionContent)
        {
            var parsedPems = ParsePemCollection(collectionContent);

            foreach (var pem in parsedPems)
            {
                yield return new PemContainer(pem.Item1, pem.Item2);
            }
        }

        private static (string, byte[]) ParsePem(string content)
        {
            var results = ParsePemCollection(content);

            if (results.Count > 1)
            {
                throw new PemFormatException(content, "Provided PEM content contains more than one container.", nameof(content));
            }
            
            if (results.Count == 0)
            {
                throw new PemFormatException(content, "Provided PEM content contains no containers.", nameof(content));
            }

            return results.Single();
        }
        
        private static IReadOnlyCollection<(string, byte[])> ParsePemCollection(string content)
        {
            var matches = PemRegex.Matches(content);
            var results = new List<(string, byte[])>(matches.Count);

            foreach (Match match in matches)
            {
                var header = match.Groups[1].Value;
                var footer = match.Groups[3].Value;
                var matchContent = match.Groups[2].Value;

                if (header != footer)
                {
                    throw new PemFormatException(content, "PEM header does not match corresponding footer.");
                }

                try
                {
                    results.Add((header.ToUpperInvariant(), Convert.FromBase64String(matchContent)));
                }
                catch (FormatException e)
                {
                    throw new PemFormatException(content, "Failed to deserialize PEM content.", e);
                }
            }

            return results;
        }
    }
}