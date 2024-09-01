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
    public class CatalogProductsApiTests : AuthorizedTestsBase
    {
        private readonly CatalogProductsPaypalService _catalogProductsService;

        public CatalogProductsApiTests()
        {
            _catalogProductsService = new CatalogProductsPaypalService(ApiOptions, AccessToken);
        }

        [Fact]
        public async Task Create_Product_Test()
        {
            var newProductInfo = new CreateCatalogProductRequest("TestProduct", "", "", "DIGITAL", "", "", "");

            var response = await _catalogProductsService.CreateProduct(newProductInfo);
            Assert.False(response is null);
        }
    }
}