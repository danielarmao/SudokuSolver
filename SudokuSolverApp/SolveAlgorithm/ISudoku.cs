using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverApp.SolveAlgorithms
{
    interface ISudoku
    {
        int[,] Matrix(int[,] sudokuBoard); 
    }
}
