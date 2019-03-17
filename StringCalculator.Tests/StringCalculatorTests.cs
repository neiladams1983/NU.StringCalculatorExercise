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
        [InlineData("1,2,3,4,5,6",21)]
        public void Should_Correctly_Add_Numbers_In_a_String(string input, int expectedResult)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            int result = sut.Add(input);

            //Assert
            Assert.Equal(expectedResult, result);
        }


    }
}
