﻿using System;
using Swagterpreter.Interfaces;

namespace Swagterpreter.Expressions
{
    public class MultiplyExpression : IExpression
    {
        private IExpression _leftExpression;
        private IExpression _rightExpression;

        public MultiplyExpression(IExpression leftExpression, IExpression rightExpression)
        {
            _leftExpression = leftExpression ?? throw new ArgumentNullException(nameof(leftExpression));
            _rightExpression = rightExpression ?? throw new ArgumentNullException(nameof(rightExpression));
        }

        public int Interpret()
        {
            return _leftExpression.Interpret() * _rightExpression.Interpret();
        }
    }
}