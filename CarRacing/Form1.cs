namespace CarRacing
{
    public partial class Form1 : Form
    {
        int pipeSpeed1 = 4;
        int pipeSpeed2 = 8;
        int pipeSpeed3 = 1;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    up.Image = Properties.Resources.up1;
                    if ((MyCar.Top - 370) > 0)
                    {
                        MyCar.Top -= 12;
                    }
                    break;
                case Keys.Down:
                    down.Image = Properties.Resources.down1;
                    if ((MyCar.Bottom + 10) < (this.Height - MyCar.Height))
                    {
                        MyCar.Top += 12;
                    }
                    break;
                case Keys.Right:
                    right.Image = Properties.Resources.right1;
                    if ((MyCar.Left + 10) < (this.Width - MyCar.Width))
                    {
                        MyCar.Left += 12;
                    }
                    break;
                case Keys.Left:
                    left.Image = Properties.Resources.left1;
                    if ((MyCar.Left - 10) > 0)
                    {
                        MyCar.Left -= 12;
                    }
                    break;
                case Keys.R:
                    StartGame();
                    break;
                case Keys.E:
                    Environment.Exit(0);
                    break;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    up.Image = Properties.Resources.up2;
                    break;
                case Keys.Down:
                    down.Image = Properties.Resources.down2;
                    break;
                case Keys.Right:
                    right.Image = Properties.Resources.right2;
                    break;
                case Keys.Left:
                    left.Image = Properties.Resources.left2;
                    break;
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            car1.Left -= pipeSpeed1;
            car2.Left -= pipeSpeed1;
            car3.Left -= pipeSpeed1;
            car4.Left -= pipeSpeed2;
            cloud1.Left -= pipeSpeed3;
            cloud2.Left -= pipeSpeed3;
            cloud3.Left -= pipeSpeed3;

            labelScore.Text = "Score : " + score.ToString();

            if (car1.Left < -150)
            {
                car1.Left = 820;
                score++;
            }

            if (car2.Left < -450)
            {
                car2.Left = 1000;
                score++;
            }

            if (car3.Left < -500)
            {
                car3.Left = 1140;
                score++;
            }

            if (car4.Left < -1000)
            {
                car4.Left = 10000;
                score++;
            }

            if (cloud1.Left < -100)
            {
               cloud1.Left = 910;
            }

            if (cloud2.Left < -200)
            {
                cloud2.Left = 940;
            }

            if (cloud3.Left < -300)
            {
                cloud3.Left = 970;
            }

            if (MyCar.Bounds.IntersectsWith(car1.Bounds) || MyCar.Bounds.IntersectsWith(car2.Bounds)
                || MyCar.Bounds.IntersectsWith(car3.Bounds) || MyCar.Bounds.IntersectsWith(car4.Bounds))
            {
                EndGame();
            }

            if (score > 50)
            {
                pipeSpeed1 = 6;
                pipeSpeed2 = 10;
            } else if (score > 30)
            {
                pipeSpeed1 = 5;
                pipeSpeed2 = 9;
            }
        }

        private void EndGame()
        {
            labelScore.Text = "Score : " + score.ToString() + " Game Over !!!";
            gameTimer.Stop();
            pipeSpeed1 = 4;
            pipeSpeed2 = 8;
            pipeSpeed3 = 1;
            score = 0;
        }

        private void StartGame()
        {
            gameTimer.Start();
            MyCar.Location = new Point(17,368);
            car1.Location = new Point(507, 366);
            car2.Location = new Point(812,414);
            car3.Location = new Point(1059,366);
            car4.Location = new Point(1275,408);
            cloud1.Location = new Point(547,23);
            cloud2.Location = new Point(843,60);
            cloud3.Location = new Point(245,68);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // untuk mengatur agar picturebox transparent nya pada picturebox lain 
            // sehingga warna backgroundnya warna dari parent nya
            cloud1.Parent = backgroundImage;
            cloud2.Parent = backgroundImage;
            cloud3.Parent = backgroundImage;
            up.Parent = backgroundImage;
            down.Parent = backgroundImage;
            circle.Parent = backgroundImage;
            right.Parent = backgroundImage;
            left.Parent = backgroundImage;
            ket.Parent = backgroundImage;
        }
    }
}