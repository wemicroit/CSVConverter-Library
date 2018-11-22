using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeMicroIt.Utils.CSVConverter.Models;
using Xunit;

namespace WeMicroIt.Utils.CSVConverter.Tests.Unit
{
    public class SerializeUnit
    {
        [Fact]
        public void SerializeNullBlock()
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeBlock(null);

            //Assert
            Assert.Null(actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Hi")]
        public void SerializeNullBlock_Header(string header)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeBlock(null, header);

            //Assert
            Assert.Null(actual);
        }

        [Theory]
        [InlineData("[{Hi: 1}]", 2, "Hi\r\n1")]
        [InlineData("[{Hi: 1},{Hi:3}]", 3, "Hi\r\n1\r\n3")]
        public void SerializeBlock(string block, int expectedCount, string expected)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeBlock<object>(JsonConvert.DeserializeObject<List<object>>(block));

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedCount, actual.Count);
            Assert.Equal(expected.Split("\r\n").ToList(), actual);

            //Act         
            actual = converter.SerializeBlock(JsonConvert.DeserializeObject<List<object>>(block));

            //Asssert
            Assert.NotNull(actual);
            Assert.Equal(expectedCount, actual.Count);
            Assert.Equal(expected.Split("\r\n").ToList(), actual);
        }

        [Theory]
        [InlineData("[{Hi: 1}]", 2, "Hi")]
        [InlineData("[{Hi: 1},{Hi:3}]", 3, "Hi")]
        public void SerializeBlock_Header(string block, int expected, string Header)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeBlock<object>(JsonConvert.DeserializeObject<List<object>>(block), Header);

            //Asssert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count);
            Assert.Equal(Header, actual.FirstOrDefault());

            //Act         
            actual = converter.SerializeBlock(JsonConvert.DeserializeObject<List<object>>(block), Header);

            //Asssert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count);
            Assert.Equal(Header, actual.FirstOrDefault());
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
        [InlineData("[{Hi: 1}]", 1, "1")]
        [InlineData("[{Hi: 1},{Hi:3}]", 2, "1\r\n3")]
        public void SerializeLines(string block, int expectedCount, string expected)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeLines<object>(JsonConvert.DeserializeObject<List<object>>(block));

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedCount, actual.Count);
            Assert.Equal(expected.Split("\r\n").ToList(), actual);

            //Act         
            actual = converter.SerializeLines(JsonConvert.DeserializeObject<List<object>>(block));

            //Asssert
            Assert.NotNull(actual);
            Assert.Equal(expectedCount, actual.Count);
            Assert.Equal(expected.Split("\r\n").ToList(), actual);
        }

        [Fact]
        public void SerializeNullHeader()
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeHeader(null);

            //Assert
            Assert.Null(actual);
        }

        [Theory]
        [InlineData("{HI: 1}", "HI")]
        public void SerializeHeader(string block, string expected)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeHeader<object>(JsonConvert.DeserializeObject<object>(block));

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);

            //Act         
            actual = converter.SerializeHeader(JsonConvert.DeserializeObject<object>(block));

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("{HI: 1}", "", "HI")]
        [InlineData("{HI: 1}", "Bo", "Bo")]
        public void SerializeHeader_Header(string block, string header, string expected)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeHeader<object>(JsonConvert.DeserializeObject<object>(block), header);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);

            //Act         
            actual = converter.SerializeHeader(JsonConvert.DeserializeObject<object>(block), header);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("{HI: 1}", "1")]
        public void SerializeLine(string block, string expected)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.SerializeLine<object>(JsonConvert.DeserializeObject<object>(block));

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);

            //Act         
            actual = converter.SerializeLine(JsonConvert.DeserializeObject<object>(block));

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
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
