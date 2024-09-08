namespace PaypalNET.Common.Models.OAuth
{
    /// <summary>
    /// Access Token, used for Paypal Api Auth.
    /// </summary>
    /// <param name="Scope">What services this access token has access to.</param>
    /// <param name="Value">The token.</param>
    /// <param name="TokenType">Type of token.</param>
    /// <param name="AppId">Id of application.</param>
    /// <param name="ExpiresIn">Expiration in seconds.</param>
    /// <param name="Nonce">Nonce.</param>
    public record AccessToken(string Scope, string Value, string TokenType, string AppId, int ExpiresIn, string Nonce);
}