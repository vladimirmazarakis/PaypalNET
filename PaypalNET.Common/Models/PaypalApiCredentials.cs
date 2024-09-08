using PaypalNET.Common.Models.OAuth;

namespace PaypalNET.Common.Models
{
    /// <summary>
    /// Api Credentials, used to ask for <see cref="AccessToken"/>.
    /// </summary>
    /// <param name="ClientId">Client Id.</param>
    /// <param name="ClientSecret">Client Secret.</param>
    public record PaypalApiCredentials(string ClientId, string ClientSecret);
}