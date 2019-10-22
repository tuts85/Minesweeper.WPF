using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Minesweeper.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[,] ButtonGrid;
        private bool[,] visited { get; set; }
        public int rows = 8;
        public int columns = 8;
        public int bombs = 10;
        public Grid BombGrid;
        public int elapsed = 0;
        public int rightFlag;
        public string level = "Beginner";
        public DispatcherTimer timer = new DispatcherTimer();
        public List<Scores> ScoreList = new List<Scores>();
        public bool challengeMode = false;

        public MainWindow()
        {
            InitializeComponent();

            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("C:\\Users\\Arthur Lazaro\\source\\repos\\Minesweeper.WPF\\Minesweeper.WPF\\bg.jpg", UriKind.Absolute));
            this.Background = myBrush;
            CreateBombGrid();

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Click;
            

        }

        public void CreateBombGrid()
        {
            rightFlag = 0;

            Button b = new Button();

            elapsed = 0;
            timer.Start();

            if (BombGrid != null)
                MainGrid.Children.Remove(BombGrid);

            bombslefttxbx.Text = Convert.ToString(bombs);

            BombGrid = new Grid
            {
                Width = (new Mine()).Width * columns + 120,
                Height = (new Mine()).Height * rows + 60,

                //BombGrid.HorizontalAlignment = HorizontalAlignment.Center;
                //BombGrid.VerticalAlignment = VerticalAlignment.Bottom;

                Margin = new Thickness(5, 105, 5, 5)
            };

            




            MainGrid.Children.Add(BombGrid);

            bool ok3bv = false;

            for (int r = 0; r < rows; r++)
            {
                BombGrid.RowDefinitions.Add(new RowDefinition());                
            }
            for (int c = 0; c < columns; c++)
            {
                BombGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            GameIni game = new GameIni();
            ButtonGrid = game.PopulateGrid(rows, columns, bombs);


            game.BVCalc(ButtonGrid, rows, columns);
            
            do
            {
                //GameIni game = new GameIni();
                //ButtonGrid = game.PopulateGrid(rows, columns, bombs);
                
                
                if (level == "Beginner")
                {
                    if (game.BVCalc(ButtonGrid, rows, columns) >= 45)
                        ok3bv = true;
                    else
                        ButtonGrid = game.PopulateGrid(rows, columns, bombs);
                }
                
                else if (level == "Intermediate")
                {
 
                        if (game.BVCalc(ButtonGrid, rows, columns) >= 120)
                            ok3bv = true;
                        else
                            ButtonGrid = game.PopulateGrid(rows, columns, bombs);
                    
                }
                else if (level == "Advanced")
                {
 
                        if (game.BVCalc(ButtonGrid, rows, columns) >= 290)
                            ok3bv = true;
                        else
                            ButtonGrid = game.PopulateGrid(rows, columns, bombs);
                    
                }
                

            } while (!ok3bv);
            


            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (ButtonGrid[r, c] == "M")
                    {
                        Mine block = new Mine();
                        block.Background = Brushes.DarkGreen;
                        //block.Content = "M";   
                        Grid.SetRow(block, r);
                        Grid.SetColumn(block, c);
                        BombGrid.Children.Add(block);                        
                        block.Click += Mouse_LeftClick;
                        block.MouseRightButtonUp += Mouse_RightClick;
                    }

                    else if (ButtonGrid[r, c] == " ")
                    {
                        Tiles tile = new Tiles();
                        tile.Background = Brushes.DarkGreen;

                        Grid.SetRow(tile, r);
                        Grid.SetColumn(tile, c);
                        tile.number = ButtonGrid[r, c];
                        BombGrid.Children.Add(tile);
                        tile.Click += Mouse_LeftClick;
                        tile.MouseRightButtonUp += Mouse_RightClick;
                    }

                    else
                    {
                        Tiles tile = new Tiles();
                        tile.Background = Brushes.DarkGreen;

                        Grid.SetRow(tile, r);
                        Grid.SetColumn(tile, c);
                        tile.number = ButtonGrid[r, c];
                        BombGrid.Children.Add(tile);
                        tile.Click += Mouse_LeftClick;
                        tile.MouseRightButtonUp += Mouse_RightClick;
                    }

                }
            }



        }

        private void Timer_Click(object sender, EventArgs e)
        {
            elapsed++;
            timetxbx.Text = Convert.ToString(elapsed);

            
            if (challengeMode == true)
            {
                if (level == "Beginner")
                {
                    if (elapsed == 60)
                    {
                        timer.Stop();
                        if (MessageBox.Show("Do you want to play again?", "Time is up! You lost!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            CreateBombGrid();
                        }
                        else
                        {
                            System.Windows.Application.Current.Shutdown();
                        }
                    }

                }
                else if (level == "Intermediate")
                {
                    if (elapsed == 180)
                    {
                        timer.Stop();
                        if (MessageBox.Show("Do you want to play again?", "Time is up! You lost!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            CreateBombGrid();
                        }
                        else
                        {
                            System.Windows.Application.Current.Shutdown();
                        }
                    }
                }
                else if (level == "Advanced")
                {
                    if (elapsed == 300)
                    {
                        timer.Stop();
                        if (MessageBox.Show("Do you want to play again?", "Time is up! You lost!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            CreateBombGrid();
                        }
                        else
                        {
                            System.Windows.Application.Current.Shutdown();
                        }
                    }
                }
            }
            
        }

        protected void Mouse_RightClick(object sender, RoutedEventArgs e)
        {
            int rowIndex = Grid.GetRow(sender as Button);
            int colIndex = Grid.GetColumn(sender as Button);

            Button button = BombGrid.Children.Cast<Button>().First(b => Grid.GetRow(b) == rowIndex && Grid.GetColumn(b) == colIndex);

            if (button.Content == "?")
                button.Content = " ";
            else if (button.Content == "🏴")
            {
                button.Content = "?";
                bombslefttxbx.Text = Convert.ToString(Convert.ToInt32(bombslefttxbx.Text) + 1);
                if (ButtonGrid[rowIndex, colIndex] == "M")
                    rightFlag--;
            }

            else
            {
                button.Content = "🏴";
                bombslefttxbx.Text = Convert.ToString(Convert.ToInt32(bombslefttxbx.Text) - 1);

                if (ButtonGrid[rowIndex, colIndex] == "M")
                    rightFlag++;

                

                if (rightFlag == bombs)
                {
                    timer.Stop();
                    BombGrid.IsEnabled = false;                    
                    if (MessageBox.Show($"Score: {elapsed}\nDo you want to play again?", "You Won! Congratulations!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        
                        CreateBombGrid();
                    }
                    else
                    {
                        System.Windows.Application.Current.Shutdown();
                    }

                }


            }
                
        }

        protected void Mouse_LeftClick(object sender, RoutedEventArgs e)
        {
            
            int rowIndex = Grid.GetRow(sender as Button);
            int colIndex = Grid.GetColumn(sender as Button);

            Button button = BombGrid.Children.Cast<Button>().First(b => Grid.GetRow(b) == rowIndex && Grid.GetColumn(b) == colIndex);

            if (button.Content != "🏴")
            {
                if (ButtonGrid[rowIndex, colIndex] == "M")
                {
                    button.Background = Brushes.White;
                    button.Content = (button as Mine).mine;
                    timer.Stop();
                    if (MessageBox.Show("Do you want to play again?", "You lost!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        CreateBombGrid();  
                    }
                    else
                    {
                        System.Windows.Application.Current.Shutdown();
                    }


                }
                else if (ButtonGrid[rowIndex, colIndex] == " ")
                {
                    List<Tuple<int, int>> toOpen = new List<Tuple<int, int>>();
                    findOpen(ButtonGrid, rowIndex, colIndex, toOpen);

                    foreach (Tuple<int, int> t in toOpen)
                    {
                        OpenTiles(BombGrid.Children.Cast<Button>().First(b => Grid.GetRow(b) == t.Item1 && Grid.GetColumn(b) == t.Item2));
                    }

                }
                else
                {
                    if (ButtonGrid[rowIndex, colIndex] == "1")
                        button.Foreground = Brushes.Blue;
                    else if (ButtonGrid[rowIndex, colIndex] == "2")
                        button.Foreground = Brushes.Green;
                    else if (ButtonGrid[rowIndex, colIndex] == "3")
                        button.Foreground = Brushes.Red;
                    else if (ButtonGrid[rowIndex, colIndex] == "4")
                        button.Foreground = Brushes.Purple;
                    else if (ButtonGrid[rowIndex, colIndex] == "5")
                        button.Foreground = Brushes.Yellow;
                    else if (ButtonGrid[rowIndex, colIndex] == "6")
                        button.Foreground = Brushes.Pink;

                    button.FontWeight = FontWeights.Bold;
                    button.Background = Brushes.White;
                    button.Content = (button as Tiles).number;
                    button.IsEnabled = false;
                }
            }
            else
                button.Content = "🏴";
        }

        private void findOpen(String[,] arr, int i, int j, List<Tuple<int, int>> toOpen)
        {
            if (i < 0 || i >= rows)
                return;
            if (j < 0 || j >= columns)
                return;
            if (toOpen.Contains(new Tuple<int, int>(i, j)))
                return;

            if (arr[i, j] == " ")
            {
                toOpen.Add(new Tuple<int, int>(i, j));
                findOpen(arr, i - 1, j - 1, toOpen);
                findOpen(arr, i, j - 1, toOpen);
                findOpen(arr, i - 1, j, toOpen);
                findOpen(arr, i - 1, j + 1, toOpen);
                findOpen(arr, i + 1, j + 1, toOpen);
                findOpen(arr, i + 1, j - 1, toOpen);
                findOpen(arr, i + 1, j, toOpen);
                findOpen(arr, i, j + 1, toOpen);
            }

            else if (arr[i,j] != "M")
                toOpen.Add(new Tuple<int, int>(i, j));

        }

        private void OpenTiles(Button button)
        {
            button.FontWeight = FontWeights.Bold;
            button.Background = Brushes.White;

            if ((button as Tiles).number == "1")
                button.Foreground = Brushes.Blue;
            else if ((button as Tiles).number == "2")
                button.Foreground = Brushes.Green;
            else if ((button as Tiles).number == "3")
                button.Foreground = Brushes.Red;
            else if ((button as Tiles).number == "4")
                button.Foreground = Brushes.Purple;
            else if ((button as Tiles).number == "5")
                button.Foreground = Brushes.Yellow;
            else if ((button as Tiles).number == "6")
                button.Foreground = Brushes.Pink;

            button.Content = (button as Tiles).number;
            button.IsEnabled = false;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateBombGrid();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            New_Game game = new New_Game();
            game.Show();
        }





        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            How_to_play how = new How_to_play();
            how.Show();
        }
    }
}




