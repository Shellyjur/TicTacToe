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
        private Dictionary<int, ButtonXO> m_ButtonDictionary;
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
            m_ButtonDictionary = new Dictionary<int, ButtonXO>();
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
            cell.Width = ((flowLayoutPanel1.Width - 50) / (m_BoardGame.Size));
            cell.Height = ((flowLayoutPanel1.Height - 100) / (m_BoardGame.Size));
            //cell.Width = 5;
            //cell.Height = 5;
            //cell.Top = j * flowLayoutPanel1.Height;
            //cell.Left = i * flowLayoutPanel1.Width;
            //cell.Height = 90;
            cell.Text = "";
            m_ButtonDictionary.Add(i * 10 + j, cell);
            cell.Click += cell_click;
            
            return cell;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void cell_click(object sender, EventArgs e)
        { ///////////////UPDATE MOVE SOMEWHERE
            bool win;
            
            ButtonXO cell = (ButtonXO)sender;
            if (cell.Text == "")
            {
                m_Move++;
                if (m_GameTypeFlag == "humanvsComputer")
                {
                    int i, j;

                    m_TicTacToeLogic.ComputerInputXO(m_BoardGame.GameMatrix, m_BoardGame.Size, m_Player2, m_Player1, m_Move, cell.x, cell.y, out i, out j, out win);
                    cell.Text = m_BoardGame.GameMatrix[cell.x, cell.y].ToString();
                    m_Move++;
                    if (win)
                    {
                        m_Player2.Score++;
                        var result = MessageBox.Show("The winner is " + m_Player2.Id + "!\nWould you like to play another round?", "A Win!",
                            MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            m_BoardGame.ClearGameBoard();
                            m_Player1.InitializeCounter();
                            m_Player2.InitializeCounter();
                            foreach (KeyValuePair<int, ButtonXO> button in m_ButtonDictionary)
                            {
                                button.Value.Text = "";
                            }

                            m_Move = 0;
                        }

                        if (result == DialogResult.No)
                        {
                            this.Close();
                            //this.ParentForm.Close();
                        }
                    }

                    if(m_Move != (m_BoardGame.Size * m_BoardGame.Size))
                    {
                        m_TicTacToeLogic.ComputerInputXO(m_BoardGame.GameMatrix, m_BoardGame.Size, m_Player2, m_Player1, m_Move, cell.x, cell.y, out i, out j, out win);
                        while (m_ButtonDictionary[i * 10 + j].Text != "")
                        {
                            m_TicTacToeLogic.ComputerInputXO(m_BoardGame.GameMatrix, m_BoardGame.Size, m_Player2, m_Player1, m_Move, cell.x, cell.y, out i, out j, out win);
                        }

                        m_ButtonDictionary[i * 10 + j].Text = "O";
                        if (win)
                        {
                            m_Player1.Score++;
                           var result = MessageBox.Show("The winner is " + m_Player1.Id + "!\nWould you like to play another round?", "A Win!",
                                MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                m_BoardGame.ClearGameBoard();
                                m_Player1.InitializeCounter();
                                m_Player2.InitializeCounter();
                                foreach (KeyValuePair<int, ButtonXO> button in m_ButtonDictionary)
                                {
                                    button.Value.Text = "";
                                }
                                m_Move = 0;
                            }

                            if (result == DialogResult.No)
                            {
                                this.Close();
                                //this.ParentForm.Close();
                            }
                        }
                    }
                    else
                    {
                        var result = MessageBox.Show("Tie!\nWould you like to play another round?", "A Tie!",
                            MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            m_BoardGame.ClearGameBoard();
                            m_Player1.InitializeCounter();
                            m_Player2.InitializeCounter();
                            foreach (KeyValuePair<int, ButtonXO> button in m_ButtonDictionary)
                            {
                                button.Value.Text = "";
                            }
                            m_Move = 0;
                        }

                        if (result == DialogResult.No)
                        {
                            this.Close();
                            //this.ParentForm.Close();
                        }
                    }
                    
                }
                else
                {
                    m_TicTacToeLogic.HumanInputXO(m_BoardGame.GameMatrix, m_BoardGame.Size, m_Player1, m_Player2, m_Move, cell.x, cell.y, out win);
                    cell.Text = m_BoardGame.GameMatrix[cell.x, cell.y].ToString();
                    if (win && m_Move % 2 == 1)
                    {
                        m_Player2.Score++;
                        var result = MessageBox.Show("The winner is " + m_Player2.Id + "!\nWould you like to play another round?", "A Win!",
                            MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            m_BoardGame.ClearGameBoard();
                            m_Player1.InitializeCounter();
                            m_Player2.InitializeCounter();
                            foreach (KeyValuePair<int, ButtonXO> button in m_ButtonDictionary)
                            {
                                button.Value.Text = "";
                            }
                            m_Move = 0;
                        }

                        if (result == DialogResult.No)
                        {
                            this.Close();
                            //this.ParentForm.Close();
                        }
                    }
                    else if (win)
                    {
                        m_Player1.Score++;
                        var result = MessageBox.Show("The winner is " + m_Player1.Id + "!\nWould you like to play another round?", "A Win!",
                            MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            m_BoardGame.ClearGameBoard();
                            m_Player1.InitializeCounter();
                            m_Player2.InitializeCounter();
                            foreach (KeyValuePair<int, ButtonXO> button in m_ButtonDictionary)
                            {
                                button.Value.Text = "";
                            }
                            m_Move = 0;
                        }

                        if (result == DialogResult.No)
                        {
                            this.Close();
                            //this.ParentForm.Close();
                        }

                    }
                    //MessageBox.Show()
                    if (m_Move == (m_BoardGame.Size * m_BoardGame.Size))
                    {
                        var result = MessageBox.Show("Tie!\nWould you like to play another round?", "A Tie!",
                            MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            m_BoardGame.ClearGameBoard();
                            m_Player1.InitializeCounter();
                            m_Player2.InitializeCounter();
                            foreach (KeyValuePair<int, ButtonXO> button in m_ButtonDictionary)
                            {
                                button.Value.Text = "";
                            }
                            m_Move = 0;
                        }

                        if (result == DialogResult.No)
                        {
                            this.Close();
                            //this.ParentForm.Close();
                        }
                    }
                }

                //cell.Text = m_BoardGame.GameMatrix[cell.x, cell.y].ToString();
            }

            //MessageBox.Show(cell.Name.ToString());
            
        }

        //private void player1L_Click(object sender, EventArgs e)
        //{

        //}
    }
}
