using PaypalNET.Common.Enums;
using PaypalNET.Common.Exceptions;
using PaypalNET.Common.Interfaces;
using PaypalNET.Common.Models;
using PaypalNET.Common.Models.CatalogsProducts;
using PaypalNET.Common.Models.OAuth;
using PaypalNET.Common.Options;
using PaypalNET.Common.Requests.CatalogsProducts;
using PaypalNET.Common.Responses.CatalogsProducts;
using PaypalNET.Core.Services;

namespace PaypalNET.Tests.Apis
{
    public class CatalogsProductsApiTests : AuthorizedTestsBase
    {
        private readonly CatalogsProductsPaypalService _catalogsProductsService;

        public CatalogsProductsApiTests() : base()
        {
            _catalogsProductsService = new CatalogsProductsPaypalService(ApiOptions, AccessToken);
        }

        [Fact]
        public async Task Should_Return_Non_Null_Product_When_Creating()
        {
            var newProductInfo = new CreateCatalogProductRequest("TestProduct", "", "", "DIGITAL", "", "", "");

            var response = await _catalogsProductsService.CreateProduct(newProductInfo);
            var castedResponse = response as CreateCatalogProductResponse;
            Assert.NotNull(castedResponse);
        }

        [Fact]
        public async Task Should_Return_Non_Null_When_Listing_Products()
        {
            var response = await _catalogsProductsService.ListProducts() as ListCatalogsProductsResponse;
            Assert.NotNull(response);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Asking_For_Non_Existing_Product_Details()
        {
            await Assert.ThrowsAsync<PaypalServiceException>(() => _catalogsProductsService.ProductDetails("some_random_non_existing_product_eg12312321312"));
        }

        [Fact]
        public async Task Should_Not_Throw_Exception_When_Removing_Product()
        {
            var createRequest = new CreateCatalogProductRequest("TestUpdateProduct", "", "Test Description", "DIGITAL", "", "", "");
            var createdResponse = await _catalogsProductsService.CreateProduct(createRequest) as CreateCatalogProductResponse;
            if(createdResponse is null)
            {
                Assert.Fail("Creation of product failed.");
            }
            string checkDescription = "Check Description";
            var updateEntityList = new List<UpdateEntity>()
            {
                new UpdateEntity(new UpdateOperation(UpdateOperations.Replace), "/description", checkDescription, "")
            };
            var updateRequest = new UpdateCatalogProductRequest(updateEntityList);

            var exception = await Record.ExceptionAsync(() => _catalogsProductsService.UpdateProduct(createdResponse.Id, updateRequest));

            var productDetailsResponse = await _catalogsProductsService.ProductDetails(createdResponse.Id) as CatalogProductDetailsResponse;

            if(productDetailsResponse is null)
            {
                Assert.Fail("Could not get product after creation.");
            }

            Assert.True(productDetailsResponse.Description.Equals(checkDescription) && exception is null);
        }
    }
}