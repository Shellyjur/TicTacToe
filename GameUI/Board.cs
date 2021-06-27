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

        private readonly BoardGame r_BoardGame;
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private readonly string r_GameTypeFlag;
        private readonly Dictionary<int, ButtonXO> r_ButtonDictionary;
        public GameLogic m_TicTacToeLogic;
        private int m_Move;
        
        public Board()
        {
            InitializeComponent();
        }

        public Board(int i_BoardSize, string i_Player1Id, string i_Player2Id, string i_GameTypeFlag)
        {
            InitializeComponent();
            m_TicTacToeLogic = new GameLogic();
            r_BoardGame = new BoardGame(i_BoardSize);
            r_Player1 = new Player(i_Player1Id, i_BoardSize);
            r_Player2 = new Player(i_Player2Id, i_BoardSize);
            r_GameTypeFlag = i_GameTypeFlag;
            m_Move = 0;
            r_ButtonDictionary = new Dictionary<int, ButtonXO>();
        } 

        private void Board_Load(object sender, EventArgs e)
        {
            for (int i = 1 ; i <= r_BoardGame.Size ; i++)
            {
                for(int j = 1 ; j <= r_BoardGame.Size ; j++)
                {
                    flowLayoutPanel1.Controls.Add(CreateCells(i, j));
                }
            }

            player1L.Text = r_Player1.Id + ": " + r_Player1.Score;
            player2L.Text = r_Player2.Id + ": " + r_Player2.Score;
        }

        public Button CreateCells(int i, int j)
        {
            ButtonXO cell = new ButtonXO(i, j);
            cell.Name = i.ToString() + j.ToString();
            cell.Width = (flowLayoutPanel1.Width - 50) / r_BoardGame.Size;
            cell.Height = (flowLayoutPanel1.Height - 50) / r_BoardGame.Size;
            cell.Text = string.Empty;
            r_ButtonDictionary.Add((i * 10) + j, cell);
            cell.Click += cell_click;
            
            return cell;
        }

        public void cell_click(object sender, EventArgs e)
        { 
            bool win;
            
            ButtonXO cell = (ButtonXO)sender;
            if (cell.Text == string.Empty)
            {
                m_Move++;
                if (r_GameTypeFlag == "humanvsComputer")
                {
                    int i, j;

                    m_TicTacToeLogic.ComputerInputXO(r_BoardGame.GameMatrix, r_BoardGame.Size,
                                     r_Player2, r_Player1, m_Move, cell.x, cell.y, out i, out j, out win);
                    cell.Text = r_BoardGame.GameMatrix[cell.x, cell.y].ToString();
                    m_Move++;
                    if (win)
                    {
                        player2L.Text = r_Player2.Id + ": " + r_Player2.Score;
                        var result = MessageBox.Show("The winner is " + r_Player2.Id + "!\nWould you like to play another round?", "A Win!",
                                                MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            RestartGame();
                        }

                        if (result == DialogResult.No)
                        {
                            this.Close();
                        }
                    }
                    else if(m_Move != (r_BoardGame.Size * r_BoardGame.Size))
                    {
                        m_TicTacToeLogic.ComputerInputXO(r_BoardGame.GameMatrix, r_BoardGame.Size,
                                         r_Player2, r_Player1, m_Move, cell.x, cell.y, out i, out j, out win);
                        while (r_ButtonDictionary[(i * 10) + j].Text != string.Empty)
                        {
                            m_TicTacToeLogic.ComputerInputXO(r_BoardGame.GameMatrix, r_BoardGame.Size,
                                             r_Player2, r_Player1, m_Move, cell.x, cell.y, out i, out j, out win);
                        }

                        r_ButtonDictionary[(i * 10) + j].Text = "O";
                        if (win)
                        {
                            player1L.Text = r_Player1.Id + ": " + r_Player1.Score;
                            var result = MessageBox.Show("The winner is " + r_Player1.Id + "!\nWould you like to play another round?", "A Win!",
                                                    MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                RestartGame();
                            }

                            if (result == DialogResult.No)
                            {
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        var result = MessageBox.Show("Tie!\nWould you like to play another round?", "A Tie!",
                                                MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            RestartGame();
                        }

                        if (result == DialogResult.No)
                        {
                            this.Close();
                        }
                    }
                }
                else
                {
                    m_TicTacToeLogic.HumanInputXO(r_BoardGame.GameMatrix, r_BoardGame.Size, r_Player1, r_Player2, m_Move, cell.x, cell.y, out win);
                    cell.Text = r_BoardGame.GameMatrix[cell.x, cell.y].ToString();
                    if (win && m_Move % 2 == 1)
                    {
                        player2L.Text = r_Player2.Id + ": " + r_Player2.Score;
                        var result = MessageBox.Show("The winner is " + r_Player2.Id + "!\nWould you like to play another round?", "A Win!",
                                                MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            RestartGame();
                        }

                        if (result == DialogResult.No)
                        {
                            this.Close();
                        }
                    }
                    else if (win)
                    {
                        player1L.Text = r_Player1.Id + ": " + r_Player1.Score;
                        var result = MessageBox.Show("The winner is " + r_Player1.Id + "!\nWould you like to play another round?", "A Win!",
                                                MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            RestartGame();
                        }

                        if (result == DialogResult.No)
                        {
                            this.Close();
                        }
                    }

                    if (m_Move == (r_BoardGame.Size * r_BoardGame.Size))
                    {
                        var result = MessageBox.Show("Tie!\nWould you like to play another round?", "A Tie!",
                                                MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            RestartGame();
                        }

                        if (result == DialogResult.No)
                        {
                            this.Close();
                        }
                    }
                }
            }
        }

        public void RestartGame()
        {
            r_BoardGame.ClearGameBoard();
            r_Player1.InitializeCounter();
            r_Player2.InitializeCounter();
            foreach (KeyValuePair<int, ButtonXO> button in r_ButtonDictionary)
            {
                button.Value.Text = string.Empty;
            }

            m_Move = 0;
        }
    }
}
