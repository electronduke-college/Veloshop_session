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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VeloShopApp.VeloShopDataSetTableAdapters;

namespace VeloShopApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private readonly MainWindow mainWindow;
        UserTableAdapter userTableAdapter;        
        public AuthPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            userTableAdapter = new UserTableAdapter();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text;
            string password = tbPassword.Text;
            var user = userTableAdapter.GetData().Where(u => u.Login == login).Where(u => u.Password == password).FirstOrDefault();

            if(user == null)
            {
                MessageBox.Show("неправильный логин или пароль!\nПроеврьте данные и повторите попытку.");
            }
            else
            {
                if(user.RoleId == 3)
                {
                    this.NavigationService.Navigate(new ClientPage(mainWindow, user));
                }
                else if(user.RoleId == 1)
                {
                    this.NavigationService.Navigate(new AdminPage(mainWindow, user));
                }
                
            }
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GuestPage(mainWindow));
        }
    }
}
