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
            // Arrange the case scenario:
            var testStore = new Store();

            // Act using the subject method:
            string createProductResponse = testStore.CreateProduct("P1", 100, 1000);

            // Assert the expected results.
            Assert.Equal("Product created; code P1, price 100, stock 1000", createProductResponse);            
        }
        [Fact]
        public void CreateProduct_ExistingProductInput_ReturnFailMessage()
        {
            // Arrange the case scenario:
            var testStore = new Store();
            testStore.CreateProduct("P1", 100, 1000);

            // Act using the subject method:
            string createProductResponse = testStore.CreateProduct("P1", 100, 1000);

            // Assert the expected results.
            Assert.Equal("A product with the code P1 already exists.", createProductResponse);
        }
    }
}