﻿using System;
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
            Sudoku game = new Sudoku("003020600900305001001806400"+
                                     "008102900700000008006708200"+
                                     "002609500800203009005010300"); 
            
            Console.WriteLine(game.BoardAsText);
            game.Solve();
            Console.WriteLine(game.BoardAsText);

        }
    }
}
