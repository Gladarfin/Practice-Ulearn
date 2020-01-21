using System.Collections.Generic;

namespace yield
{
    public static class ExpSmoothingTask
    {
        public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
        {
            var firstElement = true;
            double previousElement = 0;
            foreach (var element in data)
            {
                if (firstElement)
                {
                    previousElement = element.OriginalY;
                    firstElement = false;
                }
                element.ExpSmoothedY = alpha * element.OriginalY + (1 - alpha) * previousElement;
                previousElement = element.ExpSmoothedY;
                yield return element;
            }
        }
    }
}