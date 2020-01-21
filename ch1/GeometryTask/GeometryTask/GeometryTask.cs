using System;

namespace GeometryTasks
{
    public class Vector
    {
        public double X;
        public double Y;

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public Vector Add(Vector vector)
        {
            return Geometry.Add(this, vector);
        }

        public bool Belongs(Segment segment)
        {
            return Geometry.IsVectorInSegment(this, segment);
        }
    }

    public class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }
        public static Vector Add(Vector vectorA, Vector vectorB)
        {
            Vector vectorSum = new Vector();
            vectorSum.X = vectorA.X + vectorB.X;
            vectorSum.Y = vectorA.Y + vectorB.Y;
            return vectorSum;
        }
        public static double GetLength(Segment segment)
        {
            var segmentLength = Math.Sqrt((segment.End.X - segment.Begin.X) *
                                          (segment.End.X - segment.Begin.X) +
                                          (segment.End.Y - segment.Begin.Y) *
                                          (segment.End.Y - segment.Begin.Y));
            return segmentLength;
        }

        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {

            var condition = Math.Abs(GetLength(new Segment { Begin = segment.Begin, End = vector }) +
                                     GetLength(new Segment { Begin = segment.End, End = vector }) -
                                     GetLength(segment));
            if (condition < 1.0e-8)
            {
                return true;
            }
            else
                return false;
        }
    }

    public class Segment
    {
        public Vector Begin;
        public Vector End;

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public bool Contains(Vector vector)
        {
            return Geometry.IsVectorInSegment(vector, this);
        }
    }
}