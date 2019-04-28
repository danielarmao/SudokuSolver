using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SudokuSolverApp { 

    class SodokuFileReader
    {
        public int[,] ReadFile(string filename)
        {
            //initalize rows and columns
            int row = 0;

            int[,] sudokuBoard = new int[9, 9]; //initalize a 2D matrix of 9 rows and 9 columns

            try
            {
                string[] sudokuBoardLine = File.ReadAllLines(filename);

                //Go through each line of the file.
                for (int i = 0; i < sudokuBoardLine.Length; i++)
                {
                    string horizontalLine = sudokuBoardLine[i];
                    string[] sudokuBoardNumbers = horizontalLine.Split('|').Skip(1).Take(9).ToArray(); //splitting a string into an array by delimiter
                                                                                                       //and take the numbers and put them into an Array.
                    int col = 0;
                    for (int j = 0; j < sudokuBoardNumbers.Length; j++)
                    {
                        string spaces = sudokuBoardNumbers[j];
                        sudokuBoard[row, col] = spaces.Equals(" ") ? 0 : Convert.ToInt32(spaces); //Popping 0s in empty spaces.
                        col++;
                    }
                    row++; //when a column is complete go to the next row.
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Check files for errors: " + ex.Message);
            }
            return sudokuBoard;
        }
    }
}






