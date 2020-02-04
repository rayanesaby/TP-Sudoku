using System;
using genetic_solver;
using ORToolsSolver;

using Noyau;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO ;
using Z3Solver;
using Solver_CSP_Python;



namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            menu = true;
            do
            {


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n\n               Résolution de Sudoku\n");
                //Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("                1. Benchmark Easy");
                Console.WriteLine("                2. Benchmark Hardest");
                Console.WriteLine("                3. Benchmark Top 95");
                Console.WriteLine("                4. Benchmark initiale");

                Console.WriteLine("                5. Quitter");

                Console.WriteLine("\n         Que voulez vous faire ?");
                int choix;

                try

                {

                    choix = int.Parse(Console.ReadLine());

                }

                catch (Exception e)

                {

                    choix = -1;

                    Console.WriteLine("\n\n                Saisie invalide\n\n");

                }




                switch (choix)
                {
                    case 1:
                        Console.WriteLine("                 Benchmark Easy");
                        Sudoku_easy();

                        break;
                    case 2:
                        Console.WriteLine("                 Benchmark Hardest");
                        Sudoku_Hardest();
                        break;
                    case 3:
                        Console.WriteLine("                 Benchmark Top 95");
                        Sudoku_Top95();
                        break;
                    case 4:
                        Console.WriteLine("                 Benchmark initiale");

                        Sudoku_init();
                        break;
                    case 5:
                        Console.WriteLine("   Vous avez quitté le programme.");
                        Console.ReadLine();


                        break;
                }




                void Sudoku_init()
                {
                    /**
                    List<Sudoku>.ParseFile parsefile = new Sudoku.ParseFile;

                    ParseFile(Sudoku_Easy50.txt);
                    showScore(benchmark(sudoku.getFile("Sudoku_Easy50.txt")), 50, "Easy");
                    **/

                    Console.WriteLine("\n");
                    Console.WriteLine("  1. Genetic Solver");
                    Console.WriteLine("  2. ORToolsSolver");
                    Console.WriteLine("  3. Résolution par CSP ");
                    Console.WriteLine("  4. Résolution par SMT/Z3  ");
                    Console.WriteLine("  5. Résolution par Dancing_Links  ");
                    Console.WriteLine("  6. Résolution à la Norvig ");
                    Console.WriteLine("  7. Résolution par réseau de neurones convolués ");
                    Console.WriteLine("\n");


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

                    int solution;

                    try

                    {

                        solution = int.Parse(Console.ReadLine());

                    }

                    catch (Exception e)

                    {

                        solution = -1;

                        Console.WriteLine("\n\n                Saisie invalide\n\n");

                    }

                    Console.WriteLine("******************************************************");
                    Console.WriteLine("\n");

                    Console.WriteLine("   Sudoku initial :");
                    Console.WriteLine("\n");
                    Console.WriteLine(s.ToString());

                    Console.WriteLine("\n");
                    Console.WriteLine("******************************************************");


                    switch (solution)
                    {
                        case 1:
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

                            Console.ReadLine();
                            break;

                        case 2:
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

                            Console.ReadLine();
                            break;

                        case 3:
                            //instruction next algo
                            Console.WriteLine("Résolution par CSP ");

                            SolverCSPPython csp = new SolverCSPPython();

                            //chrono start
                            stopwatch.Start();

                            s_3 = csp.Solve(s);

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

                            Console.ReadLine();
                            break;

                        case 4:
                            //instruction next algo
                            Console.WriteLine("Résolution par SMT/Z3  ");

                            Z3Solver smt = new Z3Solver();
                            smt.execute();
                            //test debut
                            int[] initial_grid = new int[] { 0, 6, 0, 0, 5, 0, 0, 2, 0,

                                             0, 0, 0, 3, 0, 0, 0, 9, 0,

                                             7, 0, 0, 6, 0, 0, 0, 1, 0,

                                             0, 0, 6, 0, 3, 0, 4, 0, 0,

                                             0, 0, 4, 0, 7, 0, 1, 0, 0,

                                             0, 0, 5, 0, 9, 0, 8, 0, 0,

                                             0, 4, 0, 0, 0, 1, 0, 0, 6,

                                             0, 3, 0, 0, 0, 8, 0, 0, 0,

                                             0, 2, 0, 0, 4, 0, 0, 5, 0 };

                            // Pour être conforme au groupe arbitre on créé "toSolve"
                            //Noyau.Sudoku toSolve = new Sudoku(initial_grid);
                            //Console.WriteLine(toSolve.ToString());


                            //Z3Solver solve = new Z3Solver();

                            //DateTime T_init = DateTime.Now;
                            //Console.WriteLine(T_init);

                            s = smt.Solve(s);
                            Console.Writeline("ok");
                            Console.Writeline(smt.Solve(s).ToString());
                           // Console.WriteLine(toSolve.ToString());
                            Console.Writeline("fin");
                            //test fin

                            //chrono start
                            stopwatch.Start();

                            s_4 = smt.Solve(s);

                            //chrono stop
                            stopwatch.Stop();
                            Console.WriteLine(s.ToString());

                            //fonction pour evaluer si un sudoku est bon : objectif 0
                            Console.WriteLine("Fitness : ");
                            Console.WriteLine(fitness.Evaluate(s_4));

                            //instruction durée d'exe
                            Console.WriteLine("Durée d'exécution: {0} secondes", stopwatch.Elapsed.TotalSeconds);
                            stopwatch.Reset();

                            Console.WriteLine("\n");
                            Console.WriteLine("******************************************************");
                            Console.WriteLine("\n");

                            Console.ReadLine();
                            break;

                        case 5:
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

                            Console.ReadLine();
                            break;

                        case 6:
                            //instruction next algo
                            Console.WriteLine("Résolution à la Norvig ");

                            SoverNorvig.SoverNorvig nor = new SoverNorvig.SoverNorvig();

                            //chrono start
                            stopwatch.Start();

                            s_6 = nor.Solve(s);

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

                            Console.ReadLine();
                            break;

                        case 7:
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
                            break;
                    }

                    /**
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
                    **/

                    /////////////////////// CHANGEMENT DE SOLVER ////////////////////////////////////////////

                    /**
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
                    **/

                    /////////////////////// CHANGEMENT DE SOLVER ////////////////////////////////////////////

                    /**
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
                    **/

                    /////////////////////// CHANGEMENT DE SOLVER ////////////////////////////////////////////

                    /**
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
                    **/

                    /////////////////////// CHANGEMENT DE SOLVER ////////////////////////////////////////////

                    /**
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
                    **/

                    /////////////////////// CHANGEMENT DE SOLVER ////////////////////////////////////////////

                    /**
                    //instruction next algo
                    Console.WriteLine("Résolution à la Norvig ");

                    SoverNorvig.SoverNorvig nor = new SoverNorvig.SoverNorvig();




                    //chrono start
                    stopwatch.Start();

                    s_6 = nor.Solve(s);

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
                    **/

                    /////////////////////// CHANGEMENT DE SOLVER ////////////////////////////////////////////

                    /**
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
                    **/

                    //Console.ReadLine();
                }

                void Sudoku_easy()
                {

                    Console.WriteLine("\n");
                    Console.WriteLine("  1. Genetic Solver");
                    Console.WriteLine("  2. ORToolsSolver");
                    Console.WriteLine("  3. Résolution par CSP ");
                    Console.WriteLine("  4. Résolution par SMT/Z3 ");
                    Console.WriteLine("  5. Résolution par Dancing_Links  ");
                    Console.WriteLine("  6. Résolution à la Norvig ");
                    Console.WriteLine("  7. Résolution par réseau de neurones convolués ");
                    Console.WriteLine("\n");


                    Noyau.Sudoku recup = new Sudoku();
                    String text;
                    int i, j;
                    i = 0;
                    j = 0;
                    int k = 0;
                    text = getLine("Sudoku_Easy50.txt", -1);
                    //Console.WriteLine(text);
                    char[] b = new char[text.Length];

                    using (StringReader sr = new StringReader(text))
                    {
                        while (k != 81)
                        {
                            if (j == 9)
                            {
                                i++;
                                j = 0;
                            }
                            // Read 13 characters from the string into the array.
                            sr.Read(b, 0, 1);
                            recup.SetCell(i, j, Int32.Parse(b));
                            //Console.WriteLine(b);

                            j++;
                            k++;

                        }
                    }




                    //declaration du chronometre
                    Stopwatch stopwatch = new Stopwatch();

                    //Noyau.Sudoku s = new Noyau.Sudoku();
                    Noyau.Sudoku s_1 = new Noyau.Sudoku();
                    Noyau.Sudoku s_2 = new Noyau.Sudoku();
                    Noyau.Sudoku s_3 = new Noyau.Sudoku();
                    Noyau.Sudoku s_4 = new Noyau.Sudoku();
                    Noyau.Sudoku s_5 = new Noyau.Sudoku();
                    Noyau.Sudoku s_6 = new Noyau.Sudoku();
                    Noyau.Sudoku s_7 = new Noyau.Sudoku();

                    var fitness = new SudokuFitness(recup);

                    int solution;

                    try

                    {

                        solution = int.Parse(Console.ReadLine());

                    }

                    catch (Exception e)

                    {

                        solution = -1;

                        Console.WriteLine("\n\n                Saisie invalide\n\n");

                    }

                    Console.WriteLine("Sudoku Easy :");
                    Console.WriteLine(recup.ToString());

                    Console.WriteLine("\n");
                    Console.WriteLine("******************************************************");
                    Console.WriteLine("\n");

                    switch (solution)
                    {
                        case 1:
                            Console.WriteLine("Genetic Solver");

                            GeneticSolver gs = new GeneticSolver();

                            //chrono start
                            stopwatch.Start();

                            s_1 = gs.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 2:
                            Console.WriteLine("\n");

                            Console.WriteLine("ORToolsSolver");

                            OrToolsSolver ots = new OrToolsSolver();

                            //chrono start
                            stopwatch.Start();

                            s_2 = ots.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 3:
                            //instruction next algo
                            Console.WriteLine("Résolution par CSP ");

                            //CSP csp = new CSP();

                            //chrono start
                            stopwatch.Start();

                            //s_3 = csp.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 4:
                            //instruction next algo
                            Console.WriteLine("Résolution par SMT /Z3 ");

                            //SMT smt = new SMT();

                            //chrono start
                            stopwatch.Start();

                            //s_4 = smt.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 5:
                            //instruction next algo
                            Console.WriteLine("Résolution par Dancing_Links  ");

                            //Dancing_Links dancing = new Dancing_Links();

                            //chrono start
                            stopwatch.Start();

                            //s_5 = dancing.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 6:
                            //instruction next algo
                            Console.WriteLine("Résolution à la Norvig ");

                            SoverNorvig.SoverNorvig nor = new SoverNorvig.SoverNorvig();

                            //chrono start
                            stopwatch.Start();

                            s_6 = nor.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 7:
                            //instruction next algo
                            Console.WriteLine(" Résolution par réseau de neurones convolués ");

                            //Neurones neur = new Neurones();

                            //chrono start
                            stopwatch.Start();

                            //s_7 = neur.Solve(recup);

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
                            break;
                    }

                    /**
                    Console.WriteLine("Genetic Solver");

                    GeneticSolver gs = new GeneticSolver();

                    //chrono start
                    stopwatch.Start();

                    s_1 = gs.Solve(recup);

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

                    s_2 = ots.Solve(recup);

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

                    SoverNorvig.SoverNorvig nor = new SoverNorvig.SoverNorvig();




                    //chrono start
                    stopwatch.Start();

                    s_6 = nor.Solve(recup);

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
        **/

                }

                void Sudoku_Hardest()
                {

                    Console.WriteLine("\n");
                    Console.WriteLine("  1. Genetic Solver");
                    Console.WriteLine("  2. ORToolsSolver");
                    Console.WriteLine("  3. Résolution par CSP ");
                    Console.WriteLine("  4. Résolution par SMT/Z3  ");
                    Console.WriteLine("  5. Résolution par Dancing_Links  ");
                    Console.WriteLine("  6. Résolution à la Norvig ");
                    Console.WriteLine("  7. Résolution par réseau de neurones convolués ");
                    Console.WriteLine("\n");

                    Noyau.Sudoku recup = new Sudoku();
                    String text;
                    int i, j;
                    i = 0;
                    j = 0;
                    int k = 0;
                    text = getLine("Sudoku_hardest.txt", -1);
                    //Console.WriteLine(text);
                    char[] b = new char[text.Length];

                    using (StringReader sr = new StringReader(text))
                    {
                        while (k != 81)
                        {
                            if (j == 9)
                            {
                                i++;
                                j = 0;
                            }
                            // Read 13 characters from the string into the array.
                            sr.Read(b, 0, 1);
                            recup.SetCell(i, j, Int32.Parse(b));
                            //Console.WriteLine(b);

                            j++;
                            k++;

                        }
                    }




                    //declaration du chronometre
                    Stopwatch stopwatch = new Stopwatch();

                    //Noyau.Sudoku s = new Noyau.Sudoku();
                    Noyau.Sudoku s_1 = new Noyau.Sudoku();
                    Noyau.Sudoku s_2 = new Noyau.Sudoku();
                    Noyau.Sudoku s_3 = new Noyau.Sudoku();
                    Noyau.Sudoku s_4 = new Noyau.Sudoku();
                    Noyau.Sudoku s_5 = new Noyau.Sudoku();
                    Noyau.Sudoku s_6 = new Noyau.Sudoku();
                    Noyau.Sudoku s_7 = new Noyau.Sudoku();

                    var fitness = new SudokuFitness(recup);
                    int solution;

                    try

                    {

                        solution = int.Parse(Console.ReadLine());

                    }

                    catch (Exception e)

                    {

                        solution = -1;

                        Console.WriteLine("\n\n                Saisie invalide\n\n");

                    }

                    Console.WriteLine("Sudoku Hardest :");
                    Console.WriteLine(recup.ToString());

                    Console.WriteLine("\n");
                    Console.WriteLine("******************************************************");
                    Console.WriteLine("\n");

                    switch (solution)
                    {
                        case 1:
                            Console.WriteLine("Genetic Solver");

                            GeneticSolver gs = new GeneticSolver();

                            //chrono start
                            stopwatch.Start();

                            s_1 = gs.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 2:
                            Console.WriteLine("\n");

                            Console.WriteLine("ORToolsSolver");

                            OrToolsSolver ots = new OrToolsSolver();

                            //chrono start
                            stopwatch.Start();

                            s_2 = ots.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 3:
                            //instruction next algo
                            Console.WriteLine("Résolution par CSP ");

                            //CSP csp = new CSP();

                            //chrono start
                            stopwatch.Start();

                            //s_3 = csp.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 4:
                            //instruction next algo
                            Console.WriteLine("Résolution par SMT /Z3 ");

                            //SMT smt = new SMT();

                            //chrono start
                            stopwatch.Start();

                            //s_4 = smt.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 5:
                            //instruction next algo
                            Console.WriteLine("Résolution par Dancing_Links  ");

                            //Dancing_Links dancing = new Dancing_Links();

                            //chrono start
                            stopwatch.Start();

                            //s_5 = dancing.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 6:
                            //instruction next algo
                            Console.WriteLine("Résolution à la Norvig ");

                            SoverNorvig.SoverNorvig nor = new SoverNorvig.SoverNorvig();

                            //chrono start
                            stopwatch.Start();

                            s_6 = nor.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 7:
                            //instruction next algo
                            Console.WriteLine(" Résolution par réseau de neurones convolués ");

                            //Neurones neur = new Neurones();

                            //chrono start
                            stopwatch.Start();

                            //s_7 = neur.Solve(recup);

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
                            break;
                    }

                    /**
                    Console.WriteLine("Genetic Solver");

                    GeneticSolver gs = new GeneticSolver();

                    //chrono start
                    stopwatch.Start();

                    s_1 = gs.Solve(recup);

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

                    s_2 = ots.Solve(recup);

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

                    SoverNorvig.SoverNorvig nor = new SoverNorvig.SoverNorvig();




                    //chrono start
                    stopwatch.Start();

                    s_6 = nor.Solve(recup);

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
                    **/
                }

                void Sudoku_Top95()
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("  1. Genetic Solver");
                    Console.WriteLine("  2. ORToolsSolver");
                    Console.WriteLine("  3. Résolution par CSP ");
                    Console.WriteLine("  4. Résolution par SMT /Z3 ");
                    Console.WriteLine("  5. Résolution par Dancing_Links  ");
                    Console.WriteLine("  6. Résolution à la Norvig ");
                    Console.WriteLine("  7. Résolution par réseau de neurones convolués ");
                    Console.WriteLine("\n");

                    Noyau.Sudoku recup = new Sudoku();
                    String text;
                    int i, j;
                    i = 0;
                    j = 0;
                    int k = 0;
                    text = getLine("Sudoku_top95.txt", -1);
                    //Console.WriteLine(text);
                    char[] b = new char[text.Length];

                    using (StringReader sr = new StringReader(text))
                    {
                        while (k != 81)
                        {
                            if (j == 9)
                            {
                                i++;
                                j = 0;
                            }
                            // Read 13 characters from the string into the array.
                            sr.Read(b, 0, 1);
                            recup.SetCell(i, j, Int32.Parse(b));
                            //Console.WriteLine(b);

                            j++;
                            k++;

                        }
                    }




                    //declaration du chronometre
                    Stopwatch stopwatch = new Stopwatch();

                    //Noyau.Sudoku s = new Noyau.Sudoku();
                    Noyau.Sudoku s_1 = new Noyau.Sudoku();
                    Noyau.Sudoku s_2 = new Noyau.Sudoku();
                    Noyau.Sudoku s_3 = new Noyau.Sudoku();
                    Noyau.Sudoku s_4 = new Noyau.Sudoku();
                    Noyau.Sudoku s_5 = new Noyau.Sudoku();
                    Noyau.Sudoku s_6 = new Noyau.Sudoku();
                    Noyau.Sudoku s_7 = new Noyau.Sudoku();

                    var fitness = new SudokuFitness(recup);

                    int solution;

                    try

                    {

                        solution = int.Parse(Console.ReadLine());

                    }

                    catch (Exception e)

                    {

                        solution = -1;

                        Console.WriteLine("\n\n                Saisie invalide\n\n");

                    }

                    Console.WriteLine("Sudoku Top 95 :");
                    Console.WriteLine(recup.ToString());

                    Console.WriteLine("\n");
                    Console.WriteLine("******************************************************");
                    Console.WriteLine("\n");

                    switch (solution)
                    {
                        case 1:
                            Console.WriteLine("Genetic Solver");

                            GeneticSolver gs = new GeneticSolver();

                            //chrono start
                            stopwatch.Start();

                            s_1 = gs.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 2:
                            Console.WriteLine("\n");

                            Console.WriteLine("ORToolsSolver");

                            OrToolsSolver ots = new OrToolsSolver();

                            //chrono start
                            stopwatch.Start();

                            s_2 = ots.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 3:
                            //instruction next algo
                            Console.WriteLine("Résolution par CSP ");

                            //CSP csp = new CSP();

                            //chrono start
                            stopwatch.Start();

                            //s_3 = csp.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 4:
                            //instruction next algo
                            Console.WriteLine("Résolution par SMT/Z3  ");

                            //SMT smt = new SMT();

                            //chrono start
                            stopwatch.Start();

                            //s_4 = smt.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 5:
                            //instruction next algo
                            Console.WriteLine("Résolution par Dancing_Links  ");

                            //Dancing_Links dancing = new Dancing_Links();

                            //chrono start
                            stopwatch.Start();

                            //s_5 = dancing.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 6:
                            //instruction next algo
                            Console.WriteLine("Résolution à la Norvig ");

                            SoverNorvig.SoverNorvig nor = new SoverNorvig.SoverNorvig();

                            //chrono start
                            stopwatch.Start();

                            s_6 = nor.Solve(recup);

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

                            Console.ReadLine();
                            break;

                        case 7:
                            //instruction next algo
                            Console.WriteLine(" Résolution par réseau de neurones convolués ");

                            //Neurones neur = new Neurones();

                            //chrono start
                            stopwatch.Start();

                            //s_7 = neur.Solve(recup);

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
                            break;
                    }


                    /**
                    Console.WriteLine("Genetic Solver");

                    GeneticSolver gs = new GeneticSolver();

                    //chrono start
                    stopwatch.Start();

                    s_1 = gs.Solve(recup);

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

                    s_2 = ots.Solve(recup);

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

                    SoverNorvig.SoverNorvig nor = new SoverNorvig.SoverNorvig();




                    //chrono start
                    stopwatch.Start();

                    s_6 = nor.Solve(recup);

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
        **/

                }
            } while(menu);

            }

   



        public static String getLine(string fileName, int index) //Récupère un String Sudoku d'un fichier
        {
            String[] lines = getFile(fileName);

            if (index < 0 || index >= lines.Length)
            {
                Random rnd = new Random();
                index = rnd.Next(lines.Length);
            }
            return lines[index];
        }
        

        public static String[] getFile(String fileName)  //Récupère tout les Sudokus d'un fichier 
        {
            DirectoryInfo myDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            String path = Path.Combine(myDirectory.Parent.Parent.Parent.FullName, fileName);
            String[] lines = File.ReadAllLines(path);
            return lines;
        }
 
    }
}