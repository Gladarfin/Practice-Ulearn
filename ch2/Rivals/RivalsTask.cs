using System;
using System.Collections.Generic;
using System.Drawing;

namespace Rivals
{
    public class RivalsTask
    {
        public static IEnumerable<OwnedLocation> AssignOwners(Map map)
        {
            var queue = new Queue<Tuple<Point, int, int>>();
            var visited = new HashSet<Point>();

            for (int i = 0; i < map.Players.Length; i++)
                queue.Enqueue(Tuple.Create(new Point(map.Players[i].X, map.Players[i].Y), i, 0));

            while (queue.Count != 0)
            {
                var point = queue.Dequeue();
                if (PointCheck(point.Item1, map) || visited.Contains(point.Item1))
                    continue;
                visited.Add(point.Item1);

                yield return new OwnedLocation(point.Item2,
                                               new Point(point.Item1.X, point.Item1.Y), point.Item3);

                AddNearbyPoints(queue, point);
            }
        }

        private static bool PointCheck(Point newPoint, Map map)
        {
            return newPoint.X < 0 || newPoint.X >= map.Maze.GetLength(0) ||
                    newPoint.Y < 0 || newPoint.Y >= map.Maze.GetLength(1) ||
                    map.Maze[newPoint.X, newPoint.Y] == MapCell.Wall;
        }

        private static Queue<Tuple<Point, int, int>> AddNearbyPoints(
            Queue<Tuple<Point, int, int>> queue, Tuple<Point, int, int> point)
        {
            for (var dy = -1; dy <= 1; dy++)
                for (var dx = -1; dx <= 1; dx++)
                    if (dx == 0 || dy == 0)
                        queue.Enqueue(Tuple.Create(new Point
                        { X = point.Item1.X + dx, Y = point.Item1.Y + dy }, point.Item2, point.Item3 + 1));
            return queue;
        }
    }
}