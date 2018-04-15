using System.Collections.Generic;

namespace Swagterpreter.Interfaces
{
    public interface IInfixToPostfixConverter
    {
        List<string> InFixToPostFix(string infix);
    }
}