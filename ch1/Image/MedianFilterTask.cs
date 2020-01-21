using System.Collections.Generic;

namespace Recognizer
{
    internal static class MedianFilterTask
    {
        public static double[,] MedianFilter(double[,] original)
        {
            var width = original.GetLength(0);
            var height = original.GetLength(1);
            var changed = new double[width, height];
            var filterAmbitX = 0;
            var filterAmbitY = 0;
            var limitX = 0;
            var limitY = 0;
            for (var x = 0; x < width; x++)
                for (var y = 0; y < height; y++)
                {
                    AmbitPoint(x, width, out filterAmbitX, out limitX);
                    AmbitPoint(y, height, out filterAmbitY, out limitY);
                    changed[x, y] = GetMedianValue(original, x, y, filterAmbitX,
                                                   filterAmbitY, limitX, limitY);

                }
            return changed;
        }
        public static double GetMedianValue(double[,] original, int x, int y,
                                            int ambitX, int ambitY, int limX, int limY)
        {
            var brightnesses = new List<double>();
            for (int i = ambitX; i <= limX; i++)
                for (int j = ambitY; j <= limY; j++)
                {
                    brightnesses.Add(original[x + i, y + j]);
                }
            brightnesses.Sort();
            return GetMedianValue(brightnesses);
        }

        public static double GetMedianValue(List<double> bright)
        {
            double medianValue = bright[bright.Count / 2];
            if (bright.Count % 2 == 0)
            {
                medianValue = (bright[bright.Count / 2] + bright[(bright.Count / 2) - 1]) / 2;
            }
            return medianValue;
        }

        public static void AmbitPoint(int coord, int w, out int x, out int lim)
        {
            x = coord - 1 >= 0 ? -1 : 0;
            lim = coord + 1 < w ? 1 : 0;
        }
    }
}