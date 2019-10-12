using System;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Khaos.Core.ServiceHosting
{
    internal class InPlaceHostingEnvironment : IHostEnvironment
    {
        private const string DefaultEnvironmentName = "Development";

        public string EnvironmentName
        {
            get => _currentEnvironmentName;
            set => throw new NotImplementedException();
        }

        public string ApplicationName
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string ContentRootPath
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public IFileProvider ContentRootFileProvider
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        private string _currentEnvironmentName;

        public InPlaceHostingEnvironment()
        {
            _currentEnvironmentName =
                Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT") ??
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ??
                DefaultEnvironmentName;
        }
    }
}
