using System;
using System.Collections.Generic;
using System.Text;
using WeMicroIt.Tester.Library.Data;
using Xunit;

namespace WeMicroIt.Utils.CSVConverterLite.Tests
{
    public class DeSerializeTester
    {

        //Need to work out a way to box it etc.
        public TestData testData = new TestData();

        [Theory]
        [InlineData("", "")]
        [InlineData("hi", "hi")]
        public void LineDeSerialisedCorrectly(string input, string output)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.DeserialiseLine<object>(testData.FindInput(input).ToString());

            //Assert
            Assert.Equal(testData.FindOutput(output), actual);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("hi", "hi")]
        public void LineDeSerialisedInCorrectly(string input, string output)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.DeserialiseLine<object>(testData.FindInput(input).ToString());

            //Assert
            Assert.NotEqual(testData.FindOutput(output), (actual));
        }
    }
}
