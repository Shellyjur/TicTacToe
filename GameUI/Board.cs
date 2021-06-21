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
            player1L.Text = m_Player1.Id + ": " + m_Player1.Score;
            player2L.Text = m_Player2.Id + ": " + m_Player2.Score;
        }

        public void CreateCells()
        {
            
        }
    }
}
