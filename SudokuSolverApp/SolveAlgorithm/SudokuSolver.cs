using SudokuSolverApp.SolveAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverApp.SolveAlgorithms
{
    class SudokuSolver
    {
        private readonly SudokuState _sudokuState;
        private readonly SudokuBlock _sudokuBlock;

        public SudokuSolver(SudokuState sudokuState, SudokuBlock sudokuBlock)
        {
            this._sudokuState = sudokuState;
            this._sudokuBlock = sudokuBlock;
        }


        public bool IsSolved(int[,] sudokuBoard)
        {
            List<ISudoku> algorithms = new List<ISudoku>();
            {
                new BruteForce(_sudokuBlock);
            }


            string startState = _sudokuState.State(sudokuBoard); //Once file is loaded generate state
            string finishState = _sudokuState.State(algorithms.First().Matrix(sudokuBoard)); //Next state is when the algorithm runs and the ending board is shown.

            //If Sudoku board is not solved the loop will keep running otherwise print out the ending State. 
            while (!_sudokuState.SudokuSolved(sudokuBoard) && startState !=finishState)
            {
                startState = finishState;
                for (int i = 0; i < algorithms.Count; i++)
                {
                    ISudoku a = algorithms[i];
                    finishState = _sudokuState.State(a.Matrix(sudokuBoard));
                }
            }

            return _sudokuState.SudokuSolved(sudokuBoard); 
        }
    }
}
