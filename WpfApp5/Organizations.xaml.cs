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
    public partial class Organizations : Page
    {
        OrganizationsTableAdapter organizations = new OrganizationsTableAdapter();
        AddressesTableAdapter addresses = new AddressesTableAdapter();
        public Organizations()
        {
            InitializeComponent();
            datagrid.ItemsSource = organizations.GetData();
            AddressBox.ItemsSource = addresses.GetData();
            AddressBox.DisplayMemberPath = "address_street";
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddressBox.ItemsSource = addresses.GetData();
            var selectedItem = datagrid.SelectedItem;
            AddressBox.ItemsSource = addresses.GetData();
            if (selectedItem != null)
            {
                OrgNameBox.Text = (datagrid.SelectedItem as DataRowView).Row[1].ToString();
                OrgEmailBox.Text = (datagrid.SelectedItem as DataRowView).Row[3].ToString();
                OrgPhoneBox.Text = (datagrid.SelectedItem as DataRowView).Row[4].ToString();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            string loginPattern = @"^[\p{L}\p{N}]+$";
            if (string.IsNullOrWhiteSpace(OrgNameBox.Text) || string.IsNullOrWhiteSpace(AddressBox.Text)
                || string.IsNullOrWhiteSpace(OrgEmailBox.Text) || string.IsNullOrWhiteSpace(OrgPhoneBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(OrgNameBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else if (!Regex.IsMatch(AddressBox.Text, loginPattern))
            {
                MessageBox.Show("Адрес должен содержать только латинские, русские символы или цифры!");
                return;
            }
            else if (!Regex.IsMatch(OrgEmailBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Некорректный формат email");
            }
            else if (!Regex.IsMatch(OrgPhoneBox.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Некорректный формат телефонного номера. Номер должен состоять из 10 цифр.");
            }
            else
            {
                object cell1 = (AddressBox.SelectedItem as DataRowView).Row[0];
                organizations.InsertQuery(OrgNameBox.Text, Convert.ToInt32(cell1.ToString()), OrgEmailBox.Text, OrgPhoneBox.Text);
                datagrid.ItemsSource = organizations.GetData();
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            string loginPattern = @"^[\p{L}\p{N}]+$";
            if (string.IsNullOrWhiteSpace(OrgNameBox.Text) || string.IsNullOrWhiteSpace(AddressBox.Text)
                || string.IsNullOrWhiteSpace(OrgEmailBox.Text) || string.IsNullOrWhiteSpace(OrgPhoneBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(OrgNameBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else if (!Regex.IsMatch(AddressBox.Text, loginPattern))
            {
                MessageBox.Show("Адрес должен содержать только латинские, русские символы или цифры!");
                return;
            }
            else if (!Regex.IsMatch(OrgEmailBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Некорректный формат email");
            }
            else if (!Regex.IsMatch(OrgPhoneBox.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Некорректный формат телефонного номера. Номер должен состоять из 10 цифр.");
            }
            else
            {
                var selectedItem = datagrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    object cell1 = (AddressBox.SelectedItem as DataRowView).Row[0];
                    object id = (datagrid.SelectedItem as DataRowView).Row[0];
                    organizations.UpdateQuery(OrgNameBox.Text, Convert.ToInt32(cell1.ToString()), OrgEmailBox.Text,
                        OrgPhoneBox.Text, Convert.ToInt32(id));
                    datagrid.ItemsSource = organizations.GetData();
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
                organizations.DeleteQuery(Convert.ToInt32(id));
                datagrid.ItemsSource = organizations.GetData();
            }
            else
                MessageBox.Show("Элемент не выбран");
        }
    }
}
