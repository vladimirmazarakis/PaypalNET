namespace PaypalNET.Common.Requests.OAuth
{
    public class GetAccessTokenRequest
    {
        public static Dictionary<string, object> DefaultData = new(){{"grant_type","client_credentials"}};

        public Dictionary<string, object> Data { get; set; } = default!;
    }
}