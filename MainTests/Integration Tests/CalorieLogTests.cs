using System;
using Main;
using Xunit;

namespace MainTests.IntegrationTests
{
    public class CalorieLogTests
    {
        [Fact]
        public void ExampleTest_CalculateMostCalorieElfTotal_Calculates24000()
        {
            var fileReader = new FileReader(
                @"Integration Tests/TestFiles/CalorieLog/ExampleTest.txt");
            var calorieLog = new CalorieLog(fileReader);
            var expected = 24000;
            calorieLog.ReadFile();

            var result = calorieLog.CalculateMostCalorieElfTotal();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void FirstHalfTest_CalculateMostCalorieElfTotal_Calculates67450()
        {
            var fileReader = new FileReader(
                @"Integration Tests/TestFiles/CalorieLog/FirstHalfTest.txt");
            var calorieLog = new CalorieLog(fileReader);
            var expected = 67450;
            calorieLog.ReadFile();

            var result = calorieLog.CalculateMostCalorieElfTotal();

            Assert.Equal(expected, result);
        }
    }
}

