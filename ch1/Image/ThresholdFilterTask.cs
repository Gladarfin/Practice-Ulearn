using System;
using System.Collections.Generic;

namespace Recognizer
{
    public static class ThresholdFilterTask
    {
        public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
        {
            var pixels = new List<double>();
            foreach (var e in original)
                pixels.Add(e);
            pixels.Sort();
            var fraction = ChangePixelToWhite(pixels, whitePixelsFraction);
            for (var x = 0; x < original.GetLength(0); x++)
                for (var y = 0; y < original.GetLength(1); y++)
                {
                    if (original[x, y] >= fraction)
                        original[x, y] = 1;
                    else
                        original[x, y] = 0;
                }
            return original;
        }

        public static double ChangePixelToWhite(List<double> pixels, double whitePixels)
        {
            whitePixels = (int)(whitePixels * pixels.Count);
            if (whitePixels > 0 && whitePixels <= pixels.Count)
            {
                whitePixels = pixels[(int)(pixels.Count - whitePixels)];
            }
            else
            {
                whitePixels = int.MaxValue;
            }
            return whitePixels;
        }
    }
}