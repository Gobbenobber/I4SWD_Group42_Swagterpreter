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
                IExpression rightHandExpression = null;
                IExpression leftHandExpression = null;

                switch (element)
                {
                    case "+":
                        rightHandExpression = stack.Pop();
                        leftHandExpression = stack.Pop();

                        stack.Push(new PlusExpression(leftHandExpression, rightHandExpression));
                        break;

                    case "-":
                        rightHandExpression = stack.Pop();
                        leftHandExpression = stack.Pop();
                        stack.Push(new MinusExpression(leftHandExpression, rightHandExpression));
                        break;

                    case "*":
                        rightHandExpression = stack.Pop();
                        leftHandExpression = stack.Pop();
                        stack.Push(new MultiplyExpression(leftHandExpression, rightHandExpression));
                        break;

                    case "/":
                        rightHandExpression = stack.Pop();
                        leftHandExpression = stack.Pop();
                        stack.Push(new DivideExpression(leftHandExpression, rightHandExpression));
                        break;

                    case "^":
                        rightHandExpression = stack.Pop();
                        leftHandExpression = stack.Pop();
                        stack.Push(new PowerToExpression(leftHandExpression, rightHandExpression));
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