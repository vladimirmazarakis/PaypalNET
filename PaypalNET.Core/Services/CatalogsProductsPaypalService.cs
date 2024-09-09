using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PaypalNET.Common.Interfaces;
using PaypalNET.Common.Models.CatalogsProducts;
using PaypalNET.Common.Models.OAuth;
using PaypalNET.Common.Options;
using PaypalNET.Common.Requests.CatalogsProducts;
using PaypalNET.Common.Responses.CatalogsProducts;
using PaypalNET.Core.ContractResolvers;
using PaypalNET.Core.Utilities;
using Refit;

namespace PaypalNET.Core.Services
{
    public class CatalogsProductsPaypalService : AuthorizedPaypalService<ICatalogsProductsApi, ICatalogProductResponse>
    {
        public CatalogsProductsPaypalService(PaypalApiOptions paypalApiOptions, AccessToken accessToken) 
        : base(paypalApiOptions, accessToken)
        {
            
        }

        public async Task<ICatalogProductResponse> CreateProduct(CreateCatalogProductRequest createCatalogProductRequest)
        {
            var response = await Service.CreateProduct(createCatalogProductRequest);
            return CheckResponseContentAndReturn(response);
        }

        public async Task<ICatalogProductResponse> ListProducts(int pageSize = 10, int page = 1, bool total_required = false)
        {
            var response =  await Service.ListProducts(pageSize, page, total_required);
            return CheckResponseContentAndReturn(response);
        }

        public async Task<ICatalogProductResponse> ProductDetails(string productId)
        {
            var response = await Service.ProductDetails(productId);
            return CheckResponseContentAndReturn(response);
        }

        public async Task UpdateProduct(string productId, UpdateCatalogProductRequest request)
        {
            var response = await Service.UpdateProduct(productId, request);
            CheckResponseContent(response);
        }

        public override string Address => "v1/catalogs/products";        
    }
}