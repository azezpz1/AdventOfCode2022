using Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MainTests.Unit_Tests
{
    public class ElfTests
    {
        [Fact]
        public void EmptyCalorieList_AddCalorie_AddsToList()
        {
            var elf = new Elf();
            const int expectedCalories = 100;
            
            elf.AddCalorie(expectedCalories);

            Assert.Single(elf.Calories);
            Assert.Equal(expectedCalories, elf.Calories.First());
        }

        [Fact]
        public void NonEmptyCalorieList_AddCalorie_AddsToList()
        {
            var elf = new Elf();
            const int expectedCalories = 100;
            elf.Calories.Add(20);

            elf.AddCalorie(expectedCalories);

            Assert.Equal(2, elf.Calories.Count);
            Assert.Equal(expectedCalories, elf.Calories[1]);
        }

        [Fact]
        public void EmptyCalorieList_CalculateCalorieTotal_ReturnsZero()
        {
            var elf = new Elf();

            var total = elf.CalculateCalorieTotal();

            Assert.Equal(0, total);
        }

        [Fact]
        public void OneValueInCalorieList_CalculateTotal_ReturnsValue()
        {
            var elf = new Elf();
            const int expected = 20;
            elf.Calories.Add(expected);

            var total = elf.CalculateCalorieTotal();

            Assert.Equal(expected, total);
        }

        [Fact]
        public void TwoValuesInCalorieList_CalculateTotal_ReturnsValue()
        {
            var elf = new Elf();
            const int expected = 30;
            elf.Calories.Add(20);
            elf.Calories.Add(10);

            var total = elf.CalculateCalorieTotal();

            Assert.Equal(expected, total);
        }

    }
}
