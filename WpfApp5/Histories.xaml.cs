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
    public partial class Histories : Page
    {
        HistoriesTableAdapter histories = new HistoriesTableAdapter();
        AnimalsTableAdapter animals = new AnimalsTableAdapter();
        Potential_ownersTableAdapter owners = new Potential_ownersTableAdapter();
        public Histories()
        {
            InitializeComponent();
            datagrid.ItemsSource = histories.GetData();
            AnimalBox.ItemsSource = animals.GetData();
            OwnerBox.ItemsSource = owners.GetData();
            AnimalBox.DisplayMemberPath = "animal_name";
            OwnerBox.DisplayMemberPath = "owner_first_name";
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AnimalBox.ItemsSource = animals.GetData();
            OwnerBox.ItemsSource = owners.GetData();
            var selectedItem = datagrid.SelectedItem;
            if (selectedItem != null)
            {
                HistDateBox.SelectedDate = Convert.ToDateTime((datagrid.SelectedItem as DataRowView).Row[3]);
                HistTypeBox.Text = (datagrid.SelectedItem as DataRowView).Row[4].ToString();
                HistDescBox.Text = (datagrid.SelectedItem as DataRowView).Row[5].ToString();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            if (string.IsNullOrWhiteSpace(AnimalBox.Text) || string.IsNullOrWhiteSpace(OwnerBox.Text)
                || string.IsNullOrWhiteSpace(HistDateBox.SelectedDate.ToString()) || string.IsNullOrWhiteSpace(HistTypeBox.Text)
                || string.IsNullOrWhiteSpace(HistDescBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(HistDescBox.Text) || !latinAndRussianRegex.IsMatch(HistTypeBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else
            {
                object cell1 = (AnimalBox.SelectedItem as DataRowView).Row[0];
                object cell2 = (OwnerBox.SelectedItem as DataRowView).Row[0];
                histories.InsertQuery(Convert.ToInt32(cell1.ToString()), Convert.ToInt32(cell2.ToString()),
                    HistDateBox.SelectedDate.ToString(), HistTypeBox.Text, HistDescBox.Text);
                datagrid.ItemsSource = histories.GetData();
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            if (string.IsNullOrWhiteSpace(AnimalBox.Text) || string.IsNullOrWhiteSpace(OwnerBox.Text)
                || string.IsNullOrWhiteSpace(HistDateBox.SelectedDate.ToString()) || string.IsNullOrWhiteSpace(HistTypeBox.Text)
                || string.IsNullOrWhiteSpace(HistDescBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(HistDescBox.Text) || !latinAndRussianRegex.IsMatch(HistTypeBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else
            {
                var selectedItem = datagrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    object cell1 = (AnimalBox.SelectedItem as DataRowView).Row[0];
                    object cell2 = (OwnerBox.SelectedItem as DataRowView).Row[0];
                    object id = (datagrid.SelectedItem as DataRowView).Row[0];
                    histories.UpdateQuery(Convert.ToInt32(cell1.ToString()), Convert.ToInt32(cell2.ToString()),
                        HistDateBox.SelectedDate.ToString(), HistTypeBox.Text, HistDescBox.Text, Convert.ToInt32(id));
                    datagrid.ItemsSource = histories.GetData();
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
                histories.DeleteQuery(Convert.ToInt32(id));
                datagrid.ItemsSource = histories.GetData();
            }
            else
                MessageBox.Show("Элемент не выбран");
        }
    }
}
