using Xpirit.Patterns.TestableCodeRefactoring.ExtractAndOverride;

namespace Xpirit.Patterns.TestableCodeRefactoring.UnitTests.ExtractAndOverride
{
    /// <summary>
    /// A testable class of the Calculator which overrides the call to the static logger component.
    /// This class is used in the unit tests instead of the CalculatorWithStaticLogger class.
    /// </summary>
    internal class TestableCalculatorUsingVirtualMethod : CalculatorUsingVirtualMethod
    {
        /// <summary>
        /// Call to StaticLogger is overridden to avoid a dependency on the logger class.
        /// </summary>
        /// <param name="message"></param>
        protected override void WriteToStaticLogger(string message)
        {
            // Do nothing.
        }
    }
}
