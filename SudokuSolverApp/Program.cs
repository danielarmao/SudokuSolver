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

            {
                SudokuBlock sudokuBlock = new SudokuBlock();
                SudokuState sudokuState = new SudokuState();
                SudokuSolver sudokuSolver = new SudokuSolver(sudokuState, sudokuBlock);
                SodokuFileReader sodokuFileReader = new SodokuFileReader();
                SudokuASCII sudokuASCII = new SudokuASCII();

                string file = "Sudoku.txt";
                
                var sudokuBoard = sodokuFileReader.ReadFile(file);
                sudokuASCII.DisplayBoard ("Unsolved Board",sudokuBoard);

                bool SudokuSolved = sudokuSolver.IsSolved(sudokuBoard);
                sudokuASCII.DisplayBoard("Solved Board",sudokuBoard);

            }

        }
    }
}
    

