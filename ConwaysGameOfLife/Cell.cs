using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Cell : Board
    {
        private Cell[,] cells;
        private int height;
        private int width;

        public int X { get; set; }
        public int Y { get; set; }

        public bool IsAlive { get; set; }
        public Cell()
        {
            
        }
        
        //this is a test
        public void Tick()
        {
            throw new NotImplementedException();
        }

        public List<List<bool>> ToList()
        {
            throw new NotImplementedException();
        }

        internal int Checkneighbors(int row, int column)
        {
            Cell currentCell = cells[row, column];
            bool currentCellBool = currentCell.IsAlive;
            bool topLeft = cells[row + 1, column - 1].IsAlive;
            bool topTop = cells[row + 1, column].IsAlive;
            bool topRight = cells[row + 1, column + 1].IsAlive;
            bool left = cells[row, column - 1].IsAlive;
            bool right = cells[row, column + 1].IsAlive;
            bool bottomLeft = cells[row - 1, column - 1].IsAlive;
            bool bottomBottom = cells[row - 1, column].IsAlive;
            bool bottomRight = cells[row - 1, column + 1].IsAlive;
            int trueNeighbors = 0;

            List<bool> all = new List<bool>
            {
                topLeft, topTop, topRight, left, right, bottomLeft, bottomBottom, bottomRight
            };

            for (int k = 0; k < all.Count; k++)
            {
                if (all[k] == true)
                {
                    trueNeighbors++;
                }
            }
            return trueNeighbors;
        }
        }
}
