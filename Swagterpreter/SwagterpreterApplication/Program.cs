using System;
using System.Diagnostics;
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
            Console.ForegroundColor = Color.Coral;
            while (true)
            {
                var input = Console.ReadLine();

                try
                {
                    WriteResult(calculator.CalculateExpression(input));
                }
                catch (NullReferenceException e)
                {

                }
                catch (Exception e)
                {
                    WriteError(e.Message);
                }
            }
        }

        private static void WriteError(string message)
        {
            Console.Write(new string(' ', (Console.WindowWidth - message.Length) / 2));
            Console.WriteLine(message, Color.Red);
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
