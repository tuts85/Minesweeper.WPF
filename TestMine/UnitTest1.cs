using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Minesweeper.WPF
{
    [TestClass]
    public class UnitTest1
    {
        //Testing if all the mines were placed in the board
        [TestMethod]
        public void TestMinesPlaced()
        {
            
            GameIni game = new GameIni();
            game.PopulateGrid(5, 10, 5);
            int rows = 5;
            int columns = 10;
            int countMines = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (game.Board[r, c] == "M")
                    {
                        countMines++;
                    }
                }

            }
            Assert.AreEqual(5, countMines);
        }
        //testing if all the grid was populated
        [TestMethod]
        public void TestPopulateGrid()
        {
            GameIni game = new GameIni();
            game.PopulateGrid(5, 10, 5);
            int rows = 5;
            int columns = 10;
            int countEmpty = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (game.Board[r, c] == " ")
                    {
                        countEmpty++;
                    }
                }
            }
            Assert.AreEqual(0, countEmpty);
        }

        //test if the numbers of surrounding mines is correct
        [TestMethod]
        public void TestNumberSurroundingMines()
        {
            GameIni game = new GameIni();
            game.PopulateGrid(1, 2, 1);
            game.Board[0, 0] = "M";
            Assert.AreEqual(1, game.NumberOfSurroundingMines(0, 1, 1, 1));


        }
    }
}
