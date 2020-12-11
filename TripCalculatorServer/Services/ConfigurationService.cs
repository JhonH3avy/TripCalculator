using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration _config;

        public ConfigurationService(IConfiguration config)
        {
            _config = config;
        }

        public T GatValueInSection<T>(string sectionKey, string key)
        {
            return _config.GetSection(sectionKey).GetValue<T>(key);
        }
    }
}
