﻿using System;
using Swagterpreter.Interfaces;

namespace Swagterpreter.Expressions
{
    public class MinusExpression : IExpression
    {
        private readonly IExpression _leftExpression;
        private readonly IExpression _rightExpression;

        public MinusExpression(IExpression leftExpression, IExpression rightExpression)
        {
            _leftExpression = leftExpression ?? throw new ArgumentNullException(nameof(leftExpression));
            _rightExpression = rightExpression ?? throw new ArgumentNullException(nameof(rightExpression));
        }

        public int Interpret()
        {
            return _leftExpression.Interpret() - _rightExpression.Interpret();
        }
    }
}