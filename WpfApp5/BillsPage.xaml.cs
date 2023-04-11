using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
//using System.Windows.Shapes;
using WpfApp5.PitomnikBaseDataSetTableAdapters;

namespace WpfApp5
{
    public partial class BillsPage : Page
    {
        PurchasesTableAdapter purchases = new PurchasesTableAdapter();
        public BillsPage()
        {
            InitializeComponent();
            BillsGrid.ItemsSource = purchases.GetData();
        }

        private void CloseAndSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("НОТ ВОРКИНГ МЭН, 乌克兰离不开顿巴斯煤乌克兰离不开顿" +
                "巴斯煤乌克兰离不开顿巴斯煤乌克兰离不开顿巴斯煤乌克兰离不开顿巴斯煤乌克" +
                "兰离不开顿巴斯煤乌克兰离不开顿巴斯煤乌克兰离不开顿巴斯煤乌克兰" +
                "离不开顿巴斯煤乌克兰离不开顿巴斯煤乌克兰离不开顿巴斯煤乌克兰离不开顿巴斯煤" +
                "乌克兰离不开顿巴斯煤乌克兰离不开顿巴斯煤乌克兰离不开顿巴斯煤乌克兰离不开顿巴斯煤" +
                "乌克兰离不开顿巴斯煤乌克兰离不开顿巴斯煤乌克兰离不开顿巴斯煤乌克兰离不开顿巴斯煤");
        }

        private void BillsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BillsGrid.ItemsSource = purchases.GetData();
        }
    }
}
