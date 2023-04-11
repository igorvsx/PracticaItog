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
    public partial class Treatments : Page
    {
        TreatmentsTableAdapter treatments = new TreatmentsTableAdapter();
        AnimalsTableAdapter animals = new AnimalsTableAdapter();
        VeterinarsTableAdapter veterinars = new VeterinarsTableAdapter();
        public Treatments()
        {
            InitializeComponent();
            datagrid.ItemsSource = treatments.GetData();
            AnimalBox.ItemsSource = animals.GetData();
            VeterinarsBox.ItemsSource = veterinars.GetData();
            AnimalBox.DisplayMemberPath = "animal_name";
            VeterinarsBox.DisplayMemberPath = "vet_first_name";
            
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AnimalBox.ItemsSource = animals.GetData();
            VeterinarsBox.ItemsSource = veterinars.GetData();
            var selectedItem = datagrid.SelectedItem;
            if (selectedItem != null)
            {
                TreatStartDateBox.SelectedDate = Convert.ToDateTime((datagrid.SelectedItem as DataRowView).Row[3]);
                TreatEndDateBox.SelectedDate = Convert.ToDateTime((datagrid.SelectedItem as DataRowView).Row[4]);
                TreatDescBox.Text = (datagrid.SelectedItem as DataRowView).Row[5].ToString();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime firstDate = TreatStartDateBox.SelectedDate.Value;
            DateTime secondDate = TreatEndDateBox.SelectedDate.Value;
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s.,\\d]*$");
            if (string.IsNullOrWhiteSpace(AnimalBox.Text) || string.IsNullOrWhiteSpace(VeterinarsBox.Text) 
                || string.IsNullOrWhiteSpace(TreatStartDateBox.SelectedDate.ToString()) || string.IsNullOrWhiteSpace(TreatEndDateBox.SelectedDate.ToString()) 
                || string.IsNullOrWhiteSpace(TreatDescBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (secondDate < firstDate)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания");
            }
            else if (!latinAndRussianRegex.IsMatch(TreatDescBox.Text))
            {
                MessageBox.Show("Лечение должно содержать только латинские, русские символы или цифры!");
                return;
            }
            else
            {
                object cell1 = (AnimalBox.SelectedItem as DataRowView).Row[0];
                object cell2 = (VeterinarsBox.SelectedItem as DataRowView).Row[0];
                treatments.InsertQuery(Convert.ToInt32(cell1.ToString()), Convert.ToInt32(cell2.ToString()), TreatStartDateBox.SelectedDate.ToString(),
                    TreatEndDateBox.SelectedDate.ToString(), TreatDescBox.Text);
                datagrid.ItemsSource = treatments.GetData();
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime firstDate = TreatStartDateBox.SelectedDate.Value;
            DateTime secondDate = TreatEndDateBox.SelectedDate.Value;
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s.,\\d]*$");
            if (string.IsNullOrWhiteSpace(AnimalBox.Text) || string.IsNullOrWhiteSpace(VeterinarsBox.Text)
                || string.IsNullOrWhiteSpace(TreatStartDateBox.SelectedDate.ToString()) || string.IsNullOrWhiteSpace(TreatEndDateBox.SelectedDate.ToString())
                || string.IsNullOrWhiteSpace(TreatDescBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (secondDate < firstDate)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания");
            }
            else if (!latinAndRussianRegex.IsMatch(TreatDescBox.Text))
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
                    treatments.UpdateQuery(Convert.ToInt32(cell1.ToString()), Convert.ToInt32(cell2.ToString()), TreatStartDateBox.SelectedDate.ToString(),
                        TreatEndDateBox.SelectedDate.ToString(), TreatDescBox.Text, Convert.ToInt32(id));
                    datagrid.ItemsSource = treatments.GetData();
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
                treatments.DeleteQuery(Convert.ToInt32(id));
                datagrid.ItemsSource = treatments.GetData();
            }
            else
                MessageBox.Show("Элемент не выбран");
        }
    }
}
