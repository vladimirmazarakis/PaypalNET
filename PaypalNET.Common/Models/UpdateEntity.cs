using PaypalNET.Common.Models;

namespace PaypalNET.Common.Models
{
    public record UpdateEntity(UpdateOperation Op, string Path, string Value, string From);
}