using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WeMicroIt.Utils.CSVConverter.Models;
using Xunit;

namespace WeMicroIt.Utils.CSVConverter.Tests.Unit
{
    public class SerializeUnit
    {
        [Theory]
        [InlineData("")]
        public void SerializeNullBlock(string header)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeBlock(null);

            //Assert
            Assert.Null(actual);

            //Act         
            actual = converter.SerializeBlock(null, header);

            //Assert
            Assert.Null(actual);
        }

        [Theory]
        [InlineData("[{HI: 1}]", 2)]
        [InlineData("[{HI: 1},{Hi:3}]", 3)]
        public void SerializeBlock(string block, int expected)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeBlock<object>(JsonConvert.DeserializeObject<List<object>>(block));

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count);

            //Act         
            actual = converter.SerializeBlock(JsonConvert.DeserializeObject<List<object>>(block));

            //Asssert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count);

            //Act         
            actual = converter.SerializeBlock<object>(JsonConvert.DeserializeObject<List<object>>(block),"");

            //Asssert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count);

            //Act         
            actual = converter.SerializeBlock(JsonConvert.DeserializeObject<List<object>>(block), "");

            //Asssert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count);
        }

        [Fact]
        public void SerializeNullLines()
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeLines(null);

            //Assert
            Assert.Null(actual);
        }

        [Theory]
        [InlineData("[{HI: 1}]", 2)]
        [InlineData("[{HI: 1},{Hi:3}]", 3)]
        public void SerializeLines(string block, int expected)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeLines<object>(JsonConvert.DeserializeObject<List<object>>(block));

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count);

            //Act         
            actual = converter.SerializeLines(JsonConvert.DeserializeObject<List<object>>(block));

            //Asssert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count);
        }

        [Theory]
        [InlineData("")]
        public void SerializeNullHeader(string header)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeHeader(null);

            //Assert
            Assert.Null(actual);

            //Act         
            actual = converter.SerializeHeader(null, header);

            //Assert
            Assert.Null(actual);
        }

        [Theory]
        [InlineData("{HI: 1}", "")]
        public void SerializeHeader(string block, string header)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            object item = JsonConvert.DeserializeObject<object>(block);
            var actual = converter.SerializeHeader<object>(item);

            //Assert
            Assert.NotNull(actual);

            //Act         
            actual = converter.SerializeHeader(JsonConvert.DeserializeObject<object>(block));

            //Assert
            Assert.NotNull(actual);

            //Act         
            actual = converter.SerializeHeader<object>(JsonConvert.DeserializeObject<object>(block), header);

            //Assert
            Assert.NotNull(actual);

            //Act         
            actual = converter.SerializeHeader(JsonConvert.DeserializeObject<object>(block), header);

            //Assert
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("{HI: 1}")]
        public void SerializeLine(string block)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeLine<object>(JsonConvert.DeserializeObject<object>(block));

            //Assert
            Assert.NotNull(actual);

            //Act         
            actual = converter.SerializeLine(JsonConvert.DeserializeObject<object>(block));

            //Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void SerializeNullLine()
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeLine<object>(null);

            //Assert
            Assert.Null(actual);

            //Act         
            actual = converter.SerializeLine(null);

            //Assert
            Assert.Null(actual);
        }
    }
}
