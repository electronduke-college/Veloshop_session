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
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        private readonly MainWindow mainWindow;
        ManufacturerTableAdapter manufacturer;
        ProductTableAdapter products;
        private readonly VeloShopDataSet.UserRow user;

        public AddProductPage(MainWindow mainWindow, VeloShopDataSet.UserRow user)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.user = user;
            manufacturer = new ManufacturerTableAdapter();
            products = new ProductTableAdapter();   
            cbManufacturer.ItemsSource = manufacturer.GetData().ToList();
            cbManufacturer.DisplayMemberPath = "ManufacturerName";
            cbManufacturer.SelectedValuePath= "Id";
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            string description = tbDescription.Text;
            int count = 0;
            decimal price = 0;
            int discount = 0;
            int manufacturerId = 1;

            string error = "";

            
            if(tbName.Text == "")
            {
                error += "\nНазвание товара - обязательное поле!";
            }

            if (tbDescription.Text == "")
            {
                error += "\nОписание товара - обязательное поле!";
            }

            if (Int32.TryParse(tbCount.Text, out int countOut))
            {
                count = countOut;
            }
            else
            {
                error += "\nКоличество товара - целочисленное число!";
            }

            if (Int32.TryParse(tbDiscount.Text, out int discOut))
            {
                discount= discOut;
            }
            else
            {
                error += "\nРазмер скидки товара - целочисленное число!";
            }
            if (decimal.TryParse(tbCount.Text, out decimal priceOut))
            {
                price = priceOut;
            }
            else
            {
                error += "\nЦена товара должна быть числом!";
            }
            if(cbManufacturer.SelectedValue == null)
            {
                error += "\nПроизводитель - обяхательно для заполнения!";
            }
            else
            {
                manufacturerId = int.Parse(cbManufacturer.SelectedValue.ToString());
            }
            if(error != "")
            {
                MessageBox.Show(error);
            }
            else
            {
                products.InsertQuery(name, description, "", manufacturerId, price, discount, count);
                this.NavigationService.Navigate(new AdminPage(mainWindow, user));
            }


        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
