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

namespace VeloShopApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        private readonly MainWindow mainWindow;
        private readonly VeloShopDataSet.UserRow user;
        public ClientPage(MainWindow mainWindow, VeloShopDataSet.UserRow user)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.user = user;   
        }
    }
}
