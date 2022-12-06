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
        public SoundPlayer backgroundSound = new SoundPlayer(@"..\..\sounds\Thriller.wav");
        public Image gun = Image.FromFile(@"..\..\images\gun.png");
        //public Image backgroundMenu = Image.FromFile(@"..\..\images\menu_background.jpg");
        //public Image target = Image.FromFile(@"..\..\images\target.png");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = MenuScreen.Width = StatusBar.Width = this.Width;
            pictureBox1.Height = this.Height - StatusBar.Height;
            MenuScreen.Height = this.Height;

            TimeLabel.Parent = WaveLabel.Parent = HealthBar.Parent = StatusBar; ;
            pictureBoxGun.Parent = pictureBox1;
            HealthLabel.Parent = HealthBar;

            StartButton.Parent = ExitButton.Parent = MenuScreen;
            StartButton.Left = ExitButton.Left = this.Width / 2 - 3 * StartButton.Width / 8;
            StartButton.Top = this.Height - StartButton.Height * 3;
            ExitButton.Top = this.Height- StartButton.Height * 2;
            
            /*Cursor cur = Cursors.WaitCursor;
            this.Cursor = cur;
            this.Cursor = new Cursor(Application.StartupPath + @"..\..\images\target.png");
            this.Cursor = Cursor.Current;
            Cursor.Position = new Point(Cursor.Position.X - 150, Cursor.Position.Y - 150);
            Cursor.Show();
            pictureBox1.Cursor = new Cursor(@"..\..\images\target.png");*/
            
            this.Cursor = Cursors.Cross;
            Engine.Init(this);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                timer1.Enabled = false;
                Engine.BlurBackground();
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

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            MenuScreen.Enabled = false;
            MenuScreen.Visible = false;
            backgroundSound.PlayLooping();
        }
    }
}
