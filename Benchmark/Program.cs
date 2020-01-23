using System;
using genetic_solver;
using ORToolsSolver;
using Noyau;
using System.Diagnostics;

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

            //declaration du chronometre
            Stopwatch stopwatch = new Stopwatch();

            Noyau.Sudoku s = new Noyau.Sudoku(initial_grid);
            Noyau.Sudoku s_1 = new Noyau.Sudoku();
            Noyau.Sudoku s_2 = new Noyau.Sudoku();

            var fitness = new SudokuFitness(s);

            Console.WriteLine("Sudoku initial :");
            Console.WriteLine(s.ToString());

            Console.WriteLine("\n");
            Console.WriteLine("******************************************************");
            Console.WriteLine("\n");

            Console.WriteLine("Genetic Solver");

            GeneticSolver gs = new GeneticSolver();

            //chrono start
            stopwatch.Start();

            s_1 = gs.Solve(s);

            //chrono stop
            stopwatch.Stop();

            Console.WriteLine(s_1.ToString());
            //fonction pour evaluer si un sudoku est bon : objectif 0
            Console.WriteLine("Fitness : ");
            Console.WriteLine(fitness.Evaluate(s_1));

            //instruction durée d'exe
            Console.WriteLine("Durée d'exécution: {0} secondes", stopwatch.Elapsed.TotalSeconds);
            stopwatch.Reset();

            Console.WriteLine("\n");
            Console.WriteLine("******************************************************");
            Console.WriteLine("\n");

            Console.WriteLine("ORToolsSolver");

            OrToolsSolver ots = new OrToolsSolver();

            //chrono start
            stopwatch.Start();

            s_2 = ots.Solve(s);

            //chrono stop
            stopwatch.Stop();

            Console.WriteLine(s_2.ToString());
            //fonction pour evaluer si un sudoku est bon : objectif 0
            Console.WriteLine("Fitness : ");
            Console.WriteLine(fitness.Evaluate(s_2));

            //instruction durée d'exe
            Console.WriteLine("Durée d'exécution: {0} secondes", stopwatch.Elapsed.TotalSeconds);
            stopwatch.Reset();

            Console.WriteLine("\n");
            Console.WriteLine("******************************************************");
            Console.WriteLine("\n");

            //instruction next algo

            Console.WriteLine("\n");
            Console.WriteLine("******************************************************");
            Console.WriteLine("\n");

            //instruction next algo

            Console.WriteLine("\n");
            Console.WriteLine("******************************************************");
            Console.WriteLine("\n");

            //instruction next algo

            Console.WriteLine("\n");
            Console.WriteLine("******************************************************");
            Console.WriteLine("\n");

            Console.ReadLine();
        }
    }
}