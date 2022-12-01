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
        public void FileReaderHasEntries_ReadFile_AddsEntriesToCalorieLedger()
        {
            var entries = new List<string>
            {

            };
        }

        private IFileReader CreateFakeFileReader(IEnumerable<string> entries)
        {
            var fakeFileReader = new Mock<IFileReader>();
            fakeFileReader.Setup((x) => x.ReadLines()).Returns(entries);
            return fakeFileReader.Object;
        }
    }
}
