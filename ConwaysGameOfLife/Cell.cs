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

       
        }
}
