using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift1
{
    class Sudoku
    {
        private string boardAsText;
        char[,] newGameBoard = new char[9, 9];


        public string BoardAsText { get; set; }

        private void Set(char[,] board)
            {
            int atChar = 0;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    BoardAsText += board[row,column]+ " ";
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

        }

    }
}
