using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Life
    {
        int[,] cells;
        int columns;
        int rows;
        Random rnd = new Random();
        public Life(int row, int colums)
        {
            Debug.WriteLine("Init");
            this.columns = colums;
            this.rows = row;

            // Generates first structure
            cells = new int[row, colums];
        }

        public void initField()
        {
            for(int i = 0; i < this.rows; i++)
            {
                for(int j = 0; j < this.rows; j++)
                {
                    cells[i, j] = 0;
                }
            }

            int r = this.rows / 2;
            int c = this.columns / 2;

            cells[r, c] = 1;
            cells[r, c + 1] = 1;
            cells[r, c + 2] = 1;
            cells[r + 1, c + 2] = 1;
            cells[r + 2, c + 1] = 1;


            //       (r+2,c+1)
            //                 (r+1, c+2)
            // (r,c) (r  ,c+1) (r  , c+2)

            //for (int i = 0; i < 3000; i++)
            //{
            //    int r = rnd.Next(1, this.rows - 1);
            //    int c = rnd.Next(1, this.columns - 1);
            //    cells[r, c] = true;
            //    if (rnd.Next(1, 5) == 1)
            //    {
            //        cells[r + 1, c] = true;
            //        cells[r - 1, c] = true;
            //        cells[r, c + 1] = true;
            //    }
            //}
        }

        /**
         * Returns the current state of a requestet state
         * returns an integer from 0 - 3
         */
        public int cellState(int row, int column)
        {
            // Debug.WriteLine("IsAlive");
            return cells[row, column];
        }

        public void Update()
        {
            /**
             * TODO:
             * check 8 arround the testing cell
             * r - 1 & r + 1 & c - 1 => r + 1 & c + 1
             * ---------------------------------------
             * Has 3 living cells arround return true
             * Has 2 living cells arround return false
             * Has 8 Living cells arround return false
             */

            int alive = 0;
            //Debug.WriteLine(alive + " alive variable value");

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    //Debug.WriteLine("Current: col: " + column + " row: " + row);
                    alive = 0;
                    // tracks the status of a given surrounding cell
                    for (int r = (row - 1); r <= (row + 1); r++)
                    {
                        for (int c = (column - 1); c <= (column + 1); c++)
                        {
                            // bounds check
                            if (r < rows && r >= 0 && c < columns && c >= 0)
                            {
                                // Prevent the logic from counting itself
                                if (r != row || c != column)
                                {
                                    // is surroundin cell allive?
                                    //Debug.WriteLine("Current: col: " + c + " row: " + r);
                                    if (cells[r, c] == 1 || cells[r, c] == 2)
                                    {
                                        //Debug.WriteLine(alive + " Alive Before Change");
                                        alive++;
                                        //Debug.WriteLine("neighbours alive: " + alive); // this still does not count out of its scope
                                    }
                                }
                            }
                        }
                    }

                    // if the cell is allive and conditions meet keep it so
                    // if the cell is dead and conditions meet let it be born
                    // Debug.WriteLine(this.alive + " Neighbours Alive");

                    /*
                     * 0: dead
                     * 1: alive
                     * 2: dying
                     * 3: reviving
                     */

                    // execute next gen states
                    if (cells[row, column] == 2)
                    {
                        cells[row, column] = 0;
                    }
                    else if (cells[row, column] == 3)
                    {
                        cells[row, column] = 1;
                    }

                    // check and catch now states
                    if (cells[row,column] == 1)
                    {
                        if(alive < 2) 
                        {
                            if (cells[row, column] == 1)
                            {
                                cells[row, column] = 2;
                            }
                        } else if(alive > 3)
                        {
                            if (cells[row, column] == 1)
                            {
                                cells[row, column] = 2;
                            }
                        }
                    } else if(cells[row,column] == 0)
                    {
                        if(alive == 3)
                        {
                            cells[row, column] = 3;
                        }
                    }
                }
            }
        }
    }
}
