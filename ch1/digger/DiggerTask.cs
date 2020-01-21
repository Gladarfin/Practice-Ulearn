using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
//Практика «Монстры» не реализована

namespace Digger
{
    //Напишите здесь классы Player, Terrain и другие.
    class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand { };
        }
        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }
        public int GetDrawingPriority()
        {
            return 15;
        }
        public string GetImageFileName()
        {
            return "Terrain.png";
        }
    }

    class Player : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            var pressedButton = Game.KeyPressed;
            int deltaX = 0;
            int deltaY = 0;
            if (pressedButton == Keys.Up && y >= 1)
                deltaY = -1;
            else if (pressedButton == Keys.Down && y < Game.MapHeight - 1)
                deltaY = 1;
            else if (pressedButton == Keys.Right && x < Game.MapWidth - 1)
                deltaX = 1;
            else if (pressedButton == Keys.Left && x >= 1)
                deltaX = -1;
            if (!(Game.Map[x + deltaX, y + deltaY] is Sack))
            {
                return new CreatureCommand { DeltaX = deltaX, DeltaY = deltaY };
            }
            else
                return new CreatureCommand { };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Sack;
        }
        public int GetDrawingPriority()
        {
            return 7;
        }
        public string GetImageFileName()
        {
            return "Digger.png";
        }
    }

    class Gold : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }
        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Player)
                Game.Scores += 10;
            return true;
        }
        public int GetDrawingPriority()
        {
            return 10;
        }

        public string GetImageFileName()
        {
            return "Gold.png";
        }
    }

    class Sack : ICreature
    {
        int countSackFall = 0;
        public CreatureCommand Act(int x, int y)
        {
            if (y != Game.MapHeight - 1)
            {
                if (Game.Map[x, y + 1] == null || (countSackFall > 0 && Game.Map[x, y + 1] is Player))
                {
                    countSackFall++;
                    return new CreatureCommand { DeltaX = 0, DeltaY = 1 };
                }
                else if (Game.Map[x, y + 1] is Terrain && countSackFall < 2)
                {
                    countSackFall = 0;
                    return new CreatureCommand { };
                }
            }
            if (countSackFall > 1)
                return new CreatureCommand { DeltaX = 0, DeltaY = 0, TransformTo = new Gold() };
            else
                return new CreatureCommand { };
        }
        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }
        public int GetDrawingPriority()
        {
            return 0;
        }
        public string GetImageFileName()
        {
            return "Sack.png";
        }
    }
}