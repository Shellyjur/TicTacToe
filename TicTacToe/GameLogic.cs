﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class GameLogic
    {
        public void RowColValidation(out int o_Num, int i_Size, out bool o_Quit)
        {
            bool success = false;
            o_Num = 0;
            o_Quit = false;
            string rowColInput = String.Empty;
            string quitSymbol = "Q";

            rowColInput = PrintForward(string.Empty, string.Empty, ePrintReason.Input);
            o_Quit = rowColInput.Equals(quitSymbol);
            if (o_Quit == false)//didn't quit
            {
                success = int.TryParse(rowColInput, out o_Num);
                while (success == false || o_Num < 1 || o_Num > i_Size)//wrong input
                {
                    PrintForward(string.Empty, string.Empty, ePrintReason.WrongInput);
                    rowColInput = PrintForward(string.Empty, string.Empty, ePrintReason.Input);
                    if (rowColInput.Equals(quitSymbol))
                    {
                        o_Quit = true;
                        break;
                    }

                    success = int.TryParse(rowColInput, out o_Num);
                }
            }
        }

        public void HumanPlayerChoice(char[,] i_GameMatrix, int i_Size, out int io_Row,
                    out int io_Column, out bool io_Quit)
        {
            io_Row = 0;
            io_Column = 0;
            io_Quit = false;

            PrintForward(string.Empty, string.Empty, ePrintReason.Row);
            RowColValidation(out io_Row, i_Size, out io_Quit);
            if (io_Quit != true)
            {
                PrintForward(string.Empty, string.Empty, ePrintReason.Column);
                RowColValidation(out io_Column, i_Size, out io_Quit);
                if (io_Quit != true)
                {
                    while (i_GameMatrix[io_Row, io_Column] != '\0' && i_GameMatrix[io_Row, io_Column] != '0')
                    {
                        PrintForward(string.Empty, string.Empty, ePrintReason.PlaceTaken);
                        PrintForward(string.Empty, string.Empty, ePrintReason.Row);
                        RowColValidation(out io_Row, i_Size, out io_Quit);
                        PrintForward(string.Empty, string.Empty, ePrintReason.Column);
                        RowColValidation(out io_Column, i_Size, out io_Quit);
                    }
                }
                else
                {
                    PrintForward(string.Empty, string.Empty, ePrintReason.Quit);
                }
            }
            else
            {
                PrintForward(string.Empty, string.Empty, ePrintReason.Quit);
            }
        }

        public bool HumanInputXO(char[,] i_GameMatrix, int i_Size, Player i_HumanPlayer1, Player i_HumanPlayer2, int i_Move, int i_Row, int i_Column, out bool o_Win)
        {
            bool quit = false; 
            
            o_Win = false;
            //PrintForward(i_HumanPlayer1.Id, i_HumanPlayer2.Id, ePrintReason.Define);
            //for (int i = 1; i <= (i_Size * i_Size); i++)
            //{
                if (i_Move % 2 != 0)
                {
                    //PrintForward(i_HumanPlayer1.Id, string.Empty, ePrintReason.HumanX);
                    //HumanPlayerChoice(i_GameMatrix, i_Size, out i_Row, out i_Column, out quit);
                    if (quit == false)
                    {
                        UpdateMovesOfPlayer(i_HumanPlayer1, i_Row, i_Column);
                        i_GameMatrix[i_Row, i_Column] = 'X';
                        i_HumanPlayer1.Move++;
                        //PrintForward(string.Empty, string.Empty, ePrintReason.Clear);
                       // PrintForward(string.Empty, string.Empty, ePrintReason.BoardState);
                        if (i_HumanPlayer1.Move >= i_Size)
                        {
                            o_Win = CheckSequence(i_HumanPlayer1, i_Size, i_Row, i_Column);
                            if (o_Win == true)
                            {
                                i_HumanPlayer2.Score++;
                                //PrintForward(i_HumanPlayer2.Id, string.Empty, ePrintReason.Winner);
                            }
                        }
                    }
                    else
                    {
                        i_HumanPlayer2.Score++;
                    }
                }
                else
                {
                    //PrintForward(i_HumanPlayer2.Id, string.Empty, ePrintReason.HumanO);
                    //HumanPlayerChoice(i_GameMatrix, i_Size, out i_Row, out i_Column, out quit);
                    if (quit == false)
                    {
                        UpdateMovesOfPlayer(i_HumanPlayer2, i_Row, i_Column);
                        i_GameMatrix[i_Row, i_Column] = 'O';
                        i_HumanPlayer2.Move++;
                        //PrintForward(string.Empty, string.Empty, ePrintReason.Clear);
                        //PrintForward(string.Empty, string.Empty, ePrintReason.BoardState);
                        if (i_HumanPlayer2.Move >= i_Size)
                        {
                            o_Win = CheckSequence(i_HumanPlayer2, i_Size, i_Row, i_Column);
                            if (o_Win == true)
                            {
                                i_HumanPlayer1.Score++;
                               //PrintForward(i_HumanPlayer1.Id, string.Empty, ePrintReason.Winner);
                            }
                        }
                    }
                    else
                    {
                        i_HumanPlayer1.Score++;
                    }
                }
            //}

            if (o_Win == false && quit != true)
            {
                //PrintForward(string.Empty, string.Empty, ePrintReason.Tie);
            }

            return quit;
        }

        public string PrintForward(string i_Name1, string i_Name2, ePrintReason i_Reason)
        {
            return ""; //GameUI.GetInput(i_Name1, i_Name2, i_Reason);
        }

        public bool ComputerInputXO(char[,] i_GameMatrix, int i_Size, Player i_ComputerPlayer, Player i_HumanPlayer,
            int i_Move, int i_Row, int i_Column, out int o_I, out int o_J, out bool o_win)
        {
           // int row = 0, column = 0;
           bool quit = false;
           o_win = false;
           o_I = 0;
           o_J = 0;

            //for (move = 1; move <= (i_Size * i_Size); move++)
            //{
                if (i_Move % 2 != 0)
                {
                    //if (move > 2)
                    //{
                    //    //PrintForward(i_ComputerPlayer.Id, string.Empty, ePrintReason.Computer);
                    //}

                    //PrintForward(i_HumanPlayer.Id, string.Empty, ePrintReason.HumanX);
                    //HumanPlayerChoice(i_GameMatrix, i_Size, out row, out column, out quit);
                    if (quit == false)
                    {
                        UpdateMovesOfPlayer(i_HumanPlayer, i_Row, i_Column);
                        i_GameMatrix[i_Row, i_Column] = 'X';
                        i_HumanPlayer.Move++;
                        //PrintForward(string.Empty, string.Empty, ePrintReason.Clear);
                        //PrintForward(string.Empty, string.Empty, ePrintReason.BoardState);
                        if (i_HumanPlayer.Move >= i_Size)
                        {
                            o_win = CheckSequence(i_HumanPlayer, i_Size, i_Row, i_Column);
                            if (o_win == true)
                            {
                                i_ComputerPlayer.Score++;
                                //PrintForward(i_ComputerPlayer.Id, string.Empty, ePrintReason.Winner);
                            }
                        }
                    }
                    else
                    {
                        i_ComputerPlayer.Score++;
                    }
                }
                else
                {
                    //PrintForward(i_ComputerPlayer.Id, string.Empty, ePrintReason.Computer);
                    ComputerGeneratedChoice(i_GameMatrix, i_Size, out i_Row, out i_Column);
                    o_I = i_Row;
                    o_J = i_Column;
                    UpdateMovesOfPlayer(i_ComputerPlayer, i_Row, i_Column);
                    i_GameMatrix[i_Row, i_Column] = 'O';
                    i_ComputerPlayer.Move++;
                    //PrintForward(string.Empty, string.Empty, ePrintReason.Clear);
                    //PrintForward(string.Empty, string.Empty, ePrintReason.BoardState);
                    if (i_ComputerPlayer.Move >= i_Size)
                    {
                        o_win = CheckSequence(i_ComputerPlayer, i_Size, i_Row, i_Column);
                        if (o_win == true)
                        {
                            i_HumanPlayer.Score++;
                            PrintForward(i_HumanPlayer.Id, string.Empty, ePrintReason.HumanX);
                        }
                    }
                }
            //}

            if (o_win == false && quit != true)
            {
                PrintForward(string.Empty, string.Empty, ePrintReason.Tie);
            }

            return quit;
        }

        public void ComputerGeneratedChoice(char[,] i_GameMatrix, int i_Size, out int io_Row, out int io_Column)
        {
            io_Row = 0;
            io_Column = 0;
            var Rand = new Random();//change this definition
            io_Row = Rand.Next(1, i_Size + 1);
            io_Column = Rand.Next(1, i_Size + 1);

            while (i_GameMatrix[io_Row, io_Column] != '\0' && i_GameMatrix[io_Row, io_Column] != '0')
            {
                io_Row = Rand.Next(1, i_Size + 1);
                io_Column = Rand.Next(1, i_Size + 1);
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
