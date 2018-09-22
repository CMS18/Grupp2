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
        private char[,] board = new char[9, 9];
        public string BoardAsText { get; set; }
        private void FormatBoard(char[,] board)
        {
            BoardAsText = "";
            for (var row = 0; row < board.GetLength(0); row++)
            {
                for (var column = 0; column < board.GetLength(1); column++) BoardAsText += board[row, column] + "  ";

                BoardAsText += "\n";
            }
        }

        public Sudoku(string boardAsText)
        {
            CreateBoard(boardAsText);
            Console.Clear();
            Console.WriteLine(BoardAsText);
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
            Solve(board);
        }
        public char[,] Solve(char[,] currentBoard)
        {
            var hasEmptyCell = false;
            var guess = false;
            var hasUnique = false;
            for (var row = 0; row < currentBoard.GetLength(0); row++)
            {
                for (var column = 0; column < currentBoard.GetLength(1); column++)
                {

                    // If this is the first  cell
                    if (row == 0 && column == 0)
                    {
                        hasEmptyCell = false;
                        hasUnique = false;
                    }

                    // If this cell is empty
                    if (currentBoard[row, column] == '0')
                    {
                        PrintWithColor(row, column, '_', 50, ConsoleColor.DarkRed);
                        hasEmptyCell = true;
                        var availableNums = 0;
                        var correctNum = '0';

                        // Check if 1-9 is possible in this cell
                        for (var num = 1; num < 10; num++)
                        {
                            var checkNum = (char)(num + 48);
                            if (IsNotInRow(checkNum, row)
                                && IsNotInColumn(checkNum, column)
                                && IsNotInBox(checkNum, row, column))
                            {
                                availableNums++;
                                correctNum = checkNum;
                                if (guess)
                                {
                                    PrintWithColor(row, column, correctNum, 100, ConsoleColor.Magenta);
                                    currentBoard[row, column] = correctNum;

                                    char[,] temp = Solve(currentBoard);

                                    currentBoard[row, column] = '0';
                                    if (temp != null)
                                    {
                                        currentBoard = temp;
                                    }
                                    Console.SetCursorPosition(0, board.GetLength(1) + 1);

                                    FormatBoard(currentBoard);
                                    Console.WriteLine(BoardAsText + "\n");
                                }
                            }
                        }
                        // Check if there's only 1 available number for this cell
                        if (availableNums == 1)
                        {
                            hasUnique = true;
                            guess = false;
                            currentBoard[row, column] = correctNum;
                            PrintWithColor(row, column, correctNum, 100, ConsoleColor.DarkGreen);
                        }
                        else if (availableNums > 1 && !hasUnique)
                        {
                            guess = true;
                        }
                    }
                    // If we found a solution
                    if (row == currentBoard.GetLength(0) - 1 && column == currentBoard.GetLength(1) - 1 && !hasEmptyCell) return currentBoard;

                    // If this cell is the last and we found 1 unique number
                    if (row == currentBoard.GetLength(0) - 1 && column == currentBoard.GetLength(1) - 1
                        && hasEmptyCell)
                    {
                        row = -1;
                        if (guess == false) return null;
                    }

                    // TODO: RETURN FAILED

                }
            }
            Console.SetCursorPosition(0, board.GetLength(1) + 1);

            FormatBoard(currentBoard);
            Console.WriteLine(BoardAsText);
            return null;
        }

        // Check if number is not in row
        private bool IsNotInRow(char num, int row)
        {
            for (var column = 0; column < board.GetLength(0); column++)
                if (board[row, column] == num) return false;

            return true;
        }

        // Check if number is not in column
        private bool IsNotInColumn(char num, int column)
        {
            for (var row = 0; row < board.GetLength(1); row++)
                if (board[row, column] == num)
                    return false;
            return true;
        }

        // Check if number is not in box
        private bool IsNotInBox(char num, int row, int column)
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