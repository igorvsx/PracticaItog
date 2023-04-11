using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
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
//using System.Windows.Shapes;
using WpfApp5.PitomnikBaseDataSetTableAdapters;

namespace WpfApp5
{
    public partial class BuyPage : Page
    {
        AnimalsTableAdapter animals = new AnimalsTableAdapter();
        EmployeesTableAdapter employees = new EmployeesTableAdapter();
        BuyersTableAdapter buyers = new BuyersTableAdapter();
        PurchasesTableAdapter purchases = new PurchasesTableAdapter();
        private DataTable billsTable;
        public BuyPage()
        {
            InitializeComponent();
            AnimalsGrid.ItemsSource = animals.GetData();
            BuyersComboBox.ItemsSource = buyers.GetData();
            BuyersComboBox.DisplayMemberPath = "buyer_name";
            EmployessComboBox.ItemsSource = employees.GetData();
            EmployessComboBox.DisplayMemberPath = "employee_name";
            billsTable = new DataTable("BillsTable");
            DataColumn idcolumn = new DataColumn("Id", typeof(int));
            DataColumn nameColumn = new DataColumn("Name", typeof(string));
            DataColumn priceColumn = new DataColumn("Price", typeof(float));
            billsTable.Columns.Add(idcolumn);
            billsTable.Columns.Add(nameColumn);
            billsTable.Columns.Add(priceColumn);
            BillsGrid.ItemsSource = billsTable.DefaultView;
        }
        private float fullprice;
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = AnimalsGrid.SelectedItem as DataRowView;
            if (selectedItem != null)
            {
                object id = selectedItem.Row[0];
                object name = selectedItem.Row[1];
                object price = selectedItem.Row[6];
                fullprice += (byte)price;
                FullPriceTextBlock.Text = $"Товары в чеке. Полная цена: {fullprice}";
                DataRow newRow = billsTable.NewRow();
                newRow["Id"] = id;
                newRow["Name"] = name;
                newRow["Price"] = price;
                billsTable.Rows.Add(newRow);
            }
            else
                MessageBox.Show("Элемент не выбран");
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = BillsGrid.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                object price = selectedRow.Row[2];
                fullprice -= (float)price;
                FullPriceTextBlock.Text = $"Товары в чеке. Полная цена: {fullprice}";
                var dataView = (DataView)BillsGrid.ItemsSource;
                var dataTable = dataView.Table;
                dataTable.Rows.Remove(selectedRow.Row);
            }
            else
                MessageBox.Show("Элемент не выбран");
        }

        private void CloseAndSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SummaBox.Text) && string.IsNullOrWhiteSpace(BuyersComboBox.Text)
                && string.IsNullOrWhiteSpace(EmployessComboBox.Text))
            {
                MessageBox.Show("Вы ввели пустые строки");
            }
            else
            {
                float buyermoney;
                if (float.TryParse(SummaBox.Text, out buyermoney))
                {
                    if (buyermoney < 0)
                    {
                        MessageBox.Show("Где деньги лебовски");
                    }
                    else
                    {
                        if (buyermoney >= fullprice)
                        {
                            int id = 1;
                            float sdacha = buyermoney - fullprice;

                            string programName = "Питомник";
                            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                            string fileName = $"Кассовый чек№{id}.txt";
                            string filePath = Path.Combine(desktopPath, fileName);

                            object cell1 = (BuyersComboBox.SelectedItem as DataRowView).Row[0];
                            object cell2 = (EmployessComboBox.SelectedItem as DataRowView).Row[0];

                            using (StreamWriter writer = new StreamWriter(filePath))
                            {
                                writer.WriteLine($"\t\t{programName}\n\t\t{fileName}\n");
                                foreach (DataRow row in billsTable.Rows)
                                {
                                    if (!string.IsNullOrEmpty(row["Name"].ToString()) && !string.IsNullOrEmpty(row["Price"].ToString()))
                                    {
                                        string itemName = row["Name"].ToString();
                                        double itemPrice = Convert.ToDouble(row["Price"]);
                                        int idd = Convert.ToInt32(row["Id"]);
                                        writer.WriteLine($"\t{itemName}\t-\t{itemPrice:F2}");
                                        purchases.InsertQuery(Convert.ToDateTime(DateTime.Now).ToString(), itemName.ToString(),
                                            BuyersComboBox.Text, EmployessComboBox.Text, itemPrice, Convert.ToInt32(cell1.ToString()),
                                            Convert.ToInt32(cell2.ToString()), idd);
                                    }  
                                }
                                writer.WriteLine($"\nИтого к оплате: {fullprice}");
                                writer.WriteLine($"Внесено: {buyermoney}");
                                writer.WriteLine($"Сдача: {sdacha}");
                            }
                            MessageBox.Show("Данные успешно записаны в файл!");
                        }
                        else if (buyermoney < fullprice)
                        {
                            MessageBox.Show("Еще давай");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введенные значения суммы должны быть числами");
                }
            }
        }
    }
}
