using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SudokuSolverApp.SudokuWorker
{
    class FileRead
    {
        public int[,] ReadFile(string filename)
        {
            //initalize rows and columns
            int row = 0;
            int col = 0;
            int[,] sudokuBoard = new int[9, 9]; //initalize a 2D array of 9 rows and 9 columns

            //Go through a textfile
            var sudokuBoardLine = File.ReadAllLines(filename);

            //Go through each line of the file.
            foreach (var horizontalLine in sudokuBoardLine)
            {
                string [] sudokuBoardNumbers = horizontalLine.Split('|').Skip(1).Take(9).ToArray(); //splitting a string into an array by delimiter | 
                //and take only the numbers and put them into an Array.

                foreach (var matrix in sudokuBoardNumbers)
                {
                    sudokuBoard[row, col] = matrix.Equals(" ") ? 0 : Convert.ToInt32(matrix);
                    col++; //Popping 0s in empty spaces.
                }
                row++; //when a column is complete go to the next row.
            }
            return sudokuBoard;
        }
    }
}
        




