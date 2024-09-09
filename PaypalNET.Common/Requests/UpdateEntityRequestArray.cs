using PaypalNET.Common.Models;

namespace PaypalNET.Common.Requests
{
    public record UpdateEntityRequestArray(IList<UpdateEntityRequest> Array) : IUpdateEntityRequestArray;

    public interface IUpdateEntityRequestArray
    {
        public IList<UpdateEntityRequest> Array {get; init;}
    }
}