using Xunit;
using Assignment;

namespace Assignment.Tests
{
    /// <summary>
    /// <para>Tests CreateProduct method.</para>
    /// <para>Instantiates a different Store object for each test. Thus, no constructor.</para>
    /// </summary>
    public class Store_CreateProductShould
    {

        [Fact]
        public void CreateProduct_NonExistentProductInput_ReturnSuccessMessage()
        {
            var testStore = new Store();

            string actualMessage = testStore.CreateProduct("P1", 100, 1000);

            Assert.Equal("Product created; code P1, price 100, stock 1000", actualMessage);            
        }
        [Fact]
        public void CreateProduct_ExistingProductInput_ReturnFailMessage()
        {
            var testStore = new Store();
            testStore.CreateProduct("P1", 100, 1000);

            string createProductResponse = testStore.CreateProduct("P1", 100, 1000);

            Assert.Equal("A product with the code P1 already exists.", createProductResponse);
        }
    }
}