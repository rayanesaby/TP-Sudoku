using Solver_CSP_Python;
using System;

namespace ORToolsSolver
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
            Console.WriteLine(s.ToString());

            SolverCSPPython ORT = new SolverCSPPython();
            s = ORT.Solve(s);
            Console.WriteLine(s.ToString());



        }
    }
}
