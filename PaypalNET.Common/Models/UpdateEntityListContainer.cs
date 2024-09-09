using PaypalNET.Common.Models;

namespace PaypalNET.Common.Models
{
    public record UpdateEntityListContainer(IList<UpdateEntity> List) : IUpdateEntityListContainer;

    public interface IUpdateEntityListContainer
    {
        public IList<UpdateEntity> List {get; init;}
    }
}