using WebCalculator.Expressions;
using WebCalculator.Interfaces;
using WebCalculator.Models;
using WebCalculator.Models.Views;

namespace WebCalculator.Services
{
    public class OperationsInteractionService : IOperator
    {
        private readonly List<BaseOperator> _operations = new List<BaseOperator>()
        {
            new BaseOperator("-", 1, typeof(SubtractionExpression)),
            new BaseOperator("+", 1, typeof(AdditionExpression)),
            new BaseOperator("*", 2, typeof(MultiplicationExpression)),
            new BaseOperator("/", 2, typeof(DivisionExpression)),
            new BaseOperator("^", 3, typeof(PowerExpression)),
        };

        public bool СheckForDuplicates(string expression)
        {
            Stack<char> stack = new Stack<char>();
            foreach (var token in expression)
            {
                if (char.IsDigit(token) || token == '.' || token == '(' || token == ')')
                {
                    if(stack.Count > 1)
                    {
                        return true;
                    }

                    stack.Clear();
                    continue;
                }
                else
                {
                    stack.Push(token);
                }
            }

            return stack.Count <= 1;
        }

        public IExpression GetExpression(string type, object[] arguments)
        {
            if(!OperatorSupported(type))
                throw new ArgumentException($"Оператор {type} не поддерживается.");

            return _operations.First(x => x.Type == type).GetExpression(arguments);
        }

        public bool OperatorSupported(string type)
        {
            return _operations.Any(x => x.Type == type);
        }

        public int GetPrecedence(string type)
        {
            if (!OperatorSupported(type))
                throw new ArgumentException($"Оператор {type} не поддерживается.");

            return _operations.First(x => x.Type == type).Precedence;
        }

        public List<OperationModel> GetModelsToView()
        {
            List<OperationModel> models = new List<OperationModel>();
            foreach (var item in _operations)
            {
                models.Add(item.OperationModel);
            }
            return models;
        }

        public void ToggleStatus(string type)
        {
            if (!OperatorSupported(type))
                throw new ArgumentException($"Оператор {type} не поддерживается.");

            _operations.First(x => x.Type == type).ToggleStatus();
        }
    }
}
