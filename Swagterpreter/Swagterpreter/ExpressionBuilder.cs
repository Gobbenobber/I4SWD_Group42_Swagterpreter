using System.Collections;
using System.Collections.Generic;
using Swagterpreter.Expressions;
using Swagterpreter.Interfaces;

namespace Swagterpreter
{
    public class CalculatorExpressionBuilder : IExpressionBuilder
    {
        public IExpression Build(string input)
        {
            Stack<IExpression> stack = new Stack<IExpression>();

            string[] elements = input.Split(' ');

            foreach (var element in elements)
            {
                IExpression rightHandExpression = null;
                IExpression leftHandExpression = null;

                switch (element)
                {
                    case "+":
                        leftHandExpression = stack.Pop();
                        rightHandExpression = stack.Pop();

                        stack.Push(new PlusExpression(leftHandExpression, rightHandExpression));
                        break;

                    case "-":
                        leftHandExpression = stack.Pop();
                        rightHandExpression = stack.Pop();
                        stack.Push(new MinusExpression(leftHandExpression, rightHandExpression));
                        break;

                    case "*":
                        leftHandExpression = stack.Pop();
                        rightHandExpression = stack.Pop();
                        stack.Push(new MultiplyExpression(leftHandExpression, rightHandExpression));
                        break;

                    case "/":
                        leftHandExpression = stack.Pop();
                        rightHandExpression = stack.Pop();
                        stack.Push(new DivideExpression(leftHandExpression, rightHandExpression));
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