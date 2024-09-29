using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebCalculator.Expressions;
using WebCalculator.Interfaces;
using WebCalculator.Models;
using WebCalculator.Models.Views;
using WebCalculator.Services;
using Xunit;

namespace UnitTest.Tests
{
    public class OperatorTest
    {
        [Fact]
        public void СheckingСorrectnessСreationExpression()
        {
            // Arrange
            IOperator ioperator = new OperationsInteractionService();
            IExpression number1 = new NumberExpression(4);
            IExpression number2 = new NumberExpression(2);
            // Act
            List<double> answer = new List<double>();
            answer.Add(ioperator.GetExpression("+", [number1, number2]).Сalculate());
            answer.Add(ioperator.GetExpression("-", [number1, number2]).Сalculate());
            answer.Add(ioperator.GetExpression("*", [number1, number2]).Сalculate());
            answer.Add(ioperator.GetExpression("/", [number1, number2]).Сalculate());
            answer.Add(ioperator.GetExpression("^", [number1, number2]).Сalculate());
            //Assert

            List<double> correctAnswers = new List<double>() { 6, 2, 8, 2, 16 };

            Assert.All(answer, item => Assert.Contains(item, correctAnswers));
        }

        [Fact]
        public void CheckStatusChange()
        {
            // Arrange
            IOperator ioperator = new OperationsInteractionService();
            ioperator.ToggleStatus("+");
            // Act
            var list = ioperator.ListOperations.First(x => x.OpetationType == "+");
            //Assert
            Assert.Equal(ColorOperation.darkgray, list.Сolor);
        }

        [Fact]
        public void CheckForUnsupportedExpression()
        {
            // Arrange
            IOperator ioperator = new OperationsInteractionService();
            ioperator.ToggleStatus("+");
            IExpression number1 = new NumberExpression(4);
            IExpression number2 = new NumberExpression(2);
            try
            {
                // Act
                ioperator.GetExpression("+", [number1, number2]);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Contains("Оператор + выключен", ex.Message);
            }
        }
    }
}
