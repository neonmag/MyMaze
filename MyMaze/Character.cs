using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMaze
{
    internal class Character
    {
        public int health;
        public int amountOfMedals;
        public int positionInX;
        public int positionInY;
        public int amountOfSteps;
        public Character()
        {
            positionInX = 1;
            positionInY = 2;
            health = 100;
            amountOfMedals = 0;
            amountOfSteps = 0;
        }
    }
}
