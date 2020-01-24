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
            Noyau.Sudoku s_3 = new Noyau.Sudoku();
            Noyau.Sudoku s_4 = new Noyau.Sudoku();
            Noyau.Sudoku s_5 = new Noyau.Sudoku();
            Noyau.Sudoku s_6 = new Noyau.Sudoku();
            Noyau.Sudoku s_7 = new Noyau.Sudoku();





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
            Console.WriteLine("Résolution par CSP ");

            //CSP csp = new CSP();

            //chrono start
            stopwatch.Start();

            //s_3 = csp.Solve(s);

            //chrono stop
            stopwatch.Stop();
            Console.WriteLine(s_3.ToString());

            //fonction pour evaluer si un sudoku est bon : objectif 0
            Console.WriteLine("Fitness : ");
            Console.WriteLine(fitness.Evaluate(s_3));

            //instruction durée d'exe
            Console.WriteLine("Durée d'exécution: {0} secondes", stopwatch.Elapsed.TotalSeconds);
            stopwatch.Reset();


            Console.WriteLine("\n");
            Console.WriteLine("******************************************************");
            Console.WriteLine("\n");

            //instruction next algo
            Console.WriteLine("Résolution par SMT  ");

            //SMT smt = new SMT();

            //chrono start
            stopwatch.Start();

            //s_4 = smt.Solve(s);

            //chrono stop
            stopwatch.Stop();
            Console.WriteLine(s_4.ToString());

            //fonction pour evaluer si un sudoku est bon : objectif 0
            Console.WriteLine("Fitness : ");
            Console.WriteLine(fitness.Evaluate(s_4));

            //instruction durée d'exe
            Console.WriteLine("Durée d'exécution: {0} secondes", stopwatch.Elapsed.TotalSeconds);
            stopwatch.Reset();

            Console.WriteLine("\n");
            Console.WriteLine("******************************************************");
            Console.WriteLine("\n");

            //instruction next algo
            Console.WriteLine("Résolution par Dancing_Links  ");

            //Dancing_Links dancing = new Dancing_Links();

            //chrono start
            stopwatch.Start();

            //s_5 = dancing.Solve(s);

            //chrono stop
            stopwatch.Stop();
            Console.WriteLine(s_5.ToString());

            //fonction pour evaluer si un sudoku est bon : objectif 0
            Console.WriteLine("Fitness : ");
            Console.WriteLine(fitness.Evaluate(s_5));

            //instruction durée d'exe
            Console.WriteLine("Durée d'exécution: {0} secondes", stopwatch.Elapsed.TotalSeconds);
            stopwatch.Reset();


            Console.WriteLine("\n");
            Console.WriteLine("******************************************************");
            Console.WriteLine("\n");

            //instruction next algo
            Console.WriteLine("Résolution à la Norvig ");

            //Norvig nor = new Norvig();

            //chrono start
            stopwatch.Start();

            //s_6 = nor.Solve(s);

            //chrono stop
            stopwatch.Stop();
            Console.WriteLine(s_6.ToString());

            //fonction pour evaluer si un sudoku est bon : objectif 0
            Console.WriteLine("Fitness : ");
            Console.WriteLine(fitness.Evaluate(s_6));

            //instruction durée d'exe
            Console.WriteLine("Durée d'exécution: {0} secondes", stopwatch.Elapsed.TotalSeconds);
            stopwatch.Reset();

            Console.WriteLine("\n");
            Console.WriteLine("******************************************************");
            Console.WriteLine("\n");

            //instruction next algo
            Console.WriteLine(" Résolution par réseau de neurones convolués ");

            //Neurones neur = new Neurones();

            //chrono start
            stopwatch.Start();

            //s_7 = neur.Solve(s);

            //chrono stop
            stopwatch.Stop();
            Console.WriteLine(s_7.ToString());

            //fonction pour evaluer si un sudoku est bon : objectif 0
            Console.WriteLine("Fitness : ");
            Console.WriteLine(fitness.Evaluate(s_7));

            //instruction durée d'exe
            Console.WriteLine("Durée d'exécution: {0} secondes", stopwatch.Elapsed.TotalSeconds);
            stopwatch.Reset();

            Console.ReadLine();
        }
    }
}