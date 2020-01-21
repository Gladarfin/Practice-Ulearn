using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var days = new string[31];
            var sum = new double[31];
            for (int i = 0; i < 31; i++)
            {
                days[i] = (i + 1).ToString();
            }
            foreach (var day in names)
                if (day.BirthDate.Day != 1 && day.Name == name)
                {
                    sum[day.BirthDate.Day - 1]++;
                }
            return new HistogramData(string.Format("Рождаемость людей с именем '{0}'", name), days, sum);
        }
    }
}