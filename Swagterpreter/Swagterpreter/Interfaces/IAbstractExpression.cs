namespace Swagterpreter.Interfaces
{
    public interface IAbstractExpression<T>
    {
        void Interpret(T interpretMe);
    }
}