using FakeItEasy;
using FluentAssertions;
using Moq;
using Xpirit.Patterns.TestableCodeRefactoring.UsingInterfaces;
using NUnit.Framework;
using Xpirit.Patterns.TestableCodeRefactoring.UnitTests.UsingInterfaces;

namespace Xpirit.Patterns.TestableCodeRefactoring.UnitTests.UsingMockFramework
{
    [TestFixture]
    public class CalculatorWithMockFrameworkTests
    {
        [Test]
        public void Add_SingleNumber_ReturnsTheSameNumber()
        {
            // Arrange
            var calculator = GetCalculatorWithMockedLogger();

            // Act
            decimal result = calculator.Add(1);

            // Assert
            result.Should().Be(1);
        }

        /// <summary>
        /// This unit test does not test on state but on behaviour.
        /// The fake logger is constructed using FakeItEasy.
        /// </summary>
        [Test]
        public void WriteToLog_WhenAddingANumber_WriteMethodMustHaveBeenCalledOnce_UsingFakeItEasy()
        {
            // Arrange
            ILogger fakeLogger = A.Fake<ILogger>();
            var calculator = new Calculator(fakeLogger);

            // Act
            calculator.Add(1);

            // Assert that Write method is called once
            A.CallTo(() => fakeLogger.Write(A<string>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
        }

        /// <summary>
        /// This unit test does not test on state but on behaviour.
        /// The mock logger is constructed using Moq.
        /// </summary>
        [Test]
        public void WriteToLog_WhenAddingANumber_WriteMethodMustHaveBeenCalledOnced_UsingMoq()
        {
            // Arrange
            Mock<ILogger> mockLogger;
            var calculator = GetCalculatorWithMockedLogger(out mockLogger);

            // Act
            calculator.Add(1);

            // Assert that Write method is called once
            mockLogger.Verify(fake => fake.Write(It.IsAny<string>()), Times.Once);
        }

        private static Calculator GetCalculatorWithMockedLogger()
        {
            var mockLogger = new Mock<ILogger>();

            return new Calculator(mockLogger.Object);
        }

        private static Calculator GetCalculatorWithMockedLogger(out Mock<ILogger> mockLogger)
        {
            mockLogger= new Mock<ILogger>();

            return new Calculator(mockLogger.Object);
        }
    }
}
