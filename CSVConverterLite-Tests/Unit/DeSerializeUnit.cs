using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace WeMicroIt.Utils.CSVConverter.Tests.Unit
{
    public class DeSerializeUnit
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void DeSerializeNullBlock(bool header)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.DeSerializeBlock(null);

            //Assert
            Assert.Null(actual);

            //Act         
            actual = converter.DeSerializeBlock(null, header);

            //Assert
            Assert.Null(actual);
        }

        [Theory]
        [InlineData("t,1", 1)]
        [InlineData("t,1\r\nt,2", 2)]
        public void DeSerializeBlock(string block, int expected)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.DeSerializeBlock<object>(block);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count);

            //Act         
            actual = converter.DeSerializeBlock(block);

            //Asssert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count);

            //Act         
            actual = converter.DeSerializeBlock<object>(block, false);

            //Asssert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count);

            //Act         
            actual = converter.DeSerializeBlock(block, false);

            //Asssert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count);
        }

        [Fact]
        public void DeSerializeNullLines()
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.DeSerializeLines(null);

            //Assert
            Assert.Null(actual);
        }

        [Theory]
        [InlineData("t,1", 1)]
        [InlineData("t,1\r\nt,2", 2)]
        public void DeSerializeLines(string block, int expected)
        {
            //Arrange
            var converter = new CSVConverter();
            var data = block.Split("\r\n").ToList();

            //Act         
            var actual = converter.DeSerializeLines<object>(data);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count);

            //Act         
            actual = converter.DeSerializeLines(data);

            //Asssert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count);

            //Act         
            actual = converter.DeSerializeLines<object>(data, false);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count);

            //Act         
            actual = converter.DeSerializeLines(data, false);

            //Asssert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Count);
        }

        [Theory]
        [InlineData("t,1")]
        public void DeSerializeLine(string block)
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.DeSerializeLine<object>(block);

            //Assert
            Assert.NotEqual(default(object), actual);

            //Act         
            actual = converter.DeSerializeLine(block);

            //Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void DeSerializeNullLine()
        {
            //Arrange
            var converter = new CSVConverter();

            //Act         
            var actual = converter.DeSerializeLine<object>(null);

            //Assert
            Assert.Null(actual);

            //Act         
            actual = converter.DeSerializeLine(null);

            //Assert
            Assert.Equal(default(object), actual);
        }
    }
}
