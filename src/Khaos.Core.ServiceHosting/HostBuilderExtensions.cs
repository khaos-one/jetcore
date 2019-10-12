using System.IO;
using Khaos.Core.Configuration.Yaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Khaos.Core.ServiceHosting
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder WithDefaultConfiguration(this IHostBuilder builder)
        {
            return builder
                .UseEnvironment(EnvironmentName.Default)
                .ConfigureHostConfiguration(
                    configurationBuilder =>
                    {
                        configurationBuilder
                            .SetBasePath(Directory.GetCurrentDirectory())
                            // This is for strict compatibility of services with each other.
                            .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                            .AddEnvironmentVariables("NETCORE_");
                    })
                .ConfigureAppConfiguration(
                    (context, configurationBuilder) =>
                    {
                        configurationBuilder
                            .AddYamlFile($"appsettings.yml",
                                optional: false, reloadOnChange: false)
                            .AddYamlFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.yml",
                                optional: true, reloadOnChange: false)                           
                            .AddYamlFile("appsettings.configmap.yml", optional: true)
                            .AddEnvironmentVariables();
                    });
        }
    }
}