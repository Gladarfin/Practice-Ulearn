using System.Collections.Generic;
using System.Drawing;

namespace Dungeon
{
    public class BfsTask
    {
        public static IEnumerable<SinglyLinkedList<Point>> FindPaths(Map map, Point start, Point[] chests)
        {
            var allChests = new HashSet<Point>(chests);
            var visited = new HashSet<Point>();
            var queue = new Queue<SinglyLinkedList<Point>>();
            queue.Enqueue(new SinglyLinkedList<Point>(start));

            while (queue.Count != 0)
            {
                var point = queue.Dequeue();
                if (PointCheck(point, map) || visited.Contains(point.Value))
                    continue;
                visited.Add(point.Value);

                if (allChests.Contains(point.Value))
                {
                    yield return point;
                    allChests.Remove(point.Value);
                    if (allChests.Count == 0) break;
                }
                AddNearbyPoints(queue, point);
            }
        }

        private static bool PointCheck(SinglyLinkedList<Point> newPoint, Map map)
        {
            return newPoint.Value.X < 0 || newPoint.Value.X >= map.Dungeon.GetLength(0) ||
                    newPoint.Value.Y < 0 || newPoint.Value.Y >= map.Dungeon.GetLength(1) ||
                    map.Dungeon[newPoint.Value.X, newPoint.Value.Y] == MapCell.Wall;
        }

        private static Queue<SinglyLinkedList<Point>> AddNearbyPoints
            (Queue<SinglyLinkedList<Point>> queue, SinglyLinkedList<Point> point)
        {
            //вместо двух циклов лучше использовать Walker.PossibleDirections
            for (var dy = -1; dy <= 1; dy++)
                for (var dx = -1; dx <= 1; dx++)
                    if (dx == 0 || dy == 0)
                        queue.Enqueue(new SinglyLinkedList<Point>
                            (new Point { X = point.Value.X + dx, Y = point.Value.Y + dy }, point));
            return queue;
        }
    }
}