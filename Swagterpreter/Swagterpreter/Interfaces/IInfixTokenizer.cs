namespace Swagterpreter.Interfaces
{
    public interface IInfixTokenizer
    {
        string Tokenize(string input);
        bool IsValid(string input);
    }
}