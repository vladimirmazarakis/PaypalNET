namespace PaypalNET.Common.Models
{
    /// <summary>
    /// https://developer.paypal.com/api/rest/responses/#hateoas-links
    /// </summary>
    public class HATEOASLinkList : List<HATEOASLink>
    {

    }

    public record HATEOASLink(string Href, string Rel, string Method);
}