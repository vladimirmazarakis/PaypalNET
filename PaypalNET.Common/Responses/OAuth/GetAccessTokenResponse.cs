using System.Text.Json.Serialization;

namespace PaypalNET.Common.Responses.OAuth
{
    public class GetAccessTokenResponse
    {
        public string Scope { get; set; } = default!;
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = default!;
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; } = default!;
        [JsonPropertyName("app_id")]
        public string AppId { get; set; } = default!;
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
        public string Nonce { get; set; } = default!;
    }
}