using System;
using System.Collections.Generic;
using System.Text;
using WeMicroIt.Tester.Library.Data;
using WeMicroIt.Utils.CSVConverter.Models;
using Xunit;

namespace WeMicroIt.Utils.CSVConverter.Tests
{
    public class SerializeTester
    {
        public TestData testData = new TestData();

        [Theory]
        [InlineData("", "")]
        [InlineData("hi", "hi")]
        public void HeaderSerialisationCorrectly(string input, string output)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeHeader(testData.FindInput(input));

            //Assert
            Assert.Equal(testData.FindOutput(output), actual);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("hi", "hi")]
        public void HeaderSerialisationIncorrectly(string input, string output)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeHeader(testData.FindInput(input));

            //Assert
            Assert.NotEqual(testData.FindOutput(output), actual);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("hi", "hi")]
        public void LineSerialisationCorrectly(string input, string output)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeLine(testData.FindInput(input));

            //Assert
            Assert.Equal(testData.FindOutput(output), actual);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("hi", "hi")]
        public void LineSerialisationIncorrectly(string input, string output)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeLine(testData.FindInput(input));

            //Assert
            Assert.NotEqual(testData.FindOutput(output), actual);
        }
    }
}
