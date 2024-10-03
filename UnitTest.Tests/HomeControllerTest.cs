using Microsoft.AspNetCore.Mvc;
using WebCalculator.Controllers;
using WebCalculator.Factories;
using WebCalculator.Interfaces;
using WebCalculator.Models;
using WebCalculator.Models.Views;
using WebCalculator.Services;
using Xunit;

namespace UnitTest.Tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void TestingExpressionValidation()
        {
            // Arrange
            IOperator ioperator = new OperationsInteractionService();
            IExpressionAnalysisService expressionService = new ExpressionAnalysisService(ioperator);
            IExpressionFactory factory = new ExpressionFactory(ioperator);
            HomeController homeController = new HomeController(expressionService, factory);
            IndexModel model = new IndexModel()
            {
                Expression = "в )(23 fe _ $"
            };
            //Act
            IActionResult result = homeController.CalculateExpression(model);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var modelResult = Assert.IsType<IndexModel>(viewResult.Model);
            Assert.Contains("Выражение пустое или не имеет смысла", modelResult.Resultado);
        }

        [Fact]
        public void СheckForMultipleOperators()
        {
            // Arrange
            IOperator ioperator = new OperationsInteractionService();
            IExpressionAnalysisService expressionService = new ExpressionAnalysisService(ioperator);
            IExpressionFactory factory = new ExpressionFactory(ioperator);
            HomeController homeController = new HomeController(expressionService, factory);
            IndexModel model = new IndexModel()
            {
                Expression = "-5*-3"
            };
            //Act
            IActionResult result = homeController.CalculateExpression(model);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var modelResult = Assert.IsType<IndexModel>(viewResult.Model);
            Assert.Contains("Несколько операторов подряд не допускаются.", modelResult.Resultado);
        }

        [Fact]
        public void ExpressionEvaluation()
        {
            // Arrange
            IOperator ioperator = new OperationsInteractionService();
            IExpressionAnalysisService expressionService = new ExpressionAnalysisService(ioperator);
            IExpressionFactory factory = new ExpressionFactory(ioperator);
            HomeController homeController = new HomeController(expressionService, factory);
            IndexModel model = new IndexModel()
            {
                Expression = "-5+3-9*2"
            };
            //Act
            IActionResult result = homeController.CalculateExpression(model);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var modelResult = Assert.IsType<IndexModel>(viewResult.Model);
            Assert.Contains("Ответ: -20", modelResult.Resultado);
        }
    }
}
