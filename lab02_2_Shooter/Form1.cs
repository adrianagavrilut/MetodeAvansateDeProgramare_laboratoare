using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab02_2_Shooter
{
    public partial class Form1 : Form
    {
        public Image background = Image.FromFile(@"..\..\images\background.jpg");
        public Image alien = Image.FromFile(@"..\..\images\alien.png");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;
            TimeLabel.Parent = labelWave.Parent = labelHealth.Parent = pictureBox1;
            Engine.Init(this);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                timer1.Enabled = false;
                var option = MessageBox.Show("Are you sure you want to exit this game? Your progress will be lost", "Exit Game", MessageBoxButtons.OKCancel);
                if (option == DialogResult.OK)
                {
                    Close();
                }
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {/*
            foreach (Enemy enemy in Engine.enemies)
            {
                enemy.Move();
            }
            Engine.UpdateDisplay();*/
            Engine.Tick();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Engine.Shoot(e.Location);
        }
    }
}
