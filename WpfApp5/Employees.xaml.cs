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
    public partial class Employees : Page
    {
        EmployeesTableAdapter employees = new EmployeesTableAdapter();
        RolesTableAdapter roles = new RolesTableAdapter();
        public Employees()
        {
            InitializeComponent();
            datagrid.ItemsSource = employees.GetData();
            RolesBox.ItemsSource = roles.GetData();
            RolesBox.DisplayMemberPath = "role_name";
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RolesBox.ItemsSource = roles.GetData();
            var selectedItem = datagrid.SelectedItem as DataRowView;
            if (selectedItem != null)
            {
                EmployeeNameBox.Text = (datagrid.SelectedItem as DataRowView).Row[1].ToString();
                EmployeeLastBox.Text = (datagrid.SelectedItem as DataRowView).Row[2].ToString();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            if (string.IsNullOrWhiteSpace(EmployeeNameBox.Text) || string.IsNullOrWhiteSpace(EmployeeLastBox.Text) || string.IsNullOrWhiteSpace(RolesBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(EmployeeNameBox.Text) || !latinAndRussianRegex.IsMatch(EmployeeLastBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else
            {
                object cell1 = (RolesBox.SelectedItem as DataRowView).Row[0];
                employees.InsertQuery(EmployeeNameBox.Text, EmployeeLastBox.Text, Convert.ToInt32(cell1.ToString()));
                datagrid.ItemsSource = employees.GetData();
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            if (string.IsNullOrWhiteSpace(EmployeeNameBox.Text) || string.IsNullOrWhiteSpace(EmployeeLastBox.Text) || string.IsNullOrWhiteSpace(RolesBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(EmployeeNameBox.Text) || !latinAndRussianRegex.IsMatch(EmployeeNameBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else
            {
                var selectedItem = datagrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    object cell1 = (RolesBox.SelectedItem as DataRowView).Row[0];
                    object id = (datagrid.SelectedItem as DataRowView).Row[0];
                    employees.UpdateQuery(EmployeeNameBox.Text, EmployeeLastBox.Text, Convert.ToInt32(cell1.ToString()), Convert.ToInt32(id));
                    datagrid.ItemsSource = employees.GetData();
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
                employees.DeleteQuery(Convert.ToInt32(id));
                datagrid.ItemsSource = employees.GetData();
            }
            else
                MessageBox.Show("Элемент не выбран");
        }
    }
}
