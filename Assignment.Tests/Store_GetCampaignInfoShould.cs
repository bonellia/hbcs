using Xunit;

namespace Assignment.Tests
{
    public class Store_GetCampaignInfoShould
    {

        [Fact]
        public void GetCampaignInfo_ExistingActiveCampaign_ReturnSuccessMessage()
        {
            // Arrange the case scenario:
            var testStore = new Store();
            testStore.CreateProduct("P1", 100, 1000);
            testStore.CreateCampaign("C1", "P1", 10, 20, 100);

            // Act using the subject method:
            string getCampaignResponse = testStore.GetCampaignInfo("C1");

            // Assert the expected results.
            Assert.Equal("Campaign C1 info; Status Active, Target Sales 100, Total Sales 0, Turnover 0, Average Item Price -", getCampaignResponse);
        }
        [Fact]
        public void GetCampaignInfo_NonexistentCampaign_ReturnFailMessage()
        {
            // Arrange the case scenario:
            var testStore = new Store();

            // Act using the subject method:
            string getCampaignResponse = testStore.GetCampaignInfo("C1");

            // Assert the expected results.
            Assert.Equal("Could not find a campaign with the name C1.", getCampaignResponse);
        }
        [Fact]
        public void GetCampaignInfo_ExistingExpiredCampaignWithSales_ReturnSuccessMessage()
        {
            // Arrange the case scenario:
            var testStore = new Store();
            testStore.CreateProduct("P1", 100, 1000);
            testStore.CreateCampaign("C1", "P1", 10, 20, 100);
            testStore.CreateOrder("P1", 10);
            testStore.IncreaseTime(21);

            // Act using the subject method:
            string getCampaignResponse = testStore.GetCampaignInfo("C1");

            // Assert the expected results.
            Assert.Equal("Campaign C1 info; Status Ended, Target Sales 100, Total Sales 10, Turnover 1000, Average Item Price 100", getCampaignResponse);
        }
        [Fact]
        public void GetCampaignInfo_ExistingExpiredCampaignNoSales_ReturnSuccessMessage()
        {
            // Arrange the case scenario:
            var testStore = new Store();
            testStore.CreateProduct("P1", 100, 1000);
            testStore.CreateCampaign("C1", "P1", 10, 20, 100);
            testStore.IncreaseTime(21);

            // Act using the subject method:
            string getCampaignResponse = testStore.GetCampaignInfo("C1");

            // Assert the expected results.
            Assert.Equal("Campaign C1 info; Status Ended, Target Sales 100, Total Sales 0, Turnover 0, Average Item Price -", getCampaignResponse);
        }
        [Fact]
        public void GetCampaignInfo_ExistingExpiredCampaignMaxSales_ReturnSuccessMessage()
        {
            // Arrange the case scenario:
            var testStore = new Store();
            testStore.CreateProduct("P1", 100, 1000);
            testStore.CreateCampaign("C1", "P1", 10, 20, 100);
            testStore.CreateOrder("P1", 100);
            testStore.IncreaseTime(10);

            // Act using the subject method:
            string getCampaignResponse = testStore.GetCampaignInfo("C1");

            // Assert the expected results.
            Assert.Equal("Campaign C1 info; Status Ended, Target Sales 100, Total Sales 100, Turnover 10000, Average Item Price 100", getCampaignResponse);
        }
        [Fact]
        public void GetCampaignInfo_ExistingActiveCampaignWithSalesAdvancedTime_ReturnSuccessMessage()
        {
            // Arrange the case scenario:
            var testStore = new Store();
            testStore.CreateProduct("P1", 100, 1000);
            testStore.CreateCampaign("C1", "P1", 10, 20, 100);
            testStore.CreateOrder("P1", 50);
            testStore.IncreaseTime(5);

            // Act using the subject method:
            string getCampaignResponse = testStore.GetCampaignInfo("C1");

            // Assert the expected results.
            Assert.Equal("Campaign C1 info; Status Active, Target Sales 100, Total Sales 50, Turnover 5000, Average Item Price 100", getCampaignResponse);
        }
        [Fact]
        public void GetCampaignInfo_ExistingActiveCampaignWithSalesUnchangedTime_ReturnSuccessMessage()
        {
            // Arrange the case scenario:
            var testStore = new Store();
            testStore.CreateProduct("P1", 100, 1000);
            testStore.CreateCampaign("C1", "P1", 10, 20, 100);
            testStore.CreateOrder("P1", 50);

            // Act using the subject method:
            string getCampaignResponse = testStore.GetCampaignInfo("C1");

            // Assert the expected results.
            Assert.Equal("Campaign C1 info; Status Active, Target Sales 100, Total Sales 50, Turnover 5000, Average Item Price 100", getCampaignResponse);
        }
        [Fact]
        public void GetCampaignInfo_ExistingActiveCampaignNoSalesAdvancedTime_ReturnSuccessMessage()
        {
            // Arrange the case scenario:
            var testStore = new Store();
            testStore.CreateProduct("P1", 100, 1000);
            testStore.CreateCampaign("C1", "P1", 10, 20, 100);
            testStore.IncreaseTime(10);

            // Act using the subject method:
            string getCampaignResponse = testStore.GetCampaignInfo("C1");

            // Assert the expected results.
            Assert.Equal("Campaign C1 info; Status Active, Target Sales 100, Total Sales 0, Turnover 0, Average Item Price -", getCampaignResponse);
        }
        [Fact]
        public void GetCampaignInfo_ExistingActiveCampaignMultipleSalesAdvancedTime_ReturnSuccessMessage()
        {
            // Arrange the case scenario:
            var testStore = new Store();
            testStore.CreateProduct("P1", 100, 1000);
            testStore.CreateCampaign("C1", "P1", 10, 20, 100);
            decimal turnover = 0;
            testStore.CreateOrder("P1", 5);
            turnover += 100 * 5;
            // Expecting price to go 98.
            testStore.IncreaseTime(10);            
            testStore.CreateOrder("P1", 10);
            turnover += 98.0m * 10;
            decimal averageItemprice = decimal.Round(turnover / 15m);

            // Act using the subject method:
            string getCampaignResponse = testStore.GetCampaignInfo("C1");

            // Assert the expected results.
            Assert.Equal($"Campaign C1 info; Status Active, Target Sales 100, Total Sales 15, Turnover {turnover}, Average Item Price {averageItemprice}", getCampaignResponse);
        }
    }
}