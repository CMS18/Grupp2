using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Uppgift1
{
    class Program
    {
        static void Main(string[] args)
        {
            Sudoku game = new Sudoku("003006040800090050009204038028341009007000100500679280230508400080010006070400800"); 
            
            
            // Console.WriteLine(game.BoardAsText);
            game.Solve();
            //Console.WriteLine(game.BoardAsText);

        }
    }
}
