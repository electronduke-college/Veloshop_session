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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        private readonly MainWindow mainWindow;
        private readonly VeloShopDataSet.UserRow user;
        ProductTableAdapter products;
        List<VeloShopDataSet.ProductRow> productsInCart;
        public ClientPage(MainWindow mainWindow, VeloShopDataSet.UserRow user)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.user = user;
            products = new ProductTableAdapter();
            tbUsername.Text = $"{user.Surname} {user.Name}";
            productsInCart = new List<VeloShopDataSet.ProductRow>();           
            UpdateListView();
        }

        private void UpdateListView()
        {
            var list = products.GetData().ToList();

            if (tbSearch.Text != "")
            {
                list = list.Where(item => item.Name.ToLower().Contains(tbSearch.Text.ToLower()) || item.Description.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            }
            if (cbSort.SelectedValue != null)
            {
                if (cbSort.SelectedIndex == 0)
                {
                    list = list.OrderBy(item => item.Price).ToList();
                }

                if (cbSort.SelectedIndex == 1)
                {
                    list = list.OrderByDescending(item => item.Price).ToList();
                }
            }

            list = UpdateProductPhoto(list);
            tbCount.Text = $"{list.Count} из {products.GetData().ToList().Count}";
            lwProducts.ItemsSource = list;
        }

        private List<VeloShopDataSet.ProductRow> UpdateProductPhoto(List<VeloShopDataSet.ProductRow> data)
        {
            data.ForEach(item =>
            {
                if (item.Image == "")
                {
                    item.Image = "picture.png";
                }
            });
            data.ForEach(item => item.Image = $"../Images/{item.Image}");
            return data;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AuthPage(mainWindow));
        }

        private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
        {
            productsInCart.Add((sender as Button).DataContext as VeloShopDataSet.ProductRow);
            if (productsInCart.Count > 0)
            {
                btnOrder.Visibility = Visibility.Visible;
            }
            else
            {
                btnOrder.Visibility = Visibility.Collapsed;
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateListView();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow(mainWindow, productsInCart, user);

            if (orderWindow.ShowDialog().Equals(true))
            {
                Console.WriteLine("Dialog is open");
            }
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListView();
        }
    }
}
