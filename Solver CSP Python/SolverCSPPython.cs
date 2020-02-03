using Noyau;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solver_CSP_Python
{
    public class SolverCSPPython : ISudokuSolver
    {
        public Sudoku Solve(Sudoku s)
        {

            using (Py.GIL())
            {

                using (PyScope scope = Py.CreateScope())
                {
                    // convert the sudoku object to a PyObject
                    PyObject pySudoku = s.ToPython();

                    // create a Python variable "sudoku"
                    scope.Set("sudoku", pySudoku);

                    // the sudoku object may now be used in Python
                    string code = "fullName = person.FirstName + ' ' + person.LastName";
                    scope.Exec(code);
                    s = scope.Get<Sudoku>("sudoku");
                }


                return s;
                // PythonEngine.Exec("doStuff()");
            }

        }
    }
}
