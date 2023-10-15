using System;
using System.Collections.Generic;
using System.IO;

namespace Phenol_Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~\n~\n~\n~                    Phenol Code Editor Terminal Edition 1.0\n~                   Ctrl + Q to exit\n~                   Ctrl + S to save\n~                   ENTER to start editing");
            Console.ReadKey();
            Console.Clear();

            bool Editing = true;
            List<string> inputList = new List<string>();

            while (Editing)
            {
                var keyInfo = Console.ReadKey(intercept: true);

                if ((keyInfo.Key == ConsoleKey.Q) && ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0))
                {
                    Editing = false;
                }
                else if ((keyInfo.Key == ConsoleKey.S) && ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0))
                {
                    Console.Write("Enter the filename to save: ");
                    string FileName = Console.ReadLine();
                    Console.Write("Enter the directory to save (or leave blank for current directory): ");
                    string directory = Console.ReadLine();

                    if (string.IsNullOrEmpty(directory))
                    {
                        directory = Environment.CurrentDirectory;
                    }

                    string filePath = Path.Combine(directory, FileName);

                    File.WriteAllLines(filePath, inputList);
                    Console.WriteLine($"Saved the content to {filePath}");
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    string UserInput = Console.ReadLine();
                    inputList.Add(UserInput);
                }
            }
        }
    }
}
