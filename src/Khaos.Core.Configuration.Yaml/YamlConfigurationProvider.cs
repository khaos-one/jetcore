using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using YamlDotNet.Core;

namespace Khaos.Core.Configuration.Yaml
{
    public class YamlConfigurationProvider : FileConfigurationProvider
    {
        public YamlConfigurationProvider(FileConfigurationSource source) 
            : base(source)
        { }

        public override void Load(Stream stream)
        {
            var parser = new YamlConfigurationFileParser();

            try
            {
                Data = parser.Parse(stream);
            }
            catch (YamlException e)
            {
                throw new FormatException($"Failed to parse YAML file: '{e.Message}'", e);
            }
        }
    }
}
