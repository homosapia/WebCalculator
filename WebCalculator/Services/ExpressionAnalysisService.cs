using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Globalization;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using WebCalculator.Expressions;
using WebCalculator.Interfaces;

namespace WebCalculator.Services
{
    public class ExpressionAnalysisService : IExpressionAnalysisService
    {

        public List<string> GetComponentsExpressions(string expression)
        {
            if (Regex.IsMatch(expression, @"[+\-*/]{2,}"))
                throw new ArgumentException("Несколько операторов подряд не допускаются.");

            List<string> tokens = new List<string>();
            List<char> number = new List<char>();
            foreach (char token in expression)
            {
                if (char.IsDigit(token) || token == '.')
                {
                    number.Add(token);
                }
                else
                {
                    if (number.Count > 0)
                    {
                        tokens.Add(new string(number.ToArray()));
                        number.Clear();
                    }
                    else if (number.Count == 0 && GetPrecedence(token.ToString()) == 1)
                    {
                        number.Add(token);
                        continue;
                    }

                    tokens.Add(token.ToString());
                }
            }

            if(number.Any())
            {
                tokens.Add(new string(number.ToArray()));
            }

            return tokens;
        }

        public List<string> CreateSequence(List<string> components)
        {
            var output = new List<string>();
            var operators = new Stack<string>();

            foreach (var token in components)
            {
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                {
                    output.Add(token);
                }
                else if (token == "+" || token == "-" || token == "*" || token == "/")
                {
                    while (operators.Count > 0 && GetPrecedence(operators.Peek()) >= GetPrecedence(token))
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Push(token);
                }
            }

            while (operators.Count > 0)
            {
                output.Add(operators.Pop());
            }

            return output;
        }

        private int GetPrecedence(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                default:
                    return 0;
            }
        }
    }
}
