using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double segmentAC = DistanceBetweenPoints(ax, ay, x, y);
            double segmentCB = DistanceBetweenPoints(bx, by, x, y);
            double segmentAB = DistanceBetweenPoints(ax, ay, bx, by);
            double scalarCompositionABC = (x - ax) * (bx - ax) + (y - ay) * (by - ay);
            double scalarCompositionBCA = (x - bx) * (-bx + ax) + (y - by) * (-by + ay);
            if (segmentAB == 0)
            {
                return segmentAC;
            }
            else if (scalarCompositionABC >= 0 && scalarCompositionBCA >= 0)
            {
                double p = (segmentAC + segmentCB + segmentAB) / 2.0;
                double s = Math.Sqrt(Math.Abs((p * (p - segmentAC) * (p - segmentCB) * (p - segmentAB))));
                return (2.0 * s) / segmentAB;
            }
            else
            {
                return Math.Min(segmentAC, segmentCB);
            }
        }

        public static double DistanceBetweenPoints(double a, double b, double c, double d)
        {
            double segment = Math.Sqrt((c - a) * (c - a) + (d - b) * (d - b));
            return segment;
        }
    }
}