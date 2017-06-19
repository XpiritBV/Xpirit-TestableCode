namespace Xpirit.Patterns.TestableCodeRefactoring.ExtractAndOverride
{
    /// <summary>
    /// Calculator class which uses a static Logger class inside a protected virtual method.
    /// </summary>
    public class CalculatorUsingVirtualMethod
    {
        public decimal Value { get; set; }

        public decimal Add(decimal value)
        {
            WriteToStaticLogger($"Adding {value} to {Value}.");
            Value += value;

            return Value;
        }

        public decimal Substract(decimal value)
        {
            WriteToStaticLogger($"Substracting {value} from {Value}.");
            Value -= value;

            return Value;
        }

        public void Clear()
        {
            WriteToStaticLogger("Clearing the value.");
            Value = 0;
        }

        /// <summary>
        /// Encapsulates the call to the StaticLogger in a protected virtual method.
        /// A testable class can now be made (in the UnitTest project) which inherits 
        /// from this Calculator class and overrides the WriteToStaticLogger method 
        /// to break the dependency with the logger.
        /// </summary>
        /// <param name="message">Message to log.</param>
        protected virtual void WriteToStaticLogger(string message)
        {
            StaticLogger.Write(message);
        }
    }
}
