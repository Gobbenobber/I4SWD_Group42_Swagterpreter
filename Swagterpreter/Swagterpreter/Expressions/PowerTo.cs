using System;
using Swagterpreter.Interfaces;

namespace Swagterpreter.Expressions
{
    public class PowerToExpression : IExpression
    {
        private readonly IExpression _leftExpression;
        private readonly IExpression _rightExpression;
        public PowerToExpression(IExpression leftExpression, IExpression rightExpression)
        {
            _leftExpression = leftExpression ?? throw new ArgumentNullException(nameof(leftExpression));
            _rightExpression = rightExpression ?? throw new ArgumentNullException(nameof(rightExpression));
        }
        public int Interpret()
        {
            return (int)Math.Pow((double) _leftExpression.Interpret(), (double) _rightExpression.Interpret());
        }
    }
}