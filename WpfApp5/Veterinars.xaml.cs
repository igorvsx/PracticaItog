using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
    public partial class Veterinars : Page
    {
        VeterinarsTableAdapter veterinars = new VeterinarsTableAdapter();
        public Veterinars()
        {
            InitializeComponent();
            datagrid.ItemsSource = veterinars.GetData();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = datagrid.SelectedItem;
            if (selectedItem != null)
            {
                FirstVetNameBox.Text = (datagrid.SelectedItem as DataRowView).Row[1].ToString();
                LastVetNameBox.Text = (datagrid.SelectedItem as DataRowView).Row[2].ToString();
                EmailVetBox.Text = (datagrid.SelectedItem as DataRowView).Row[3].ToString();
                PhoneVetBox.Text = (datagrid.SelectedItem as DataRowView).Row[4].ToString();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            if (string.IsNullOrWhiteSpace(FirstVetNameBox.Text) || string.IsNullOrWhiteSpace(LastVetNameBox.Text) ||
                string.IsNullOrWhiteSpace(EmailVetBox.Text) || string.IsNullOrWhiteSpace(PhoneVetBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(FirstVetNameBox.Text) || !latinAndRussianRegex.IsMatch(LastVetNameBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else if (!Regex.IsMatch(EmailVetBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Некорректный формат email");
            }
            else if (!Regex.IsMatch(PhoneVetBox.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Некорректный формат телефонного номера. Номер должен состоять из 10 цифр.");
            }
            else
            {
                veterinars.InsertQuery(FirstVetNameBox.Text, LastVetNameBox.Text, EmailVetBox.Text, PhoneVetBox.Text);
                datagrid.ItemsSource = veterinars.GetData();
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            if (string.IsNullOrWhiteSpace(FirstVetNameBox.Text) || string.IsNullOrWhiteSpace(LastVetNameBox.Text) ||
                string.IsNullOrWhiteSpace(EmailVetBox.Text) || string.IsNullOrWhiteSpace(PhoneVetBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(FirstVetNameBox.Text) || !latinAndRussianRegex.IsMatch(LastVetNameBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else if (!Regex.IsMatch(EmailVetBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Некорректный формат email");
            }
            else if (!Regex.IsMatch(PhoneVetBox.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Некорректный формат телефонного номера. Номер должен состоять из 10 цифр.");
            }
            else
            {
                var selectedItem = datagrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    object id = (datagrid.SelectedItem as DataRowView).Row[0];
                    veterinars.UpdateQuery(FirstVetNameBox.Text, LastVetNameBox.Text, EmailVetBox.Text, PhoneVetBox.Text, Convert.ToInt32(id));
                    datagrid.ItemsSource = veterinars.GetData();
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
                veterinars.DeleteQuery(Convert.ToInt32(id));
                datagrid.ItemsSource = veterinars.GetData();
            }
            else
                MessageBox.Show("Элемент не выбран");
        }

        private void ImportBtn_Click(object sender, RoutedEventArgs e)
        {
            List<veterinarsModel> forimport = JsonConverter.DeserializeObject<List<veterinarsModel>>();
            if (forimport != null)
            {
                foreach (var item in forimport)
                {
                    veterinars.InsertQuery(item.vet_first_name, item.vet_last_name, item.vet_email, item.vet_phone);
                }
                datagrid.ItemsSource = null;
                datagrid.ItemsSource = veterinars.GetData();
            }
            else
            {
                MessageBox.Show("Не выбран файл");
            }
        }
    }
    internal class veterinarsModel
    {
        public string vet_first_name { get; set; }
        public string vet_last_name { get; set; }
        public string vet_email { get; set; }
        public string vet_phone { get; set; }
    }
}
