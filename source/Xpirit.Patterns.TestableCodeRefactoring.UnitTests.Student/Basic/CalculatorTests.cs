using Xpirit.Patterns.TestableCodeRefactoring.Basic;
using NUnit.Framework;

namespace Xpirit.Patterns.TestableCodeRefactoring.UnitTests.Student.Basic
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
    }
}
