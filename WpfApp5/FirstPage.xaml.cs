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
    public partial class FirstPage : Page
    {
        AnimalsTableAdapter animals = new AnimalsTableAdapter();
        OrganizationsTableAdapter organizations = new OrganizationsTableAdapter();
        public FirstPage()
        {
            InitializeComponent();
            datagrid.ItemsSource = animals.GetData();
            AnimalOrganizationBox.ItemsSource = organizations.GetData();
            AnimalOrganizationBox.DisplayMemberPath = "organization_name";
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            if (string.IsNullOrWhiteSpace(AnimalNameBox.Text) || string.IsNullOrWhiteSpace(AnimalBreedBox.Text) || string.IsNullOrWhiteSpace(AnimalAgeBox.Text)
                || string.IsNullOrWhiteSpace(AnimalWeightBox.Text) || string.IsNullOrWhiteSpace(AnimalStatusBox.Text) || string.IsNullOrWhiteSpace(AnimalPriceBox.Text)
                || string.IsNullOrWhiteSpace(AnimalOrganizationBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(AnimalNameBox.Text) || !latinAndRussianRegex.IsMatch(AnimalBreedBox.Text) || !latinAndRussianRegex.IsMatch(AnimalStatusBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else
            {
                byte animalAge, animalPrice;
                double animalWeight;
                if (byte.TryParse(AnimalAgeBox.Text, out animalAge) && double.TryParse(AnimalWeightBox.Text, out animalWeight) && byte.TryParse(AnimalPriceBox.Text, out animalPrice))
                {
                    if (animalAge < 0 || animalWeight < 0 || animalPrice < 0)
                    {
                        MessageBox.Show("Введенные значения для возраста, веса и цены не могут быть отрицательными");
                    }
                    else
                    {
                        object cell1 = (AnimalOrganizationBox.SelectedItem as DataRowView).Row[0];
                        animals.InsertQuery(AnimalNameBox.Text, AnimalBreedBox.Text, animalAge, animalWeight, AnimalStatusBox.Text, animalPrice, Convert.ToInt32(cell1.ToString()));
                        datagrid.ItemsSource = animals.GetData();
                    }    
                }
                else
                {
                    MessageBox.Show("Введенные значения для возраста, веса и цены должны быть числами");
                }
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
            if (string.IsNullOrWhiteSpace(AnimalNameBox.Text) || string.IsNullOrWhiteSpace(AnimalBreedBox.Text) || string.IsNullOrWhiteSpace(AnimalAgeBox.Text)
                || string.IsNullOrWhiteSpace(AnimalWeightBox.Text) || string.IsNullOrWhiteSpace(AnimalStatusBox.Text) || string.IsNullOrWhiteSpace(AnimalPriceBox.Text)
                || string.IsNullOrWhiteSpace(AnimalOrganizationBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else if (!latinAndRussianRegex.IsMatch(AnimalNameBox.Text) || !latinAndRussianRegex.IsMatch(AnimalBreedBox.Text) || !latinAndRussianRegex.IsMatch(AnimalStatusBox.Text))
            {
                MessageBox.Show("Поля должно содержать только латинские или русские символы");
            }
            else
            {
                var selectedItem = datagrid.SelectedItem as DataRowView;
                if (selectedItem != null)
                {
                    byte animalAge, animalPrice;
                    double animalWeight;
                    if (byte.TryParse(AnimalAgeBox.Text, out animalAge) && double.TryParse(AnimalWeightBox.Text, out animalWeight) && byte.TryParse(AnimalPriceBox.Text, out animalPrice))
                    {
                        if (animalAge < 0 || animalWeight < 0 || animalPrice < 0)
                        {
                            MessageBox.Show("Введенные значения для возраста, веса и цены не могут быть отрицательными");
                        }
                        else
                        {
                            object cell1 = (AnimalOrganizationBox.SelectedItem as DataRowView).Row[0];
                            object id = (datagrid.SelectedItem as DataRowView).Row[0];
                            animals.UpdateQuery(AnimalNameBox.Text, AnimalBreedBox.Text, animalAge, animalWeight,
                                AnimalStatusBox.Text, animalPrice, Convert.ToInt32(cell1.ToString()), Convert.ToInt32(id));
                            datagrid.ItemsSource = animals.GetData();
                        } 
                    }
                    else
                    {
                        MessageBox.Show("Введенные значения для возраста, веса и цены должны быть числами");
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
                animals.DeleteQuery(Convert.ToInt32(id));
                datagrid.ItemsSource = animals.GetData();
            }
            else
                MessageBox.Show("Элемент не выбран");
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AnimalOrganizationBox.ItemsSource = organizations.GetData();
            var selectedItem = datagrid.SelectedItem;
            if (selectedItem != null)
            {
                AnimalNameBox.Text = (datagrid.SelectedItem as DataRowView).Row[1].ToString();
                AnimalBreedBox.Text = (datagrid.SelectedItem as DataRowView).Row[2].ToString();
                AnimalAgeBox.Text = (datagrid.SelectedItem as DataRowView).Row[3].ToString(); 
                AnimalWeightBox.Text = (datagrid.SelectedItem as DataRowView).Row[4].ToString();
                AnimalStatusBox.Text = (datagrid.SelectedItem as DataRowView).Row[5].ToString();
                AnimalPriceBox.Text = (datagrid.SelectedItem as DataRowView).Row[6].ToString();
            }
        }
    }
}
