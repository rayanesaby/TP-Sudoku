
using System.Collections.Generic;
using Noyau;

namespace genetic_solver
{
    /// <summary>
    /// Each type of chromosome for solving a sudoku is simply required to output a list of candidate sudokus
    /// </summary>
    public interface ISudokuChromosome
    {
        IList<Sudoku> GetSudokus();
    }
}