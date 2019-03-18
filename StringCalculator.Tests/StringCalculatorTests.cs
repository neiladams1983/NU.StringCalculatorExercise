using Xunit;
using System;

namespace StringCalculatorExercise.Tests
{
    public class StringCalculatorTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1\n2", 3)]
        [InlineData("1\n2,3", 6)]
        [InlineData("//;\n1;2", 3)]
        public void Should_Correctly_Add_Numbers_In_a_String(string input, int expectedResult)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            int result = sut.Add(input);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1,\n", "Input string is malformed")]
        public void Should_Return_Error_As_Input_String_Is_Malformed(string input, string expectedResult)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var ex = Assert.Throws<Exception>(() => sut.Add(input));

            //Asset
            Assert.Equal(expectedResult, ex.Message);

        }

        [Theory]
        [InlineData("1,2,3,-6", "negatives are not allowed -6")]
        [InlineData("1,2,3,-6,2,-3", "negatives are not allowed -6 -3")]
        public void Should_Return_Error_As_Input_String_Contains_Negative_Numbers(string input, string expectedResult)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.Add(input));

            //Asset
            Assert.Equal(expectedResult, ex.ParamName);

        }
    }
}