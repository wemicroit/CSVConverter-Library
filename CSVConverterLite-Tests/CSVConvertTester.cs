using System;
using WeMicroIt.Utils.CSVConverter;
using WeMicroIt.Utils.CSVConverter.Models;
using Xunit;

namespace WeMicroIt.Utils.CSVConverter.Tests
{
    public class CSVConvertTester
    {
        [Fact]
        public void ConfigureConverterCorrectly()
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SetOptions(new CSVSettings());

            //Assert
            Assert.True(actual);

        }
    }
}