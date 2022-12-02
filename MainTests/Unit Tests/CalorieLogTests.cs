using Main;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MainTests.Unit_Tests
{
    public class CalorieLogTests
    {
        [Fact]
        public void ReadFile_AttemptsToReadFromFile()
        {
            var fileReader = CreateFakeFileReader(new List<string>());
            var calorieLog = new CalorieLog(fileReader);

            calorieLog.ReadFile();

            Mock.Get(fileReader).Verify((x) => x.ReadLines(), Times.Once);
        }

        [Fact]
        public void FileReaderHasNoNewLines_ReadFile_AddsOneElfWithEntries()
        {
            var entries = new List<string>
            {
                "100",
                "1000"
            };
            var expectedEntries = entries.Select(int.Parse).ToList();
            var fileReader = CreateFakeFileReader(entries);
            var calorieLog = new CalorieLog(fileReader);

            calorieLog.ReadFile();

            Assert.Single(calorieLog.CalorieLedger);
            Assert.Equal(calorieLog.CalorieLedger[0].Calories, expectedEntries);
        }

        [Fact]
        public void FileReaderHasOneNewLine_ReadFile_AddsTwoElvesWithEntries()
        {
            var entries = new List<string>
            {
                "100",
                "1000",
                "",
                "1500"
            };
            var firstElfExpectedEntries = new List<int>
            {
                100,
                1000
            };
            var secondElfExpectedEntries = new List<int>
            {
                1500
            };
            var fileReader = CreateFakeFileReader(entries);
            var calorieLog = new CalorieLog(fileReader);

            calorieLog.ReadFile();

            Assert.Equal(2, calorieLog.CalorieLedger.Count);
            Assert.Equal(calorieLog.CalorieLedger[0].Calories, firstElfExpectedEntries);
            Assert.Equal(calorieLog.CalorieLedger[1].Calories, secondElfExpectedEntries);
        }

        [Fact]
        public void OneElfWithOneEntry_CalculateMostCalorieElfTotal_AddsUpTotal()
        {
            var fileReader = CreateFakeFileReader(new List<string>());
            var calorieLog = new CalorieLog(fileReader);
            var elf = new Elf();
            elf.Calories = new List<int>()
            {
                100
            };
            var calorieLedger = new List<Elf>()
            {
                elf
            };
            calorieLog.CalorieLedger = calorieLedger;
            var expected = 100;

            var total = calorieLog.CalculateMostCalorieElfTotal();

            Assert.Equal(expected, total);

        }

        [Fact]
        public void OneElfWithTwoEntries_CalculateMostCalorieElfTotal_AddsUpTotal()
        {
            var fileReader = CreateFakeFileReader(new List<string>());
            var calorieLog = new CalorieLog(fileReader);
            var elf = new Elf();
            elf.Calories = new List<int>()
            {
                100,
                150
            };
            var calorieLedger = new List<Elf>()
            {
                elf
            };
            calorieLog.CalorieLedger = calorieLedger;
            var expected = 250;

            var total = calorieLog.CalculateMostCalorieElfTotal();

            Assert.Equal(expected, total);

        }

        [Fact]
        public void TwoElvesWithTwoEntries_CalculateMostCalorieElfTotal_AddsUpTotal()
        {
            var fileReader = CreateFakeFileReader(new List<string>());
            var calorieLog = new CalorieLog(fileReader);
            var elf1 = new Elf();
            elf1.Calories = new List<int>()
            {
                300,
                150
            };
            var elf2 = new Elf();
            elf2.Calories = new List<int>()
            {
                100,
                150
            };
            var calorieLedger = new List<Elf>()
            {
                elf1,
                elf2
            };
            calorieLog.CalorieLedger = calorieLedger;
            var expected = 450;

            var total = calorieLog.CalculateMostCalorieElfTotal();

            Assert.Equal(expected, total);

        }

        private IFileReader CreateFakeFileReader(IEnumerable<string> entries)
        {
            var fakeFileReader = new Mock<IFileReader>();
            fakeFileReader.Setup((x) => x.ReadLines()).Returns(entries);
            return fakeFileReader.Object;
        }
    }
}
