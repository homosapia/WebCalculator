using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalculator.Factories;
using WebCalculator.Interfaces;
using WebCalculator.Services;
using Xunit.Abstractions;
using Xunit;
using WebCalculator.Models;

namespace UnitTest.Tests
{
    public class ExpressionFactoryTest
    {
        [Fact]
        public void CheckingTreeAssemblyMethod()
        {
            // Arrange
            string expression = "-5+3-9*2";
            IOperator ioperator = new ListOperators();
            IExpressionAnalysisService expressionService = new ExpressionAnalysisService(ioperator);
            IExpressionFactory factory = new ExpressionFactory(ioperator);
            List<string> components = expressionService.GetComponentsExpressions(expression);
            List<string> sequence = expressionService.CreateSequence(components);
            // Act
            IExpression iexpression = factory.BuildExpressionTree(sequence);
            // Assert
            Assert.Equal(-20, iexpression.Сalculate());
        }
    }
}
