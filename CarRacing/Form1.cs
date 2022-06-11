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
                    if ((MyCar.Top - 370) > 0)
                    {
                        MyCar.Top -= 12;
                    }
                    break;
                case Keys.Down:
                    if ((MyCar.Bottom + 10) < (this.Height - MyCar.Height))
                    {
                        MyCar.Top += 12;
                    }
                    break;
                case Keys.Right:
                    if ((MyCar.Left + 10) < (this.Width - MyCar.Width))
                    {
                        MyCar.Left += 12;
                    }
                    break;
                case Keys.Left:
                    if ((MyCar.Left - 10) > 0)
                    {
                        MyCar.Left -= 12;
                    }
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
                gameTimer.Stop();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // untuk mengatur agar picturebox transparent nya pada picturebox lain 
            // sehingga warna backgroundnya warna dari parent nya
            cloud1.Parent = backgroundImage;
            cloud2.Parent = backgroundImage;
            cloud3.Parent = backgroundImage;
        }
    }
}