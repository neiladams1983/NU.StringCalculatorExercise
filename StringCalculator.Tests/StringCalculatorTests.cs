using Xunit;
using System;

namespace StringCalculatorExercise.Tests
{
    public class StringCalculatorTests
    {
        [Theory]
        [InlineData("",0)]
        [InlineData("1",1)]
        [InlineData("1\n2",3)]
        [InlineData("1\n2,3", 6)]
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
    }
}
