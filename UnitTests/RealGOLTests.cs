using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ConwaysGameOfLife;


namespace UnitTests
{
    [TestClass]
    public class RealGOLTests
    {
        [TestMethod]
        public void ICanCreateAWorld()
        {
            RealGOL my_world = new RealGOL();
            Assert.IsNotNull(my_world);
        }    

        [TestMethod]
        public void BoundedWorldEnsureIHaveArrayOfCorrectSize()
        {
            int height = 80;
            int width = 80;
            RealGOL my_world = new RealGOL(width, height);
            int actual_height = my_world.Height;
            int actual_width = my_world.Width;
            int expected_height = height;
            int expected_width = width;
            Assert.AreEqual(expected_height, actual_height);
            Assert.AreEqual(expected_width, actual_width);
        }

        [TestMethod]
        public void FirstCellExists()
        {
            int height = 80;
            int width = 80;
            RealGOL my_world = new RealGOL(width, height);
            Cell[,] board = my_world.Board();
            Cell first_cell = board[0, 0];
            bool actual = first_cell.IsAlive;
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CanSetTheFirstCell()
        {
            int height = 80;
            int width = 80;
            RealGOL my_world = new RealGOL(width, height);
            my_world.SetBoard(0, 0, true);
            Cell[,] board = my_world.Board();
            Cell first_cell = board[0, 0];
            bool actual = first_cell.IsAlive;
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CanSetAMiddleCell()
        {
            int height = 80;
            int width = 80;
            RealGOL my_world = new RealGOL(width, height);
            Cell[,] board = my_world.Board();
            Cell middle_cell = board[33, 45];
            my_world.SetBoard(33, 45, true);
            bool actual = middle_cell.IsAlive;
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountingHowManyNeighborsAreAliveWithOneAliveNeighbor()
        {
            int height = 6;
            int width = 6;
            RealGOL my_world = new RealGOL(width, height);
           // Cell[,] board = my_world.Board();
            int row = 2;
            int column = 1;
            my_world.SetBoard(2, 2, true);
            int actual = my_world.CheckNeighbors(row, column);
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountingHowManyNeighborsAreAliveWithTwoAliveNeighbor()
        {
            int height = 6;
            int width = 6;
            RealGOL my_world = new RealGOL(width, height);
            // Cell[,] board = my_world.Board();
            int row = 2;
            int column = 1;
            my_world.SetBoard(2, 2, true);
            my_world.SetBoard(1, 0, true);
            int actual = my_world.CheckNeighbors(row, column);
            int expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountingHowManyNeighborsAreAliveWithThreeAliveNeighbor()
        {
            int height = 6;
            int width = 6;
            RealGOL my_world = new RealGOL(width, height);
            int row = 2;
            int column = 1;
            my_world.SetBoard(2, 2, true);
            my_world.SetBoard(1, 0, true);
            my_world.SetBoard(3, 0, true);
            int actual = my_world.CheckNeighbors(row, column);
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ALiveCellWithLessThanTwoLiveNeighborsDies()
        {
            int height = 6;
            int width = 6;
            RealGOL my_world = new RealGOL(width, height);
            int row = 2;
            int column = 2;
            Cell[,] board = my_world.Board();
            Cell currentCell = board[2, 2];
            bool toTest = currentCell.IsAlive;
            my_world.SetBoard(2, 2, true);
            int liveNeighbors = my_world.CheckNeighbors(row, column);
            bool liveOrDie = my_world.ApplyRules(toTest, liveNeighbors);
            Assert.IsFalse(liveOrDie);
        }

        [TestMethod]
        public void ALiveCellWithMoreThanThreeLiveNeighborsDies()
        {
            int height = 6;
            int width = 6;
            RealGOL my_world = new RealGOL(width, height);
            Cell[,] board = my_world.Board();
            Cell currentCell = board[2, 2];
            bool toTest = currentCell.IsAlive;
            my_world.SetBoard(2, 2, true);
            my_world.SetBoard(1, 1, true);
            my_world.SetBoard(1, 3, true);
            my_world.SetBoard(3, 1, true);
            my_world.SetBoard(3, 3, true);
            int row = 2;
            int column = 2;
            int liveNeighbors = my_world.CheckNeighbors(row, column);
            bool liveOrDie = my_world.ApplyRules(toTest, liveNeighbors);
            Assert.IsFalse(liveOrDie);
        }

        [TestMethod]
        public void ALiveCellWithTwoLiveNeighborsLives()
        {
            int height = 6;
            int width = 6;
            RealGOL my_world = new RealGOL(width, height);
            Cell[,] board = my_world.Board();
            Cell currentCell = board[2, 2];
            my_world.SetBoard(2, 2, true);
            my_world.SetBoard(1, 3, true);
            my_world.SetBoard(3, 1, true);
            int row = 2;
            int column = 2;
            int liveNeighbors = my_world.CheckNeighbors(row, column);
            bool toTest = currentCell.IsAlive;
            bool liveOrDie = my_world.ApplyRules(toTest, liveNeighbors);
            Assert.IsTrue(liveOrDie);
        }

        [TestMethod]
        public void ALiveCellWithThreeLiveNeighborsLives()
        {
            int height = 6;
            int width = 6;
            RealGOL my_world = new RealGOL(width, height);
            Cell[,] board = my_world.Board();
            Cell currentCell = board[2, 2];
            bool toTest = currentCell.IsAlive;
            my_world.SetBoard(2, 2, true);
            my_world.SetBoard(1, 3, true);
            my_world.SetBoard(3, 1, true);
            my_world.SetBoard(3, 3, true);
            int row = 2;
            int column = 2;
            int liveNeighbors = my_world.CheckNeighbors(row, column);
            bool liveOrDie = my_world.ApplyRules(toTest, liveNeighbors);
            Assert.IsTrue(liveOrDie);
        }

        [TestMethod]
        public void ADeadCellWithThreeLiveNeighborsLives()
        {
            int height = 6;
            int width = 6;
            RealGOL my_world = new RealGOL(width, height);
            Cell[,] board = my_world.Board();
            Cell currentCell = board[2, 2];
            bool toTest = currentCell.IsAlive;
            my_world.SetBoard(1, 3, true);
            my_world.SetBoard(3, 1, true);
            my_world.SetBoard(3, 3, true);
            int row = 2;
            int column = 2;
            int liveNeighbors = my_world.CheckNeighbors(row, column);
            bool liveOrDie = my_world.ApplyRules(toTest, liveNeighbors);
            Assert.IsTrue(liveOrDie);
        }

        [TestMethod]
        public void CanMakeNewBoardOfAllRulesToAllCells()
        {
            int height = 5;
            int width = 5;
            RealGOL my_world = new RealGOL(width, height);
            my_world.SetBoard(1, 2, true);
            my_world.SetBoard(2, 2, true);
            my_world.SetBoard(2, 3, true);
            RealGOL tickedBoard = my_world.RulesToBoard();
            RealGOL expectedBoard = new RealGOL(width, height);
            expectedBoard.SetBoard(2, 1, true);
            expectedBoard.SetBoard(2, 2, true);
            expectedBoard.SetBoard(2, 3, true);
            Assert.AreEqual(expectedBoard, tickedBoard);
        }
    }
}
