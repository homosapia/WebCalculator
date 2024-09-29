using System.Text.RegularExpressions;
using WebCalculator.Models.Views;

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

            string pattern = @"^[\d\^\+\-\*\/\(\)\.]+$";
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
