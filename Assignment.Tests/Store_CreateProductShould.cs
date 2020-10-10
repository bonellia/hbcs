using Xunit;
using Assignment;

namespace Assignment.Tests
{
    public class Store_CreateProductShould
    {

        public Store_CreateProductShould()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void CreateProduct_NonExistentProductInput_ReturnSuccessMessage()
        {
            var testStore = new Store();

            string actualMessage = testStore.CreateProduct("P1", 100, 1000);

            Assert.Equal("Product created; code P1, price 100, stock 1000", actualMessage);            
        }
    }
}