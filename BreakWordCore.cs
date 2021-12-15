using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PunchWordsConsoleApp
{
    class BreakWordCore
    {
        public List<string> BreakWord(List<string> rootDictonary, string word)
        {
            // Зробити погрузку на максимальну глибиину
            List<string> longestWords = SearchSubword(rootDictonary, word);
            foreach (string propositionWord in longestWords)
            {
                if (propositionWord == word)
                {
                    return new List<string>() { propositionWord };
                }
                string nextWord = word.Remove(0, propositionWord.Length);
                List<string> breakIntoWord = BreakWord(rootDictonary, nextWord);
                if (breakIntoWord != null)
                {
                    // Тут ми збираємо слова по ланцюжку на оборот і рекурсивно виходимо з функції
                    breakIntoWord.Add(propositionWord);
                    return breakIntoWord;
                }
            }

            return new List<string>() { word };
        }

        private static List<string> SearchSubword(List<string> rootDictonary, string word)
        {
            List<string> probablyLongestWords = new List<string>();
            List<string> tempDictonary = rootDictonary;

            for (int i = 0; i < word.Length; i++)
            {
                // По символно шукаємо слово
                List<string> temp = new List<string>(); // Слова котрі підходять під даний набір символів
                foreach (string s in tempDictonary) // Проходимось по кожному слові словника
                {
                    // Якщо слово підходить під припущення то добавляємо у словник
                    if (s.Length > i && s[i] == word[i])
                    {
                        temp.Add(s);
                        if (s.Length == i + 1 && s.Length > 1)
                        {
                            probablyLongestWords.Add(s); // Слово знайдено!
                        }
                    }
                }
                tempDictonary = temp;
                if (tempDictonary.Count == 0) break;
            }

            List<string> reverseProbablyLongestWords = Enumerable.Reverse(probablyLongestWords).ToList();
            return reverseProbablyLongestWords;
        }
    }
}
