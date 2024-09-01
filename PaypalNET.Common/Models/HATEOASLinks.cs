namespace PaypalNET.Common.Models
{
    public class HATEOASLinkList : List<HATEOASLink>
    {

    }

    public record HATEOASLink(string Href, string Rel, string Method);
}