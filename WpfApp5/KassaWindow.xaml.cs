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

namespace WpfApp5
{
    public partial class KassaWindow : Window
    {
        private List<Page> pages = new List<Page>();
        private int index = 0;
        public KassaWindow()
        {
            InitializeComponent();
            pages.Add(new BuyPage());
            pages.Add(new BillsPage());
            PageFrame.Content = pages[0];
        }

        private void BuyBtn_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = pages[0];
        }

        private void BillsBtn_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = pages[1];
        }
    }
}
