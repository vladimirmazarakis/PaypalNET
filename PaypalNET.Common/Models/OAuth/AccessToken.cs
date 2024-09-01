namespace PaypalNET.Common.Models.OAuth
{
    public record AccessToken(string Scope, string Value, string TokenType, string AppId, int ExpiresIn, string Nonce);
}