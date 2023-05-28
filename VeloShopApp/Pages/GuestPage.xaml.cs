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
    /// Логика взаимодействия для GuestPage.xaml
    /// </summary>
    public partial class GuestPage : Page
    {
        private readonly MainWindow mainWindow;
        ProductTableAdapter products;
        public GuestPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            products = new ProductTableAdapter();           
            UpdateListView();

        }

        private void UpdateListView()
        {
            var list = products.GetData().ToList();
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
