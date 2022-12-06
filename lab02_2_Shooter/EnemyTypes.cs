using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab02_2_Shooter
{
    public class NormalAlien : Enemy
    {
        public static Image normalAlien = Image.FromFile(@"..\..\images\alien.png");

        public NormalAlien(int spawnTime) : base(100, 5, 20, 80, 100, spawnTime, normalAlien)
        { }

        protected override bool IsHeadShot(Point click)
        {
            return click.Y - position.Y < sizeY / 2.76;
        }
    }

    public class SkinnyAlien : Enemy
    {
        public static Image skinnyAlien = Image.FromFile(@"..\..\images\skinnyAlien.png");

        public SkinnyAlien(int spawnTime) : base(250, 2, 50, 100, 100, spawnTime, skinnyAlien)
        { }

        protected override bool IsHeadShot(Point click)
        {
            return click.Y - position.Y < sizeY / 4.65;
        }
    }
}
