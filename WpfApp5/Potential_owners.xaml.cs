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
    public partial class Potential_owners : Page
    {
        Potential_ownersTableAdapter owners = new Potential_ownersTableAdapter();
        public Potential_owners()
        {
            InitializeComponent();
            datagrid.ItemsSource = owners.GetData();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = datagrid.SelectedItem;
            if (selectedItem != null)
            {
                OwnerFirstNameBox.Text = (datagrid.SelectedItem as DataRowView).Row[1].ToString();
                OwnerLastNameBox.Text = (datagrid.SelectedItem as DataRowView).Row[2].ToString();
                OwnerEmailBox.Text = (datagrid.SelectedItem as DataRowView).Row[3].ToString();
                OwnerPhoneBox.Text = (datagrid.SelectedItem as DataRowView).Row[4].ToString();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            if (string.IsNullOrWhiteSpace(OwnerFirstNameBox.Text) || string.IsNullOrWhiteSpace(OwnerLastNameBox.Text) || 
                string.IsNullOrWhiteSpace(OwnerEmailBox.Text) || string.IsNullOrWhiteSpace(OwnerPhoneBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(OwnerFirstNameBox.Text) || !latinAndRussianRegex.IsMatch(OwnerLastNameBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else if (!Regex.IsMatch(OwnerEmailBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Некорректный формат email");
            }
            else if (!Regex.IsMatch(OwnerPhoneBox.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Некорректный формат телефонного номера. Номер должен состоять из 10 цифр.");
            }
            else
            {
                owners.InsertQuery(OwnerFirstNameBox.Text, OwnerLastNameBox.Text, OwnerEmailBox.Text, OwnerPhoneBox.Text);
                datagrid.ItemsSource = owners.GetData();
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            if (string.IsNullOrWhiteSpace(OwnerFirstNameBox.Text) || string.IsNullOrWhiteSpace(OwnerLastNameBox.Text) ||
                string.IsNullOrWhiteSpace(OwnerEmailBox.Text) || string.IsNullOrWhiteSpace(OwnerPhoneBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(OwnerFirstNameBox.Text) || !latinAndRussianRegex.IsMatch(OwnerLastNameBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else if (!Regex.IsMatch(OwnerEmailBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Некорректный формат email");
            }
            else if (!Regex.IsMatch(OwnerEmailBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Некорректный формат email");
            }
            else if (!Regex.IsMatch(OwnerPhoneBox.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Некорректный формат телефонного номера. Номер должен состоять из 10 цифр.");
            }
            else
            {
                var selectedItem = datagrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    object id = (datagrid.SelectedItem as DataRowView).Row[0];
                    owners.UpdateQuery(OwnerFirstNameBox.Text, OwnerLastNameBox.Text, OwnerEmailBox.Text, OwnerPhoneBox.Text, Convert.ToInt32(id));
                    datagrid.ItemsSource = owners.GetData();
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
                owners.DeleteQuery(Convert.ToInt32(id));
                datagrid.ItemsSource = owners.GetData();
            }
            else
                MessageBox.Show("Элемент не выбран");
        }
    }
}
