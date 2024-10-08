using PaypalNET.Common.Models;
using PaypalNET.Common.Requests;

namespace PaypalNET.Common.Requests.CatalogsProducts
{
    public record UpdateCatalogProductRequest(IList<UpdateEntity> List) : IUpdateEntityListContainer;
}