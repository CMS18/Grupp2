using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Uppgift2
{
    internal class Sudoku
    {
        private readonly char[,] board = new char[9, 9];
        public string BoardAsText { get; set; }
        private bool debug;
        int recCount = 0;
        int tries = 0;

        private void FormatBoard(char[,] board)
        {
            BoardAsText = "";
            for (var row = 0; row < board.GetLength(0); row++)
            {
                for (var column = 0; column < board.GetLength(1); column++) BoardAsText += board[row, column] + "  ";

                BoardAsText += "\n";
            }
        }

        public Sudoku(string boardAsText, bool debug)
        {
            this.debug = debug;
            CreateBoard(boardAsText);
        }

        public void CreateBoard(string table)
        {
            var atChar = 0;
            for (var row = 0; row < board.GetLength(0); row++)
                for (var column = 0; column < board.GetLength(1); column++) board[row, column] = table[atChar++];

            FormatBoard(board);
        }
        public void Solve()
        {
            Console.Clear();
            Console.WriteLine(BoardAsText);
            Solve(board, -1);
        }
        // Set cellGuessed to -1 if no previous guesses have been made
        public char[,] Solve(char[,] currentBoard, int cellGuessed)
        {
            var hasEmptyCell = false;
            var iGiveUp = true;
            var guess = false;
            var loopsWithoutProgress = 0;
            var currentCell = 0;

            for (var row = 0; row < currentBoard.GetLength(0); row++)
            {
                for (var column = 0; column < currentBoard.GetLength(1); column++)
                {
                    // If this is the first  cell
                    if (row == 0 && column == 0)
                    {
                        hasEmptyCell = false;
                        iGiveUp = true;
                        loopsWithoutProgress++;
                        currentCell = 0;
                    }
                    // If this cell is empty
                    if (currentBoard[row, column] == '0')
                    {
                        if(debug) PrintWithColor(row, column, '_', 0, ConsoleColor.DarkRed);
                        hasEmptyCell = true;
                        var correctNum = '0';

                        // Check if 1-9 is possible in this cell
                        List<char> availableNums = new List<char>(); 
                        for (var num = 1; num < 10; num++)
                        {
                            var checkNum = (char)(num + 48);
                            if (IsNotInRow(currentBoard, checkNum, row)
                                && IsNotInColumn(currentBoard, checkNum, column)
                                && IsNotInBox(currentBoard, checkNum, row, column))
                            {
                                correctNum = checkNum;
                                availableNums.Add(correctNum);
                            }
                        }
                        // If we are doing guesses on a new cell
                        if (guess && currentCell > cellGuessed && availableNums.Count > 1)
                        {
                            foreach (char num in availableNums) {
                                if (debug) PrintWithColor(row, column, num, 0, ConsoleColor.Red);
                                currentBoard[row, column] = num;
                                recCount++;
                                tries++;
                                // Try the number in a new recursion of a cloned board
                                char[,] testBoard = Solve(currentBoard.Clone() as char[,], currentCell); 
                                currentBoard[row, column] = '0';
                                if (testBoard != null)
                                {
                                    currentBoard = testBoard;
                                    hasEmptyCell = false;
                                    Console.SetCursorPosition(0, 15);
                                    FormatBoard(currentBoard);
                                    Console.WriteLine("FOUND IT! " + recCount +"\n"+ BoardAsText);
                                    break;
                                }
                                recCount--;
                                loopsWithoutProgress = 0;
                            }
                            cellGuessed = currentCell;
                        }

                        // Check if there's only 1 available number for this cell
                        else if (availableNums.Count == 1)
                        {
                            currentBoard[row, column] = correctNum;
                            if (debug) PrintWithColor(row, column, correctNum, 0, ConsoleColor.DarkGreen);
                            iGiveUp = false;
                            guess = false;
                            loopsWithoutProgress = 0;
                            //rowGuessed = -1;
                            //columnGuessed = -1;
                        }
                    }
                    currentCell++;
                }                        
                
                // If we looped without any new guesses or unique numbers
                if (loopsWithoutProgress > 3)
                {
                    currentBoard = null;
                    break;
                }
                // If we are on last row but couldn't add a number we guess
                if (row == currentBoard.GetLength(0) - 1)
                {
                    // If we found a solution
                    if (!hasEmptyCell) break;
                    if (iGiveUp) guess = true;
                    row = -1;
                }
            }
            
            if (currentBoard != null) { Console.SetCursorPosition(0, board.GetLength(1) + 1); FormatBoard(currentBoard); Console.WriteLine("Solution:\n"+BoardAsText); }
            return currentBoard;
        }

        // Check if number is not in row
        private bool IsNotInRow(char[,] board, char num, int row)
        {
            for (var column = 0; column < board.GetLength(0); column++)
                if (board[row, column] == num) return false;

            return true;
        }

        // Check if number is not in column
        private bool IsNotInColumn(char[,] board, char num, int column)
        {
            for (var row = 0; row < board.GetLength(1); row++)
                if (board[row, column] == num)
                    return false;
            return true;
        }

        // Check if number is not in box
        private bool IsNotInBox(char[,] board, char num, int row, int column)
        {
            var startColumn = GetStartFromThisBox(column);
            var startRow = GetStartFromThisBox(row);

            for (var r = startRow; r < startRow + 3; r++)
                for (var c = startColumn; c < startColumn + 3; c++)
                    if (board[r, c] == num)
                        return false;
            return true;
        }

        // Get the start position in a box (Upper left corner)
        private static int GetStartFromThisBox(int element)
        {
            if (element < 3)
                return 0;
            else if (element < 6)
                return 3;
            else
                return 6;
        }

        // Print a number at correct position with specified color
        private static void PrintWithColor(int row, int column, char num, int sleepTime, ConsoleColor color)
        {
            Console.SetCursorPosition(column * 3, row);
            Console.ForegroundColor = color;
            Console.Write(num);
            Thread.Sleep(sleepTime);
        }
    }
}