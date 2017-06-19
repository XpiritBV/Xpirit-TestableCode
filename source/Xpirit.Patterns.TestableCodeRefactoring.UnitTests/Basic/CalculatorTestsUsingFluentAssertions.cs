using FluentAssertions;
using Xpirit.Patterns.TestableCodeRefactoring.Basic;
using NUnit.Framework;

namespace Xpirit.Patterns.TestableCodeRefactoring.UnitTests.Basic
{
    /// <summary>
    /// Class with unit tests for the basic Calculator without dependencies but using FluentAssertions for the asserts.
    /// </summary>
    [TestFixture]
    public class CalculatorTestsUsingFluentAssertions
    {
        [Test]
        public void Add_SingleNumber_ReturnsTheSameNumber()
        {
            // Arrange
            var calculator = GetCalculator();

            // Act
            decimal result = calculator.Add(1);

            // Assert
            result.Should().Be(1);
        }

        [Test]
        public void Add_TwoNumbers_ReturnsTheSumOfTheNumbers()
        {
            // Arrange
            var calculator = GetCalculator();

            // Act
            calculator.Add(1);
            decimal result = calculator.Add(2);

            // Assert
            result.Should().Be(3);
        }

        [Test]
        public void Substract_SinglePositiveNumber_ReturnsTheNegativeOfTheNumber()
        {
            // Arrange
            var calculator = GetCalculator();

            // Act
            decimal result = calculator.Substract(1);

            // Assert
            result.Should().Be(-1);
        }

        [Test]
        public void Substract_TwoNumbers_ReturnsTheDifferenceBetweenTheNumbers()
        {
            // Arrange
            var calculator = GetCalculator();

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
            var calculator = GetCalculator();
            calculator.Add(1);
            calculator.Add(2);

            // Act
            calculator.Clear();

            // Assert
            calculator.Value.Should().Be(0);
        }

        private static Calculator GetCalculator()
        {
            return new Calculator();
        }
    }
}
