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
    public partial class Addresses : Page
    {
        AddressesTableAdapter address = new AddressesTableAdapter();
        public Addresses()
        {
            InitializeComponent();
            datagrid.ItemsSource = address.GetData();
        }

        
        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = datagrid.SelectedItem;
            if (selectedItem != null)
            {
                StreetBox.Text = (datagrid.SelectedItem as DataRowView).Row[1].ToString();
                CityBox.Text = (datagrid.SelectedItem as DataRowView).Row[2].ToString();
                StateBox.Text = (datagrid.SelectedItem as DataRowView).Row[3].ToString();
                PostalCodeBox.Text = (datagrid.SelectedItem as DataRowView).Row[4].ToString();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s.,\\d]*$");
            if (string.IsNullOrWhiteSpace(StreetBox.Text) || string.IsNullOrWhiteSpace(CityBox.Text) ||
                string.IsNullOrWhiteSpace(StateBox.Text) || string.IsNullOrWhiteSpace(PostalCodeBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(StreetBox.Text) || !latinAndRussianRegex.IsMatch(CityBox.Text)
                || !latinAndRussianRegex.IsMatch(StateBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else
            {
                
                int postalCode;
                if (!int.TryParse(PostalCodeBox.Text, out postalCode))
                {
                    MessageBox.Show("Почтовый индекс должен быть числом");
                }
                else
                {
                    if (postalCode < 0)
                    {
                        MessageBox.Show("Почтовый индекс не может быть отрицательным");
                    }
                    else
                    {
                        address.InsertQuery(StreetBox.Text, CityBox.Text, StateBox.Text, PostalCodeBox.Text);
                        datagrid.ItemsSource = address.GetData();
                    }
                }
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s.,\\d]*$");
            if (string.IsNullOrWhiteSpace(StreetBox.Text) || string.IsNullOrWhiteSpace(CityBox.Text) ||
                string.IsNullOrWhiteSpace(StateBox.Text) || string.IsNullOrWhiteSpace(PostalCodeBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(StreetBox.Text) || !latinAndRussianRegex.IsMatch(CityBox.Text)
                || !latinAndRussianRegex.IsMatch(StateBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else
            {
                var selectedItem = datagrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    int postalCode;
                    if (!int.TryParse(PostalCodeBox.Text, out postalCode))
                    {
                        MessageBox.Show("Почтовый индекс должен быть числом");
                    }
                    else
                    {
                        if (postalCode < 0)
                        {
                            MessageBox.Show("Почтовый индекс не может быть отрицательным");
                        }
                        else
                        {
                            object id = (datagrid.SelectedItem as DataRowView).Row[0];
                            address.UpdateQuery(StreetBox.Text, CityBox.Text, StateBox.Text, PostalCodeBox.Text, Convert.ToInt32(id));
                            datagrid.ItemsSource = address.GetData();
                        }
                    }
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
                address.DeleteQuery(Convert.ToInt32(id));
                datagrid.ItemsSource = address.GetData();
            }
            else
                MessageBox.Show("Элемент не выбран");
        }

        private void ImportBtn_Click(object sender, RoutedEventArgs e)
        {
            List<addressModel> forimport = JsonConverter.DeserializeObject<List<addressModel>>();
            if (forimport != null)
            {
                foreach (var item in forimport)
                {
                    address.InsertQuery(item.address_street, item.address_city, item.address_state, item.address_postal_code);
                }
                datagrid.ItemsSource = null;
                datagrid.ItemsSource = address.GetData();
            }
            else
            {
                MessageBox.Show("Не выбран файл");
            }
        }
    }
    internal class addressModel
    {
        public string address_street { get; set; }
        public string address_city { get; set; }
        public string address_state { get; set; }
        public string address_postal_code { get; set; }
    }
}
