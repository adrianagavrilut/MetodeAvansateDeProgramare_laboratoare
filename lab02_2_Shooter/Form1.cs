using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace lab02_2_Shooter
{
    public partial class Form1 : Form
    {
        public Image background = Image.FromFile(@"..\..\images\background.jpg");
        public Image alien = Image.FromFile(@"..\..\images\alien.png");
        public SoundPlayer backgroundSound = new SoundPlayer(@"..\..\sounds\Thriller.wav");
        public Image gun = Image.FromFile(@"..\..\images\gun.png");
        //public Image target = Image.FromFile(@"..\..\images\target.png");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;
            TimeLabel.Parent = labelWave.Parent = labelHealth.Parent = pictureBox1;
            pictureBoxGun.Parent = pictureBox1;
            backgroundSound.Play();
            /*Cursor cur = Cursors.WaitCursor;
            this.Cursor = cur;
            this.Cursor = new Cursor(Application.StartupPath + @"..\..\images\target.png");
            this.Cursor = Cursor.Current;
            Cursor.Position = new Point(Cursor.Position.X - 150, Cursor.Position.Y - 150);
            Cursor.Show();*/
            //pictureBox1.Cursor = new Cursor(@"..\..\images\target.png");
            this.Cursor = Cursors.Cross;
            Engine.Init(this);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                timer1.Enabled = false;
                Engine.form.backgroundSound.PlayLooping();
                var option = MessageBox.Show("Are you sure you want to exit this game? Your progress will be lost", "Exit Game", MessageBoxButtons.OKCancel);
                if (option == DialogResult.OK)
                {
                    Close();
                }
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Engine.Tick();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxGun.Location = new Point(e.Location.X, e.Location.Y + 20);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Engine.Shoot(e.Location);
        }
    }
}
