using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MyMaze
{
    public partial class Form1 : Form
    {
        Character character = new Character();
        public int lastPositionX;
        public int lastPositionY;
        Labirint labirint;
        public Form1()
        {
            InitializeComponent();
            Options();
            StartGame();
        }
        public void Options()
        {
            Text = "Maze";

            BackColor = Color.FromArgb(255, 92, 118, 137);

            int sizeX = 40;
            int sizeY = 20;

            Width = sizeX * 16 + 16;
            Height = sizeY * 16 + 40;
            StartPosition = FormStartPosition.CenterScreen;
        }

        public void StartGame()
        {
            labirint = new Labirint(this, 40, 20);
            labirint.Show();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Movement(e);
            character.amountOfSteps++;
            ChangeStats();
            UpdateToolStrip();
            Changing();
            CheckWin();
        }
        // Movement
        public void Movement(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                if (character.positionInY + 1 < 20 && labirint.maze[character.positionInY + 1, character.positionInX].texture != labirint.maze[character.positionInY + 1, character.positionInX].images[1])
                {
                    lastPositionY = character.positionInY;
                    lastPositionX = character.positionInX;
                    character.positionInY++;
                }
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                if (character.positionInY - 1 > 0 && labirint.maze[character.positionInY - 1, character.positionInX].texture != labirint.maze[character.positionInY - 1, character.positionInX].images[1])
                {
                    lastPositionY = character.positionInY;
                    lastPositionX = character.positionInX;
                    character.positionInY--;
                }
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                if (character.positionInX - 1 > 0 && labirint.maze[character.positionInY, character.positionInX - 1].texture != labirint.maze[character.positionInY, character.positionInX - 1].images[1])
                {
                    lastPositionX = character.positionInX;
                    lastPositionY = character.positionInY;
                    character.positionInX--;
                }
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                if (character.positionInX + 1 < 40 && labirint.maze[character.positionInY, character.positionInX + 1].texture != labirint.maze[character.positionInY, character.positionInX + 1].images[1])
                {
                    lastPositionX = character.positionInX;
                    lastPositionY = character.positionInY;
                    character.positionInX++;
                }
            }

        }
        // Change character stats
        public void ChangeStats()
        {
            if (labirint.maze[character.positionInY, character.positionInX].texture == labirint.maze[character.positionInY, character.positionInX].images[2])
            {
                character.amountOfMedals++;
            }
            else if (labirint.maze[character.positionInY, character.positionInX].texture == labirint.maze[character.positionInY, character.positionInX].images[3])
            {
                character.health -= 25;
            }
            else if (labirint.maze[character.positionInY, character.positionInX].texture == labirint.maze[character.positionInY, character.positionInX].images[5])
            {
                character.health += 5;
            }
        }
        // Check on win/lose
        public void CheckWin()
        {
            if (character.positionInX == labirint.width - 1 && character.positionInY == labirint.height - 3 || character.amountOfMedals == labirint.amountOfMedals)
            {
                MessageBox.Show("You win!");
                this.Close();
            }
            else if (character.health <= 0)
            {
                MessageBox.Show("You lose!");
                this.Close();
            }
        }
        public void Changing()
        {
            // Change last position
            labirint.maze[lastPositionY, lastPositionX] = new MyObjects(MyObjects.MazeObjectType.HALL);
            labirint.images[lastPositionY, lastPositionX].BackgroundImage = labirint.maze[lastPositionY, lastPositionX].texture;
            labirint.images[lastPositionY, lastPositionX].Location = new Point(lastPositionX * labirint.maze[lastPositionY, lastPositionX].width,
                lastPositionY * labirint.maze[lastPositionY, lastPositionX].height);
            labirint.images[lastPositionY, lastPositionX].Parent = labirint.parent;
            labirint.images[lastPositionY, lastPositionX].Width = labirint.maze[lastPositionY, lastPositionX].width;
            labirint.images[lastPositionY, lastPositionX].Height = labirint.maze[lastPositionY, lastPositionX].height;
            // Change current position
            labirint.maze[character.positionInY, character.positionInX] = new MyObjects(MyObjects.MazeObjectType.CHAR);
            labirint.images[character.positionInY, character.positionInX].BackgroundImage = labirint.maze[character.positionInY, character.positionInX].texture;
            labirint.images[character.positionInY, character.positionInX].Location = new Point(character.positionInX * labirint.maze[character.positionInY, character.positionInX].width,
                character.positionInY * labirint.maze[character.positionInY, character.positionInX].height);
            labirint.images[character.positionInY, character.positionInX].Parent = labirint.parent;
            labirint.images[character.positionInY, character.positionInX].Width = labirint.maze[character.positionInY, character.positionInX].width;
            labirint.images[character.positionInY, character.positionInX].Height = labirint.maze[character.positionInY, character.positionInX].height;
        }
        // Updating toolstrip
        public void UpdateToolStrip()
        {
            this.toolStripLabel1.Text = $"Amount of steps: {character.amountOfSteps}";
            this.toolStripLabel2.Text = $"Amount of medals: {character.amountOfMedals}";
            this.toolStripLabel3.Text = $"X: {character.positionInX}";
            this.toolStripLabel4.Text = $"X: {character.positionInY}";
            this.toolStripLabel5.Text = $"Health: {character.health}";
        }
    }
}