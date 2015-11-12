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
        private int numberTrue;
        private int height;
        private int width;
        private bool result;

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
            Cell currentCell = cells[row, column];
            bool currentCellBool = currentCell.IsAlive;
            bool topLeft = cells[row + 1, column - 1].IsAlive;
            bool topTop = cells[row + 1, column].IsAlive;
            bool topRight = cells[row + 1, column + 1].IsAlive;
            bool left = cells[row, column -1].IsAlive;
            bool right = cells[row, column + 1].IsAlive;
            bool bottomLeft = cells[row - 1, column - 1].IsAlive;
            bool bottomBottom = cells[row - 1, column].IsAlive;
            bool bottomRight = cells[row - 1, column + 1].IsAlive;
            int trueNeighbors = 0;

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
            return trueNeighbors;
        }

        public List<List<bool>> ToList()
    {
        throw new NotImplementedException();
    }

    public void Tick(RealGOL initialBoard)
    {
            RealGOL convertedBoard = new RealGOL();
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

        public RealGOL RulesToBoard(RealGOL initialBoard)
        {
            //need to run ApplyRules to every cell and store the results into convertedBoard
            RealGOL convertedBoard = new RealGOL();
            Cell[,] board = initialBoard.Board();

            foreach (Cell i in board)
            {
                int row = 0;
                int column = 0;
                bool currentCellBool = i.IsAlive;
                int numberofNeighbors = i.Checkneighbors(row, column);
                bool newCellState = ApplyRules(currentCellBool, numberofNeighbors);
                convertedBoard.SetBoard(row, column, newCellState);



            }
            //int row = 0;
            //int column = 0;
            //Cell[,] board = initialBoard.Board();
            //Cell currentCell = board[row, column];
            //bool currentCellBool = currentCell.IsAlive;

            //foreach (Cell i in board)
            //{
            //    int liveNeighbors = board.CheckNeighbors(row, column);
            //    Cell rulesApplied = ApplyRules(currentCellBool, liveNeighbors);
            //    bool newCellState = rulesApplied.
            //    //somehow add result to convertedBoard
            //    convertedBoard.SetBoard(row, column, newCellState);
            //}
            return convertedBoard;
        }
    }
}
