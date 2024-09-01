using Microsoft.Extensions.Configuration;

namespace PaypalNET.Tests.Config
{
    public static class TestsConfigManager
    {
        public static IConfigurationRoot GetIConfigurationRoot()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)       // <-- this is the new line !!
                .AddEnvironmentVariables()
                .Build();
        }

        public static TestsConfig GetConfiguration()
        {
            var configuration = GetIConfigurationRoot().GetSection("Tests").Get<TestsConfig>();
            if(configuration is null)
            {
                throw new Exception("Please fill in the configuration file.");
            }
            return configuration;
        }
    }
}