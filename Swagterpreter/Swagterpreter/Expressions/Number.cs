using System;
using Swagterpreter.Interfaces;

namespace Swagterpreter.Expressions
{
    public class NumberExpression : IExpression
    {
        private readonly int _number;

        public NumberExpression(int number)
        {
            _number = number;
        }

        public int Interpret()
        {
            return _number;
        }
    }
}