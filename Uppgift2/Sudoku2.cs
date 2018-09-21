using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift2
{
    class Sudoku2
    {
        static void Main(string[] args)
        {
            Sudoku game = new Sudoku("000000000000000000000000000000000000000010000000000000000000000000000000000000000");
            game.Solve();
            
        }
    }
}
