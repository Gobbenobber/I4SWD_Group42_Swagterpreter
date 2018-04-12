using System;
using Swagterpreter;

namespace SwagterpreterApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Reverse Polish Notation expression: ");
            var input = Console.ReadLine();

            var expressionBuilder = new CalculatorExpressionBuilder();

            var output = expressionBuilder.Build(input);
            Console.WriteLine("= {0}", output.Interpret());
            Console.ReadLine();
        }
    }
}
