using FizzBizz.Utils;
using System;
using Xunit;

namespace FizzBizz.Tests
{
    public class FizzBizzTests
    {
        private Solution _solution;
        public FizzBizzTests()
        {
            _solution = new Solution();
        }

        [Fact]
        public void WhenTheRemainderIsZero_ItPrints_FizzBizzWoof()
        {
            // Arrange
            var numbers = new int[] { 2, 3, 4, 5, 7 };

            // Act
            var result = _solution.OutputNumbers(numbers);

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
            var result = _solution.OutputNumbers(numbers, 13, "Thirteen");

            //Assert
            Assert.Contains("Thirteen", result);
        }
    }
}
