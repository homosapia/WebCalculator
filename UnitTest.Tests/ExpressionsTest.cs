using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalculator.Expressions;
using WebCalculator.Interfaces;
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UnitTest.Tests
{
    public class ExpressionsTest
    {
        [Fact]
        public void TestingTheNumber() 
        {
            // Arrange
            IExpression expression = new NumberExpression(2);
            // Act
            double number = expression.Сalculate();
            // Assert
            Assert.Equal(2, number);
        }

        [Fact]
        public void TestingSubtractionExpression() 
        {
            // Arrange
            IExpression number1 = new NumberExpression(4);
            IExpression number2 = new NumberExpression(2);
            IExpression expression = new SubtractionExpression(number1, number2);
            // Act
            double number = expression.Сalculate();
            // Assert
            Assert.Equal(2, number);
        }

        [Fact]
        public void TestingAdditionExpression() 
        {
            // Arrange
            IExpression number1 = new NumberExpression(4);
            IExpression number2 = new NumberExpression(2);
            IExpression expression = new AdditionExpression(number1, number2);
            // Act
            double number = expression.Сalculate();
            // Assert
            Assert.Equal(6, number);
        }

        [Fact]
        public void TestingMultiplicationExpression()
        {
            // Arrange
            IExpression number1 = new NumberExpression(4);
            IExpression number2 = new NumberExpression(2);
            IExpression expression = new MultiplicationExpression(number1, number2);
            // Act
            double number = expression.Сalculate();
            // Assert
            Assert.Equal(8, number);
        }

        [Fact]
        public void TestingDivisionExpression()
        {
            //Arrange
            IExpression number1 = new NumberExpression(4);
            IExpression number2 = new NumberExpression(2);
            IExpression expression = new DivisionExpression(number1, number2);
            // Act
            double number = expression.Сalculate();
            // Assert
            Assert.Equal(2, number);
        }
    }
}
