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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp5.PitomnikBaseDataSetTableAdapters;

namespace WpfApp5
{
    public partial class MainWindow : Window
    {
        private List<Page> pages = new List<Page>();
        private int index = 0;

        public MainWindow()
        {
            InitializeComponent();

            pages.Add(new Roles());
            pages.Add(new Employees());
            pages.Add(new LoginData());
            //pages.Add(new Potential_owners());
            //pages.Add(new Addresses());
            //pages.Add(new Veterinars());
            //pages.Add(new Treatments());
            //pages.Add(new Vaccinations());
            //pages.Add(new Feedings());
            //pages.Add(new Adaptations());
            //pages.Add(new Histories());
            //pages.Add(new Organizations());
            PageFrame.Content = pages[0];
        }

        //private void PreviousBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    if (index > 0)
        //    {
        //        index--;
        //        PageFrame.Content = pages[index];
        //    }
        //}

        //private void NextBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    if (index < pages.Count - 1)
        //    {
        //        index++;
        //        PageFrame.Content = pages[index];
        //    }
        //}

        private void RolesBtn_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = pages[0];
        }

        private void EmployessBtn_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = pages[1];
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = pages[2];
        }

        private void TableBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminTablesWindow window = new AdminTablesWindow();
            window.ShowDialog();
        }
    }
}
