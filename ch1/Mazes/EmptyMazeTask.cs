namespace Mazes
{
	public static class EmptyMazeTask
	{
        public static void MoveOut(Robot robot, int width, int height)
        {
            int moveCount = 0;
            while (!robot.Finished)
            {
                moveCount++;
                if (moveCount < width - 2)
                    robot.MoveTo(Direction.Right);
                else
                    robot.MoveTo(Direction.Down);
            }
        }
    }
}