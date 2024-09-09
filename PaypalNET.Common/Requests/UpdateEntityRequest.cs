using PaypalNET.Common.Models;

namespace PaypalNET.Common.Requests
{
    public record UpdateEntityRequest(UpdateOperation Op, string Path, string Value, string From);
}