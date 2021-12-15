using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PunchWordsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WidgetOperations widgetOperations = new WidgetOperations();

            List<string> rootDictonary = File.ReadAllLines(@"src\de-dictionary.tsv").ToList();
            // List<string> testDictonary = File.ReadAllLines(@"C:\Users\Niko\Desktop\LAb 4\de-test-words.tsv").ToList();
            List<string> testDictonary = widgetOperations.ReadFile("Specify the path to the word set file to process\nExample C:\\Users\\Username\\Desktop\\de-test-words.tsv");

            // Preprocessing
            List<string> tempRootDictonary = new List<string>();
            foreach (string w in rootDictonary)
            {
                tempRootDictonary.Add(w.ToLower());
            }

            BreakWordCore breakWordCore = new BreakWordCore();
            LineGenerator lineGenerator = new LineGenerator();

            // Formation of the result
            string resultText = null;
            foreach (string testString in testDictonary)
            {
                List<string> breakWords = breakWordCore.BreakWord(tempRootDictonary, testString);
                if(breakWords != null) breakWords = Enumerable.Reverse(breakWords).ToList();
                resultText += lineGenerator.GenerateResult(testString, breakWords);
            }

            if (resultText != null)
            {
                // Console.Write(resultText);
                widgetOperations.SaveFile("Specify the path where to save the results\nExample C:\\Users\\Username\\Desktop\\result.txt", resultText);
            }
            else widgetOperations.PrintMessage("No results to save");

            Console.ReadLine();
        }
    }
}