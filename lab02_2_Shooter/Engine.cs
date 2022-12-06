using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        public static Graphics graphics, healthBarGraphics;
        public static Bitmap bitmap, healthBarBitmap;
        public static List<Enemy> enemies = new List<Enemy>(), currentWave = new List<Enemy>();
        public static List<List<Enemy>> waves = new List<List<Enemy>>();
        public static int horizon = 150, wave = 1;
        public static double fortHealth = 100, time = 0;

        public static void Init(Form1 f1)
        {
            form = f1;
            bitmap = new Bitmap(form.Width, form.Height);
            graphics = Graphics.FromImage(bitmap);

            healthBarBitmap = new Bitmap(form.HealthBar.Width, form.HealthBar.Height);
            healthBarGraphics = Graphics.FromImage(healthBarBitmap);
            DrawGradient();

            var wave1 = new List<Enemy>();
            wave1.Add(new NormalAlien(0));
            wave1.Add(new NormalAlien(20));
            wave1.Add(new NormalAlien(35));
            wave1.Add(new NormalAlien(45));
            wave1.Add(new NormalAlien(55));


            var wave2 = new List<Enemy>();
            wave2.Add(new NormalAlien(0));
            wave2.Add(new NormalAlien(10));
            wave2.Add(new NormalAlien(17));
            wave2.Add(new NormalAlien(10));
            wave2.Add(new NormalAlien(22));
            wave2.Add(new SkinnyAlien(27));
            wave2.Add(new SkinnyAlien(37));
            wave2.Add(new SkinnyAlien(42));
            wave2.Add(new SkinnyAlien(52));

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
            if (currentWave.Any() && currentWave[0].spawnTime <= time)
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
            form.WaveLabel.Text = $"Wave {wave}";
        }

        public static void UpdateDisplay()
        {
            graphics.DrawImage(form.background, 0, 0, form.Width, form.pictureBox1.Height);
            enemies.Sort((e1, e2) => e1.position.Y - e2.position.Y);
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw();
            }
            form.pictureBox1.Image = bitmap;
        }

        public static void BlurBackground()
        {
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.Black)), 
                0, 0, form.Width, form.Height);
            form.pictureBox1.Image = bitmap;
        }

        private static void DrawGradient()
        {
            // calculam procentul de viata ramasa ce trebuie afisat
            float width = form.HealthBar.Width * (float)(fortHealth / 100);
            // aceste brush-uri sunt necesare pentru a avea gradient
            var redYellowBrush = new LinearGradientBrush(
                new RectangleF(0, 0, form.HealthBar.Width / 2, form.HealthBar.Height),
                Color.Red, Color.Yellow, 0f);
            var yellowGreenBrush = new LinearGradientBrush(
                new RectangleF(-1, 0, form.HealthBar.Width / 2, form.HealthBar.Height),
                Color.Yellow, Color.Green, 0f);

            // desenam intai gradientul de la rosu la verde
            healthBarGraphics.FillRectangle(redYellowBrush,
                0, 0, form.HealthBar.Width / 2, form.HealthBar.Height);
            healthBarGraphics.FillRectangle(yellowGreenBrush,
                form.HealthBar.Width / 2, 0, form.HealthBar.Width / 2, form.HealthBar.Height);
            // apoi ascundem cu o culoare gri inchis procentul de viata pierduta, si inconjuram cu un chenar de culoare gri mai deschis
            // acestea vor da efectul unui recipient care se goleste pe masura ce pierdem viata
            healthBarGraphics.FillRectangle(new SolidBrush(Color.FromArgb(130, 130, 130)),
                width, 0, form.HealthBar.Width, form.HealthBar.Height);
            healthBarGraphics.DrawRectangle(new Pen(Color.DarkGray, 6),
                0, 0, form.HealthBar.Width, form.HealthBar.Height);

            form.HealthBar.Image = healthBarBitmap;
        }

        public static bool IsPixelTransparent(Point click, Enemy enemy)
        {
            int x = click.X - enemy.position.X;
            int y = click.Y - enemy.position.Y;
            Bitmap zombie = new Bitmap((int)enemy.sizeX, (int)enemy.sizeY);
            Graphics grp = Graphics.FromImage(zombie);
            grp.DrawImage(enemy.image, 0, 0, (int)enemy.sizeX, (int)enemy.sizeY);
            return zombie.GetPixel(x, y).ToArgb() == 0;
        }

        public static void MoveEnemies()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy enemy = enemies[i];
                enemy.Move();
                if (enemy.position.Y >= form.pictureBox1.Height)
                {
                    fortHealth -= enemy.damage;
                    DrawGradient();
                    form.HealthLabel.Text = $" {fortHealth}/100";
                    enemies.Remove(enemies[i]);
                    i--;
                }
            }
        }

        public static void Win()
        {
            form.timer1.Enabled = false;
            form.backgroundSound.Stop();
            MessageBox.Show("You defeated all the enemies!", "You Win!");
            form.Close();
        }

        private static void CheckIfYouLose()
        {
            if (fortHealth <= 0)
            {
                form.timer1.Enabled = false;
                form.backgroundSound.Stop();
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
