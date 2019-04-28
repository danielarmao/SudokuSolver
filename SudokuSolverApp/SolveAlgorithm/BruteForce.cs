﻿using SudokuSolverApp.SolveAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverApp.SolveAlgorithm
{
    //Class finds all possibilities for each row and column.
    class BruteForce : ISudoku
    {
        private int[] elements = { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; //Initalize an array over numbers 1 to 9
        private readonly SudokuBlock _sudokuBlock;

        public BruteForce(SudokuBlock sudokuBlock)
        {
            this._sudokuBlock = sudokuBlock;
        }



        int[,] ISudoku.Matrix(int[,] sudokuBoard)
        {
            throw new NotImplementedException();
        }

        public int[,] SudokuSolved(int[,] sudokuBoard)
        {
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int col = 0; row < sudokuBoard.GetLength(1); col++)
                {
                    if (sudokuBoard[row, col] == 0 || sudokuBoard[row, col].ToString().Length > 1)
                    {
                        //initalize our brute force strategy.
                        var rc = GetRow_Col(sudokuBoard, row, col);
                        var Block = GetBlock(sudokuBoard, row, col);
                        sudokuBoard[row, col] = GetMatrix(rc, Block);

                    }

                }
            }
            return sudokuBoard;
        }

        private int GetRow_Col(int[,] sudokuBoard, int GetRow, int GetCol)
        {


            for (int col = 0; col < 9; col++) //index by column
            {
                if (ValidAnswer(sudokuBoard[GetRow, col])) //If we find a Valid Single it will be sent to the ValidAnswer method to check
                {
                    elements[sudokuBoard[GetRow, col] - 1] = 0; //If confirmed a valid single set it to 0
                }
            }

            for (int row = 0; row < 9; row++) //index by row
            {
                if (ValidAnswer(sudokuBoard[row, GetCol]))
                {
                    elements[sudokuBoard[row, GetCol] - 1] = 0;
                }
            }
            return Convert.ToInt32(String.Join(string.Empty, elements
                .Select(e => e)
                .Where(e => e != 0))); //puts arrays together and selects any element that is not 0 (LINQ)
        }

        private int GetBlock(int[,] sudokuBoard, int GetRow, int GetCol)
        {
            SudokuData sudokuBlock = _sudokuBlock.Find(GetRow, GetCol); //We are calling sudokuBlock to isolate by block.

            for (int row = sudokuBlock.SetRow; row <= sudokuBlock.SetRow + 2; row++) //indexing by block by only going 2 over (0 -> 1-> 2)
            {
                for (int col = sudokuBlock.SetCol; col <= sudokuBlock.SetCol + 2; col++)
                {
                    if (ValidAnswer(sudokuBoard[row, col]))
                    {
                        elements[sudokuBoard[row, col] - 1] = 0; 
                    }
                }
            }
            return Convert.ToInt32(String.Join(string.Empty, elements
                .Select(e => e)
                .Where(e => e != 0)));
        }

       


        private int GetMatrix(int rc, int Block) //put it all together
        {
            var rcArray = rc.ToString().ToCharArray();
            var BlockArray = Block.ToString().ToCharArray();
            var matrixArray = rcArray.Intersect(BlockArray); //LINQ Intersect so we can put the rol/col Array and block Array together(intersected)
            return Convert.ToInt32(string.Join(string.Empty, matrixArray));
        }

        private bool ValidAnswer(int v)
        {
            return v != 0 && v.ToString().Length < 2; //A Valid Single goes by these conditions
        }

    }
}