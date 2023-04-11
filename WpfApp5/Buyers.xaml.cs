using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class Buyers : Page
    {
        BuyersTableAdapter buyers = new BuyersTableAdapter();
        public Buyers()
        {
            InitializeComponent();
            datagrid.ItemsSource = buyers.GetData();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = datagrid.SelectedItem;
            if (selectedItem != null)
            {
                BuyerNameBox.Text = (datagrid.SelectedItem as DataRowView).Row[1].ToString();
                BuyerLastBox.Text = (datagrid.SelectedItem as DataRowView).Row[2].ToString();
                BuyerPhoneBox.Text = (datagrid.SelectedItem as DataRowView).Row[3].ToString();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            if (string.IsNullOrWhiteSpace(BuyerNameBox.Text) || string.IsNullOrWhiteSpace(BuyerLastBox.Text) ||
                string.IsNullOrWhiteSpace(BuyerPhoneBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(BuyerNameBox.Text) && !latinAndRussianRegex.IsMatch(BuyerLastBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else if (!Regex.IsMatch(BuyerPhoneBox.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Некорректный формат телефонного номера. Номер должен состоять из 10 цифр.");
            }
            else
            {
                buyers.InsertQuery(BuyerNameBox.Text, BuyerLastBox.Text, BuyerPhoneBox.Text);
                datagrid.ItemsSource = buyers.GetData();
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            if (string.IsNullOrWhiteSpace(BuyerNameBox.Text) || string.IsNullOrWhiteSpace(BuyerLastBox.Text) ||
                string.IsNullOrWhiteSpace(BuyerPhoneBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(BuyerNameBox.Text) && !latinAndRussianRegex.IsMatch(BuyerLastBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else if (!Regex.IsMatch(BuyerPhoneBox.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Некорректный формат телефонного номера. Номер должен состоять из 10 цифр.");
            }
            else
            {
                var selectedItem = datagrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    object id = (datagrid.SelectedItem as DataRowView).Row[0];
                    buyers.UpdateQuery(BuyerNameBox.Text, BuyerLastBox.Text, BuyerPhoneBox.Text, Convert.ToInt32(id));
                    datagrid.ItemsSource = buyers.GetData();
                }
                else
                    MessageBox.Show("Элемент не выбран");
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem != null)
            {
                object id = (datagrid.SelectedItem as DataRowView).Row[0];
                buyers.DeleteQuery(Convert.ToInt32(id));
                datagrid.ItemsSource = buyers.GetData();
            }
            else
                MessageBox.Show("Элемент не выбран");
        }
    }
}
