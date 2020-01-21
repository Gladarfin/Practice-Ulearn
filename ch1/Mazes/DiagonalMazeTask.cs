namespace Mazes
{
    public static class DiagonalMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            int ratioHeightWidth = (height - 2) / (width - 2);
            int rightDirection = (int)Direction.Down;
            int diagonalStep = (int)Direction.Right;
            if (width > height)
            {
                ratioHeightWidth = (width - 2) / (height - 2);
                rightDirection = (int)Direction.Right;
                diagonalStep = (int)Direction.Down;
            }
            while (!robot.Finished)
            {
                MoveDirection(robot, ratioHeightWidth, rightDirection);
                if (!robot.Finished)
                {
                    robot.MoveTo((Direction)diagonalStep);
                }
            }
        }
        public static void MoveDirection(Robot robot, int ratio, int rightDirection)
        {
            for (int i = 0; i < ratio; i++)
            {
                robot.MoveTo((Direction)rightDirection);
            }
        }
    }
}