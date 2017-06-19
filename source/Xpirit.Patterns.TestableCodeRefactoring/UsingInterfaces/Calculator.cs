namespace Xpirit.Patterns.TestableCodeRefactoring.UsingInterfaces
{
    /// <summary>
    /// Calculator class which uses the ILogger interface through constructor injection.
    /// </summary>
    public class Calculator
    {
        private readonly ILogger _logger;

        public Calculator(ILogger logger)
        {
            _logger = logger;
        }

        public decimal Value { get; set; }

        public decimal Add(decimal value)
        {
            _logger.Write($"Adding {value} to {Value}.");
            Value += value;

            return Value;
        }

        public decimal Substract(decimal value)
        {
            _logger.Write($"Substracting {value} from {Value}.");
            Value -= value;

            return Value;
        }

        public void Clear()
        {
            _logger.Write("Clearing the value.");
            Value = 0;
        }
    }
}
