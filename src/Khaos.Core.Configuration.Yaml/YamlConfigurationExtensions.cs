using System.IO;
using JetBrains.Annotations;
using Khaos.Core.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace Khaos.Core.Configuration.Yaml
{
    public static class YamlConfigurationExtensions
    {
        public static IConfigurationBuilder AddYamlFile(
            [NotNull] this IConfigurationBuilder builder,
            [NotNull] string path,
            [CanBeNull] IFileProvider provider = null, 
            bool optional = false, 
            bool reloadOnChange = false)
        {
            Check.NotNull(builder, nameof(builder));
            Check.NotNullOrWhiteSpace(path, nameof(path));

            if (provider == null && Path.IsPathRooted(path))
            {
                provider = new PhysicalFileProvider(Path.GetDirectoryName(path));
                path = Path.GetFileName(path);
            }

            var source = new YamlConfigurationSource
            {
                FileProvider = provider,
                Path = path,
                Optional = optional,
                ReloadOnChange = reloadOnChange
            };

            return builder.Add(source);
        }
    }
}
