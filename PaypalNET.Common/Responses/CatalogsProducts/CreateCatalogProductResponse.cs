using System.Text.Json.Serialization;
using PaypalNET.Common.Models;
using PaypalNET.Common.Models.CatalogsProducts;

namespace PaypalNET.Common.Responses.CatalogsProducts
{
    public record CreateCatalogProductResponse
    (string Name, string Id, string Description, string Type, string Category, string ImageUrl
    , string HomeUrl, HATEOASLinkList Links, string CreateTime, string UpdateTime) 
    : 
    UrlInfoCatalogProduct
    (Name, Id, Description, Type, Category, ImageUrl, HomeUrl)
    , ILinkedCreatedUpdatedTimeCatalogProduct, ICatalogProductResponse;
}