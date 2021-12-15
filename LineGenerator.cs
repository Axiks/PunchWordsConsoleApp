using System;
using System.Collections.Generic;
using System.Text;

namespace PunchWordsConsoleApp
{
    class LineGenerator
    {
        public string GenerateResult(string initialWord, List<string> brokenWords)
        {
            string newText = "(in) " + initialWord + " -> (out) ";
            if (brokenWords.Count > 0)
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
    }
}
