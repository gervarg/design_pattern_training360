using System;

namespace FactoryMethod
{    
    partial class ConfigProviderFactrory
    {
        public static IConfigProvider GetConfigProvider(ConfigProvider configProvider)
        {
            switch (configProvider)
            {
                case ConfigProvider.Json:
                    return new JsonConfigProvider();
                case ConfigProvider.Xml:
                    return new XmlConfigProvider();
                case ConfigProvider.Sample:
                    return new SampleConfigProvider();
                default:
                    throw new Exception($"Not supported {nameof(configProvider)}!");
            }
        }
    }
}