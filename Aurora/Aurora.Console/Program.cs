using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to Aurora Store!");
            System.Console.Write("> ");

            var command = System.Console.ReadLine();
            while (command.ToLower() != "exit")
            {
                ProcessCommand(command);

                System.Console.Write("> ");
                command = System.Console.ReadLine();
            }
        }

        private static void ProcessCommand(string command)
        {
            System.Console.WriteLine(command);
        }
    }
}
