using System.Collections.Generic;
using Swagterpreter.Expressions;
using Swagterpreter.Interfaces;

namespace Swagterpreter.ExpressionBuilders
{

    /// <summary>
    /// This class acts as the expression builder for interpreting mathematical expressions written in Reverse Polish Notation.
    /// </summary>
    public class PostfixExpressionBuilder : IExpressionBuilder
    {
        public IExpression Build(string[] input)
        {
            Stack<IExpression> stack = new Stack<IExpression>();

            foreach (var element in input)
            {
                IExpression rightExpression = null;
                IExpression leftExpression = null;

                switch (element)
                {
                    case "+":
                        rightExpression = stack.Pop();
                        leftExpression = stack.Pop();

                        stack.Push(new AddExpression(leftExpression, rightExpression));
                        break;

                    case "-":
                        rightExpression = stack.Pop();
                        leftExpression = stack.Pop();
                        stack.Push(new SubtractExpression(leftExpression, rightExpression));
                        break;

                    case "*":
                        rightExpression = stack.Pop();
                        leftExpression = stack.Pop();
                        stack.Push(new MultiplyExpression(leftExpression, rightExpression));
                        break;

                    case "/":
                        rightExpression = stack.Pop();
                        leftExpression = stack.Pop();
                        stack.Push(new DivideExpression(leftExpression, rightExpression));
                        break;

                    case "^":
                        rightExpression = stack.Pop();
                        leftExpression = stack.Pop();
                        stack.Push(new PowerToExpression(leftExpression, rightExpression));
                        break;

                    default:
                        int number = int.Parse(element);
                        stack.Push(new NumberExpression(number));
                        break;
                }
            }
            return stack.Pop();
        }
    }
}