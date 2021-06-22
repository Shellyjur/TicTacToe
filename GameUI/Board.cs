using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TicTacToe;

namespace GameUI
{
    public partial class Board : Form
    {
        private BoardGame m_BoardGame;
        //private privetPlayer m_Player1;
        private Player m_Player1;
        private Player m_Player2;

        public Board()
        {
            InitializeComponent();
        }

        public Board(int i_BoardSize, string i_Player1Id, string i_Player2Id)
        {
            InitializeComponent();
            m_BoardGame = new BoardGame(i_BoardSize);
            m_Player1 = new Player(i_Player1Id, i_BoardSize);
            m_Player2 = new Player(i_Player2Id, i_BoardSize);

        } 

        private void Board_Load(object sender, EventArgs e)
        {
        
           
            for (int i = 1 ; i <= m_BoardGame.Size ; i++)
            {
                for(int j = 1 ; j <= m_BoardGame.Size; j++)
                {
                    flowLayoutPanel1.Controls.Add(CreateCells(i, j));
                    
                }
            }
            player1L.Text = m_Player1.Id + ": " + m_Player1.Score;
            player2L.Text = m_Player2.Id + ": " + m_Player2.Score;
        }

        public Button CreateCells(int i , int j)
        {
            Button cell = new Button();
            cell.Name = i.ToString() + j.ToString();
            cell.Width = ((flowLayoutPanel1.Width-50) / (m_BoardGame.Size));
            cell.Height = ((flowLayoutPanel1.Height-50) / (m_BoardGame.Size));
            //cell.Width = 50;
            //cell.Height = 50;
            //cell.Top = j * flowLayoutPanel1.Height;
            //cell.Left = i * flowLayoutPanel1.Width;
            //cell.Height = 90;
            cell.Text = "";
            //cell.Click += cell_click;
            return cell;
        }

        //public void cell_click(object sender, EventArgs e)
        //{
        //    Button cell = (Button)sender;
        //    //MessageBox.Show(cell.Name.ToString());
        //}
    }
}
