using PaypalNET.Common.Options;
using PaypalNET.Tests.Config;

namespace PaypalNET.Tests
{
    public class TestsBase
    {
        protected TestsConfig Config { get; set; }
        protected PaypalApiOptions ApiOptions { get; set; }

        public TestsBase()
        {
            Config = TestsConfigManager.GetConfiguration();
            ApiOptions = new PaypalApiOptions()
            {
                Mode = Common.Enums.PaypalApiMode.Sandbox
            };
        }
    }
}