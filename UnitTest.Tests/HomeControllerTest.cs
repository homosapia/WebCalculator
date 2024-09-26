using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebCalculator.Controllers;
using WebCalculator.Factories;
using WebCalculator.Interfaces;
using WebCalculator.Models;
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
            IExpressionAnalysisService expressionService = new ExpressionAnalysisService();
            IExpressionFactory factory = new ExpressionFactory();
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
            Assert.Contains("Строка пуста или содержит недопустимые символы.", modelResult.Resultado);
        }

        [Fact]
        public void СheckForMultipleOperators()
        {
            // Arrange
            IExpressionAnalysisService expressionService = new ExpressionAnalysisService();
            IExpressionFactory factory = new ExpressionFactory();
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
            IExpressionAnalysisService expressionService = new ExpressionAnalysisService();
            IExpressionFactory factory = new ExpressionFactory();
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
