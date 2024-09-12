namespace WebCalculator.Interfaces
{
    public interface IExpressionAnalysisService
    {
        public List<string> GetComponentsExpressions(string expression);
        public List<string> CreateSequence(List<string> components);
    }
}
