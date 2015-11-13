using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConwaysGameOfLife
{
    public class RealGOL : Board
    {    
        private Cell[,] cells; //could set this to public and not need the getter and setter
        private Cell[,] initialBoard;
        private Cell[,] convertedBoard;

        public int Height { get; set; }
        public int Width { get; set; }

        public RealGOL(int width, int height)
        {
            cells = new Cell[height, width];
            Width = width;
            Height = height;
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    cells[row, col] = new Cell();
                }
            }
        }
        public Cell[,] Board()
        {
            return cells;
        }

        public void SetBoard(int row, int column, bool set)
        {
            Cell cell = cells[row, column];
            cell.IsAlive = set;
        }

        public RealGOL()
        {
        }
       
        public int CheckNeighbors(int row, int column)
        {
            int trueNeighbors = 0;

            Cell currentCell = cells[row, column];
            bool currentCellBool = currentCell.IsAlive;
            if ((row - 1) >= 0 && (row - 1) <= this.Width && (column - 1) >=0 && (column - 1) <= this.Height )
            {
                bool topLeft = cells[row + 1, column - 1].IsAlive;
                bool topTop = cells[row + 1, column].IsAlive;
                bool topRight = cells[row + 1, column + 1].IsAlive;
                bool left = cells[row, column -1].IsAlive;
                bool right = cells[row, column + 1].IsAlive;
                bool bottomLeft = cells[row - 1, column - 1].IsAlive;
                bool bottomBottom = cells[row - 1, column].IsAlive;
                bool bottomRight = cells[row - 1, column + 1].IsAlive;

                List<bool> all = new List<bool>
                {
                    topLeft, topTop, topRight, left, right, bottomLeft, bottomBottom, bottomRight
                };

                for (int k = 0; k < all.Count(); k++)
                {
                    if (all[k] == true)
                    {
                        trueNeighbors++;
                    }
                }
            } 
            return trueNeighbors;
        }

        public List<List<bool>> ToList()
    {
        throw new NotImplementedException();
    }
    public void Tick ()
        {
            OldTick(cells);
        }

    public Cell[,] OldTick(Cell[,] initialBoard)
    {
            convertedBoard = RulesToBoard(initialBoard);
            return convertedBoard;
        }

    public bool ApplyRules(bool AliveOrDead,  int liveNeighbors)
    {
        if (AliveOrDead == true && (liveNeighbors <2 || liveNeighbors > 3))
        {
            return false;
        } else if (AliveOrDead == true && (liveNeighbors == 2 || liveNeighbors == 3))
        {
            return true;
        }else if (AliveOrDead == false && liveNeighbors == 3)
        {
            return true;
        }else
        {
            return false;
        }
    }

        public Cell[,] RulesToBoard(Cell[,] initialBoard)
        {
            Cell[,] gameBoard = initialBoard;
            
            
            foreach (Cell i in gameBoard)
            {
                bool currentCellBool = i.IsAlive;
                int numberofNeighbors = CheckNeighbors(i.X, i.Y);
                bool newCellState = ApplyRules(currentCellBool, numberofNeighbors);
                SetBoard(i.X, i.Y, newCellState);
            }
            return gameBoard;
        }
    }
}
