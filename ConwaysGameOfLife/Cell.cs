using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Cell : Board
    {
        private Cell[,] cells;
        private int height;
        private int width;

        public bool IsAlive { get; set; }
        public Cell()
        {
            
        }
        

        public void Tick()
        {
            throw new NotImplementedException();
        }

        public List<List<bool>> ToList()
        {
            throw new NotImplementedException();
        }

        
    }
}
