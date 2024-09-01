using PaypalNET.Common.Models.CatalogProducts;

namespace PaypalNET.Common.Requests.CatalogProducts
{
    public record CreateCatalogProductRequest
    (string Name, string Id, string Description, string Type, string Category, string ImageUrl, string HomeUrl) 
    : UrlInfoCatalogProduct
    (Name, Id, Description, Type, Category, ImageUrl, HomeUrl);
}