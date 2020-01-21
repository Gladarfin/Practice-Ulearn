using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_slideviews
{
    public static class ExtensionsTask
    {
        public static double Median(this IEnumerable<double> items)
        {
            var arr = items.OrderBy(item => item).ToArray();
            if (!arr.Any())
                throw new InvalidOperationException();
            var averrage = arr[arr.Length / 2];
            return (arr.Length % 2 != 0) ?
                averrage :
                (averrage + arr[arr.Length / 2 - 1]) / 2;
        }

        public static IEnumerable<Tuple<T, T>> Bigrams<T>(this IEnumerable<T> items)
        {
            T current = default(T);
            int n = 1;
            foreach (var item in items)
            {
                if (n == 1)
                {
                    current = item;
                    n = Int32.MaxValue;
                    continue;
                }
                yield return Tuple.Create(current, item);
                current = item;
            }
        }
    }
}