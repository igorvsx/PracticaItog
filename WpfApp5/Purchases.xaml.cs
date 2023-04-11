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
    public partial class Purchases : Page
    {
        PurchasesTableAdapter purchases = new PurchasesTableAdapter();
        BuyersTableAdapter buyers = new BuyersTableAdapter();
        EmployeesTableAdapter employees = new EmployeesTableAdapter();
        AnimalsTableAdapter animals = new AnimalsTableAdapter();
        public Purchases()
        {
            InitializeComponent();
            datagrid.ItemsSource = purchases.GetData();
            BuyerBox.ItemsSource = buyers.GetData();
            EmployeeBox.ItemsSource = employees.GetData();
            AnimalBox.ItemsSource = animals.GetData();
            BuyerBox.DisplayMemberPath = "buyer_name";
            EmployeeBox.DisplayMemberPath = "employee_name";
            AnimalBox.DisplayMemberPath = "animal_name";
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BuyerBox.ItemsSource = buyers.GetData();
            EmployeeBox.ItemsSource = employees.GetData();
            AnimalBox.ItemsSource = animals.GetData();
            var selectedItem = datagrid.SelectedItem;
            if (selectedItem != null)
            {
                PurchDateBox.SelectedDate = Convert.ToDateTime((datagrid.SelectedItem as DataRowView).Row[1]);
                AnimalNameBox.Text = (datagrid.SelectedItem as DataRowView).Row[2].ToString();
                BuyerNameBox.Text = (datagrid.SelectedItem as DataRowView).Row[3].ToString();
                EmployeeNameBox.Text = (datagrid.SelectedItem as DataRowView).Row[4].ToString();
                PriceBox.Text = (datagrid.SelectedItem as DataRowView).Row[5].ToString();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            if (string.IsNullOrWhiteSpace(PurchDateBox.SelectedDate.ToString()) || string.IsNullOrWhiteSpace(AnimalNameBox.Text) 
                || string.IsNullOrWhiteSpace(BuyerNameBox.Text) || string.IsNullOrWhiteSpace(EmployeeNameBox.Text)
                || string.IsNullOrWhiteSpace(PriceBox.Text) || string.IsNullOrWhiteSpace(BuyerBox.Text) 
                || string.IsNullOrWhiteSpace(EmployeeBox.Text)|| string.IsNullOrWhiteSpace(AnimalBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(AnimalNameBox.Text) || !latinAndRussianRegex.IsMatch(BuyerNameBox.Text) || !latinAndRussianRegex.IsMatch(EmployeeNameBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else
            {
                byte animalPrice;
                if (byte.TryParse(PriceBox.Text, out animalPrice))
                {
                    if (animalPrice < 0)
                    {
                        MessageBox.Show("Введенные значения цены не могут быть отрицательными");
                    }
                    else
                    {
                        object cell1 = (BuyerBox.SelectedItem as DataRowView).Row[0];
                        object cell2 = (EmployeeBox.SelectedItem as DataRowView).Row[0];
                        object cell3 = (AnimalBox.SelectedItem as DataRowView).Row[0];
                        purchases.InsertQuery(PurchDateBox.SelectedDate.ToString(), AnimalNameBox.Text,
                            BuyerNameBox.Text, EmployeeNameBox.Text, animalPrice, Convert.ToInt32(cell1.ToString()),
                            Convert.ToInt32(cell2.ToString()), Convert.ToInt32(cell3.ToString()));
                        datagrid.ItemsSource = purchases.GetData();
                    }
                }
                else
                {
                    MessageBox.Show("Введенные значения для цены должны быть числами");
                }
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            if (string.IsNullOrWhiteSpace(PurchDateBox.SelectedDate.ToString()) || string.IsNullOrWhiteSpace(AnimalNameBox.Text)
                || string.IsNullOrWhiteSpace(BuyerNameBox.Text) || string.IsNullOrWhiteSpace(EmployeeNameBox.Text)
                || string.IsNullOrWhiteSpace(PriceBox.Text) || string.IsNullOrWhiteSpace(BuyerBox.Text)
                || string.IsNullOrWhiteSpace(EmployeeBox.Text) || string.IsNullOrWhiteSpace(AnimalBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(AnimalNameBox.Text) || !latinAndRussianRegex.IsMatch(BuyerNameBox.Text) || !latinAndRussianRegex.IsMatch(EmployeeNameBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else
            {
                var selectedItem = datagrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    byte animalPrice;
                    if (byte.TryParse(PriceBox.Text, out animalPrice))
                    {
                        if (animalPrice < 0)
                        {
                            MessageBox.Show("Введенные значения для цены не могут быть отрицательными");
                        }
                        else
                        {
                            object cell1 = (BuyerBox.SelectedItem as DataRowView).Row[0];
                            object cell2 = (EmployeeBox.SelectedItem as DataRowView).Row[0];
                            object cell3 = (AnimalBox.SelectedItem as DataRowView).Row[0];
                            object id = (datagrid.SelectedItem as DataRowView).Row[0];
                            purchases.UpdateQuery(PurchDateBox.SelectedDate.ToString(), AnimalNameBox.Text,
                            BuyerNameBox.Text, EmployeeNameBox.Text, animalPrice, Convert.ToInt32(cell1.ToString()),
                            Convert.ToInt32(cell2.ToString()), Convert.ToInt32(cell3.ToString()), Convert.ToInt32(id));
                            datagrid.ItemsSource = purchases.GetData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введенные значения цены должны быть числами");
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
                purchases.DeleteQuery(Convert.ToInt32(id));
                datagrid.ItemsSource = purchases.GetData();
            }
            else
                MessageBox.Show("Элемент не выбран");
        }
    }
}
