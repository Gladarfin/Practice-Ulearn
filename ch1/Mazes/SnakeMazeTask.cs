namespace Mazes
{
    public static class SnakeMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            int countHeight = 1;
            int stepsCount = width - 3;
            int rightDirection = (int)Direction.Right;
            while (!robot.Finished)
            {
                if (countHeight % 2 == 0)
                {
                    rightDirection = (int)Direction.Left;
                }
                else
                {
                    rightDirection = (int)Direction.Right;
                }
                Move(robot, stepsCount, rightDirection);
                countHeight++;
            }
        }

        public static void Move(Robot robot, int count, int direction)
        {
            for (int i = 0; i < count; i++)
            {
                robot.MoveTo((Direction)direction);
            }
            if (!robot.Finished)
            {
                robot.MoveTo(Direction.Down);
                robot.MoveTo(Direction.Down);
            }
        }
    }
}