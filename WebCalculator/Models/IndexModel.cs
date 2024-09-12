using System.Text.RegularExpressions;

namespace WebCalculator.Models
{
    public class IndexModel
    {
        public string Expression { get; set; } = string.Empty;

        public string Resultado { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Expression))
            {
                return false;
            }

            // Регулярное выражение для проверки строки
            string pattern = @"^[0-9\.,+\-*/]+$";
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(Expression))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
