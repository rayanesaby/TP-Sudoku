using System;
using Noyau;

namespace genetic_solver
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initial_grid = new int[] { 0, 6, 0, 0, 5, 0, 0, 2, 0,

                                             0, 0, 0, 3, 0, 0, 0, 9, 0,

                                             7, 0, 0, 6, 0, 0, 0, 1, 0,

                                             0, 0, 6, 0, 3, 0, 4, 0, 0,

                                             0, 0, 4, 0, 7, 0, 1, 0, 0,

                                             0, 0, 5, 0, 9, 0, 8, 0, 0,

                                             0, 4, 0, 0, 0, 1, 0, 0, 6,

                                             0, 3, 0, 0, 0, 8, 0, 0, 0,

                                             0, 2, 0, 0, 4, 0, 0, 5, 0 };

            Noyau.Sudoku S1 = new Sudoku(initial_grid);
            Console.WriteLine(S1.ToString());

            GeneticSolver gs = new GeneticSolver();
            S1 = gs.Solve(S1);
            Console.WriteLine(S1.ToString());
        }
    }
}
