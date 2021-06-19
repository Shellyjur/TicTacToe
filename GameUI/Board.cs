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
        BoardGame boardGame;
        Player Player1;
        Player Player2;
        //public Board()
        //{
        //    InitializeComponent();
        //}

        public Board(int i_BoardSize, string i_Player1Id, string i_Player2Id)
        {
            InitializeComponent();
            boardGame = new BoardGame(i_BoardSize);
            Player1 = new Player(i_Player1Id, i_BoardSize);
            Player2 = new Player(i_Player2Id, i_BoardSize);

        } 

        private void Board_Load(object sender, EventArgs e)
        {
            player1L.Text = Player1.Id + ": " + Player1.Score;
            player2L.Text = Player2.Id + ": " + Player2.Score;
        }
    }
}
