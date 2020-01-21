using System.Drawing;
using System;

namespace Fractals
{
    internal static class DragonFractalTask
    {
        public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
        {
            var x = 1.0;
            var y = 0.0;
            double[] result = new double[2];
            var random = new Random(seed);
            for (int i = 0; i < iterationsCount; i++)
            {
                var nextRandom = random.Next(10);
                if (nextRandom % 2 > 0)
                {
                    result = NewPixel(x, y, 45);
                    x = result[0];
                }
                else
                {
                    result = NewPixel(x, y, 135);
                    x = result[0] + 1;
                }
                y = result[1];
                pixels.SetPixel(x, y);
            }
        }
        public static double[] NewPixel(double x, double y, int degree)
        {
            var x1 = (x * Math.Cos(Math.PI * degree / 180) - y * Math.Sin(Math.PI * degree / 180)) / Math.Sqrt(2);
            var y1 = (x * Math.Sin(Math.PI * degree / 180) + y * Math.Cos(Math.PI * degree / 180)) / Math.Sqrt(2);
            return new[] { x1, y1 };
        }
    }
}