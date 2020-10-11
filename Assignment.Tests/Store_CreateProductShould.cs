using Xunit;
using Assignment;

namespace Assignment.Tests
{
    /// <summary>
    /// This class is responsible of unit tests for CreateProduct method of Store class.
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
    }
}