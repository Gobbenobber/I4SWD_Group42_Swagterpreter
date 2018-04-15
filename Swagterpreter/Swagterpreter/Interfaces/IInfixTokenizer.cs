namespace Swagterpreter.Interfaces
{
    public interface IInfixTokenizer
    {
        string Parse(string input);
        bool IsValid(string input);
    }
}