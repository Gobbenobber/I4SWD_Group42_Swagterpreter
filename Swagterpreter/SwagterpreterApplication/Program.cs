using System;
using Swagterpreter.Controller;
using Swagterpreter.ExpressionBuilders;
using Swagterpreter.Interfaces;

namespace SwagterpreterApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator(new InfixToRpnConverter(), new PostfixExpressionBuilder(), new InfixParser());

            Console.WriteLine("Enter infix notation: ");

            while (true)
            {
                var input = Console.ReadLine();

                try
                {
                    Console.WriteLine($"Result is: {calculator.CalculateExpression(input)}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
