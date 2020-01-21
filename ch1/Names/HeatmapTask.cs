using System;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var heat = new double[30, 12];
            var xLabels = HeatmapLabels(31, 1);
            var yLabels = HeatmapLabels(12, 0);
            foreach (var person in names)
                if (person.BirthDate.Day != 1)
                {
                    heat[person.BirthDate.Day - 2, person.BirthDate.Month - 1]++;
                }
            return new HeatmapData("Карта интенсивностей", heat, xLabels, yLabels);
        }

        public static string[] HeatmapLabels(int count, int space)
        {
            var label = new string[count - space];
            for (var i = space; i < count; i++)
            {
                label[i - space] = (i + 1).ToString();
            }
            return label;
        }
    }
}