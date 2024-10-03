using WebCalculator.Models.Views;

namespace WebCalculator.Interfaces
{
    public interface IOperator
    {
        public List<OperationModel> GetModelsToView();
        public bool СheckForDuplicates(string expression);
        public IExpression GetExpression(string action, object[] arguments);
        public bool OperatorSupported(string @operator);
        public int GetPrecedence(string @operator);
        public void ToggleStatus(string @operator);
    }
}
