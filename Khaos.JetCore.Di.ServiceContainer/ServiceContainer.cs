using System;
using Microsoft.Extensions.DependencyInjection;

namespace Khaos.JetCore.Di.ServiceContainer
{
	public static class ServiceContainer
	{
		private static IServiceProvider _container;
		private static object _sync = new object();

		public static void Assign(in Func<IServiceProvider> generator)
		{
			var serviceProvider = generator();
			Assign(in serviceProvider);
		}
		
		public static void Assign(in IServiceProvider provider)
		{
			lock (_sync)
			{
				if (_container != null)
					throw new InvalidOperationException("ServiceContainer has already been assigned.");

				_container = provider;
			}
		}

		public static T Get<T>()
		{
			lock (_sync)
			{
				return _container.GetService<T>();
			}
		}

		public static T GetRequired<T>()
		{
			lock (_sync)
			{
				return _container.GetRequiredService<T>();
			}
		}
	}
}