    using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
using static WpfApp5.PitomnikBaseDataSet;

namespace WpfApp5
{
    public partial class Adaptations : Page
    {
        AdaptationsTableAdapter adaptations = new AdaptationsTableAdapter();
        AnimalsTableAdapter animals = new AnimalsTableAdapter();
        Potential_ownersTableAdapter owners = new Potential_ownersTableAdapter();
        public Adaptations()
        {
            InitializeComponent();
            datagrid.ItemsSource = adaptations.GetData();
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
                StartDateBox.SelectedDate = Convert.ToDateTime((datagrid.SelectedItem as DataRowView).Row[3]);
                EndDateBox.SelectedDate = Convert.ToDateTime((datagrid.SelectedItem as DataRowView).Row[4]);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime firstDate = StartDateBox.SelectedDate.Value;
            DateTime secondDate = EndDateBox.SelectedDate.Value;
            if (string.IsNullOrWhiteSpace(AnimalBox.Text) || string.IsNullOrWhiteSpace(OwnerBox.Text)
                || string.IsNullOrWhiteSpace(StartDateBox.SelectedDate.ToString()) || string.IsNullOrWhiteSpace(EndDateBox.SelectedDate.ToString()))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (secondDate < firstDate)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания");
            }
            else
            {
                object cell1 = (AnimalBox.SelectedItem as DataRowView).Row[0];
                object cell2 = (OwnerBox.SelectedItem as DataRowView).Row[0];
                adaptations.InsertQuery(Convert.ToInt32(cell1.ToString()), Convert.ToInt32(cell2.ToString()),
                    StartDateBox.SelectedDate.ToString(), EndDateBox.SelectedDate.ToString());
                datagrid.ItemsSource = adaptations.GetData();
                AnimalBox.ItemsSource = animals.GetData();
                OwnerBox.ItemsSource = owners.GetData();
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime firstDate = StartDateBox.SelectedDate.Value;
            DateTime secondDate = EndDateBox.SelectedDate.Value;
            if (string.IsNullOrWhiteSpace(AnimalBox.Text) || string.IsNullOrWhiteSpace(OwnerBox.Text)
                || string.IsNullOrWhiteSpace(StartDateBox.SelectedDate.ToString()) || string.IsNullOrWhiteSpace(EndDateBox.SelectedDate.ToString()))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (secondDate < firstDate)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания");
            }
            else
            {
                var selectedItem = datagrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    object cell1 = (AnimalBox.SelectedItem as DataRowView).Row[0];
                    object cell2 = (OwnerBox.SelectedItem as DataRowView).Row[0];
                    object id = (datagrid.SelectedItem as DataRowView).Row[0];
                    adaptations.UpdateQuery(Convert.ToInt32(cell1.ToString()), Convert.ToInt32(cell2.ToString()),
                        StartDateBox.SelectedDate.ToString(), EndDateBox.SelectedDate.ToString(), Convert.ToInt32(id));
                    datagrid.ItemsSource = adaptations.GetData();
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
                adaptations.DeleteQuery(Convert.ToInt32(id));
                datagrid.ItemsSource = adaptations.GetData();
            }
            else
                MessageBox.Show("Элемент не выбран");
        }
    }
}
