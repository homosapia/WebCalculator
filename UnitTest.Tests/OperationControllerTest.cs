using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalculator.Controllers;
using WebCalculator.Factories;
using WebCalculator.Interfaces;
using WebCalculator.Models;
using WebCalculator.Models.Views;
using WebCalculator.Services;
using Xunit;

namespace UnitTest.Tests
{
    public class OperationControllerTest
    {
        [Fact]
        public void TestingGettingPageAndList()
        {
            // Arrange
            IOperator ioperator = new OperationsInteractionService();
            OperationController operationController = new OperationController(ioperator);
            //Act
            IActionResult result = operationController.GetListOperation();

            //Assert
            var viewResult = Assert.IsType<PartialViewResult>(result);
            var modelResult = Assert.IsType<List<OperationModel>>(viewResult.Model);
            Assert.Equal(ioperator.GetModelsToView(), modelResult);
        }

        [Fact]
        public void TestingExpressionValidation()
        {
            // Arrange
            IOperator ioperator = new OperationsInteractionService();
            OperationController operationController = new OperationController(ioperator);
            //Act
            operationController.СhangeStatus("+");

            //Assert
            var @operator = ioperator.GetModelsToView().Single(x => x.OpetationType == "+");
            Assert.Equal(ColorOperation.darkgray, @operator.Сolor);
        }
    }
}
