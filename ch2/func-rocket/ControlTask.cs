using System;

namespace func_rocket
{
    public class ControlTask
    {
        public static Turn ControlRocket(Rocket rocket, Vector target)
        {
            Vector vectorToTarget = target - rocket.Location;
            return (((rocket.Velocity.Angle + rocket.Direction) / 2 > vectorToTarget.Angle) ||
                (rocket.Velocity.Angle - rocket.Direction < -1)) ?
                Turn.Left : Turn.Right;
        }
    }
}