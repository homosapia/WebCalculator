namespace WebCalculator.Interfaces
{
    public interface IOperator
    {
        public IExpression GetExpression(string action, object[] arguments);
        public bool OperatorSupported(string @operator);
        public int GetPrecedence(string @operator);
    }
}
