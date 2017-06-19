using Xpirit.Patterns.TestableCodeRefactoring.Basic;
using NUnit.Framework;

namespace Xpirit.Patterns.TestableCodeRefactoring.UnitTests.Basic
{
    /// <summary>
    /// Class with unit tests for the basic Calculator without dependencies.
    /// </summary>
    [TestFixture]
    public class CalculatorTests
    {

        /* Naming convention
         * 
         * A very common naming convention for unit tests is:
         * 
         * public void [UnitOfWork]_[ScenarioUnderTest]_[ExpectedBehaviour]()
         * {
         *    // Arrange
         *    [In the Arrange part the system under test (SUT) is instantiated and 
         *    prepared for the desired scenario.]
         *    
         *    // Act
         *    [In the Act part the unit of work is executed.]
         *    
         *    // Assert
         *    [In the Assert part the result or behaviour is asserted.]
         * }
         * 
         */


        [Test]
        public void Add_SingleNumber_ReturnsTheSameNumber()
        {
            // Arrange
            var calculator = GetCalculator();

            // Act
            decimal result = calculator.Add(1);

            // Assert
            Assert.AreEqual(1, result);
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
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Substract_SinglePositiveNumber_ReturnsTheNegativeOfTheNumber()
        {
            // Arrange
            var calculator = GetCalculator();

            // Act
            decimal result = calculator.Substract(1);

            // Assert
            Assert.AreEqual(-1, result);
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
            Assert.AreEqual(1, result);
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
            Assert.AreEqual(0, calculator.Value);
        }

        private static Calculator GetCalculator()
        {
            return new Calculator();
        }
    }
}
