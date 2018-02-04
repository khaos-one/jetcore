using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Khaos.JetCore.Configuration
{
	public class ApplicationConfiguration : IApplicationConfiguration
	{
		private readonly IConfiguration _configuration;
		private readonly IApplicationEnvironment _environment;

		public string this[string key]
		{
			get => _configuration.GetSection(_environment.EnvironmentName)[key];
			set => _configuration.GetSection(_environment.EnvironmentName)[key] = value;
		}

		public IApplicationEnvironment Environment => _environment;
		
		public ApplicationConfiguration(in IApplicationEnvironment environment, in IConfiguration configuration)
		{
			_environment = environment;
			_configuration = configuration;
		}

		public IEnumerable<IConfigurationSection> GetChildren()
		{
			return _configuration.GetSection(_environment.EnvironmentName).GetChildren();
		}

		public IChangeToken GetReloadToken()
		{
			return _configuration.GetSection(_environment.EnvironmentName).GetReloadToken();
		}

		public IConfigurationSection GetSection(string key)
		{
			return _configuration.GetSection(_environment.EnvironmentName).GetSection(key);
		}
	}
}