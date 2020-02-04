using System;

namespace SolverDLX
{
    class Program
    {
        static void Main(string[] args)
        {
            var allSudokus = Sudoku.Core.Sudoku.ParseFile("../../data/Sudoku_Easy50.txt");
            var SudokuSolver = new SolverDlx();
            Console.Write(allSudokus[1]);
            var resolu = SudokuSolver.Solve(allSudokus[1]);
            Console.WriteLine(resolu.ToString());
        }
    }
}
