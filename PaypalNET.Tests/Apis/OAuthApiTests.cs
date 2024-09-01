using System.Text;
using PaypalNET.Common.Constants;
using PaypalNET.Common.Exceptions;
using PaypalNET.Common.Exceptions.Auth;
using PaypalNET.Common.Interfaces;
using PaypalNET.Common.Models.OAuth;
using PaypalNET.Common.Requests.OAuth;
using PaypalNET.Common.Responses.OAuth;
using PaypalNET.Core.Services;
using Refit;

namespace PaypalNET.Tests.Apis
{
    public class OAuthApiTests : TestsBase
    {
        private readonly AuthPaypalService _authPaypalService;

        public OAuthApiTests()
        {
            _authPaypalService = new AuthPaypalService(ApiOptions);
        }

        private static bool AccessTokenValid(AccessToken? accessToken) => accessToken is not null && !string.IsNullOrEmpty(accessToken.Value);

        [Fact]
        public async Task Should_Return_Valid_AccessToken_When_Correct_ClientId_And_ClientSecret()
        {
            IOAuthResponse accessToken = await _authPaypalService.GetAccessToken(Config.Paypal.ClientId, Config.Paypal.ClientSecret);

            var castedAccessToken = accessToken as AccessToken;

            Assert.True(AccessTokenValid(castedAccessToken));
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Wrong_ClientId_And_Correct_ClientSecret()
        {
            await Assert.ThrowsAsync<IdentityPaypalServiceException>(() => _authPaypalService.GetAccessToken("Test123", Config.Paypal.ClientSecret));
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Correct_ClientId_And_Wrong_ClientSecret()
        {
            await Assert.ThrowsAsync<IdentityPaypalServiceException>(() => _authPaypalService.GetAccessToken(Config.Paypal.ClientId, "Test123"));
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Both_ClientId_And_ClientSecret_Wrong()
        {
            await Assert.ThrowsAsync<IdentityPaypalServiceException>(() => _authPaypalService.GetAccessToken("Test456", "Test123"));
        }
    }
}