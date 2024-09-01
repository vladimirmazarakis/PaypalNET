using PaypalNET.Common.Models;
using PaypalNET.Common.Models.CatalogsProducts;

namespace PaypalNET.Common.Responses.CatalogsProducts
{
    public record ListCatalogsProductsResponse
    (List<ListCatalogProductItem> Products, int TotalItems, int TotalPages, HATEOASLinkList Links) 
    : ICatalogProductResponse;

    public record ListCatalogProductItem(string Id, string Name, string Description, HATEOASLinkList Links, string CreateTime) 
    : BaseCatalogProduct(Id, Name, Description), ILinkedCatalogProduct, ICreatedTimeCatalogProduct;
}