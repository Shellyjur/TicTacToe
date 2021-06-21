using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameUI
{
    public partial class GameSettings : Form
    {
        public GameSettings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (player2CB.Checked)
            {
                player2NameTB.Enabled = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void nUDRows_ValueChanged(object sender, EventArgs e)
        {
            nUDCols.Value = (sender as NumericUpDown).Value;
        }

        private void nUDCols_ValueChanged(object sender, EventArgs e)
        {
            nUDRows.Value = (sender as NumericUpDown).Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (player2CB.Checked)
            {
                player2NameTB.Enabled = true;
            }
            else
            {
                player2NameTB.Enabled = false;
                player2NameTB.Text = "[Computer]";
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Board boardGame;

            if (player2CB.Checked)
            {
                boardGame = new Board((int) nUDRows.Value, player1NameTB.Text, player2NameTB.Text);
            }
            else
            {
                boardGame = new Board((int) nUDRows.Value, player2NameTB.Text, "Computer");
            }

            this.Hide();
            boardGame.ShowDialog();
            this.Close();
        }

    }
}
