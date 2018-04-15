using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Swagterpreter.Interfaces;

namespace Swagterpreter.ExpressionBuilders
{
    /// <summary>
    /// This class was inspired from https://github.com/karimo94/infix-to-rpn/blob/master/Program.cs
    /// </summary>
    public class InfixToPostfixConverter : IInfixToPostfixConverter
    {
        /// <summary>
        /// Converts the passed string to postfix notation
        /// </summary>
        /// <param name="infix"></param>
        /// <returns>A list of tokens corresponding to the postfix notation of the passed input string</returns>
        public List<string> InFixToPostFix(string infix)
        {
            var postFix = new List<string>();
            var operators = new Stack<string>();

            string[] tokens = infix.Split(' ');
            int number;

            foreach (string current in tokens)
            {
                if (int.TryParse(current.ToString(), out number))
                {
                    postFix.Add(current);
                }
                if (current == "(")
                {
                    operators.Push(current);
                }
                if (current == ")")
                {
                    while (operators.Count != 0 && operators.Peek() != "(")
                    {
                        postFix.Add(operators.Pop());
                    }
                    operators.Pop();
                }
                if (IsOperator(current))
                {
                    while (operators.Count != 0 && Priority(operators.Peek()) >= Priority(current))
                    {
                        postFix.Add(operators.Pop());
                    }
                    operators.Push(current);
                }
            }
            while (operators.Count != 0)//if any operators remain in the stack, pop all & add to output list until stack is empty 
            {
                postFix.Add(operators.Pop());
            }
            return postFix;
        }

        #region Utility

        private int Priority(string value)
        {
            if (value == "^")
            {
                return 3;
            }
            else if (value == "*" || value == "/")
            {
                return 2;
            }
            else if (value == "+" || value == "-")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private bool IsOperator(string value)
        {
            if (value == "+" || value == "-" || value == "*" || value == "/" || value == "^")
            {
                return true;
            }

            return false;
        }

        #endregion

    }
}