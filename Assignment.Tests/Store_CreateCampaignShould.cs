using Xunit;
using Assignment;

namespace Assignment.Tests
{
    /// <summary>
    /// <para>Tests CreateCampaign method.</para>
    /// <para>Instantiates a different Store object for each test. Thus, no constructor.</para>
    /// <para>The following cases are excluded:</para>
    /// <list type="bullet">
    /// <item> A product with the given code doesn't exist, but a campaign for this nonexistent product does. If a product doesn't exist, there is no need to check validity of existing campaigns.</item>
    /// <item> A product has enough stock, but a campaign already exists. This case is already covered by other cases.</item>
    /// <item> A product has doesn't have enough stock, but a campaign for this product exists. This is already covered by the other cases as well.</item>
    /// </list>
    /// </summary>
    public class Store_CreateCampaignShould
    {

        [Fact]
        public void CreateCampaign_NonexistentCampaignExistingProductEnoughStock_ReturnSuccessMessage()
        {
            // Arrange the case scenario:
            var testStore = new Store();
            testStore.CreateProduct("P1", 100, 150);

            // Act using the subject method:
            string createCampaignResponse = testStore.CreateCampaign("C1", "P1", 10, 20, 100);

            // Assert the expected results.
            Assert.Equal("Campaign created; name C1, product P1, duration 10, limit 20, target sales count 100", createCampaignResponse);

        }
        [Fact]
        public void CreateCampaign_ExistingProductInsufficientStock_ReturnFailMessage()
        {
            // Arrange the case scenario:
            var testStore = new Store();
            testStore.CreateProduct("P1", 100, 90);

            // Act using the subject method:
            string createCampaignResponse = testStore.CreateCampaign("C1", "P1", 10, 20, 100);

            // Assert the expected results.
            Assert.Equal("Cannot create a campaign for the product P1, since the product stock (90) is insufficient.", createCampaignResponse);
        }
        [Fact]
        public void CreateCampaign_NonExistentProduct_ReturnFailMessage()
        {
            // Arrange the case scenario:
            var testStore = new Store();

            // Act using the subject method:
            string createCampaignResponse = testStore.CreateCampaign("C1", "P1", 10, 20, 100);

            // Assert the expected results.
            Assert.Equal("Cannot create a campaign for the product P1, since such a product does not exist.", createCampaignResponse);
        }
        [Fact]
        public void CreateCampaign_ExistingCampaignExistingProductEnoughStock_ReturnFailMessage()
        {
            // Arrange the case scenario:
            var testStore = new Store();
            testStore.CreateProduct("P1", 100, 150);
            testStore.CreateCampaign("C1", "P1", 10, 20, 100);

            // Act using the subject method:
            string createCampaignResponse = testStore.CreateCampaign("C1", "P1", 10, 20, 100);

            // Assert the expected results.
            Assert.Equal("Cannot create a campaign with the product code P1, since a campaign for this product already exists.", createCampaignResponse);
        }
    }
}

/// <item>Success: Campaign created; name C1, product P1, duration 10, limit 20, target sales count 100</item>
/// <item>Failure: Cannot create a campaign with the product code P1, since a campaign for this product already exists.</item>
/// <item>Failure: Cannot create a campaign for the product P1, since the product stock (10) is insufficient.</item>