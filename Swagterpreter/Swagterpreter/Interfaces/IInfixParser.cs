namespace Swagterpreter.Interfaces
{
    public interface IInfixParser
    {
        string Parse(string input);
        bool IsValid(string input);
    }
}