using System;
using System.Collections.Generic;
using System.Text;
using Noyau;
using Google.OrTools.LinearSolver;


namespace ORToolsSolver
{
    public class OrToolsSolver : ISudokuSolver
    {
        public Sudoku Solve(Sudoku s)
        {
            //adapter le code pourque la variable sudoku fonctionne et coder la function cellVar(i,j,k)  = 1 si la case ij prend la valeur k 
            // is a boolean variable, equal to 1 if grid cell (i,j) takes value k,
            // 0 otherwise.
            var solver = LinearOptimizationService.createEngine();
            var sheet = SpreadsheetApp.getActiveSpreadsheet();
            var size = input.length;
            var blockSize = Math.sqrt(size);
            if (blockSize * blockSize != size)
            {
                throw 'Grid size must be the square of a number';
            }
            var width = s[0].length;
            if (size != width)
            {
                throw 'Grid must be a square';
            }
            // Variables
          
            for (var i = 0; i < size; ++i)
            {
                for (var j = 0; j < size; ++j)
                {
                    // Each cell can only take a single value:
                    // for all (i,j) in (rows, columns), Sum(k)cellVar(i,j,k) == 1
                    var uniqueValueCt = solver.addConstraint(1, 1);
                    for (var k = 1; k <= size; ++k)
                    {
                        // var(i,j,k) == 1 <=> cell(i,j) == k
                        if (s[i][j])
                        {
                            if (s[i][j] == k)
                            {
                                solver.addVariable(cellVar(i, j, k), 1, 1, LinearOptimizationService.VariableType.INTEGER);
                            }
                            else
                            {
                                solver.addVariable(cellVar(i, j, k), 0, 0, LinearOptimizationService.VariableType.INTEGER);
                            }
                        }
                        else
                        {
                            solver.addVariable(cellVar(i, j, k), 0, 1, LinearOptimizationService.VariableType.INTEGER);
                        }
                        uniqueValueCt.setCoefficient(cellVar(i, j, k), 1);
                    }
                }
            }
            // Constraints: each value appears once one each row, column and sub-block.
            for (var i = 0; i < size; ++i)
            {
                for (var k = 1; k <= size; ++k)
                {
                    // Values appear once in each row:
                    // for all i in rows, k in values, Sum(j)cellVar(i,j,k) == 1
                    var oncePerRowCt = solver.addConstraint(1, 1);
                    // Values appear once in each column:
                    // for all i in columns, k in values, Sum(j)cellVar(j,i,k) == 1
                    var oncePerColumnCt = solver.addConstraint(1, 1);
                    for (var j = 0; j < size; ++j)
                    {
                        oncePerRowCt.setCoefficient(cellVar(i, j, k), 1);
                        oncePerColumnCt.setCoefficient(cellVar(j, i, k), 1);
                    }
                }
            }
            for (var i = 0; i < blockSize; ++i)
            {
                for (var j = 0; j < blockSize; ++j)
                {
                    for (var k = 1; k <= size; ++k)
                    {
                        // Values appear once in each sub-block:
                        // for each block(i,j),
                        // Sum(blockRow,blockColumn,k)cellVar(i * blockSize + blockRow, j * blockSize + blockColumn, k) == 1
                        var oncePerBlockCt = solver.addConstraint(1, 1);
                        for (var blockRow = 0; blockRow < blockSize; ++blockRow)
                        {
                            for (var blockColumn = 0; blockColumn < blockSize; ++blockColumn)
                            {
                                oncePerBlockCt.setCoefficient(cellVar(i * blockSize + blockRow, j * blockSize + blockColumn, k), 1);
                            }
                        }
                    }
                }
            }
            // Solve the Sudoku grid.
            var solution = solver.solve(5);
            var status = solution.getStatus();
            if (status != LinearOptimizationService.Status.FEASIBLE && status != LinearOptimizationService.Status.OPTIMAL)
            {
                // If the remote Linear Optim Service fails, try to solve locally.
                if (status != LinearOptimizationService.Status.INFEASIBLE)
                {
                    return solveLocal(s);
                }
                return null;
            }

            // Output solution.
            var out = [];
            for (var i = 0; i < size; ++i)
            {
                var row = []
              for (var j = 0; j < size; ++j)
                {
                    for (var k = 1; k <= size; ++k)
                    {
                        if (Math.round(solution.getVariableValue(cellVar(i, j, k))) == 1)
                        {
                            row.push(k);
                            break;
                        }
                    }
                }
    out.push(row);
            }
            return out;









        }
    }
}
