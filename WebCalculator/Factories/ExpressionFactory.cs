using System.Globalization;
using WebCalculator.Expressions;
using WebCalculator.Interfaces;

namespace WebCalculator.Factories
{
    public class ExpressionFactory : IExpressionFactory
    {
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

                        switch (token)
                        {
                            case "+":
                                stack.Push(new AdditionExpression(left, right));
                                break;
                            case "-":
                                stack.Push(new SubtractionExpression(left, right));
                                break;
                            case "*":
                                stack.Push(new MultiplicationExpression(left, right));
                                break;
                            case "/":
                                stack.Push(new DivisionExpression(left, right));
                                break;
                        }
                    }
                    catch
                    {
                        throw new ArgumentException("Не получилось вычислить вырожение");
                    }
                }
            }

            return stack.Pop();
        }
    }
}
