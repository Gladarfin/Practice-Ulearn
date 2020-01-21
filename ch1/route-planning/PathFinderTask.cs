using System;
using System.Drawing;

namespace RoutePlanning
{
    public static class PathFinderTask
    {
        public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
        {
            double minLenght = double.PositiveInfinity;
            var pathLength = new double[checkpoints.Length];
            var bestOrder = new int[checkpoints.Length];

            MakePermutation(checkpoints, new int[checkpoints.Length], 1,
                            ref minLenght, bestOrder, pathLength);
            return bestOrder;
        }

        public static int[] GetMinLength(int[] permutation, ref double minLength,
                                       int[] result, int position, double[] length)
        {
            if (position == permutation.Length)
                if (minLength > length[position - 1])
                {
                    minLength = length[position - 1];
                    for (int i = 0; i < permutation.Length; i++)
                        result[i] = permutation[i];
                }
            return result;
        }

        public static void MakePermutation(Point[] checkpoints, int[] permutation, int position,
                                           ref double minLength, int[] result, double[] length)
        {

            result = GetMinLength(permutation, ref minLength, result, position, length);
            for (int i = 1; i < permutation.Length; i++)
            {
                var index = Array.IndexOf(permutation, i, 0, position);
                if (index == -1)
                {
                    length[position] = length[position - 1] +
                        checkpoints[permutation[position - 1]].DistanceTo(checkpoints[i]);
                    if (length[position] < minLength)
                    {
                        permutation[position] = i;
                        MakePermutation(checkpoints, permutation, position + 1,
                                        ref minLength, result, length);
                    }
                }
            }
            return;
        }
    }
}