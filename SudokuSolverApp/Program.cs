using SudokuSolverApp.SolveAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                SudokuBlock sudokuBlock = new SudokuBlock();
                SudokuState sudokuState = new SudokuState();
                SudokuSolver sudokuSolver = new SudokuSolver(sudokuState, sudokuBlock);
                SodokuFileReader sodokuFileReader = new SodokuFileReader();
                SudokuASCII sudokuASCII = new SudokuASCII();

                var file = "Sudoku.txt";

                var sudokuBoard = sodokuFileReader.ReadFile(file);
                sudokuASCII.DisplayBoard("Unsolved Puzzle", sudokuBoard);

                bool SudokuSolved = sudokuSolver.IsSolved(sudokuBoard);
                sudokuASCII.DisplayBoard("Solved Puzzle", sudokuBoard);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            }
    }
}
