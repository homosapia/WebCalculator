using Moq;
using System.Linq.Expressions;
using WebCalculator.Interfaces;
using WebCalculator.Models;
using WebCalculator.Services;
using Xunit;

namespace UnitTest.Tests
{
    public class ExpressionAnalysisServiceTest
    {
        [Fact]
        public void CheckingExpressionComponents()
        {
            // Arrange
            IOperator ioperator = new OperationsInteractionService();
            var expressionService = new ExpressionAnalysisService(ioperator);
            string expression = "-5+3-9*2";
            // Act
            List<string> itens = expressionService.GetComponentsExpressions(expression);
            // Assert
            List<string> expectedResult = new List<string>() { "-5", "+", "3", "-", "9", "*", "2" };
            Assert.Equal(expectedResult, itens);
        }

        [Fact]
        public void CheckingMethodConstructingSequence() 
        {
            // Arrange
            IOperator ioperator = new OperationsInteractionService();
            IExpressionAnalysisService expressionService = new ExpressionAnalysisService(ioperator);
            List<string> componentsExpression = new List<string>() { "-5", "+", "3", "-", "9", "*", "2" };
            // Act
            List<string> itens = expressionService.CreateSequence(componentsExpression);
            // Assert
            List<string> expectedResult = new List<string>() { "-5", "3", "+", "9", "2", "*", "-" };
            Assert.Equal(expectedResult, itens);
        }
    }
}
