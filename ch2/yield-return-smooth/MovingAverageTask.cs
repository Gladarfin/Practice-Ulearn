using System;
using System.Collections.Generic;

namespace yield
{
    public static class MovingAverageTask
    {
        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
        {
            Queue<double> elementsQueue = new Queue<double>();
            double sum = 0.0;
            foreach (var elem in data)
            {
                sum += elem.OriginalY;
                elementsQueue.Enqueue(elem.OriginalY);
                if (elementsQueue.Count > windowWidth)
                    sum -= elementsQueue.Dequeue();
                elem.AvgSmoothedY = sum / Math.Min(elementsQueue.Count, windowWidth);
                yield return elem;
            }
        }
    }
}