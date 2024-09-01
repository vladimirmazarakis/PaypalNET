using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PaypalNET.Common.Errors.CatalogProducts;
using PaypalNET.Common.Interfaces;
using PaypalNET.Common.Models.CatalogProducts;
using PaypalNET.Common.Models.OAuth;
using PaypalNET.Common.Options;
using PaypalNET.Common.Requests.CatalogProducts;
using PaypalNET.Common.Responses.CatalogProducts;
using PaypalNET.Core.ContractResolvers;
using PaypalNET.Core.Services.Interfaces;
using Refit;

namespace PaypalNET.Core.Services
{
    public class CatalogProductsPaypalService : AuthorizedPaypalService<ICatalogProductsApi>
    {
        public CatalogProductsPaypalService(PaypalApiOptions paypalApiOptions, AccessToken accessToken) 
        : base(paypalApiOptions, accessToken)
        {
            
        }

        public async Task<CreateCatalogProductResponse> CreateProduct(CreateCatalogProductRequest createCatalogProductRequest)
        {
            var response = await Service.CreateProduct(createCatalogProductRequest);
            if(!response.IsSuccessStatusCode)
            {
                throw response.Error;
            }
            CreateCatalogProductResponse? catalogProductResp = response?.Content;
            if(catalogProductResp is null)
            {
                throw new Exception();
            }
            return catalogProductResp;
        }

        // public async Task<ListCatalogProductsResponse> ListProducts(int pageSize = 10, int page = 1, bool total_required = false)
        // {
        //     var response =  await Service.ListProducts(pageSize, page, total_required);
        //     if(!response.IsSuccessStatusCode)
        //     {
        //         throw response.Error;
        //     }
        //     ListCatalogProductsResponse? listResponse = response?.Content;
        //     if(listResponse is null)
        //     {
        //         throw new UnableToListProductsException();
        //     }
        //     return listResponse;
        // }

        public override string Address => "v1/catalogs/products";        
    }
}