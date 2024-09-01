using PaypalNET.Common.Interfaces;
using PaypalNET.Common.Models.CatalogsProducts;
using PaypalNET.Common.Models.OAuth;
using PaypalNET.Common.Options;
using PaypalNET.Common.Requests.CatalogsProducts;
using PaypalNET.Common.Responses.CatalogsProducts;
using PaypalNET.Core.Services;
using PaypalNET.Core.Services.Interfaces;

namespace PaypalNET.Tests.Apis
{
    public class CatalogsProductsApiTests : AuthorizedTestsBase
    {
        private readonly CatalogsProductsPaypalService _CatalogsProductsService;

        public CatalogsProductsApiTests()
        {
            _CatalogsProductsService = new CatalogsProductsPaypalService(ApiOptions, AccessToken);
        }

        [Fact]
        public async Task Create_Product_Test()
        {
            var newProductInfo = new CreateCatalogProductRequest("TestProduct", "", "", "DIGITAL", "", "", "");

            var response = await _CatalogsProductsService.CreateProduct(newProductInfo);
            Assert.False(response is null);
        }
    }
}