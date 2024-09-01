using PaypalNET.Common.Constants;
using PaypalNET.Common.Requests.CatalogProducts;
using PaypalNET.Common.Responses.CatalogProducts;
using Refit;

namespace PaypalNET.Common.Interfaces
{
    [Headers(AuthorizationHeaders.Bearer)]
    public interface ICatalogProductsApi
    {
        [Post("")]
        Task<IApiResponse<CreateCatalogProductResponse>> CreateProduct([Body] CreateCatalogProductRequest requestBody);

    //     [Get("")]
    //     Task<IApiResponse<ListCatalogProductsResponse>> ListProducts([Query]int page_size = 10, [Query]int page = 1, [Query]bool total_required = false);
    }
}