using System.Collections.Generic;
using System.Linq;
//!!! 10-08-2018 постановки в задачах изменили, код писался 11.02.2018, так что редактируйте, чтобы прошло тесты
namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static readonly string[] StopWords =
        {
            "the", "and", "to", "a", "of", "in", "on", "at", "that",
            "as", "but", "with", "out", "for", "up", "one", "from", "into"
        };

        public static List<List<string>> ParseSentences(string text)
        {
            var separators = new char[] { '.', '!', '?', ';', ':', '(', ')' };
            var sentences = text.Split(separators);
            var result = new List<List<string>>();
            foreach (var e in sentences)
            {
                var tempSentences = ParseSentence(e);
                if (tempSentences.Count != 0)
                {
                    result.Add(tempSentences);
                }
            }
            return result;
        }

        public static List<string> ParseSentence(string tempSentence)
        {
            var sentence = new List<string>();
            var word = "";
            for (int i = 0; i < tempSentence.Length; i++)
            {
                if (char.IsLetter(tempSentence[i]) || tempSentence[i] == '\'')
                {
                    word += tempSentence[i].ToString().ToLower();
                }
                else if (word != "")
                {
                    if (!StopWords.Contains(word))
                        sentence.Add(word);
                    word = "";
                }
                if (i == tempSentence.Length - 1 && word != "")
                {
                    if (!StopWords.Contains(word))
                        sentence.Add(word);
                    word = "";
                }
            }
            return sentence;
        }
    }
}