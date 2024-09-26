using WebCalculator.Expressions;
using WebCalculator.Interfaces;

namespace WebCalculator.Models
{
    public class ListOperators : IOperator
    {
        private readonly Dictionary<string, Type> _operators = new Dictionary<string, Type>()
        {
            { "-",  typeof(SubtractionExpression)},
            { "+",  typeof(AdditionExpression)},
            { "*",  typeof(MultiplicationExpression)},
            { "/",  typeof(DivisionExpression)}
        };

        public IExpression GetExpression(string action, object[] arguments)
        {
            try
            {
                Type type = _operators[action];
                object myObject = Activator.CreateInstance(type, arguments);
                return (IExpression)myObject;
            }
            catch 
            {
                throw new ArgumentException($"Оператор {action} не поддерживается.");
            }
        }

        public bool OperatorSupported(string @operator)
        {
            return _operators.ContainsKey(@operator);
        }

        public int GetPrecedence(string @operator)
        {
            switch (@operator)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                default:
                    return 0;
            }
        }
    }
}
