using PaypalNET.Common.Constants;
using PaypalNET.Common.Requests.CatalogsProducts;
using PaypalNET.Common.Responses.CatalogsProducts;
using Refit;

namespace PaypalNET.Common.Interfaces
{
    /// <summary>
    /// Catalogs Products Api, more info: https://developer.paypal.com/docs/api/catalog-products/v1/
    /// </summary>
    [Headers(AuthorizationHeaders.Bearer)]
    public interface ICatalogsProductsApi
    {
        [Post("")]
        Task<IApiResponse<CreateCatalogProductResponse>> CreateProduct([Body] CreateCatalogProductRequest requestBody);

        [Get("")]
        Task<IApiResponse<ListCatalogsProductsResponse>> ListProducts([Query]int page_size = 10, [Query]int page = 1, [Query]bool total_required = false);
    
        [Get("/{product_id}")]
        Task<IApiResponse<CatalogProductDetailsResponse>> ProductDetails(string product_id);

        [Patch("/{product_id}")]
        Task<IApiResponse> UpdateProduct(string product_id, [Body] UpdateCatalogProductRequest requestBody);
    }
}