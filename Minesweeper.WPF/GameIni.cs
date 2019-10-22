using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Minesweeper.WPF
{

    public class GameIni
    {
        //Declaring variables that will have values assigned later in the methods

        public String[,] Board { get; set; }
        private int mines { get; set; }
        private int bv3 { get; set; }
        private bool[,] visited { get; set; }
        

        public GameIni()
        {

        }

        //Method that populates the grid with mines or empty blocks
        public String[,] PopulateGrid(int rows, int columns, int mines)
        {
            Board = new string[rows, columns];
            int placed = 0;

            //Loop that iterates until the number of mines placed is the same as the total mines
            while (placed < mines)
            {
                //Generating random numbers to place the mines
                Random rand = new Random();
                int row = rand.Next(rows - 1);
                int col = rand.Next(columns - 1);

                //Checks if there is already a mine in that spot, if not, it places one there
                if (Board[row, col] != "M")
                {
                    Board[row, col] = "M";
                    placed++;
                }
            }

            //Populates the rest of the grid with a ' - '. 
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    //Checks if is there a mine in that spot, if not, it populates with a ' - '.                    
                    if (Board[r, c] != "M")
                        if (NumberOfSurroundingMines(r, c, rows, columns, Board) == 0)
                        {
                            Board[r, c] = " ";
                        }

                        else
                        {
                            Board[r, c] = Convert.ToString(NumberOfSurroundingMines(r, c, rows, columns, Board));
                        }

                }
            }
            return Board;
        }

        //Method that will get the number of surrounding mines
        public int NumberOfSurroundingMines(int row, int col, int rows, int columns, String[,] Board)
        {
            int count = 0;
            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (IsInside(r, c, rows, columns) && Board[r, c] == "M")
                        count++;
                }
            }
            return count;
        }


        public bool IsInside(int r, int c, int rows, int columns)
        {
            return r >= 0 && c >= 0 && r < rows && c < columns;
        }


        public int BVCalc(String[,] BVBoard, int rows, int columns)
        {
            bv3 = 0;

            visited = new bool[rows, columns];

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {

                    if (BVBoard[i, j] == " " && !visited[i, j])
                    {
                        // If a cell with value ' ' is not 
                        // visited yet, then new island  
                        // found, Visit all cells in this 
                        // island and increment island count 
                        DFS(BVBoard, i, j, visited, rows, columns);
                        ++bv3;
                    }
                    if (BVBoard[i, j] != "M" && BVBoard[i, j] != " ")
                        ++bv3;
                }

            }
            return bv3;
        }

        static bool isSafe(String[,] M, int row,
                   int col, bool[,] visited, int rows, int columns)
        {
            // row number is in range, column number is in range 
            // and value is ' ' and not yet visited 
            return (row >= 0) && (row < rows) &&
                   (col >= 0) && (col < columns) &&
                   (M[row, col] == " " &&
                   !visited[row, col]);
        }

        static void DFS(String[,] M, int row,
                 int col, bool[,] visited, int rows, int columns)
        {
            // These arrays are used to get row and column numbers 
            // of 8 neighbors of a given cell 
            int[] rowNbr = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] colNbr = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

            // Mark this cell as visited 
            visited[row, col] = true;

            // Recur for all connected neighbours 
            for (int k = 0; k < 8; ++k)
                if (isSafe(M, row + rowNbr[k], col +
                                    colNbr[k], visited, rows, columns))
                    DFS(M, row + rowNbr[k],
                           col + colNbr[k], visited, rows, columns);
        }



    }
}
