using System.Collections.Generic;

namespace Swagterpreter.Interfaces
{
    public interface IInfixToRpnConverter
    {
        List<string> InFixToPostFix(string infix);
    }
}