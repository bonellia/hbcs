using Xunit;
using Assignment;

namespace Assignment.Tests
{
    public class Store_GetProductInfoShould
    {

        public Store_GetProductInfoShould()
        {

        }

        [Fact]
        public void GetProductInfo_ExistingProduct_ReturnSuccessMessage()
        {
            var testStore = new Store();
            
            testStore.CreateProduct("P1", 100, 1000);
            string actualMessage = testStore.GetProductInfo("P1");

            Assert.Equal("Product P1 info; price 100, stock 1000", actualMessage);
        }
        [Fact]
        public void GetProductInfo_NonExistentProduct_ReturnFailMessage()
        {
            var testStore = new Store();
            
            string actualMessage = testStore.GetProductInfo("P1");

            Assert.Equal("Could not find a product with the code P1.", actualMessage);
        }
    }
}