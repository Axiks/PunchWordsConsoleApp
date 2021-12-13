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
            List<string> rootDictonary = File.ReadAllLines(@"C:\Users\Niko\Desktop\LAb 4\de-dictionary.tsv").ToList();
            List<string> testDictonary = readFileWidget("Specify the path to the word set file to process\nExample C:\\Users\\Username\\Desktop\\de-test-words.tsv");

            List<string> tempRootDictonary = new List<string>();
            foreach (string w in rootDictonary)
            {
                tempRootDictonary.Add(w.ToLower());
            }

            string resultText = "";
            foreach (string word in testDictonary)
            {
                List<string> breakWords = BreakIntoWords(tempRootDictonary, word);
                resultText += renderResultLine(word, breakWords);
            }

            Console.Write(resultText);
            saveFileWidget("Specify the path where to save the results\nExample C:\\Users\\Username\\Desktop\\result.txt", resultText);

            Console.ReadLine();
        }

        static List<string> readFileWidget(string message)
        {
            Console.WriteLine(message);
            while (true)
            {
                String pathToFile = Console.ReadLine();
                try
                {
                    return File.ReadAllLines(@pathToFile).ToList();
                }
                catch
                {
                    Console.WriteLine("Error: Failed to read file. Maybe you entered the path incorrectly or by mistake. Try again!");
                }
            }
        }

        static void saveFileWidget(string message, string textToSave)
        {
            Console.WriteLine(message);
            while (true)
            {
                String pathToFile = Console.ReadLine();
                try
                {
                    File.WriteAllText(@pathToFile, textToSave);
                    Console.WriteLine("Save success!");
                    break;
                }
                catch
                {
                    Console.WriteLine("Error: Failed to write file. Maybe you entered the path incorrectly or by mistake. Try again!");
                }
            }
        }

        static string renderResultLine(String initialWord, List<string> brokenWords)
        {
            string newText = "(in) " + initialWord + " -> (out) ";
            if (brokenWords != null)
            {
                newText += brokenWords[0];
                for (int i = 1; i < brokenWords.Count; i++)
                {
                    newText += ", " + brokenWords[i];
                }
            }
            else
            {
                newText += initialWord;
            }
            newText += "\n";
            return newText;
        }

        static List<string> BreakIntoWords(List<string> rootDictonary, string word)
        {
            List<string> tempDictonary = rootDictonary;

            for (int i = 0; i < word.Length; i++)
            {
                List<string> temp = new List<string>();
                foreach (string s in tempDictonary)
                {
                    if (s.Length > i && s[i] == word[i])
                    {
                        temp.Add(s);
                        if (s.Length == i + 1 && s.Length > 1)
                        {
                            if (word.Length != s.Length)
                            {
                                List<string> tempWords = new List<string>();
                                tempWords.Add(s);

                                string  trimWords = word.Remove(0, s.Length);
                                List<string> res = BreakIntoWords(rootDictonary, trimWords);
                                if (res != null)
                                {
                                    tempWords.AddRange(res);
                                    return tempWords;
                                }
                            }
                            else
                            {
                                List<string> res = new List<string> { s };
                                return res;
                            }
                        }
                    }
                }
                tempDictonary = temp;
                if (tempDictonary.Count == 0) break;
            }
            return null;
        }
    }
}