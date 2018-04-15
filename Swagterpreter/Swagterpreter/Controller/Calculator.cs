using System;
using Swagterpreter.Interfaces;

namespace Swagterpreter.Controller
{
    public class Calculator : ICalculator
    {
        private readonly IInfixToRpnConverter _infixToRpnConverter;
        private readonly IExpressionBuilder _expressionBuilder;
        private readonly IInfixParser _parser;

        public Calculator(IInfixToRpnConverter converter, IExpressionBuilder builder, IInfixParser parser)
        {
            _infixToRpnConverter = converter;
            _expressionBuilder = builder;
            _parser = parser;
        }
        public int CalculateExpression(string input)
        {
            var infix = input.Replace(" ", string.Empty);

            if (_parser.IsValid(infix))
            {
                infix = _parser.Parse(infix);
                var postfix = _infixToRpnConverter.InFixToPostFix(infix);
                var expression = _expressionBuilder.Build(postfix.ToArray());
                return expression.Interpret();
            }

            throw new ArgumentException("Not a valid input");
        }
    }
}