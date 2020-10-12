using Xunit;
using System;
using Assignment;

namespace Assignment.Tests
{
    /// <summary>
    /// <para>Only tests the text output of increaseTime.</para>
    /// <para>The business rules are tested on other methods.</para>
    /// </summary>
    public class Store_IncreaseTimeShould
    {

        [Fact]
        public void IncreaseTime_NoCampaign_ReturnSuccessMessage()
        {
            // Arrange the case scenario:
            var testStore = new Store();
            var initialTime = testStore.time;


            // Act using the subject method:
            var increaseTimeResult = testStore.IncreaseTime(1);
            DateTime updatedTime = initialTime.AddHours(1);

            // Assert the expected results.
            Assert.Equal("Time is 01:00", increaseTimeResult);
            Assert.Equal(updatedTime, testStore.time);
        }
    }
}