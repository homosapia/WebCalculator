using System;
using WebCalculator.Expressions;
using WebCalculator.Interfaces;
using WebCalculator.Models.Views;

namespace WebCalculator.Services
{
    public class OperationsInteractionService : IOperator
    {
        private readonly Dictionary<string, Type> _operators = new Dictionary<string, Type>()
        {
            { "-",  typeof(SubtractionExpression)},
            { "+",  typeof(AdditionExpression)},
            { "*",  typeof(MultiplicationExpression)},
            { "/",  typeof(DivisionExpression)},
            { "^", typeof(PowerExpression) }
        };

        public OperationsInteractionService()
        {
            ListOperations = new List<Operation>();
            foreach (var item in _operators)
            {
                Operation operation = new Operation(item.Key, ColorOperation.cornflowerblue);
                ListOperations.Add(operation);
            }
        }

        public List<Operation> ListOperations { get; private set; }

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

        public void ToggleStatus(string @operator)
        {
            Operation operation = ListOperations.Find(x => x.OpetationType == @operator);
            ColorOperation[] values = (ColorOperation[])Enum.GetValues(typeof(ColorOperation));
            int currentIndex = Array.IndexOf(values, operation.Сolor);
            int nextIndex = (currentIndex + 1) % values.Length;
            operation.SetStatus(values[nextIndex]);
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
                case "^":
                    return 3;
                default:
                    return 0;
            }
        }
    }
}
