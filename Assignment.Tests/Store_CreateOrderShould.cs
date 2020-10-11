using Xunit;
using Assignment;

namespace Assignment.Tests
{
    public class Store_CreateOrderShould
    {

        /// <summary>
        /// <para>Tests all branches of the CreateOrder method.</para>
        /// <para>Instantiates a different Store object for each test.</para>
        /// </summary>
        public Store_CreateOrderShould()
        {

        }

        [Fact]
        public void CreateOrder_ExistingProductHasStockNoCampaign_ReturnSuccessMessage()
        {
            var testStore = new Store();

            testStore.CreateProduct("P1", 100, 5);
            var newProduct = testStore.GetProduct("P1");
            var stockBeforeOrder = newProduct.stock;
            string createOrderResponse = testStore.CreateOrder("P1", 3);
            var stockAfterOrder = newProduct.stock;

            Assert.Equal("Order created; product P1, quantity 3", createOrderResponse);
            Assert.Equal(stockBeforeOrder-3, stockAfterOrder);

        }

        [Fact]
        public void CreateOrder_ExistingProductNoStockNoCampaign_ReturnFailMessage()
        {
            var testStore = new Store();

            testStore.CreateProduct("P1", 100, 2);
            var newProduct = testStore.GetProduct("P1");
            var stockBeforeOrder = newProduct.stock;
            string createOrderResponse = testStore.CreateOrder("P1", 3);
            var stockAfterOrder = newProduct.stock;

            Assert.Equal("Order failed; insufficient stock (2) for the product P1.", createOrderResponse);
            Assert.Equal(stockBeforeOrder, stockAfterOrder);
        }

        [Fact]
        public void CreateOrder_NonExistentProductNoCampaign_ReturnFailMessage()
        {
            var testStore = new Store();

            string createOrderResponse = testStore.CreateOrder("P1", 3);

            Assert.Equal("Order failed; no product with the product code P1.", createOrderResponse);
        }

        [Fact]
        public void CreateOrder_ExistingProductHasStockHasCampaign_ReturnSuccessMessage()
        {
            var testStore = new Store();

            testStore.CreateProduct("P1", 100, 5);
            var newProduct = testStore.GetProduct("P1");
            var stockBeforeOrder = newProduct.stock;
            testStore.CreateCampaign("C1", "P1", 10, 20, 100);
            string createOrderResponse = testStore.CreateOrder("P1", 3);
            var stockAfterOrder = newProduct.stock;

            Assert.Equal("Order created; product P1, quantity 3", createOrderResponse);
            Assert.Equal(stockBeforeOrder-3, stockAfterOrder);

        }
    }
}