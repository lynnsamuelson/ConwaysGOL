using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;

namespace UnitTests
{
    [TestClass]
    public class CellsTests
    {
        [TestMethod]
        public void CellEnsureCellIsAlive()
        {
            //Use Public setters when creating new instance
            Cell my_cell = new Cell { IsAlive = true }; //Object Initializer Syntax
            Assert.IsTrue(my_cell.IsAlive);
        }

        [TestMethod]
        public void CellEnureCellIsDeadByDefault()
        {
            Cell my_cell = new Cell();
            Assert.IsFalse(my_cell.IsAlive);
        }
    }
}
