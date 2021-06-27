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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (player2CB.Checked)
            {
                player2NameTB.Enabled = true;
            }
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
                player2NameTB.Text = string.Empty;
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
                boardGame = new Board((int)nUDRows.Value, player1NameTB.Text, player2NameTB.Text, "humanVsHuman");
            }
            else
            {
                boardGame = new Board((int)nUDRows.Value, player1NameTB.Text, "Computer", "humanvsComputer");
            }

            this.Hide();
            boardGame.ShowDialog();
            this.Close();
        }
    }
}
