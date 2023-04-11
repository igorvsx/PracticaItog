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
    public partial class Vaccinations : Page
    {
        VaccinationsTableAdapter vaccinations = new VaccinationsTableAdapter();
        AnimalsTableAdapter animals = new AnimalsTableAdapter();
        VeterinarsTableAdapter veterinars = new VeterinarsTableAdapter();
        public Vaccinations()
        {
            InitializeComponent();
            datagrid.ItemsSource = vaccinations.GetData();
            AnimalBox.ItemsSource = animals.GetData();
            VeterinarsBox.ItemsSource = veterinars.GetData();
            AnimalBox.DisplayMemberPath = "animal_name";
            VeterinarsBox.DisplayMemberPath = "vet_first_name";
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s.,\\d]*$");
            if (string.IsNullOrWhiteSpace(AnimalBox.Text) || string.IsNullOrWhiteSpace(VeterinarsBox.Text)
                || string.IsNullOrWhiteSpace(VacDateBox.SelectedDate.ToString()) || string.IsNullOrWhiteSpace(VacDescBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(VacDescBox.Text))
            {
                MessageBox.Show("Адрес должен содержать только латинские, русские символы или цифры!");
                return;
            }
            else
            {
                object cell1 = (AnimalBox.SelectedItem as DataRowView).Row[0];
                object cell2 = (VeterinarsBox.SelectedItem as DataRowView).Row[0];
                vaccinations.InsertQuery(Convert.ToInt32(cell1.ToString()), Convert.ToInt32(cell2.ToString()), VacDateBox.SelectedDate.ToString(),
                    VacDescBox.Text);
                datagrid.ItemsSource = vaccinations.GetData();
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s.,\\d]*$");
            if (string.IsNullOrWhiteSpace(AnimalBox.Text) || string.IsNullOrWhiteSpace(VeterinarsBox.Text)
                || string.IsNullOrWhiteSpace(VacDateBox.SelectedDate.ToString()) || string.IsNullOrWhiteSpace(VacDescBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(VacDescBox.Text))
            {
                MessageBox.Show("Адрес должен содержать только латинские, русские символы или цифры!");
                return;
            }
            else
            {
                var selectedItem = datagrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    object cell1 = (AnimalBox.SelectedItem as DataRowView).Row[0];
                    object cell2 = (VeterinarsBox.SelectedItem as DataRowView).Row[0];
                    object id = (datagrid.SelectedItem as DataRowView).Row[0];
                    vaccinations.UpdateQuery(Convert.ToInt32(cell1.ToString()), Convert.ToInt32(cell2.ToString()), VacDateBox.SelectedDate.ToString(),
                        VacDescBox.Text, Convert.ToInt32(id));
                    datagrid.ItemsSource = vaccinations.GetData();
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
                vaccinations.DeleteQuery(Convert.ToInt32(id));
                datagrid.ItemsSource = vaccinations.GetData();
            }
            else
                MessageBox.Show("Элемент не выбран");
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AnimalBox.ItemsSource = animals.GetData();
            VeterinarsBox.ItemsSource = veterinars.GetData();
            var selectedItem = datagrid.SelectedItem;
            if (selectedItem != null)
            {
                VacDateBox.SelectedDate = Convert.ToDateTime((datagrid.SelectedItem as DataRowView).Row[3]);
                VacDescBox.Text = (datagrid.SelectedItem as DataRowView).Row[4].ToString();
            }
        }
    }
}
