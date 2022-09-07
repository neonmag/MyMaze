using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMaze
{
    internal class MyObjects
    {
        public enum MazeObjectType { HALL, WALL, MEDAL, ENEMY, CHAR, HEAL };

        public Bitmap[] images = {new Bitmap(@"C:\Forms\MyMaze\MyMaze\bin\Debug\net6.0-windows\pics\hall.png"),
            new Bitmap(@"C:\Forms\MyMaze\MyMaze\bin\Debug\net6.0-windows\pics\wall.png"),
            new Bitmap(@"C:\Forms\MyMaze\MyMaze\bin\Debug\net6.0-windows\pics\medal.png"),
            new Bitmap(@"C:\Forms\MyMaze\MyMaze\bin\Debug\net6.0-windows\pics\enemy.png"),
            new Bitmap(@"C:\Forms\MyMaze\MyMaze\bin\Debug\net6.0-windows\pics\player.png"),
            new Bitmap(@"C:\Forms\MyMaze\MyMaze\bin\Debug\net6.0-windows\pics\aidkit.png")};

        public MazeObjectType type;
        public int width;
        public int height;
        public Image texture;

        public MyObjects(MazeObjectType type)
        {
            this.type = type;
            width = 16;
            height = 16;
            texture = images[(int)type];
        }
    }
}
