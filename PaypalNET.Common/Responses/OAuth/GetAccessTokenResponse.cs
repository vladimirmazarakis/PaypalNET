using System.Text.Json.Serialization;
using PaypalNET.Common.Models.OAuth;

namespace PaypalNET.Common.Responses.OAuth
{
    public record GetAccessTokenResponse
    (string Scope, string AccessToken, string TokenType, string AppId, int ExpiresIn, string Nonce) 
    : AccessToken(Scope, AccessToken, TokenType, AppId, ExpiresIn, Nonce), IOAuthResponse;
}