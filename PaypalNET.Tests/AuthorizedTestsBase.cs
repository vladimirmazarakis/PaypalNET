using PaypalNET.Common.Models.OAuth;
using PaypalNET.Core.Services;

namespace PaypalNET.Tests
{
    public class AuthorizedTestsBase : TestsBase
    {
        protected AccessToken AccessToken { get; init; }

        public AuthorizedTestsBase()
        {
            AccessToken = (AccessToken)new AuthPaypalService(ApiOptions).GetAccessToken(Config.Paypal.ClientId, Config.Paypal.ClientSecret).Result;
        }
    }
}