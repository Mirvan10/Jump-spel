using System;
using System.Windows.Forms;

namespace Jump_spel
{
    public partial class form1 : Form
    {

        bool goleft, goright, jumping, isGameOver;
       

        int JumpSpeed;
        int Force;
        int Score = 0;
        int PlayerSpeed = 7;

        int HorizontalSpeed = 5;
        int VerticalSpeed = 3;

        int enemyOneSpeed = 5;
        int enemyTwoSpeed = 3;
      

        public form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }   

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + Score;

            Player.Top += JumpSpeed;  
            if (goleft == true)
            {
                Player.Left -= PlayerSpeed;
            }
            if (goright == true)
            {
                Player.Left -= PlayerSpeed;
            }
            if (jumping == true && Force < 0)
            {
                jumping = false;

            }
            if (jumping == true)
            {
                JumpSpeed = -8;
                Force -= 1;
            }
            else
            {
                JumpSpeed = 10;
            }
            foreach (Control x in this.Controls)
            {



                if (x is PictureBox)
                {
                    if ((string)x.Tag == "platform")
                    {
                        if (Player.Bounds.IntersectsWith(x.Bounds))
                        {
                            Force = 8;
                            Player.Top = x.Top - Player.Height;

                            if ((string)x.Name == "horizontalPlatform" && goleft == false || (string)x.Name == "horizontalPlatform" && goright == false)
                            {
                                Player.Left -= HorizontalSpeed;
                            }


                        }
                        x.BringToFront();

                    }

                    if ((string)x.Tag == "coin")
                    {
                        if (Player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            Score++;
                        }
                    }
                    if ((string)x.Tag == "enemy")
                    {
                        if (Player.Bounds.IntersectsWith(x.Bounds))
                        {
                            GameTimer.Stop();
                            isGameOver = true;
                            txtScore.Text = "Score: " + Score + Environment.NewLine + "You were killed in your journey!!";
                        }
                    }

                }
            }

            HorizontalPlatform.Left -= HorizontalSpeed;

            if (HorizontalPlatform.Left < 0 || HorizontalPlatform.Left + HorizontalPlatform.Width > this.ClientSize.Width)
            {
                HorizontalSpeed = -HorizontalSpeed;
            }

            VerticalPlatform.Top += VerticalSpeed;

            if (VerticalPlatform.Top < 195 || VerticalPlatform.Top > 581)
            {
                VerticalSpeed = -VerticalSpeed;
            }


            enemyOne.Left -= enemyOneSpeed;

            if (enemyOne.Left < pictureBox5.Left || enemyOne.Left + enemyOne.Width > pictureBox5.Left + pictureBox5.Width)
            {
                enemyOneSpeed = -enemyOneSpeed;
            }

            enemyTwo.Left += enemyTwoSpeed;

            if (enemyTwo.Left < pictureBox2.Left || enemyTwo.Left + enemyTwo.Width > pictureBox2.Left + pictureBox2.Width)
            {
                enemyTwoSpeed = -enemyTwoSpeed;
            }


            if (Player.Top + Player.Height > this.ClientSize.Height + 50)
            {
                GameTimer.Stop();
                isGameOver = true;
                txtScore.Text = "Score: " + Score + Environment.NewLine + "You fell to your death!";
            }

            if (Player.Bounds.IntersectsWith(Door.Bounds) && Score == 26)
            {
                GameTimer.Stop();
                isGameOver = true;
                txtScore.Text = "Score: " + Score + Environment.NewLine + "Your quest is complete!";
            }
            else
            {
                txtScore.Text = "Score: " + Score + Environment.NewLine + "Collect all the coins";
            }





        }



        private void enemyTwo_Click(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;

            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;

            }
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;

                    

            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                goleft = false;

            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;

            }
            if (jumping == true)
            {
                jumping = false;

            }

            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                RestartGame();
            }



        }
        private void RestartGame()
        {


            jumping = false;
            goleft = false;
            goright = false;
            isGameOver = false;
            Score = 0;

            txtScore.Text = "Score; " + Score;


            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }



            // 

            Player.Left = 0;
            Player.Top = 532;

            enemyOne.Left = 413;
            enemyTwo.Top = 351;

            HorizontalPlatform.Left = 235;
            VerticalPlatform.Top = 426;

            GameTimer.Start();






        }
    }
}
