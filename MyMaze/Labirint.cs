using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMaze
{
    internal class Labirint
    {
        public int height; // высота лабиринта (количество строк)
        public int width; // ширина лабиринта (количество столбцов в каждой строке)

        public int amountOfMedals;

        public MyObjects[,] maze;
        public PictureBox[,] images;

        public static Random r = new Random();
        public Form parent;
        public Labirint(Form parent, int width, int height)
        {
            this.width = width;
            this.height = height;
            this.parent = parent;

            maze = new MyObjects[height, width];
            images = new PictureBox[height, width];

            amountOfMedals = 0;

            Generate();
        }
        private void Generate()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    MyObjects.MazeObjectType current = MyObjects.MazeObjectType.HALL;

                    // в 1 случае из 5 - ставим стену
                    if (r.Next(5) == 0)
                    {
                        current = MyObjects.MazeObjectType.WALL;
                    }

                    // в 1 случае из 250 - кладём денежку
                    if (r.Next(250) == 0)
                    {
                        amountOfMedals++;
                        current = MyObjects.MazeObjectType.MEDAL;
                    }
                    if (r.Next(250) == 0)
                    {
                        current = MyObjects.MazeObjectType.HEAL;
                    }
                    // в 1 случае из 250 - размещаем врага
                    if (r.Next(250) == 0)
                    {
                        current = MyObjects.MazeObjectType.ENEMY;
                    }

                    // стены по периметру обязательны
                    if (y == 0 || x == 0 || y == height - 1 | x == width - 1)
                    {
                        current = MyObjects.MazeObjectType.WALL;
                    }

                    // наш персонажик
                    if (x == 1 && y == 2)
                    {
                        current = MyObjects.MazeObjectType.CHAR;
                    }

                    // есть выход, и соседняя ячейка справа всегда свободна
                    if (x == 2 && y == 2 || x == width - 1 && y == height - 3)
                    {
                        current = MyObjects.MazeObjectType.HALL;
                    }

                    maze[y, x] = new MyObjects(current);
                    images[y, x] = new PictureBox();
                    images[y, x].Location = new Point(x * maze[y, x].width, y * maze[y, x].height);
                    images[y, x].Parent = parent;
                    images[y, x].Width = maze[y, x].width;
                    images[y, x].Height = maze[y, x].height;
                    images[y, x].BackgroundImage = maze[y, x].texture;
                    images[y, x].Visible = false;
                }
            }
        }
        public void Show()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    images[y, x].Visible = true;
                }
            }
        }
    }
}
