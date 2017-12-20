using Horus.Logger;
using Horus.Common.Tools.BaseConfigurationsReader.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Horus.Common.Tools.BaseConfigurationsReader.Constants;

namespace Horus.Common.Tools.BaseConfigurationsReader
{
    public class JsonBaseConfigurationsReader
    {
        protected readonly string configurationFileName;
        private readonly IConfigurationRoot configuration;
        private readonly ILogger _logger;

        public JsonBaseConfigurationsReader(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            configurationFileName = ConfigurationConstants.DefaultConfigurationFileName;
        }

        protected string GetOptionalConfiguration(string key)
        {
            _logger.DEBUG(string.Format("Reading optional configuration for Key: \"{0}\", from the file \"{1}\" from the directory {2}", key, configurationFileName, Directory.GetCurrentDirectory()));
            string value = configuration[key];

            _logger.DEBUG(string.Format("Value: \"{0}\", found for the key: \"{1}\"", value, key));
            return value;
        }

        protected string GetManadatoryConfiguration(string key)
        {
            _logger.DEBUG(string.Format("Reading manadatory configuration for Key: \"{0}\", from the file \"{1}\" from the directory {2}", key, configurationFileName, Directory.GetCurrentDirectory()));
            string value = configuration[key];
            
            if(value==null)
            {
                _logger.ERROR(string.Format("Manadatory Configuration, The key: \"{0}\", didn't match with any of the properties keys in the configuration file: \"{1}\" found in the directory: \"{2}\", are you sure you included this configuration in the config file ???", key, configurationFileName, Directory.GetCurrentDirectory()));
                throw new ManadatoryConfigurationPropertyNotFoundException(configurationFileName, Directory.GetCurrentDirectory(), key);
            }
            else
            {
                _logger.DEBUG(string.Format("Value: \"{0}\", found for the key: \"{1}\"", value, key));
                return value;
            }
            
        }

        protected void BuildConfiguration()
        {

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile(configurationFileName);
        }
    }
}
