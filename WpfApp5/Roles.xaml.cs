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
    public partial class Roles : Page
    {
        RolesTableAdapter roles = new RolesTableAdapter();
        public Roles()
        {
            InitializeComponent();
            datagrid.ItemsSource = roles.GetData();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string loginPattern = @"^[\p{L}\p{N}]+$";
            if (string.IsNullOrWhiteSpace(RoleNameBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!Regex.IsMatch(RoleNameBox.Text, loginPattern))
            {
                MessageBox.Show("Адрес должен содержать только латинские, русские символы или цифры!");
                return;
            }
            else
            {
                roles.InsertQuery(RoleNameBox.Text);
                datagrid.ItemsSource = roles.GetData();
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            string loginPattern = @"^[\p{L}\p{N}]+$";
            if (string.IsNullOrWhiteSpace(RoleNameBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!Regex.IsMatch(RoleNameBox.Text, loginPattern))
            {
                MessageBox.Show("Адрес должен содержать только латинские, русские символы или цифры!");
                return;
            }
            else
            {
                var selectedItem = datagrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    object id = (datagrid.SelectedItem as DataRowView).Row[0];
                    roles.UpdateQuery(RoleNameBox.Text, Convert.ToInt32(id));
                    datagrid.ItemsSource = roles.GetData();
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
                roles.DeleteQuery(Convert.ToInt32(id));
                datagrid.ItemsSource = roles.GetData();
            }
            else
                MessageBox.Show("Элемент не выбран");
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = datagrid.SelectedItem;
            if (selectedItem != null)
            {
                RoleNameBox.Text = (datagrid.SelectedItem as DataRowView).Row[1].ToString();
            }
        }
    }
}
