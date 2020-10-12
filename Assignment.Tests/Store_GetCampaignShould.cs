using Xunit;
using Assignment;

namespace Assignment.Tests
{
    public class Store_GetCampaignShould
    {
        /// <summary>
        /// Indirectly tests campaign constructor as well.
        /// </summary>
        [Fact]
        public void GetCampaign_ExistingCampaign_ReturnsCampaign()
        {
            // Arrange the case scenario:
            var testStore = new Store();
            testStore.CreateProduct("P1", 100, 1000);
            testStore.CreateCampaign("C1", "P1", 10, 20, 100);
            var creationTime = testStore.time;

            // Act using the subject method:
            var getCampaignResult = testStore.GetCampaign("P1");

            // Assert the expected results.
            Assert.NotNull(getCampaignResult);
            // Make sure that the returned object has the attributes we used while creating it.
            Assert.Equal("C1", getCampaignResult.name);
            Assert.Equal("P1", getCampaignResult.productCode);
            Assert.Equal(10, getCampaignResult.duration);
            Assert.Equal(20, getCampaignResult.priceManipulationLimit);
            Assert.Equal(100, getCampaignResult.targetSalesCount);
            // Make sure that the object was initialized properly.
            Assert.Equal(creationTime, getCampaignResult.startTime);
            Assert.True(getCampaignResult.isActive);
            Assert.Equal(0, getCampaignResult.totalSales);
            Assert.Equal(0, getCampaignResult.turnover);
            Assert.Equal(100, getCampaignResult.initialPrice);

        }
        [Fact]
        public void GetCampaign_NonexistentCampaign_Returnsnull()
        {
            // Arrange the case scenario:
            var testStore = new Store();
            testStore.CreateProduct("P1", 100, 1000);

            // Act using the subject method:
            var getCampaignResult = testStore.GetCampaign("C1");

            // Assert the expected results.
            Assert.Null(getCampaignResult);
        }
    }
}