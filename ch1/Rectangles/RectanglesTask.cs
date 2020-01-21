using System;

namespace Rectangles
{
    public static class RectanglesTask
    {
        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            bool intersectedLeftRight = IntersectRect(r1.Left, r2.Left, r1.Right, r2.Right);
            bool intersectedTopBottom = IntersectRect(r1.Top, r2.Top, r1.Bottom, r2.Bottom);
            return (intersectedLeftRight && intersectedTopBottom);
        }
        public static bool IntersectRect(int recA, int recB, int recC, int recD)
        {
            return Math.Max(recA, recB) <= Math.Min(recC, recD);
        }
        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            int xIntersection = 0;
            int yIntersection = 0;
            if (AreIntersected(r1, r2))
            {
                xIntersection = GetIntersectionLength(r1.Left, r1.Right, r2.Left, r2.Right);
                yIntersection = GetIntersectionLength(r1.Top, r1.Bottom, r2.Top, r2.Bottom);
            }
            return xIntersection * yIntersection;
        }
        public static int GetIntersectionLength(int recX, int recY, int recW, int rectH)
        {
            int left = Math.Max(recX, recW);
            int right = Math.Min(recY, rectH);
            return right - left;
        }
        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            if (RectangleInside(r1, r2))
            {
                return 0;
            }
            else if (RectangleInside(r2, r1))
            {
                return 1;
            }
            return -1;
        }
        public static bool RectangleInside(Rectangle r1, Rectangle r2)
        {
            if ((r1.Left >= r2.Left) && (r1.Top >= r2.Top) && (r1.Right <= r2.Right) && (r1.Bottom <= r2.Bottom))
            {
                return true;
            }
            return false;
        }
    }
}