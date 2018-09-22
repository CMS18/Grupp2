using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    internal class Sudoku
    {
        private int[,] cells = new int[9, 9];

        public Sudoku(string board)
        {
            int position = 0;
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (int.TryParse(board.Substring(position, 1), out int number))
                    {
                        SetCellValue(row, col, number);
                    }
                    position++;
                }
            }
        }

        private int GetCellValue(int row, int column)
        {
            return cells[row, column];
        }

        private void SetCellValue(int row, int column, int value)
        {
            cells[row, column] = value;
        }

        public void PrintBoard()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    int cellValue = GetCellValue(row, col);

                    if (cellValue != 0)
                    {
                        Console.Write(cellValue + " ");
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                }
                Console.WriteLine();
            }
        }


        private bool CellIsEmpty(int row, int column)
        {
            // Hämta värde på cell i rad och kolumn
            // Om (cell == 0) så är den tom

            throw new NotImplementedException();
        }

        private int[] GetNumbersInRow(int row)
        {
            // Hämta siffrorna i en rad
            // TODO: hämta siffror från rad
            return new[] { 0, 0, 8, 1, 0, 2, 9, 0, 0 };

        }

        private int[] GetNumbersInColumn(int column)
        {

            // TODO: Hämta siffrorna i en rad
            return new[] { 2, 0, 0, 0, 0, 0, 0, 0, 1 };


        }

        private int[] GetNumbersInBlock(int row, int column)
        {
            // Beräkna vilket block
            // Hämta siffrorna i blocket rad för rad
            int[] result = new int[9];

            int topLeftRow = (row < 3) ? 0 : ((row < 6) ? 3 : 6);
            int topLeftColumn = (column / 3) * 3;
            int position = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int cellValue = GetCellValue(topLeftRow + i, topLeftColumn + j);
                    result[position] = cellValue;
                    position++;
                }
            }
            return result;
        }

        public int[] FindPossibleNumbers(int row, int column)
        {
            // Hitta möjliga tal för cell utifrån rad, kolumn och block
            List<int> result = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] numbersInRow = GetNumbersInRow(row);
            int[] numbersInColumn = GetNumbersInColumn(column);

            foreach (var number in numbersInRow)
            {
                if (result.Contains(number)) result.Remove(number);
            }
            foreach (var number in numbersInColumn)
            {
                if (result.Contains(number)) result.Remove(number);
            }
            foreach (var number in GetNumbersInBlock(row, column))
            {
                if (result.Contains(number)) result.Remove(number);
            }
            return result.ToArray();
        }
        private bool IsComplete()
        {
            // Loopa igenom alla celler
            //   Om (cell är tom) inte färdig

            throw new NotImplementedException();
        }

        public void Solve()
        {
            // Loopa tills färdig (dvs inga tomma rutor)
            //   Loopa igenom alla celler (for-loop nestade rad och kolumn)
            //     Om (cell är tom) 
            //       Hitta möjliga tal för cell utifrån rad, kolumn och block
            //       Om (noll alternativ för cellen) finns ingen lösning - avbryta
            //       Om (ett alternativ för cellen) skriv in tal i cell
            //       Om (flera alternativ för cellen) gå vidare

            throw new NotImplementedException();
        }
    }
}