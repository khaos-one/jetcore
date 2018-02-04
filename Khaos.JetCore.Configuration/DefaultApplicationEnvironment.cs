using System;

namespace Khaos.JetCore.Configuration
{
	public class DefaultApplicationEnvironment : IApplicationEnvironment
	{
		private const string EnvironmentVariableName = "NETCORE_ENVIRONMENT";
		private const string DefaultEnvironmentName = "default";
		private const string StagingEnvironmentName = "staging";
		private const string ProductionEnvironmentName = "production";

		private readonly string _environmentName;
		private readonly bool _isDevelopment;
		private readonly bool _isDemo;
		private readonly bool _isStaging;
		private readonly bool _isProduction;

		public string EnvironmentName => _environmentName;

		public bool IsEnvironment(string environmentName)
		{
			return _environmentName == environmentName;
		}

		public bool Development => _isDevelopment;

		public bool Staging => _isStaging;

		public bool Production => _isProduction;

		public DefaultApplicationEnvironment()
		{
			if (Environment.GetEnvironmentVariables().Contains(EnvironmentVariableName))
			{
				_environmentName = Environment
					.GetEnvironmentVariable(EnvironmentVariableName)
					.Trim()
					.ToLowerInvariant();
			}
			else
			{
				_environmentName = DefaultEnvironmentName;
			}

			_isStaging = _environmentName == StagingEnvironmentName;
			_isProduction = _environmentName == ProductionEnvironmentName;
			_isDevelopment = !_isDemo && !_isStaging && !_isProduction;
		}
	}
}