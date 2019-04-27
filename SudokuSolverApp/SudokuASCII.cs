using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverApp
{
    class SudokuASCII
    {
        public void DisplayBoard(int [,] sudokuBoard)
        {
            for (int row=0; row < sudokuBoard.GetLength(0); row++) //Grab the first dimension of a 2D Array.
            {
                Console.WriteLine("|");
                for (int col = 0; row < sudokuBoard.GetLength(1); col++) //2nd dimension
                {
                    Console.WriteLine("{0}{1}", sudokuBoard[row, col], "|"); //Creating the board
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
