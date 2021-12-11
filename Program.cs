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
            Console.WriteLine("Hello World!");

            List<string> rootDictonary = File.ReadAllLines(@"C:\Users\Niko\Desktop\LAb 4\de-dictionary.tsv").ToList();
            string[] testWords = File.ReadAllLines(@"C:\Users\Niko\Desktop\LAb 4\de-test-words.tsv");
            string word = "heilerziehungspfleger";

            List<string> breakWords = BreakIntoWords(rootDictonary, word);
            List<string> tempBreakWords = breakWords;
            while (true)
            {
                List<string> tBreakWords = new List<string>();
                foreach (string t in tempBreakWords)
                {
                    Console.WriteLine("Words: " + t);
                    String trimWords = word.Remove(0, t.Length);
                    Console.WriteLine("Trim words: " + trimWords);

                    List<string> tempWords2 = BreakIntoWords(rootDictonary, trimWords);
                    Console.WriteLine(tempWords2.Count);
                    foreach (string t2 in tempWords2)
                    {
                        Console.WriteLine(t2);
                    }

                }
                break;

            }

            Console.ReadLine();
        }

        static List<string> BreakIntoWords(List<string> rootDictonary, string word)
        {
            Console.WriteLine(word);
            List<string> tempDictonary = new List<string>();

            List<string> tempWords = new List<string>();

            foreach (string w in rootDictonary)
            {
                tempDictonary.Add(w.ToLower());
            }

            /*Console.WriteLine(tempDictonary.Count);*/

            for (int i = 0; i < word.Length; i++)
            {
                List<string> temp = new List<string>();
                foreach (string s in tempDictonary)
                {
                    if (s.Length > i && s[i] == word[i])
                    {
                        temp.Add(s);
                        if (s.Length == i+1)
                        {
                            tempWords.Add(s);
                        }
                    }
                }
                tempDictonary = temp;
                if (tempDictonary.Count == 0) break;
                /*Console.WriteLine(tempDictonary.Count);*/
            }
            return tempWords;
        }
    }
}
