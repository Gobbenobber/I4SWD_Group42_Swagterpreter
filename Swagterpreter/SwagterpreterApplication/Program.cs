using System;
using Swagterpreter.Controller;
using Swagterpreter.ExpressionBuilders;
using Swagterpreter.Interfaces;
using Console = Colorful.Console;
using System.Drawing;
using Colorful;

namespace SwagterpreterApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator(new InfixToPostfixConverter(), new PostfixExpressionBuilder(), new InfixTokenizer());

            WriteWelcome("Welcome to SwagUlator 3000");
            WriteWelcome("Enter infix notation: ");

            while (true)
            {
                var input = Console.ReadLine();

                try
                {
                    WriteResult(calculator.CalculateExpression(input));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void WriteWelcome(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text, Color.DarkTurquoise);
        }

        private static void WriteResult(int result)
        {
            string output = $"Result: {result}";
            Console.Write(new string(' ', (Console.WindowWidth - output.Length) / 2));
            Console.Write("Result: ", Color.Yellow);
            Console.WriteLine($"{result}", Color.LawnGreen);
        }

    }
}
