using System.Collections.Generic;
using System.Text;
//!!! 10-08-2018 постановки в задачах изменили, код писался 11.02.2018, так что редактируйте, чтобы прошло тесты
namespace TextAnalysis
{
    static class BigramGeneratorTask
    {
        public static string ContinuePhraseWithBigramms(
            Dictionary<string, string> mostFrequentNextWords,
            string phraseBeginning, int phraseWordsCount)
        {
            StringBuilder phrase = new StringBuilder(phraseBeginning);
            for (int i = 1; i < phraseWordsCount; i++)
            {
                if (!mostFrequentNextWords.ContainsKey(phraseBeginning))
                    break;
                phraseBeginning = mostFrequentNextWords[phraseBeginning];
                phrase.Append(" " + phraseBeginning);
            }
            return phrase.ToString();
        }
    }
}