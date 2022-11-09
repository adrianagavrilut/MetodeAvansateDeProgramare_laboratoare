using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab02_2_Shooter
{
    public static class Engine
    {
        public static Form1 form;
        public static Random rnd = new Random();
        public static int horizon = 150, wave = 1;
        public static double fortHealth = 100, time = 0;
        public static Graphics graphics;
        public static Bitmap bitmap;
        public static List<Enemy> enemies = new List<Enemy>(), currentWave = new List<Enemy>();
        public static List<List<Enemy>> waves = new List<List<Enemy>>();

        public static void Init(Form1 f1)
        {
            form = f1;
            bitmap = new Bitmap(form.Width, form.Height);
            graphics = Graphics.FromImage(bitmap);
            var wave1 = new List<Enemy>();
            wave1.Add(new Enemy(50, 10, 20, 70, 70, 0));
            wave1.Add(new Enemy(60, 5, 20, 100, 100, 20));
            wave1.Add(new Enemy(60, 10, 20, 50, 50, 35));
            wave1.Add(new Enemy(30, 10, 20, 70, 70, 45));
            wave1.Add(new Enemy(100, 10, 20, 100, 100, 55));
            wave1.Add(new Enemy(60, 10, 20, 70, 70, 20));
            wave1.Add(new Enemy(70, 10, 20, 100, 100, 0));


            var wave2 = new List<Enemy>();
            wave2.Add(new Enemy(50, 10, 20, 70, 70, 0));
            wave2.Add(new Enemy(60, 10, 20, 100, 100, 10));
            wave2.Add(new Enemy(60, 10, 20, 50, 50, 17));
            wave2.Add(new Enemy(30, 10, 20, 70, 70, 10));
            wave2.Add(new Enemy(100, 10, 20, 100, 100, 22));
            wave2.Add(new Enemy(60, 10, 20, 70, 70, 27));
            wave2.Add(new Enemy(70, 5, 20, 100, 100, 10));
            wave2.Add(new Enemy(100, 7, 20, 100, 100, 42));
            wave2.Add(new Enemy(60, 8, 20, 70, 70, 27));
            wave2.Add(new Enemy(70, 5, 20, 100, 100, 10));

            waves.Add(wave1);
            waves.Add(wave2);
            currentWave = wave1;
        }

        public static void Tick()
        {
            time++;
            form.TimeLabel.Text = $"{time / 10}.s";
            //you win
            if (currentWave.Count == 0 && enemies.Count == 0)
            {
                if (wave < waves.Count)
                {
                    NextWave();
                }
                else
                {
                    Win();
                }
            }
            if (currentWave.Count> 0 && currentWave[0].spawnTime <= time)
            {
                enemies.Add(currentWave[0]);
                currentWave.RemoveAt(0);
            }
            MoveEnemies();
            CheckIfYouLose();
            UpdateDisplay();
        }

        public static void Shoot(Point click)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].GetShot(click);
                if(enemies[i].health <= 0)
                {
                    enemies.Remove(enemies[i]);
                    i--;
                }
            }
        }

        private static void NextWave()
        {
            wave++;
            currentWave = waves[wave - 1];
            time = 0;
            form.labelWave.Text = $"Wave {wave}";
        }

        public static void UpdateDisplay()
        {
            graphics.DrawImage(form.background, 0, 0, form.Width, form.Height);
            enemies.Sort((e1, e2) => e1.position.Y - e2.position.Y);
            foreach (Enemy enemy in enemies)
            {
                graphics.DrawImage(form.alien, enemy.position.X, enemy.position.Y, (int)enemy.sizeX, (int)enemy.sizeY);
            }
            form.pictureBox1.Image = bitmap;
        }

        public static void Win()
        {
            form.timer1.Enabled = false;
            form.backgroundSound.Stop();
            MessageBox.Show("You defeated all the enemies!", "You Win!");
            form.Close();
        }

        public static void MoveEnemies()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy enemy = enemies[i];
                enemy.Move();
                if (enemy.position.Y >= form.Height)
                {
                    fortHealth -= enemy.damage;
                    form.labelHealth.Text = $"Health {fortHealth}";
                    enemies.Remove(enemies[i]);
                    i--;
                }
            }
        }

        private static void CheckIfYouLose()
        {
            if (fortHealth <= 0)
            {
                form.timer1.Enabled = false;
                MessageBox.Show("Your fort walls were destroyed!", "You lose!");
                form.Close();
            }
        }

        public static Point GetRandomPoint(int sizeX, int sizeY)
        {
            return new Point(rnd.Next(form.Width - sizeX), horizon - sizeY);
        }
    }
}
