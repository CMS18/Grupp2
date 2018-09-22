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
            Sudoku game = new Sudoku("900040000000010200370000005000000090001000400000705000000020100580300000000000000");
            game.Solve();
            
        }
    }
}
