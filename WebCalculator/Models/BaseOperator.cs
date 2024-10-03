using System.Linq.Expressions;
using System.Numerics;
using WebCalculator.Interfaces;
using WebCalculator.Models.Views;

namespace WebCalculator.Models
{
    public class BaseOperator
    {
        private readonly Type Expression;

        public readonly int Precedence;

        public readonly OperationModel OperationModel;

        public string Type => OperationModel.OpetationType;

        public bool IsActively => OperationModel.IsActively();

        public BaseOperator(string operation, int precedence, Type expression) 
        {
            Expression = expression;
            Precedence = precedence;
            OperationModel = new OperationModel(operation, ColorOperation.cornflowerblue);
        }

        public IExpression GetExpression(object[] arguments)
        {
            if (!IsActively)
                throw new ArgumentException($"Оператор {OperationModel.OpetationType} выключен");

            object myObject = Activator.CreateInstance(Expression, arguments);
            return (IExpression)myObject;
        }

        public void ToggleStatus()
        {
            ColorOperation[] values = (ColorOperation[])Enum.GetValues(typeof(ColorOperation));
            int currentIndex = Array.IndexOf(values, OperationModel.Сolor);
            int nextIndex = (currentIndex + 1) % values.Length;
            OperationModel.SetStatus(values[nextIndex]);
        }
    }
}
