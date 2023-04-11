using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WpfApp5.PitomnikBaseDataSetTableAdapters;

namespace WpfApp5
{
    public partial class AuthWIndow : Window
    {
        LoginDataTableAdapter adapter = new LoginDataTableAdapter();
        public AuthWIndow()
        {
            InitializeComponent();
            textblock.Visibility = Visibility.Hidden;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var allLogins = adapter.GetData().Rows;

            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][1].ToString() == LoginBox.Text &&
                    allLogins[i][2].ToString() == PasswordBox.Password)
                {
                    int roleId = (int)allLogins[i][3];

                    switch (roleId)
                    {
                        case 1:
                            MainWindow window = new MainWindow();
                            window.Show();
                            Close();
                            break;
                        case 3:
                            KassaWindow secwindow = new KassaWindow();
                            secwindow.Show();
                            Close();
                            break;
                    }
                }   
                else
                    textblock.Visibility = Visibility.Visible;
            }
        }
    }
}
