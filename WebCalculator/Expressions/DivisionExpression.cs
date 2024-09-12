using WebCalculator.Interfaces;

namespace WebCalculator.Expressions
{
    public class DivisionExpression : IExpression
    {
        public IExpression Left { get; }
        public IExpression Right { get; }

        public DivisionExpression(IExpression left, IExpression right)
        {
            Left = left;
            Right = right;
        }

        public double Сalculate()
        {
            return Left.Сalculate() / Right.Сalculate();
        }
    }
}
