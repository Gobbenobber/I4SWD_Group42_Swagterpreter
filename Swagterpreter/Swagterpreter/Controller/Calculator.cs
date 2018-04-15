using System;
using Swagterpreter.Interfaces;

namespace Swagterpreter.Controller
{
    public class Calculator : ICalculator
    {
        private readonly IInfixToPostfixConverter _infixToPostfixConverter;
        private readonly IExpressionBuilder _expressionBuilder;
        private readonly IInfixTokenizer _tokenizer;

        public Calculator(IInfixToPostfixConverter converter, IExpressionBuilder builder, IInfixTokenizer tokenizer)
        {
            _infixToPostfixConverter = converter;
            _expressionBuilder = builder;
            _tokenizer = tokenizer;
        }
        public int CalculateExpression(string input)
        {
            var infix = input.Replace(" ", string.Empty);

            if (_tokenizer.IsValid(infix))
            {
                infix = _tokenizer.Tokenize(infix);
                var postfix = _infixToPostfixConverter.InFixToPostFix(infix);
                var expression = _expressionBuilder.Build(postfix.ToArray());
                return expression.Interpret();
            }

            throw new ArgumentException("Not a valid input");
        }
    }
}