using System;
using Xunit;
using d10Demo02;

namespace FizzBuzzTests
{
    public class UnitTest1
    {
        // Attribute
        // "Tags"
        [Fact]
        public void Test1()
        {
            // Arrange
            // the setup
            // Act
            // the actual act of what is going to get tested
            // Assert
            // "test" if the ACT is behaving properly

            bool isTrue = false;
            // We write our tests!
            Assert.True(true);
        }

        // Two types of tests
        // FACTS - One statement, "always true"
        // THEORIES

            //FIZZ : divisible by 3
            // BUZZ : divisible by 5
            // FizzBuzz : Divisible by both 3 & 5

        [Fact]
        public void CanReturn1()
        {
            // Arrange and Act
            string number = Program.FizzBuzz(1);
            Assert.Equal("1", number);
        }

        // Facts are always True
        [Fact]
        public void CanReturn2()
        {
            Assert.Equal("2", Program.FizzBuzz(2));
        }

        // Theories are conditionally True
            // MUST have at least one parameter
            // MUST have "inline Data"
        [Theory]
        // This is 2 tests
        [InlineData(3)]
        [InlineData(6)]
        public void CanReturnFizzForDivisibleBy3(int number)
        {
            Assert.Equal("Fizz", Program.FizzBuzz(number));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void CanReturnBuzzForDivisibleBy5(int number)
        {
            Assert.Equal("Buzz", Program.FizzBuzz(number));

        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        public void CanReturnFizzBuzzForDivisibleByBoth3And5(int number)
        {
            Assert.Equal("FizzBuzz", Program.FizzBuzz(number));

        }

        [Fact]
        public void CanReturnBuzzFor5()
        {
            Assert.Equal("Buzz", Program.FizzBuzz(5));

        }


        // Alternative is a "super theory"
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "Fizz")]
        [InlineData(25, "Buzz")]
        [InlineData(110, "Buzz")]
        [InlineData(60, "FizzBuzz")]

        public void CanDoFizzBuzz(int actual, string expected)
        {
            Assert.Equal(expected, Program.FizzBuzz(actual));
        }

    }
}
