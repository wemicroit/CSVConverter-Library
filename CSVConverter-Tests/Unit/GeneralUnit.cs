using System;
using System.Collections.Generic;
using System.Text;
using WeMicroIt.Utils.CSVConverter.Models;
using Xunit;

namespace WeMicroIt.Utils.CSVConverter.Tests.Unit
{
    public class GeneralUnit
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        public void SetOptions(string settings, bool expected)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SetOptions(settings);

            //Assert
            Assert.Equal(expected, actual);

        }
    }
}
