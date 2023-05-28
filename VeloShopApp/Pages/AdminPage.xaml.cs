using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using VeloShopApp.VeloShopDataSetTableAdapters;

namespace VeloShopApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class AdminPage: Page
    {
        private readonly MainWindow mainWindow;
        private readonly VeloShopDataSet.UserRow user;
        ProductTableAdapter products;        
        public AdminPage(MainWindow mainWindow, VeloShopDataSet.UserRow user)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.user = user;
            products = new ProductTableAdapter();
            tbUsername.Text = $"{user.Surname} {user.Name}";            
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

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateListView();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListView();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddProductPage(mainWindow, user));
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var product = ((sender as Button).DataContext as VeloShopDataSet.ProductRow);
            
            var orders = new OrderProductTableAdapter();
            var productInOrder = orders.GetData().ToList().FirstOrDefault(order => order.ProductId == product.Id);
            if (productInOrder == null)
            {               
                products.DeleteQuery(product.Id);
            }
            else
            {
                MessageBox.Show("Данный товар нельзя удалить, так как он находится в заказе");
            }
            
            UpdateListView();
        }
    }
}
