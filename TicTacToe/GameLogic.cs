using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class GameLogic
    { 
        private readonly Random m_RandomMove = new Random();

        public void HumanInputXO(char[,] i_GameMatrix, int i_Size, Player i_HumanPlayer1, Player i_HumanPlayer2,
                    int i_Move, int i_Row, int i_Column, out bool o_Win)
        {
            o_Win = false;
            if (i_Move % 2 != 0)
            {
                UpdateMovesOfPlayer(i_HumanPlayer1, i_Row, i_Column);
                i_GameMatrix[i_Row, i_Column] = 'X';
                i_HumanPlayer1.Move++;
                if (i_HumanPlayer1.Move >= i_Size)
                {
                    o_Win = CheckSequence(i_HumanPlayer1, i_Size, i_Row, i_Column); 
                    if (o_Win == true) 
                    { 
                        i_HumanPlayer2.Score++;
                    }
                }      
            }
            else
            {
                UpdateMovesOfPlayer(i_HumanPlayer2, i_Row, i_Column); 
                i_GameMatrix[i_Row, i_Column] = 'O'; 
                i_HumanPlayer2.Move++;
                if (i_HumanPlayer2.Move >= i_Size)
                { 
                    o_Win = CheckSequence(i_HumanPlayer2, i_Size, i_Row, i_Column); 
                    if (o_Win == true) 
                    { 
                        i_HumanPlayer1.Score++;
                    }
                }
            }
        }

        public void ComputerInputXO(char[,] i_GameMatrix, int i_Size, Player i_ComputerPlayer, Player i_HumanPlayer,
                    int i_Move, int i_Row, int i_Column, out int o_I, out int o_J, out bool o_win)
        {
           o_win = false;
           o_I = 0;
           o_J = 0;
           if (i_Move % 2 != 0)
           {
               UpdateMovesOfPlayer(i_HumanPlayer, i_Row, i_Column); 
               i_GameMatrix[i_Row, i_Column] = 'X'; 
               i_HumanPlayer.Move++;
               if (i_HumanPlayer.Move >= i_Size)
               {
                   o_win = CheckSequence(i_HumanPlayer, i_Size, i_Row, i_Column); 
                   if (o_win == true) 
                   { 
                       i_ComputerPlayer.Score++;
                   }
               }
           }
           else 
           {
               ComputerGeneratedChoice(i_GameMatrix, i_Size, out i_Row, out i_Column); 
               o_I = i_Row; 
               o_J = i_Column; 
               UpdateMovesOfPlayer(i_ComputerPlayer, i_Row, i_Column); 
               i_GameMatrix[i_Row, i_Column] = 'O'; 
               i_ComputerPlayer.Move++;
               if (i_ComputerPlayer.Move >= i_Size)
               {
                   o_win = CheckSequence(i_ComputerPlayer, i_Size, i_Row, i_Column); 
                   if (o_win == true) 
                   { 
                       i_HumanPlayer.Score++;
                   }
               }
            }
        }

        public void ComputerGeneratedChoice(char[,] i_GameMatrix, int i_Size, out int io_Row, out int io_Column)
        {
            io_Row = 0;
            io_Column = 0;
            io_Row = m_RandomMove.Next(1, i_Size + 1);
            io_Column = m_RandomMove.Next(1, i_Size + 1);
            while (i_GameMatrix[io_Row, io_Column] != '\0' && i_GameMatrix[io_Row, io_Column] != '0')
            {
                io_Row = m_RandomMove.Next(1, i_Size + 1);
                io_Column = m_RandomMove.Next(1, i_Size + 1);
            }
        }

        public void UpdateMovesOfPlayer(Player i_PlayerUpdateMove, int i_Row, int i_Column)
        {
            i_PlayerUpdateMove.ArrayRowCounter[i_Row]++;
            i_PlayerUpdateMove.ArrayColumnCounter[i_Column]++;
            if (i_Row == i_Column)
            {
                i_PlayerUpdateMove.PrimaryDiagonalCounter++;
            }

            if ((i_Row + i_Column) == (i_PlayerUpdateMove.BoardSize + 1))
            {
                i_PlayerUpdateMove.SecondaryDiagonalCounter++;
            }
        }

        public bool CheckSequence(Player i_PlayerSequenceCheck, int i_Size, int i_Row, int i_Column)
        {
            bool isSequence = false;

            if (i_PlayerSequenceCheck.ArrayRowCounter[i_Row] == i_Size ||
                i_PlayerSequenceCheck.ArrayColumnCounter[i_Column] == i_Size ||
                i_PlayerSequenceCheck.PrimaryDiagonalCounter == i_Size ||
                i_PlayerSequenceCheck.SecondaryDiagonalCounter == i_Size)
            {
                isSequence = true;
            }

            return isSequence;
        }
    }
}
