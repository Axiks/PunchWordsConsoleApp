using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PunchWordsConsoleApp
{
    class WidgetOperations
    {
        const string successReadFileMessage= "Success read file!";
        const string errorReadFileMessage= "Error: Failed to read file. Maybe you entered the path incorrectly or by mistake. Try again!";
        const string successSaveFileMessage = "Success write file!";
        const string errorSaveFileMessage= "Error: Failed to write file. Maybe you entered the path incorrectly or by mistake. Try again!";

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public List<string> ReadFile(string message)
        {
            PrintMessage(message);
            while (true)
            {
                string pathToFile = Console.ReadLine();
                try
                {
                    List<string> result = File.ReadAllLines(@pathToFile).ToList();
                    PrintMessage(successReadFileMessage);
                    return result;
                }
                catch
                {
                    PrintMessage(errorReadFileMessage);
                }
            }
        }

        public void SaveFile(string message, string textToSave)
        {
            PrintMessage(message);
            while (true)
            {
                string pathToFile = Console.ReadLine();
                try
                {
                    File.WriteAllText(@pathToFile, textToSave);
                    PrintMessage(successSaveFileMessage);
                    break;

                }
                catch
                {
                    PrintMessage(errorSaveFileMessage);
                }
            }
        }
    }
}
