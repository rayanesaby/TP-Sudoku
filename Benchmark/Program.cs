using System;
using genetic_solver;
using ORToolsSolver;
using Noyau;


namespace Benchmark
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


            Noyau.Sudoku s = new Noyau.Sudoku(initial_grid);
            Noyau.Sudoku s_1 = new Noyau.Sudoku();
            Noyau.Sudoku s_2 = new Noyau.Sudoku();

            Console.WriteLine(s.ToString());
            GeneticSolver gs = new GeneticSolver();
            s_1 = gs.Solve(s);
            OrToolsSolver ots = new OrToolsSolver();
            s_2 = ots.Solve(s);

            Console.WriteLine("Genetic Solver");
            Console.WriteLine(s_1.ToString());

            Console.WriteLine("ORToolsSolver");
            Console.WriteLine(s_2.ToString());

            Console.ReadLine();
        }
    }
}