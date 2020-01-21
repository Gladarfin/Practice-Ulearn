using System.Collections.Generic;
//!!! 10-08-2018 постановки в задачах изменили, код писался 11.02.2018, так что редактируйте, чтобы прошло тесты
namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var bigrams = FindAllBigrams(text);
            var dictionary = new Dictionary<string, string>();
            foreach (var word in bigrams)
            {
                dictionary[word.Key] = FindNextWord(word.Value);
            }
            return dictionary;
        }
        public static string FindNextWord(Dictionary<string, int> dictionary)
        {
            var maxCount = 0;
            var nextWord = "";
            foreach (var word in dictionary)
            {
                if (word.Value > maxCount)
                {
                    maxCount = word.Value;
                    nextWord = word.Key;
                }
                else if (word.Value == maxCount && string.CompareOrdinal(word.Key, nextWord) < 0)
                {
                    nextWord = word.Key;
                }
            }
            return nextWord;
        }
        public static Dictionary<string, Dictionary<string, int>> FindAllBigrams(List<List<string>> text)
        {
            var allBigrams = new Dictionary<string, Dictionary<string, int>>();
            for (var i = 0; i < text.Count; i++)
                for (var j = 0; j < text[i].Count - 1; j++)
                {
                    if (allBigrams.ContainsKey(text[i][j]))
                        if (allBigrams[text[i][j]].ContainsKey(text[i][j + 1]))
                            allBigrams[text[i][j]][text[i][j + 1]]++;
                        else
                            allBigrams[text[i][j]].Add(text[i][j + 1], 1);
                    else
                    {
                        var temp = new Dictionary<string, int>();
                        temp.Add(text[i][j + 1], 1);
                        allBigrams.Add(text[i][j], temp);
                    }
                }
            return allBigrams;
        }
    }
}