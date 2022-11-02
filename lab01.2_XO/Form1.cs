using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//ctrl + '.' + enter = rename

namespace lab01d2_XO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Button[,] buttons;
        int n = 3;
        //int player = 1;
        bool isPlayerX = true; 

        private void button1_Click(object sender, EventArgs e)
        {
            if (buttons == null)
            {
                buttons = new Button[n, n];
                int size = pictureBox1.Width / 3;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Button button = new Button();
                        button.Parent = pictureBox1;
                        button.Size = new Size(size, size);
                        button.Location = new Point(j * size, i * size);
                        button.Font = new Font("Arial", 30);
                        button.Click += Button_Click;

                        buttons[i, j] = button;
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        buttons[i, j].Enabled = true;
                        buttons[i, j].Text = "";
                    }
                }
                isPlayerX = true;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (isPlayerX)
            {
                button.Text = "X";
                button.Enabled = false;
            }
            else
            {
                button.Text = "O";
                button.Enabled = false;
            }
            if (CheckGameWon())
            {
                int player = isPlayerX ? 1 : 2;
                //echivalent cu:
                //int player;
                //if (isPlayerX)
                //    player = 1;
                //else
                //    player = 2;

                MessageBox.Show($"Player {player} has won", "Game Won!");
            }
            else if(CheckGameLost())
            {
                MessageBox.Show("Remiza", "Game Over!");
            }
            isPlayerX = !isPlayerX;
        }

        bool CheckGameLost()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (buttons[i, j].Enabled)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        bool CheckGameWon()
        {
            int sumaX, sumaY;
            for (int i = 0; i < n; i++)
            {
                //verificare pe linii
                sumaX = 0;
                sumaY = 0;
                for (int j = 0; j < n; j++)
                {
                    if (buttons[i, j].Text == "X")
                    {
                        sumaX++;
                    }
                    else if (buttons[i, j].Text == "O")
                    {
                        sumaY++;
                    }
                }
                if (sumaX == 3 || sumaY == 3)
                    return true;

                //verificare pe coloane
                sumaX = 0; sumaY = 0;
                for (int j = 0; j < n; j++)
                {
                    if (buttons[j, i].Text == "X")
                    {
                        sumaX++;
                    }
                    else if (buttons[j, i].Text == "O")
                    {
                        sumaY++;
                    }
                }
                if (sumaX == 3 || sumaY == 3)
                    return true;
            }
            //verificare diagonale
            //dp
            sumaX = 0; sumaY = 0;
            for (int i = 0; i < n; i++)
            {
                if (buttons[i, i].Text == "X")
                    sumaX++;
                else if (buttons[i, i].Text == "O")
                    sumaY++;
            }
            if (sumaX == 3 || sumaY == 3)
                return true;
            //ds
            sumaX = 0; sumaY = 0;
            for (int i = 0; i < n; i++)
            {
                if (buttons[i, n - i -1].Text == "X")
                    sumaX++;
                else if (buttons[i, n - i - 1].Text == "O")
                    sumaY++;
            }
            if (sumaX == 3 || sumaY == 3)
                return true;
            return false;
        }
    }
}
