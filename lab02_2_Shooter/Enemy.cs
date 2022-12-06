using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace lab02_2_Shooter
{
    public abstract class Enemy
    {
        public double health, speed, damage, sizeX, sizeY, positionX;
        public int spawnTime;
        public Point position;
        public Image image;

        public Enemy(double health, double speed, double damage, double sizeX, double sizeY, int spawnTime, Image image)
        {
            this.health = health;
            this.speed = speed;
            this.damage = damage;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.spawnTime = spawnTime;
            this.image = image;
            position = Engine.GetRandomPoint((int)sizeX, (int)sizeY);
            positionX = position.X;

        }

        protected abstract bool IsHeadShot(Point click);

        public virtual void Move()
        {
            position.Y += (int)speed;
            sizeX += speed / 16;
            sizeY += speed / 8;
            positionX -= speed / 32;
            position.X = (int)positionX;
        }

        public void Draw()
        {
            Engine.graphics.DrawImage(image, position.X, position.Y, (int)sizeX, (int)sizeY);
        }

        public void GetShot(Point click)
        {
            if (click.X > position.X && click.X < position.X + sizeX && click.Y > position.Y && click.Y < position.Y + sizeY)
            {
                /*int x = click.X - position.X;
                int y = click.Y - position.Y;
                Bitmap bitmap = new Bitmap(Engine.form.alien);
                if (bitmap.GetPixel(x, y).ToKnownColor() == KnownColor.Transparent)
                    return;
                health -= 20;
                Engine.graphics.DrawString("20", new Font("Arial", 12), new SolidBrush(Color.White), click.X, click.Y - 20);
                Engine.form.pictureBox1.Image = Engine.bitmap;*/
                if (click.X > position.X && click.X < position.X + sizeX
                    && click.Y > position.Y && click.Y < position.Y + sizeY)
                {
                    if (Engine.IsPixelTransparent(click, this))
                        return;

                    if (IsHeadShot(click))
                    {
                        health -= 50;
                        Engine.graphics.DrawString("50", new Font("Arial", 12, FontStyle.Bold),
                            new SolidBrush(Color.Red), click.X, click.Y - 20);
                    }
                    else
                    {
                        health -= 20;
                        Engine.graphics.DrawString("20", new Font("Arial", 12, FontStyle.Bold),
                            new SolidBrush(Color.White), click.X, click.Y - 20);
                    }
                    Engine.form.pictureBox1.Image = Engine.bitmap;
                }
            }
        }
    }
}
