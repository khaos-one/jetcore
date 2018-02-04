using System;

namespace Khaos.JetCore.Configuration
{
    public interface IApplicationEnvironment
    {
        string EnvironmentName { get; }
        bool IsEnvironment(string environmentName);
        bool Development { get; }
        bool Staging { get; }
        bool Production { get; }
    }
}
