using System;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.IO;
using Khaos.Core.Configuration.Yaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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

        public static IHostBuilder WithDefaultLogging(
            this IHostBuilder builder, 
            Action<HostBuilderContext, ILoggingBuilder> configurator = null)
        {
            return builder
                .ConfigureLogging(
                    (context, loggingBuilder) =>
                    {
                        loggingBuilder
                            .AddConfiguration(context.Configuration.GetSection("logging"));

                        if (Debugger.IsAttached)
                        {
                            loggingBuilder.AddDebug();
                        }
                        
                        configurator?.Invoke(context, loggingBuilder);
                    });
        }
    }
}