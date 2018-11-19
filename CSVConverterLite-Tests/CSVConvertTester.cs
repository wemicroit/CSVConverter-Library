using System;
using WeMicroIt.Utils.CSVConverterLite;
using WeMicroIt.Utils.CSVConverterLite.Models;
using Xunit;

namespace WeMicroIt.Utils.CSVConverterLite.Tests
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