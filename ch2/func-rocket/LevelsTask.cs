using System;
using System.Collections.Generic;
using System.Drawing;

namespace func_rocket
{
    public class LevelsTask
    {
        static readonly Physics standardPhysics = new Physics();
        static readonly Rocket rocket = new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI);
        static readonly Vector target = new Vector(600, 200);
        static readonly Vector anomaly = new Vector(400, 350);

        public static Vector GravityIsUp(Size size, Vector v)
        {
            return new Vector(0, -300 / (size.Height - v.Y + 300));
        }

        public static Vector WhiteHoleGravity(Size size, Vector v)
        {
            var distance = (v - target).Length;
            return (v - target).Normalize() * 140 * distance / (distance * distance + 1);
        }

        public static Vector BlackHoleGravity(Size size, Vector v)
        {
            var distance = (v - anomaly).Length;
            return (anomaly - v).Normalize() * 300 * distance / (distance * distance + 1);
        }

        public static Vector BlackAndWhiteGravity(Size size, Vector v)
        {
            return (BlackHoleGravity(size, v) + WhiteHoleGravity(size, v)) / 2;
        }

        public static IEnumerable<Level> CreateLevels()
        {
            yield return new Level("Zero", rocket, target, (size, v) => Vector.Zero, standardPhysics);
            yield return new Level("Heavy", rocket, target, (size, v) => new Vector(0, 0.9), standardPhysics);
            yield return new Level("Up", rocket, new Vector(700, 500), GravityIsUp, standardPhysics);
            yield return new Level("WhiteHole", rocket, target, WhiteHoleGravity, standardPhysics);
            yield return new Level("BlackHole", rocket, target, BlackHoleGravity, standardPhysics);
            yield return new Level("BlackAndWhite", rocket, target, BlackAndWhiteGravity, standardPhysics);
        }
    }
}