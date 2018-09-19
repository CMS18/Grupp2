using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Uppgift1
{
    class Sudoku
    {
        char[,] newGameBoard = new char[9, 9];


        public string BoardAsText { get; set; }

        private void FormatBoard(char[,] board)
        {
            BoardAsText = "";
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    BoardAsText += board[row,column]+ "  ";
                }
                BoardAsText += "\n";
            }
        }
        
        public Sudoku(string boardAsText)
        {
            this.CreateBoard(boardAsText);
        }
        
        public void CreateBoard(string table)
        {
            int atChar = 0;
            for (int row = 0; row < newGameBoard.GetLength(0); row++)
            {
                for (int column = 0; column < newGameBoard.GetLength(1); column++)
                {
                    newGameBoard[row, column] = table[atChar++];
                }
            }
            FormatBoard(newGameBoard);   
        }

        public void Solve()
        {
            Console.Clear();
            Console.WriteLine(BoardAsText);
            bool hasEmptyCell = false;
            bool iGiveUp = true;
            for (int row=0; row<newGameBoard.GetLength(0); row++)
            {
                for (int column=0; column<newGameBoard.GetLength(1); column++)
                {
                    // If this is the first  cell
                    if (row == 0 && column == 0)
                    {
                        hasEmptyCell = false;
                        iGiveUp = true;
                    }
                    // If this cell is empty
                    if(newGameBoard[row, column] == '0')
                    {
                        printWithColor(row, column, '_', 0, ConsoleColor.Red);
                        hasEmptyCell = true;
                        int availableNums = 0;
                        char correctNum = '0';
                        // Check if 1-9 is possible in this cell
                        for (int num=1; num<10; num++)
                        {
                            char checkNum = (char) (num + 48);
                            if ((IsNotInRow(checkNum, row)
                                && IsNotInColumn(checkNum, column)) 
                                && IsNotInBox(checkNum, row, column))
                            {
                                availableNums++;
                                correctNum = checkNum;
                            }
                        }
                        // Check if there's only 1 available number for this cell
                        if (availableNums == 1)
                        {
                            newGameBoard[row, column] = correctNum;
                            printWithColor(row, column, correctNum, 100, ConsoleColor.Green);                   
                            iGiveUp = false;
                        }
                    }
                    
                    // If this cell is the last and we are not giving up
                    if (!iGiveUp && row == newGameBoard.GetLength(0)-1 && column == newGameBoard.GetLength(1)-1)
                    {
                        if (hasEmptyCell)
                        {
                            row = -1;  
                        }
                    }
                }
                
                // If we are on last row & we have an empty cell but couldn't add a number we stop looping
                if (iGiveUp && row == newGameBoard.GetLength(0) - 1 && hasEmptyCell)
                {
                    Console.SetCursorPosition(0, newGameBoard.GetLength(1));
                    Console.WriteLine("Sorry! This sudoku is too hard for me. ");
                    break;
                }
            }
            Console.SetCursorPosition(0, newGameBoard.GetLength(1)+1);
            //FormatBoard(newGameBoard);
        }
        // Check if number is not in row
        private bool IsNotInRow(char num, int row)
        {
            for(int column = 0; column < newGameBoard.GetLength(0); column++)
            {
                if (newGameBoard[row, column] == num) return false;
            }
            return true;
        }
        // Check if number is not in column
        private bool IsNotInColumn(char num, int column)
        {
            for (int row = 0; row < newGameBoard.GetLength(1); row++)
                if (newGameBoard[row, column] == num) return false;
            return true;
        }
        // Check if number is not in box
        private bool IsNotInBox(char num, int row, int column)
        {
            int startColumn = getStartFromThisBox(column);
            int startRow = getStartFromThisBox(row);

            for (int r = startRow; r < startRow+3; r++)
                for(int c = startColumn; c < startColumn+3; c++)
                    if (newGameBoard[r, c] == num) return false;
            return true;
        }
        // Get the start position in a box (Upper left corner)
        private int getStartFromThisBox(int element)
        {
            if (element < 3)
                return 0;
            else if (element < 6)
                return 3;
            else
                return 6;
        }
        // Print a number at correct position with specified color
        private void printWithColor(int row, int column, char num, int sleepTime, ConsoleColor color)
        {
            Console.SetCursorPosition(column * 3, row);
            Console.ForegroundColor = color;
            Console.Write(num);
            Thread.Sleep(sleepTime);
        }
    }
}
