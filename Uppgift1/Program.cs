using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift1
{
    class Program
    {
        static void Main(string[] args)
        {
            Sudoku game = new Sudoku("380570240572040900004026503703002081420107009006034705630205090040763050085000637"); 
            
            Console.WriteLine(game.BoardAsText);
            game.Solve();
            Console.WriteLine(game.BoardAsText);

        }
    }
}
