using PaypalNET.Common.Interfaces;
using PaypalNET.Common.Models.CatalogProducts;
using PaypalNET.Common.Models.OAuth;
using PaypalNET.Common.Options;
using PaypalNET.Common.Requests.CatalogProducts;
using PaypalNET.Common.Responses.CatalogProducts;
using PaypalNET.Core.Services;
using PaypalNET.Core.Services.Interfaces;

namespace PaypalNET.Tests
{
    public class CatalogProductsApiTests
    {
        private readonly PaypalApiOptions _sandboxApiOptions;
        private readonly AccessToken _accessToken;

        public CatalogProductsApiTests()
        {
            _sandboxApiOptions = new PaypalApiOptions()
            {
                Mode = Common.Enums.PaypalApiMode.Sandbox
            };

            AuthPaypalService authPaypalService = new AuthPaypalService(_sandboxApiOptions);
            _accessToken = authPaypalService.GetAccessToken("CLIENT ID", "CLIENT SECRET").Result;
        }

        [Fact]
        public async Task Create_Product_Test()
        {
            CatalogProductsPaypalService catalogProductService 
            = new CatalogProductsPaypalService(_sandboxApiOptions, _accessToken);
            
            var newProductInfo = new CreateCatalogProductRequest("TestProduct", "", "", "DIGITAL", "", "", "");

            var response = await catalogProductService.CreateProduct(newProductInfo);
            Assert.True(response is null);
        }
    }
}