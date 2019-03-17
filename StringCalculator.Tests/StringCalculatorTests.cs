using Xunit;
using System;

namespace StringCalculatorExercise.Tests
{
    public class StringCalculatorTests
    {
        [Theory]
        [InlineData("",0)]
        [InlineData("1",1)]
        [InlineData("1,2",3)]
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
        [InlineData("1,2,3", "Method can handle 0,1 or 2 numbers as input")]
        public void Should_Throw_An_Exception_If_Input_String_More_Two_Numbers(string input, string expectedResult)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var ex = Assert.Throws<ApplicationException>(() => sut.Add(input));

            //Asset
            Assert.Equal(expectedResult, ex.Message);
        }
    }
}
