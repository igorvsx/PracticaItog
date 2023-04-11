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
using WpfApp5.PitomnikBaseDataSetTableAdapters;

namespace WpfApp5
{
    public partial class AdminTablesWindow : Window
    {
        private List<Page> pages = new List<Page>();
        private int index = 0;
        public AdminTablesWindow()
        {
            InitializeComponent();
            pages.Add(new FirstPage());
            pages.Add(new Potential_owners());
            pages.Add(new Addresses());
            pages.Add(new Veterinars());
            pages.Add(new Treatments());
            pages.Add(new Vaccinations());
            pages.Add(new Feedings());
            pages.Add(new Adaptations());
            pages.Add(new Histories());
            pages.Add(new Organizations());
            pages.Add(new Buyers());
            pages.Add(new Purchases());
            PageFrame.Content = pages[0];
        }

        private void PreviousBtn_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                index--;
                PageFrame.Content = pages[index];
            }
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (index < pages.Count - 1)
            {
                index++;
                PageFrame.Content = pages[index];
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
