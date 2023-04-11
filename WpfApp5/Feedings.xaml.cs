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
    public partial class Feedings : Page
    {
        FeedingsTableAdapter feedings = new FeedingsTableAdapter();
        AnimalsTableAdapter animals = new AnimalsTableAdapter();
        VeterinarsTableAdapter veterinars = new VeterinarsTableAdapter();
        public Feedings()
        {
            InitializeComponent();
            datagrid.ItemsSource = feedings.GetData();
            AnimalBox.ItemsSource = animals.GetData();
            VeterinarsBox.ItemsSource = veterinars.GetData();
            AnimalBox.DisplayMemberPath = "animal_name";
            VeterinarsBox.DisplayMemberPath = "vet_first_name";
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            if (string.IsNullOrWhiteSpace(AnimalBox.Text) || string.IsNullOrWhiteSpace(VeterinarsBox.Text)
                || string.IsNullOrWhiteSpace(FoodTypeBox.Text) || string.IsNullOrWhiteSpace(FoodAmountBox.Text)
                || string.IsNullOrWhiteSpace(FeedDateBox.SelectedDate.ToString()))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(FoodTypeBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else
            {
                int foodAmount;
                if (!int.TryParse(FoodAmountBox.Text, out foodAmount))
                {
                    MessageBox.Show("Количество еды должно быть числом");
                }
                else
                {
                    if (foodAmount < 0)
                    {
                        MessageBox.Show("Количество еды не может быть отрицательным");
                    }
                    else
                    {
                        object cell1 = (AnimalBox.SelectedItem as DataRowView).Row[0];
                        object cell2 = (VeterinarsBox.SelectedItem as DataRowView).Row[0];
                        feedings.InsertQuery(Convert.ToInt32(cell1.ToString()), Convert.ToInt32(cell2.ToString()), FoodTypeBox.Text,
                            Convert.ToInt16(FoodAmountBox.Text), FeedDateBox.SelectedDate.ToString());
                        datagrid.ItemsSource = feedings.GetData();
                    }
                }
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            if (string.IsNullOrWhiteSpace(AnimalBox.Text) || string.IsNullOrWhiteSpace(VeterinarsBox.Text)
                || string.IsNullOrWhiteSpace(FoodTypeBox.Text) || string.IsNullOrWhiteSpace(FoodAmountBox.Text)
                || string.IsNullOrWhiteSpace(FeedDateBox.SelectedDate.ToString()))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(FoodTypeBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else
            {
                var selectedItem = datagrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    int foodAmount;
                    if (!int.TryParse(FoodAmountBox.Text, out foodAmount))
                    {
                        MessageBox.Show("Количество еды должно быть числом");
                    }
                    else
                    {
                        if (foodAmount < 0)
                        {
                            MessageBox.Show("Количество еды не может быть отрицательным");
                        }
                        else
                        {
                            object cell1 = (AnimalBox.SelectedItem as DataRowView).Row[0];
                            object cell2 = (VeterinarsBox.SelectedItem as DataRowView).Row[0];
                            object id = (datagrid.SelectedItem as DataRowView).Row[0];
                            feedings.UpdateQuery(Convert.ToInt32(cell1.ToString()), Convert.ToInt32(cell2.ToString()), FoodTypeBox.Text,
                                Convert.ToInt16(FoodAmountBox.Text), FeedDateBox.SelectedDate.ToString(), Convert.ToInt32(id));
                            datagrid.ItemsSource = feedings.GetData();
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
                feedings.DeleteQuery(Convert.ToInt32(id));
                datagrid.ItemsSource = feedings.GetData();
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
                FoodTypeBox.Text = (datagrid.SelectedItem as DataRowView).Row[3].ToString();
                FoodAmountBox.Text = (datagrid.SelectedItem as DataRowView).Row[4].ToString();
                FeedDateBox.SelectedDate = Convert.ToDateTime((datagrid.SelectedItem as DataRowView).Row[5]);
            }
        }
    }
}
