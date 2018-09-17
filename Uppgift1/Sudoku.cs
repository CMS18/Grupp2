using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift1
{
    class Sudoku
    {
        char[,] newGameBoard = new char[9, 9];


        public string BoardAsText { get; set; }

        private void Set(char[,] board)
            {
            int atChar = 0;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    BoardAsText += board[row,column]+ "  ";
                    atChar++;
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
                    newGameBoard[row, column] = table[atChar];
                    atChar++;
                }
            }
            Set(newGameBoard);   
        }

        public void Solve()
        {
            for (int row=0; row<newGameBoard.GetLength(0); row++)
            {
                for (int column=0; column<newGameBoard.GetLength(1); column++)
                {
                    if(newGameBoard[row, column] == '0')
                    {
                        for (int num=1; num<10; num++)
                        {
                            char correctNum = (char)(num + 48);
                            if ((IsNotInRow(correctNum, row)
                                && IsNotInColumn(correctNum, column)) 
                                && IsNotInBox(correctNum, row, column))
                            {
                                newGameBoard[row, column] = correctNum;
                            }
                        }
                    }
                }
            }
        }
        private bool IsNotInRow(char num, int row)
        {
            for(int column = 0; column < newGameBoard.GetLength(0); column++)
            {
                if (newGameBoard[row, column] == num) return false;
            }
            return true;
        }
        private bool IsNotInColumn(char num, int column)
        {
            for (int row = 0; row < newGameBoard.GetLength(1); row++)
                if (newGameBoard[row, column] == num) return false;
            return true;
        }
        private bool IsNotInBox(char num, int row, int column)
        {
            int startColumn = getStartFromThisBox(column);
            int startRow = getStartFromThisBox(row);

            for (int r = startRow; r < startRow+3; r++)
                for(int c = startColumn; c < startColumn+3; c++)
                    if (newGameBoard[r, c] == num) return false;
            return true;
        }
        private int getStartFromThisBox(int element)
        {
            if (element < 3)
                return 0;
            else if (element < 6)
                return 3;
            else
                return 6;
        }
    }
}
