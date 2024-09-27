using WebCalculator.Models.Views;

namespace WebCalculator.Interfaces
{
    public interface IOperator
    {
        public List<Operation> ListOperations { get; }
        public IExpression GetExpression(string action, object[] arguments);
        public bool OperatorSupported(string @operator);
        public int GetPrecedence(string @operator);
        public void ToggleStatus(string @operator);
    }
}
