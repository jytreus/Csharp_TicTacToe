//Title of this code
//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.PrintBoard();
            game.Play();
        }
    }
    
    
    class TicTacToe
    {
        private const int BOARDSIZE = 3; // size of board
        private string[,] board = new string[3,3] {    { " "," "," "},
                                                    { " "," "," "},
                                                    { " "," "," "} };//board set to blank spaces
        private bool playerTurn = false; //false for player 1 , true for player 2
        private int turns = 0;
        //print the game board
        public void PrintBoard()
        {
            Console.WriteLine(" ----------------------- ");
            Console.WriteLine("|       |       |       |");
            //col 1 code
            Console.WriteLine("|   " + board[0,0] + "   |   " + board[0,1]+"   |   " + board[0,2] + "   |");
            Console.WriteLine("|       |       |       |");
            Console.WriteLine(" ----------------------- ");
            Console.WriteLine("|       |       |       |");
            //col 2 code
            Console.WriteLine("|   " + board[1, 0] + "   |   " + board[1, 1] + "   |   " + board[1, 2] + "   |");
            Console.WriteLine("|       |       |       |");
            Console.WriteLine(" ----------------------- ");
            //col 3 code
            Console.WriteLine("|       |       |       |");
            Console.WriteLine("|   " + board[2, 0] + "   |   " + board[2, 1] + "   |   " + board[2, 2] + "   |");
            Console.WriteLine("|       |       |       |");
            Console.WriteLine(" ----------------------- ");
        }

        //This does everything till the game has a win condition or tie
        public void Play()
        {
            bool playGame = true;
            Console.WriteLine("TIC TAC TOE!");
            Console.WriteLine("");
            while (playGame==true)
            {
                //a player takes a turn
                TakeTurn();
                //print board
                PrintBoard();
                Console.WriteLine("");
                //test for a win
                playGame = !(testWin());  
            }
            Console.WriteLine("Game over! ( °?°)  ");
            
            string x = Console.ReadLine();
            Console.WriteLine("Press any key to end.");
        }
        public int getInput()
        {
            int numb= 0;
            bool goodInput = false;
            
            while (goodInput == false)
            {
                string row1 = Console.ReadLine();
                Console.WriteLine("Enter 1, 2, or 3: ");
                if (row1 == "1" || row1 == "2" || row1 == "3")
                {
                    if (row1 == "1")
                    {
                        Console.WriteLine("You entered 1");
                        Console.WriteLine("");
                        numb = 0;
                        goodInput = true;
                    }
                    if (row1 == "2")
                    {
                        Console.WriteLine("You entered 2");
                        Console.WriteLine("");
                        numb = 1;
                        goodInput = true;
                    }
                    if (row1 == "3")
                    {
                        Console.WriteLine("You entered 3");
                        numb = 2;
                        goodInput = true;
                    }
                    
                    
                }
            }
            return numb;
        }

        public void TakeTurn()
        {
            turns++;
            //false is player 1
            if (playerTurn == false)
            {
                bool goodInput = false;
                while (!goodInput)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Player 1's turn.");
                    Console.WriteLine("Player 1 Enter row.");
                    Console.WriteLine("");
                    int rowCord = getInput();

                    Console.WriteLine("Player 1 Enter Column.");
                    int colCord = getInput();
                    
                    if (board[rowCord, colCord] == "2" || board[rowCord, colCord] == "1")
                    {
                        Console.WriteLine("You Dirty Rat, You Can't Cheat.");
                    }
                    if (board[rowCord, colCord] == " ") { board[rowCord, colCord] = "1"; goodInput = true; }
                }
                //all done switches to player 2 for next turn
                playerTurn = true;
               }
            //true is player 2
            else
            {
                bool goodInput2 = false;
                while (!goodInput2)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Player 2's turn.");
                    Console.WriteLine("Player 2 Enter row.");

                    int rowCord = getInput();

                    Console.WriteLine("Player 2 Enter column.");
                    int colCord = getInput();

                    if (board[rowCord, colCord] == "2" || board[rowCord, colCord] == "1")
                    {
                        Console.WriteLine("You Dirty Rat, You Can't Cheat.");
                        Console.WriteLine("");
                    }
                    if (board[rowCord, colCord] == " ") { board[rowCord, colCord] = "2"; goodInput2 = true; }
                    //all done
                    
                }
                //switches bck to player 1 for next turn.
                playerTurn = false;
            }
        }

        //This method stops the returns true so the game stops.
        public bool testWin()
        {
            //Console.WriteLine("Testing for a win.");
            bool endGame = false;
            
            //8 ways to win at tic tac toe
            
            //check for full board first
            if (turns == 9) { endGame = true; Console.WriteLine("You Ran Out Of Room!  Game over!."); return true;  }

            //across row 1
            if (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2] && board[0, 0] != " ") 
            { endGame = true; Console.WriteLine("Player " + board[0, 2] + " wins."); }
            //across row 2
            if (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2] && board[1, 0] != " ")
            { endGame = true; Console.WriteLine("Player " + board[1, 2] + " wins."); }
            //across row 3
            if (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2] && board[2, 0] != " ")
            { endGame = true; Console.WriteLine("Player " + board[2, 2] + " wins."); }
            //down col 1
            if (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0] && board[0, 0] != " ")
            { endGame = true; Console.WriteLine("Player " + board[0, 0] + " wins."); }
            //down col 2
            if (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1] && board[0, 1] != " ")
            { endGame = true; Console.WriteLine("Player " + board[0, 1] + " wins."); }
            //down col 3
            if (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2] && board[0, 2] != " ")
            { endGame = true; Console.WriteLine("Player " + board[2, 2] + " wins."); }
            //cross from top left to bottom right
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != " ")
            { endGame = true; Console.WriteLine("Player " + board[2, 2] + " wins."); }
            //cross from bottom left to top right
            if (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2] && board[2, 0] != " ")
            { endGame = true; Console.WriteLine("Player " + board[0, 2] + " wins."); }

            return endGame;
        }
    }
    
    
    
    
    
    
}