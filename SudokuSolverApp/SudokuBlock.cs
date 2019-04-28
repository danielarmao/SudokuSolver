using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolverApp;

namespace SudokuSolverApp
{
    //This class is to determine where we are in a sudoku puzzle. Determine our sudoku "block"
    class SudokuBlock
    {
        public SudokuData Find(int Row, int Col)
        {
            SudokuData sData = new SudokuData();

            //Note: Array starts at 0 the block matrixes are all 3x3. We are to satisfy a full matrix of 9x9

            //Our first block is the the top left hand side. It is the block that starts on Row 0 and ends on Row 2. Starts on Col 2 and ends on Col 2.
            if ((Row>=0 && Row <=2) && (Col >= 0 && Col <= 2))
            {
                sData.SetRow = 0;
                sData.SetCol = 0;
            }
            //The 2nd Block That is the next few columns over. And so on...
            else if ((Row >= 0 && Row <= 2) && (Col >= 3 && Col <= 5))
            {
                sData.SetRow = 0;
                sData.SetCol = 3;
            }
            else if ((Row >= 0 && Row <= 2) && (Col >= 6 && Col <= 8))
            {
                sData.SetRow = 0;
                sData.SetCol = 6;
            }
            else if ((Row >= 3 && Row <= 5) && (Col >= 0 && Col <= 2))
            {
                sData.SetRow = 3;
                sData.SetCol = 0;
            }
            else if ((Row >= 3 && Row <= 5) && (Col >= 3 && Col <= 5))
            {
                sData.SetRow = 3;
                sData.SetCol = 3;
            }
            else if ((Row >= 3 && Row <= 5) && (Col >= 6 && Col <= 8))
            {
                sData.SetRow = 3;
                sData.SetCol = 6;
            }
            else if ((Row >= 6 && Row <= 8) && (Col >= 0 && Col <= 2))
            {
                sData.SetRow = 6;
                sData.SetCol = 0;
            }
            else if ((Row >= 6 && Row <= 8) && (Col >= 3 && Col <= 5))
            {
                sData.SetRow = 6;
                sData.SetCol = 3;
            }
            else if ((Row >= 6 && Row <= 8) && (Col >= 6 && Col <= 8))
            {
                sData.SetRow = 6;
                sData.SetCol = 6;
            }

            return sData;
        }
    }
}
