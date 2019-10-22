using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Minesweeper.WPF
{
    /// <summary>
    /// Interaction logic for New_Game.xaml
    /// </summary>
    public partial class New_Game : Window
    {
        public New_Game()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow win = ((MainWindow)Application.Current.MainWindow);
            if (beginnerrdbtn.IsChecked == true)
            {
                win.rows = 8;
                win.columns = 8;
                win.bombs = 10;
                win.level = "Beginner";
                if (challengechbx.IsChecked == true)
                    win.challengeMode = true;
                else
                    win.challengeMode = false;

                win.CreateBombGrid();
                Close();
            }
            else if (intermrdbtn.IsChecked == true)
            {
                win.rows = 16;
                win.columns = 16;
                win.bombs = 40;
                win.level = "Intermediate";
                if (challengechbx.IsChecked == true)
                    win.challengeMode = true;
                else
                    win.challengeMode = false;
                win.CreateBombGrid();
                Close();
            }
            else if (advancedrdbtn.IsChecked == true)
            {
                win.rows = 16;
                win.columns = 31;
                win.bombs = 99;
                win.level = "Advanced";
                if (challengechbx.IsChecked == true)
                    win.challengeMode = true;
                else
                    win.challengeMode = false;
                win.CreateBombGrid();
                Close();
            }
            else if (customrdbtn.IsChecked == true)
            {
                win.rows = Convert.ToInt32(rowstxbx.Text);
                win.columns = Convert.ToInt32(colstxbx.Text);
                win.bombs = Convert.ToInt32((win.rows * win.columns)* 0.25);
                win.CreateBombGrid();
                Close();
            }

           

        }
    }
}
