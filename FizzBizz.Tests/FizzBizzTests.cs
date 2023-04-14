using FizzBizz.Utils;
using FluentAssertions;
using System;
using Xunit;

namespace FizzBizz.Tests
{
    public class FizzBizzTests
    {
        [Fact]
        public void WhenTheRemainderIsZero_ItPrints_FizzBizzWoof()
        {
            // Arrange
            var numbers = new int[] { 2, 3, 4, 5, 7 };

            // Act
            //var result = Solution.OutputNumbers(numbers);
            var result = Solution.OutputNumbers2(numbers);

            //Assert
            Assert.Contains(nameof(OutputEnum.Fizz), result);
            Assert.Contains(nameof(OutputEnum.Buzz), result);
            Assert.Contains(nameof(OutputEnum.Woof), result);
        }

        [Fact]
        public void WhenTheRemainderIsZero_ForAGivenNumber_ItPrints_ACustomWord()
        {
            // Arrange
            var numbers = new int[] { 13 };

            // Act
            //var result = Solution.OutputNumbers(numbers, 13, "Thirteen");
            var result = Solution.OutputNumbers2(numbers, 13, "Thirteen");

            //Assert
            Assert.Contains("Thirteen", result);
        }

        [Theory]
        [InlineData(3, nameof(OutputEnum.Fizz))]
        [InlineData(6, nameof(OutputEnum.Fizz))]
        public void WhenMultipleOf_Three_ItPrintsFizz(int number, string output)
        {
            // Arrange
            // Act
            var result = Solution.OutputWord(number);

            // Assert
            result.Should().Be(output);
        }

        [Theory]
        [InlineData(5, nameof(OutputEnum.Buzz))]
        [InlineData(10, nameof(OutputEnum.Buzz))]
        public void WhenMultipleOf_Five_ItPrintsBuzz(int number, string output)
        {
            // Arrange
            // Act
            var result = Solution.OutputWord(number);

            // Assert
            result.Should().Be(output);
        }

        [Theory]
        [InlineData(15, nameof(OutputEnum.FizzBuzz))]
        [InlineData(30, nameof(OutputEnum.FizzBuzz))]
        public void WhenMultipleOf_ThreeAndFive_ItPrintsFizzBuzz(int number, string output)
        {
            // Arrange
            // Act
            var result = Solution.OutputWord(number);

            // Assert
            result.Should().Be(output);
        }

        [Theory]
        [InlineData(7, nameof(OutputEnum.Woof))]
        [InlineData(14, nameof(OutputEnum.Woof))]
        [InlineData(42, nameof(OutputEnum.Woof))]
        public void WhenMultipleOf_Seven_ItPrintsWoof(int number, string output)
        {
            // Arrange
            // Act
            var result = Solution.OutputWord(number);

            // Assert
            result.Should().Be(output);
        }

        [Theory]
        [InlineData(4, "4")]
        [InlineData(13, "13")]
        [InlineData(37, "37")]
        public void WhenNotMultipleOf_ThreeFiveOrSeven_ItPrintsTheNumber(int number, string output)
        {
            // Arrange
            // Act
            var result = Solution.OutputWord(number);

            // Assert
            result.Should().Be(output);
        }
    }
}
