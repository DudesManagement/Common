using System;
using System.Collections.Generic;
using System.Text;

namespace Horus.Common.Tools.BaseConfigurationsReader.Exceptions
{
    class ManadatoryConfigurationPropertyNotFoundException : Exception
    {

        public ManadatoryConfigurationPropertyNotFoundException (string configurationFileName, string DirectoryOfConfigurationFile, string missingPropertyKey,Exception innerException = null): base (CreateMessage(configurationFileName, DirectoryOfConfigurationFile, missingPropertyKey), innerException)
        {
        }

        private static string CreateMessage(string configurationFileName, string DirectoryOfConfigurationFile, string missingPropertyKey)
        {
            return string.Format("The key: \"{0}\", didn't match with any of the properties keys in the configuration file: \"{1}\" found in the directory: \"{2}\", are you sure you included this configuration in the config file ???", missingPropertyKey,configurationFileName,DirectoryOfConfigurationFile);
        }
    }
}
