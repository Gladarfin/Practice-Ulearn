using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {
        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            var result = new double[width, height];
            var shift = sx.GetLength(0) / 2;
            var sy = TransposeMatrix(sx);

            for (int x = shift; x < width - shift; x++)
                for (int y = shift; y < height - shift; y++)
                {
                    var gx = MultiplyPixelsByMatrix(g, sx, x, y, shift);
                    var gy = MultiplyPixelsByMatrix(g, sy, x, y, shift);
                    result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            return result;
        }

        public static double[,] TransposeMatrix(double[,] matrix)
        {
            var transposedMatrix = new double[matrix.GetLength(0), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    transposedMatrix[i, j] = matrix[j, i];
                }
            return transposedMatrix;
        }

        public static double MultiplyPixelsByMatrix(double[,] pixels, double[,] matrix,
                                                    int x, int y, int shift)
        {
            double multiplyResult = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    multiplyResult += matrix[i, j] * pixels[x - shift + i, y - shift + j];
                }
            return multiplyResult;
        }
    }
}