using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverApp
{

    class SudokuState
    {

        public string State(int[,] sudokuBoard)
        {
            
            StringBuilder key = new StringBuilder(); //Using StringBuilder to be able to use Append()
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int col = 0; row < sudokuBoard.GetLength(1); col++)
                {
                    key.Append(sudokuBoard[row, col]); //Calculate the current state of the sudoku board.
                }
            }

            return key.ToString();
        }

        public bool SudokuSolved(int[,] sudokuBoard)
        {
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int col = 0; row < sudokuBoard.GetLength(1); col++)
                {
                    if (sudokuBoard[row, col] == 0 || sudokuBoard[row, col].ToString().Length > 1) //Requirements of not solving the Board.
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
   

                    

