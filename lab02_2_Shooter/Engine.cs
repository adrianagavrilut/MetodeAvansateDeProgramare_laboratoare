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
        public static int horizon = 150;
        public static double fortHealth = 100, time = 0;
        public static Graphics graphics;
        public static Bitmap bitmap;
        public static List<Enemy> enemies = new List<Enemy>();
        public static List<Enemy> wave = new List<Enemy>();

        public static void Init(Form1 f1)
        {
            form = f1;
            wave.Add(new Enemy(50, 10, 20, 70, 70, 0));
            wave.Add(new Enemy(60, 10, 20, 100, 100, 20));
            wave.Add(new Enemy(60, 10, 20, 50, 50, 35));
            wave.Add(new Enemy(30, 10, 20, 70, 70, 45));
            wave.Add(new Enemy(100, 10, 20, 100, 100, 55));
            wave.Add(new Enemy(60, 10, 20, 70, 70, 20));
            wave.Add(new Enemy(70, 10, 20, 100, 100, 0));
            bitmap = new Bitmap(form.Width, form.Height);
            graphics = Graphics.FromImage(bitmap);
        }

        public static void Tick()
        {
            time++;
            //form.TimeLabel.Text = time.ToString();
            form.TimeLabel.Text = $"{time / 10}.s";
            if (wave.Count> 0 && wave[0].spawnTime <= time)
            {
                enemies.Add(wave[0]);
                wave.RemoveAt(0);
            }

            for (int i = 0; i< enemies.Count; i ++)
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
            if (fortHealth <= 0)
            {
                form.timer1.Enabled = false;
                MessageBox.Show("Your fort walls were destroyed!", "You lose!");
                form.Close();
            }
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
            //you win
            if (wave.Count == 0 && enemies.Count == 0)
            {
                form.timer1.Enabled = false;
                MessageBox.Show("You defeated all the enemies!", "You Win!");
                form.Close();
            }
        }

        public static void UpdateDisplay()
        {
            //graphics.Clear(Color.PaleGoldenrod);
            graphics.DrawImage(form.background, 0, 0, form.Width, form.Height);
            foreach (Enemy enemy in enemies)
            {
                graphics.DrawImage(form.alien, enemy.position.X, enemy.position.Y, (int)enemy.sizeX, (int)enemy.sizeY);
                //graphics.FillRectangle(new SolidBrush(Color.Firebrick), enemy.position.X, enemy.position.Y, (int)enemy.size, (int)enemy.size);
            }
            form.pictureBox1.Image = bitmap;
        }

        public static Point GetRandomPoint(int sizeX, int sizeY)
        {
            return new Point(rnd.Next(form.Width - sizeX), horizon - sizeY);
        }
    }
}
