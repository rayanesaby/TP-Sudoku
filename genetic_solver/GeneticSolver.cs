using System;
using System.Linq;
using GeneticSharp;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using genetic_solver;
using Noyau;

namespace genetic_solver
{
    public class GeneticSolver: ISudokuSolver
    {
        public GeneticSolver()
        {
        }

        public Sudoku Solve(Sudoku s)
        {
            //Working parameters : Pop = 1000 , ite = 500
            return Eval(s,150,0,500);
        }

        public static Sudoku Eval( Sudoku sudoku, int populationSize, double fitnessThreshold, int generationNb)
        {
            //creation du chromosome
            IChromosome chromosome = new SudokuPermutationsChromosome(sudoku);

            //variable qui indique l'erreure
            var fitness = new SudokuFitness(sudoku);

            //choix de la selection : ici elite
            var selection = new EliteSelection();

            //Choix du crossover : ici uniform
            var crossover = new UniformCrossover();

            //choix de la mutation : ici uniform
            var mutation = new UniformMutation();

            //creation de la population
            var population = new Population(populationSize, populationSize, chromosome);

            //création de l'algo génétique
            var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation)
            {
                //pour mettre fin a l'exec si on atteint le threshold ou le nombre de rep fixé
                Termination = new OrTermination(new ITermination[]
                {
                    new FitnessThresholdTermination(fitnessThreshold),
                    new GenerationNumberTermination(generationNb)
                })
            };

            ga.Start();

            //recupétaion de la meilleure solution
            var bestIndividual = ((ISudokuChromosome)ga.Population.BestChromosome);
            var solutions = bestIndividual.GetSudokus();

            return solutions[0];
        }
    }
}
