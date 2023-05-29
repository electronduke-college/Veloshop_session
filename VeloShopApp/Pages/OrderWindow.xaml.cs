using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
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

namespace VeloShopApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private readonly MainWindow mainWindow;
        private List<VeloShopDataSet.ProductRow> products;
        public OrderWindow(MainWindow mainWindow, List<VeloShopDataSet.ProductRow> products)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.products = products;
            UpdateListView();
        }

        private void UpdateListView()
        {

            if (products.Count > 0)
            {
                btnMakeOrder.Visibility = Visibility.Visible;
            }
            else
            {
                btnMakeOrder.Visibility = Visibility.Collapsed;
            }
            var list = products;

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
            tbCount.Text = $"{list.Count} из {products.Count}";
            lwProducts.ItemsSource = list;
            lwProducts.Items.Refresh();
            decimal fullPrice = 0;
            decimal newPrice = 0;

            products.ForEach(item => fullPrice += item.Price);
            products.ForEach(item =>
            {
                if (item.DiscountAmount != 0)
                {
                    newPrice += item.Price - (item.Price / 100 * item.DiscountAmount);
                }
                else
                {
                    newPrice += item.Price;
                }
            });
            tbOldPrice.Text = fullPrice.ToString();
            tbNewPrice.Text = newPrice.ToString();

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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMakeOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            products.Remove(products.Where(item => item == ((sender as Button).DataContext as VeloShopDataSet.ProductRow)).First());
            UpdateListView();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListView();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateListView();
        }
    }
}
