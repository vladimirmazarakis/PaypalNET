using System.Runtime.ConstrainedExecution;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using PaypalNET.Common.Interfaces.Abstractions;

namespace PaypalNET.Common.Models.CatalogsProducts
{
    /// <summary>
    /// Catalog product
    /// </summary>
    /// <param name="Name">Name of product.</param>
    /// <param name="Id">Id of product. (Usually an SKU)</param>
    /// <param name="Description">Description of product.</param>
    public record BaseCatalogProduct(string Name, string Id, string Description);
    public record BaseTypedCatalogProduct(string Name, string Id, string Description, string Type, string Category) : BaseCatalogProduct(Name, Id, Description);
    public record UrlInfoCatalogProduct(string Name, string Id, string Description, string Type, string Category, string ImageUrl, string HomeUrl) : BaseTypedCatalogProduct(Name, Id, Description, Type, Category);
    public interface ILinkedCatalogProduct{ public HATEOASLinkList Links {get; init;} }
    public interface ILinkedCreatedUpdatedTimeCatalogProduct : ILinkedCatalogProduct, ICreatedUpdateTime{}
}