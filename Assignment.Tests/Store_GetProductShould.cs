using Xunit;
using Assignment;

namespace Assignment.Tests
{
    public class Store_GetProductShould
    {
        /// <summary>
        /// Indirectly tests Product constructor as well.
        /// </summary>
        [Fact]
        public void GetProduct_ExistingProduct_ReturnsProduct()
        {
            // Arrange the case scenario:
            var testStore = new Store();
            testStore.CreateProduct("P1", 100, 1000);

            // Act using the subject method:
            var getProductResult = testStore.GetProduct("P1");

            // Assert the expected results.
            Assert.NotNull(getProductResult);
            // Make sure that the returned object has the attributes we used while creating it.
            Assert.Equal("P1", getProductResult.productCode);
            Assert.Equal(100, getProductResult.price);
            Assert.Equal(1000, getProductResult.stock);

        }
        [Fact]
        public void GetProduct_NonexistentProduct_Returnsnull()
        {
            // Arrange the case scenario:
            var testStore = new Store();

            // Act using the subject method:
            var getProductResult = testStore.GetProduct("P1");

            // Assert the expected results.
            Assert.Null(getProductResult);
        }
    }
}