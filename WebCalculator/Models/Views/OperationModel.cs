namespace WebCalculator.Models.Views
{
    public enum ColorOperation
    {
        cornflowerblue = 1,
        darkgray = 2,
    }

    public class OperationModel
    {
        public readonly string OpetationType;
        public ColorOperation Сolor { get; private set; }

        public OperationModel(string opetationType, ColorOperation status) 
        {
            OpetationType = opetationType;
            Сolor = status;
        }

        public void SetStatus(ColorOperation status)
        {
            Сolor = status;
        }

        public bool IsActively()
        {
            return Сolor == ColorOperation.cornflowerblue;
        }
    }
}
