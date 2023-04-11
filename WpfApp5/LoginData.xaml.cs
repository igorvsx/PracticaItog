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
    public partial class LoginData : Page
    {
        LoginDataTableAdapter logins = new LoginDataTableAdapter();
        RolesTableAdapter roles = new RolesTableAdapter();
        public LoginData()
        {
            InitializeComponent();
            datagrid.ItemsSource = logins.GetData();
            RolesBox.ItemsSource = roles.GetData();
            RolesBox.DisplayMemberPath = "role_name";
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RolesBox.ItemsSource = roles.GetData();
            var selectedItem = datagrid.SelectedItem as DataRowView;
            if (selectedItem != null)
            {
                LoginBox.Text = (datagrid.SelectedItem as DataRowView).Row[1].ToString();
                PassBox.Password = (datagrid.SelectedItem as DataRowView).Row[2].ToString();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string loginPattern = @"^[\p{L}\p{N}]+$";
            if (string.IsNullOrWhiteSpace(LoginBox.Text) || string.IsNullOrWhiteSpace(PassBox.Password) || string.IsNullOrWhiteSpace(RolesBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!Regex.IsMatch(LoginBox.Text, loginPattern))
            {
                MessageBox.Show("Логин должен содержать только латинские, русские символы или цифры!");
                return;
            }
            else
            {
                object cell1 = (RolesBox.SelectedItem as DataRowView).Row[0];
                logins.InsertQuery(LoginBox.Text, PassBox.Password, Convert.ToInt32(cell1.ToString()));
                datagrid.ItemsSource = logins.GetData();
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            string loginPattern = @"^[\p{L}\p{N}]+$";
            if (string.IsNullOrWhiteSpace(LoginBox.Text) || string.IsNullOrWhiteSpace(PassBox.Password) || string.IsNullOrWhiteSpace(RolesBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!Regex.IsMatch(LoginBox.Text, loginPattern))
            {
                MessageBox.Show("Логин должен содержать только латинские, русские символы или цифры!");
                return;
            }
            else
            {
                var selectedItem = datagrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    object cell1 = (RolesBox.SelectedItem as DataRowView).Row[0];
                    object id = (datagrid.SelectedItem as DataRowView).Row[0];
                    logins.UpdateQuery(LoginBox.Text, PassBox.Password, Convert.ToInt32(cell1.ToString()), Convert.ToInt32(id));
                    datagrid.ItemsSource = logins.GetData();
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
                logins.DeleteQuery(Convert.ToInt32(id));
                datagrid.ItemsSource = logins.GetData();
            }
            else
                MessageBox.Show("Элемент не выбран");
        }
    }
}
