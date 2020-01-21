using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Autocomplete
{
    internal class AutocompleteTask
    {
        /// <returns>
        /// Возвращает первую фразу словаря, начинающуюся с prefix.
        /// </returns>
        /// <remarks>
        /// Эта функция уже реализована, она заработает, 
        /// как только вы выполните задачу в файле LeftBorderTask
        /// </remarks>
        public static string FindFirstByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            if (index < phrases.Count && phrases[index].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return phrases[index];
            else
                return null;
        }
        /// <returns>
        /// Возвращает первые в лексикографическом порядке count (или меньше, если их меньше count) 
        /// элементов словаря, начинающихся с prefix.
        /// </returns>
        /// <remarks>Эта функция должна работать за O(log(n) + count)</remarks>
        public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
        {
            var start = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            var words = new List<string>();
            int numbers = GetCountByPrefix(phrases, prefix); //вызов этого метода == нарушение условия на сложность, переписать
            if (numbers == 0)
                return new string[0];
            if (count > numbers)
                count = numbers;
            for (int i = 0; i < count; i++)
                words.Add(phrases[start + i]);
            return words.ToArray();
        }
        /// <returns>
        /// Возвращает количество фраз, начинающихся с заданного префикса
        /// </returns>
        public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var right = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrases.Count);
            var left = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count);
            if (right - left - 1 < 0)
                return 0;
            else
                return (right - left - 1);
        }
    }

    [TestFixture]
    public class AutocompleteTests
    {
        [Test]
        public void TopByPrefix_IsEmpty_WhenNoPhrases()
        {
            var topWords = AutocompleteTask.GetTopByPrefix(new List<string> { }, "a", 1);
            CollectionAssert.IsEmpty(topWords);
        }
        // ...
        [Test]
        public void CountByPrefix_IsTotalCount_WhenEmptyPrefix()
        {
            var topWords = AutocompleteTask.GetTopByPrefix(new List<string> { "a", "b" }, "", 1);
            Assert.AreEqual(topWords, 0);
        }
        // ...
    }
}