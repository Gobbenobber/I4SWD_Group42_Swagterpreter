using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Swagterpreter.Interfaces;

namespace Swagterpreter.ExpressionBuilders
{
    public class InfixParser : IInfixParser
    {
        public string Parse(string input)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                var character = input[i];

                sb.Append(character);

                if (i < input.Length - 1)
                {
                    if (AddSpace(character, input[i + 1]))
                    {
                        sb.Append(" ");
                    }
                }
            }
            return sb.ToString();
        }

        public bool IsValid(string infix)
        {
            Regex operators = new Regex(@"[\-^+*/%]", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);

            var input = infix;

            if (string.IsNullOrEmpty(input))
                return false;

            if (input.ToCharArray().Count(c => c == '(') != input.ToCharArray().Count(c => c == ')'))
                return false;

            string tempString = operators.Replace(input, ".");

            if (tempString.EndsWith("."))
                return false;

            string[] contains = new string[] { "(.)", "()", "..", ".)" };

            foreach (string s in contains)
            {
                if (tempString.Contains(s))
                    return false;
            }

            operators = new Regex(@"[().]", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
            tempString = operators.Replace(tempString, string.Empty);

            foreach (char c in tempString.ToCharArray())
            {
                if (!Char.IsNumber(c))
                    return false;
            }

            if (input.Contains("."))
                return false;

            tempString = input;

            operators = new Regex(@"[1234567890]", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
            var moreOps = new Regex(@"[(]", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled );

            tempString = operators.Replace(tempString, ".");
            tempString = moreOps.Replace(tempString, "g");

            if (tempString.Contains(".g"))
                return false;
            if (input.StartsWith("*") || input.StartsWith("/") || input.StartsWith("%")
                || input.StartsWith("+") || input.StartsWith("-"))
                return false;

            contains = new string[] { "(%", "(/", "(*", "(+", "(-" };
            foreach (string s in contains)
            {
                if (input.Contains(s))
                    return false;
            }

            return true;
        }

        private bool AddSpace(char current, char next)
        {
            if (Char.IsNumber(current) && Char.IsNumber(next))
            {
                return false;
            }

            if (Char.IsLetter(current) && Char.IsLetter(next))
            {
                return false;
            }

            return true;
        }
    }
}