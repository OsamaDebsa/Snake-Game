using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class ScrSnake : Form
    {
        Random R;
        enum Screen
        {
            Free,
            Snake,
            Bouns,
            Trap

        };
        enum directions
        {
            up,
            down,
            left,
            right
        };
      

        struct snakeDimensional
        {
            public int x;
            public int y;
        }

        Screen[,] Screens;
        snakeDimensional[] snakeXY;
        int snakeLength;
        directions direction;
        Graphics g;

        public ScrSnake()
        {
            InitializeComponent();
            Screens = new Screen[11, 11];
            snakeXY = new snakeDimensional[100];
            R = new Random();
        }

        private void ScrSnake_Load(object sender, EventArgs e)
        {
            PickGameBoard.Image = new Bitmap(420, 420);
            g=Graphics.FromImage(PickGameBoard.Image);
            g.Clear(Color.White);

            // Initial wall :
            // top & down 
            for (int i = 0; i < 11; i++)
            {
                g.DrawImage(ImageList.Images[12],  0, i * 35);
                g.DrawImage(ImageList.Images[12], 385, i * 35);
            }

            // right & left
            for (int i = 0; i < 12; i++)
            {
                g.DrawImage(ImageList.Images[12], i * 35, 0);
                g.DrawImage(ImageList.Images[12], i * 35, 385);
            }

            

            // initial Snake Body & Head :
            snakeXY[0].x = 5;   // this for Head (5,5).
            snakeXY[0].y = 5;
            snakeXY[1].x = 5;   // this for Body P1 (5,6).
            snakeXY[1].y = 6;
            snakeXY[2].x = 5;   // this for Body P2 (5,7).
            snakeXY[2].y = 7;

            g.DrawImage(ImageList.Images[10], 5 * 35, 5 * 35); // Head
            g.DrawImage(ImageList.Images[11], 5 * 35, 6 * 35); // body P1
            g.DrawImage(ImageList.Images[11], 5 * 35, 7 * 35); // body P2
            Screens[5, 5] = Screen.Snake;
            Screens[5, 6] = Screen.Snake;
            Screens[5, 7] = Screen.Snake;

            // initial
            direction = directions.up;
            snakeLength = 3;

            // Bouns and trap :
            for (int i = 0; i < 2; i++)
            {
                Bouns();
                if (i==1)
                {
                    Trap();
                }
            }

        }
        private void Bouns()
        {
            int x, y;
            var imgIndex = R.Next(0,7);

            do
            {
                x = R.Next(1, 10);
                y = R.Next(1, 10);
            } while (Screens[x,y]!= Screen.Free);


            Screens[x,y]=Screen.Bouns;
            g.DrawImage(ImageList.Images[imgIndex], x * 35, y * 35);


        }
        private void Trap()
        {

            int x, y;
            var imgIndex = R.Next(7, 10); 
            do
            {
                x = R.Next(1, 10);
                y = R.Next(1, 10);
            } while (Screens[x, y] != Screen.Free);


            Screens[x, y] = Screen.Trap;
            g.DrawImage(ImageList.Images[imgIndex], x * 35, y * 35);


        }




        private void snake_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    direction=directions.up;
                    break;
                case Keys.Down:
                    direction=directions.down;
                    break;
                case Keys.Left:
                    direction=directions.left;
                    break;
                case Keys.Right:
                    direction=directions.right;
                    break;
        
            }
        }

        private void GameOver()
        {
            timer.Enabled=false;
            MessageBox.Show("GAME OVER !");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // delete the end of the snake 
            g.FillRectangle(Brushes.White, snakeXY[snakeLength - 1].x * 35,
                 snakeXY[snakeLength - 1].y * 35, 35, 35);

            Screens[snakeXY[snakeLength - 1].x, snakeXY[snakeLength - 1].y] = Screen.Free;

            // move snake field on the position of the previous one
            for (int i = snakeLength; i >= 1; i--)
            {
                snakeXY[i].x = snakeXY[i - 1].x;
                snakeXY[i].y = snakeXY[i - 1].y;
            }
            g.DrawImage(ImageList.Images[11], snakeXY[0].x * 35, snakeXY[0].y * 35);


            // change direction of Head
            switch (direction)
            {
                case directions.up:
                    snakeXY[0].y -= 1;
                    break;
                case directions.down:
                    snakeXY[0].y += 1;

                    break;
                case directions.left:

                    snakeXY[0].x -= 1;
                    break;
                case directions.right:
                    snakeXY[0].x += 1;

                    break;

            }

            // cheack if the snake hit the wall
            if (snakeXY[0].x < 1 || snakeXY[0].x > 10 || snakeXY[0].y < 1 || snakeXY[0].y > 10)
            {
                GameOver();
                PickGameBoard.Refresh();
                return;
            }
            //cheack if the snake hits body
            if (Screens[snakeXY[0].x, snakeXY[0].y]== Screen.Snake)
            {
                GameOver();
                PickGameBoard.Refresh();
                return;

            }
            if (Screens[snakeXY[0].x, snakeXY[0].y] == Screen.Trap)
            {
                GameOver();
                PickGameBoard.Refresh();
                return;

            }
            // cheack if the snake eat the bouns
            if (Screens[snakeXY[0].x, snakeXY[0].y] == Screen.Bouns)
            {
                g.DrawImage(ImageList.Images[11], snakeXY[snakeLength].x * 35,
                    snakeXY[snakeLength].y * 35);
                Screens[snakeXY[snakeLength].x, snakeXY[snakeLength].y] = Screen.Snake;
                snakeLength++;
                 if(snakeLength <80)
                    Bouns();
                this.Text = "Snake Score = " + snakeLength;

            }
            //drwa the head
            g.DrawImage(ImageList.Images[10], snakeXY[0].x * 35,
                               snakeXY[0].y * 35);
            Screens[snakeXY[0].x, snakeXY[0].y] = Screen.Snake;
            PickGameBoard.Refresh();

        }
    }
}
