namespace Xpirit.Patterns.TestableCodeRefactoring.Basic
{
    /// <summary>
    /// Basic Calculator class without any dependencies.
    /// </summary>
    public class Calculator
    {
        public decimal Value { get; set; }

        public decimal Add(decimal value)
        {
            Value += value;

            return Value;
        }

        public decimal Substract(decimal value)
        {
            Value -= value;

            return Value;
        }

        public void Clear()
        {
            Value = 0;
        }
    }
}
