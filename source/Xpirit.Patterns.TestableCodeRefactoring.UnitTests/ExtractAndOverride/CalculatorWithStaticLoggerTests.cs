using FluentAssertions;
using NUnit.Framework;

namespace Xpirit.Patterns.TestableCodeRefactoring.UnitTests.ExtractAndOverride
{
    /// <summary>
    /// Class with unit tests for the Calculator which uses the StaticLogger based on a testable class which overrides the virtual method.
    /// </summary>
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Add_SingleNumber_ReturnsTheSameNumber()
        {
            // Arrange
            var calculator = GetTestableCalculator();

            // Act
            decimal result = calculator.Add(1);

            // Assert
            result.Should().Be(1);
        }

        [Test]
        public void Add_TwoNumbers_ReturnsTheSumOfTheNumbers()
        {
            // Arrange
            var calculator = GetTestableCalculator();

            // Act
            calculator.Add(1);
            decimal result  = calculator.Add(2);

            // Assert
            result.Should().Be(3);
        }

        [Test]
        public void Substract_SinglePositiveNumber_ReturnsTheNegativeOfTheNumber()
        {
            // Arrange
            var calculator = GetTestableCalculator();

            // Act
            decimal result = calculator.Substract(1);

            // Assert
            result.Should().Be(-1);
        }

        [Test]
        public void Substract_TwoNumbers_ReturnsTheDifferenceBetweenTheNumbers()
        {
            // Arrange
            var calculator = GetTestableCalculator();

            // Act
            calculator.Add(3);
            decimal result = calculator.Substract(2);

            // Assert
            result.Should().Be(1);
        }

        [Test]
        public void Clear_AfterCalculation_ReturnsZero()
        {
            // Arrange
            var calculator = GetTestableCalculator();
            calculator.Add(1);
            calculator.Add(2);

            // Act
            calculator.Clear();

            // Assert
            calculator.Value.Should().Be(0);
        }

        private static TestableCalculatorUsingVirtualMethod GetTestableCalculator()
        {
            return new TestableCalculatorUsingVirtualMethod();
        }
    }
}
