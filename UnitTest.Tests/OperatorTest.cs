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
using Xunit;

namespace UnitTest.Tests
{
    public class OperatorTest
    {
        [Fact]
        public void СheckingСorrectnessСreationExpression()
        {
            // Arrange
            IOperator ioperator = new ListOperators();
            IExpression number1 = new NumberExpression(4);
            IExpression number2 = new NumberExpression(2);
            // Act
            IExpression expression = ioperator.GetExpression("+", [number1, number2]);
            //Assert
            Assert.Equal(6, expression.Сalculate());
        }

        [Fact]
        public void CheckForUnsupportedExpression()
        {
            // Arrange
            IOperator ioperator = new ListOperators();
            IExpression number1 = new NumberExpression(4);
            IExpression number2 = new NumberExpression(2);
            try
            {
                // Act
                ioperator.GetExpression("df", [number1, number2]);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Contains("Оператор df не поддерживается.", ex.Message);
            }
        }
    }
}
