using Microsoft.Extensions.Configuration;

namespace Khaos.JetCore.Configuration
{
    public interface IApplicationConfiguration : IConfiguration
    {
        IApplicationEnvironment Environment { get; }
    }
}