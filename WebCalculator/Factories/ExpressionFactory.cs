using System.Globalization;
using WebCalculator.Expressions;
using WebCalculator.Interfaces;

namespace WebCalculator.Factories
{
    public class ExpressionFactory : IExpressionFactory
    {
        private IOperator _operator;
        public ExpressionFactory(IOperator @operator) 
        {
            _operator = @operator;
        }


        public IExpression BuildExpressionTree(List<string> postfixExpression)
        {
            var stack = new Stack<IExpression>();

            foreach (var token in postfixExpression)
            {
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                {
                    stack.Push(new NumberExpression(number));
                }
                else
                {
                    try
                    {
                        var right = stack.Pop();
                        var left = stack.Pop();

                        stack.Push(_operator.GetExpression(token, [left, right]));
                    }
                    catch(InvalidOperationException)
                    {
                        throw new ArgumentException("Не получилось вычислить вырожение");
                    }
                }
            }

            return stack.Pop();
        }
    }
}
