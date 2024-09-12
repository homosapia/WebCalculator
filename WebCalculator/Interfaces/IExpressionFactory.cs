namespace WebCalculator.Interfaces
{
    public interface IExpressionFactory
    {
        public IExpression BuildExpressionTree(List<string> postfixExpression);
    }
}
