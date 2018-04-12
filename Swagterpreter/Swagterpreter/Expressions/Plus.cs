﻿using System;
using System.Collections.Generic;
using System.Text;
using Swagterpreter.Interfaces;

namespace Swagterpreter.Expressions
{
    class PlusExpression : IExpression
    {
        private IExpression _leftExpression;
        private IExpression _rightExpression;
        public PlusExpression(IExpression leftExpression, IExpression rightExpression)
        {
            _leftExpression = leftExpression ?? throw new ArgumentNullException(nameof(leftExpression));
            _rightExpression = rightExpression ?? throw new ArgumentNullException(nameof(rightExpression));
        }
        public int Interpret()
        {
            return _leftExpression.Interpret() + _rightExpression.Interpret();
        }
    }
}
