using PaypalNET.Common.Models.CatalogsProducts;

namespace PaypalNET.Common.Requests.CatalogsProducts
{
    public record CreateCatalogProductRequest
    (string Name, string Id, string Description, string Type, string Category, string ImageUrl, string HomeUrl) 
    : UrlInfoCatalogProduct
    (Name, Id, Description, Type, Category, ImageUrl, HomeUrl);
}