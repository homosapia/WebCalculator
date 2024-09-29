using WebCalculator.Interfaces;

namespace WebCalculator.Expressions
{
    public class PowerExpression : IExpression
    {
        public IExpression Left { get; }
        public IExpression Right { get; }

        public PowerExpression(IExpression left, IExpression right)
        {
            Left = left;
            Right = right;
        }

        public double Сalculate()
        {
            return Math.Pow(Left.Сalculate(), Right.Сalculate());
        }
    }
}
