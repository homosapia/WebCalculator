using WebCalculator.Interfaces;

namespace WebCalculator.Expressions
{
    public class NumberExpression : IExpression
    {
        public double Value { get; }

        public NumberExpression(double value)
        {
            Value = value;
        }

        public double Сalculate()
        {
            return Value;
        }
    }
}
