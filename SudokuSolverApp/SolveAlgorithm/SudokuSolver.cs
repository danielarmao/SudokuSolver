using SudokuSolverApp.SolveAlgorithm;
using SudokuSolverApp;
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
            _sudokuState = sudokuState;
            _sudokuBlock = sudokuBlock;
        }


        public bool IsSolved(int[,] sudokuBoard)
        {
            List<ISudoku> strategies = new List<ISudoku>();
            {
                new BruteForce(_sudokuBlock);
               
            }

            var currentState = _sudokuState.State(sudokuBoard);
            var nextState = _sudokuState.State(strategies.FirstOrDefault().IsSolved(sudokuBoard));

            while (!_sudokuState.SudokuSolved(sudokuBoard) && currentState != nextState)
            {
                currentState = nextState;
                for (int i = 0; i < strategies.Count; i++)
                {
                    ISudoku strategy = strategies[i];
                    nextState = _sudokuState.State(strategy.IsSolved(sudokuBoard));
                }
            }

            return _sudokuState.SudokuSolved(sudokuBoard);
        }
    }
}
