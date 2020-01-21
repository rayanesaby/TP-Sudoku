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

         

            return Eval(s,5000,0,100);
        }

        public static Sudoku Eval( Sudoku sudoku, int populationSize, double fitnessThreshold, int generationNb)
        {

            IChromosome chromosome = new SudokuPermutationsChromosome(sudoku);
            var fitness = new SudokuFitness(sudoku);
            var selection = new EliteSelection();
            var crossover = new UniformCrossover();
            var mutation = new UniformMutation();

            var population = new Population(populationSize, populationSize, chromosome);
            var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation)
            {
                Termination = new OrTermination(new ITermination[]
                {
                    new FitnessThresholdTermination(fitnessThreshold),
                    new GenerationNumberTermination(generationNb)
                })
            };

            ga.Start();

            var bestIndividual = ((ISudokuChromosome)ga.Population.BestChromosome);
            var solutions = bestIndividual.GetSudokus();
   
            return solutions[0];
        }
    }
}
