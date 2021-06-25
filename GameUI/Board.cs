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
        private class ButtonXO : Button
        {
            private int m_X;
            private int m_Y;

            public ButtonXO(int i_X, int i_Y)
            {
                m_X = i_X;
                m_Y = i_Y;
            }

            public int x
            {
                get
                {
                    return m_X;
                }

                set
                {
                    m_X = value;
                }
            }

            public int y
            {
                get
                {
                    return m_Y;
                }

                set
                {
                    m_Y = value;
                }
            }
        }

        public GameLogic m_TicTacToeLogic; 
        private BoardGame m_BoardGame;
        //private privetPlayer m_Player1;
        private Player m_Player1;
        private Player m_Player2;
        private int m_Move;
        private string m_GameTypeFlag;
        public Board()
        {
            InitializeComponent();
        }

        public Board(int i_BoardSize, string i_Player1Id, string i_Player2Id, string i_GameTypeFlag)
        {
            InitializeComponent();
            m_TicTacToeLogic = new GameLogic();
            m_BoardGame = new BoardGame(i_BoardSize);
            m_Player1 = new Player(i_Player1Id, i_BoardSize);
            m_Player2 = new Player(i_Player2Id, i_BoardSize);
            m_GameTypeFlag = i_GameTypeFlag;
            m_Move = 0;
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
            ButtonXO cell = new ButtonXO(i, j);
            cell.Name = i.ToString() + j.ToString();
            cell.Width = ((flowLayoutPanel1.Width-50) / (m_BoardGame.Size));
            cell.Height = ((flowLayoutPanel1.Height-50) / (m_BoardGame.Size));
            //cell.Width = 50;
            //cell.Height = 50;
            //cell.Top = j * flowLayoutPanel1.Height;
            //cell.Left = i * flowLayoutPanel1.Width;
            //cell.Height = 90;
            cell.Text = "";
            cell.Click += cell_click;
            return cell;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void cell_click(object sender, EventArgs e)
        { ///////////////UPDATE MOVE SOMEWHERE
            ButtonXO cell = (ButtonXO)sender;
            if (cell.Text == "")
            {
                m_Move++;
            }

            //MessageBox.Show(cell.Name.ToString());
            if (m_GameTypeFlag == "humanvsComputer")
            {
                m_TicTacToeLogic.ComputerInputXO(m_BoardGame.GameMatrix, m_BoardGame.Size, m_Player2, m_Player1, m_Move, cell.x, cell.y);
                //cell.Text = m_BoardGame.GameMatrix[cell.x, cell.y].ToString();
                //m_Move++;
                //m_TicTacToeLogic.ComputerInputXO(m_BoardGame.GameMatrix, m_BoardGame.Size, m_Player2, m_Player1, m_Move, cell.x, cell.y);
                

            }
            else
            {
                m_TicTacToeLogic.HumanInputXO(m_BoardGame.GameMatrix, m_BoardGame.Size, m_Player1, m_Player2, m_Move, cell.x, cell.y);
                //cell.Text = m_BoardGame.GameMatrix[cell.x, cell.y].ToString();
            }

            cell.Text = m_BoardGame.GameMatrix[cell.x, cell.y].ToString();
        }
    }
}
