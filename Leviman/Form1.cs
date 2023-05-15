using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leviman
{
    public partial class Form1 : Form
    {
        bool goup, godown, goleft, goright, isGameOver;

        int score, playerSpeed, skullOneSpeed, skullTwoSpeed, skullTwoX, skullTwoY, skullThreeX, skullThreeY, skullThreeSpeed, skullFourSpeed;

        public Form1()
        {
            InitializeComponent();

            resetGame();
        }

        private void Cskull1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                goup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if(e.KeyCode == Keys.Enter && isGameOver == true)
            {
                resetGame();
            }
        }

        private void manGameTimer(object sender, EventArgs e)
        {
            txtScore.Text = "Score" + score;

            if(goleft == true)
            {
                leviTheBarbarian.Left -= playerSpeed;
                leviTheBarbarian.Image = Properties.Resources.BarbLeft;
            }
            if (goright == true)
            {
                leviTheBarbarian.Left += playerSpeed;
                leviTheBarbarian.Image = Properties.Resources.BarbRight;
            }
            if (godown == true)
            {
                leviTheBarbarian.Top += playerSpeed;
                leviTheBarbarian.Image = Properties.Resources.BarbDown;
            }
            if (goup == true)
            {
                leviTheBarbarian.Top -= playerSpeed;
                leviTheBarbarian.Image = Properties.Resources.BarbUp;
            }

            //leaving from one side of the screen to the other one. Defining boundaries left to right

            if (leviTheBarbarian.Left < -10)
            {
                leviTheBarbarian.Left = 880;
            }
            if (leviTheBarbarian.Left > 880)
            {
                leviTheBarbarian.Left = 10;
            }

            //top and bottom

            if (leviTheBarbarian.Top < -10)
            {
                leviTheBarbarian.Top = 550;
            }
            if (leviTheBarbarian.Top > 550)
            {
                leviTheBarbarian.Top = 0;
            }

            //For SkullTwo
            if (skullTwo.Left < -10)
            {
                skullTwo.Left = 880;
            }
            if (skullTwo.Left > 880)
            {
                skullTwo.Left = 10;
            }

            //top and bottom

            if (skullTwo.Top < -10)
            {
                skullTwo.Top = 550;
            }
            if (skullTwo.Top > 550)
            {
                skullTwo.Top = 0;
            }
            //For SkullThree
            if (skullThree.Left < -10)
            {
                skullThree.Left = 880;
            }
            if (skullThree.Left > 880)
            {
                skullThree.Left = 10;
            }

            //top and bottom

            if (skullThree.Top < -10)
            {
                skullThree.Top = 550;
            }
            if (skullThree.Top > 550)
            {
                skullThree.Top = 0;
            }
            //identifying the "coins" treasure

            foreach (Control x in this.Controls)
            {
                if(x is PictureBox)
                {

                    if ((string)x.Tag == "Coin" && x.Visible == true)   //player interacting with treasure
                    {
                        if (leviTheBarbarian.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;   //makes the treasure dissappear. next step is to set the score increments
                            x.Visible = false;
                        }//wouldn't be too hard to create another type of treasure worth different amounts of points

                    }

                    if ((string)x.Tag == "Wall") //the walls!
                    {
                        if (leviTheBarbarian.Bounds.IntersectsWith(x.Bounds))
                        {
                            //game over losing condition
                            gameOver("You died!");
                        }

                        if(skullTwo.Bounds.IntersectsWith(x.Bounds))
                        {
                            skullTwoX = -skullTwoX;
                        }
                        if (skullThree.Bounds.IntersectsWith(x.Bounds))
                        {
                            skullThreeX = -skullThreeX;
                        }
                    }

                    if ((string)x.Tag == "Skull")//the skulls!
                        if (leviTheBarbarian.Bounds.IntersectsWith(x.Bounds))
                        {
                            //another lose condition
                            gameOver("You died!");
                        }  
                }
            }
            //making the skulls move! One and Four are left to right
            skullOne.Left += skullOneSpeed;

            if (skullOne.Bounds.IntersectsWith(wallBox1.Bounds) || skullOne.Bounds.IntersectsWith(wallBox2.Bounds ))
            {
                skullOneSpeed = -skullOneSpeed;
            }
            skullFour.Left += skullFourSpeed;

            if (skullFour.Bounds.IntersectsWith(wallBox5.Bounds) || skullFour.Bounds.IntersectsWith(wallBox6.Bounds))
            {
                skullFourSpeed = -skullFourSpeed;
            }
            //Skull 2 and 3 are more advanced

            skullTwo.Left -= skullTwoX;
            skullTwo.Top -= skullTwoY;

            if(skullTwo.Top < 0 || skullTwo.Top > 520)
            {
                skullTwoY = -skullTwoY;
            }
            if (skullTwo.Left < 0 || skullTwo.Left > 620)
            {
                skullTwoY = -skullTwoY;
            }

            skullThree.Left -= skullThreeX;
            skullThree.Top -= skullThreeY;

            if (skullThree.Top < 0 || skullFour.Top > 520)
            {
                skullThreeY = -skullThreeY;
            }
            if (skullThree.Left < 0 || skullThree.Left > 620)
            {
                skullThreeY = -skullThreeY;
            }


            if (score == 48)
            {
                // game over win condition time
                gameOver("You Win!");
            }
        }

        private void resetGame()
        {
            txtScore.Text = "Score: 0";
            score = 0;

            skullOneSpeed = 5;
            skullTwoSpeed = 5;
            skullThreeSpeed = 5;
            skullFourSpeed = 5;
            playerSpeed = 8;

            skullTwoX = 5;
            skullTwoY = 5;
            skullThreeY = 5;
            skullThreeX = 5;

            isGameOver = false;

            leviTheBarbarian.Left = 29;
            leviTheBarbarian.Top = 69;

            skullOne.Left = 439;
            skullOne.Top = 49;

            skullTwo.Left = 800;
            skullTwo.Top = 12;

            skullThree.Left = 424;
            skullThree.Top = 510;

            skullFour.Left = 666;
            skullFour.Top = 478;


            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    x.Visible = true; //if not true then any image visibility checked to false will be invisible

                }


            }


            GameTimer.Start();
        }

        private void gameOver(string message)
        {

            isGameOver = true;

            GameTimer.Stop();

            txtScore.Text = "Score: " + score + Environment.NewLine + message;
        }
    }
}
