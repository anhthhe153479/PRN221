using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Core.IRepository;
using Core.Models;
using Core.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProjectQLBH
{
    /// <summary>
    /// Interaction logic for QLProduct.xaml
    /// </summary>
    public partial class QLProduct : UserControl
    {
        Management_System_ProjectContext _context = new Management_System_ProjectContext();
        private List<Product> products;
        private List<Category> categories;
        private IProductRepository productRepository;
        public QLProduct()
        {
            products = new List<Product>();
            categories = new List<Category>();
            InitializeComponent();
            products = _context.Products.ToList();
            categories = _context.Categories.ToList();
            cbCate.ItemsSource = categories;
            cbSearch.ItemsSource = categories;
            ProductListView.ItemsSource = products;
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductListView.SelectedItem != null)
            {
                Product selectedProduct = (Product)ProductListView.SelectedItem;
                tbName.Text = selectedProduct.ProductName;
                tbStatus.Text = selectedProduct.Status;
                dpdateAdd.SelectedDate = selectedProduct.DateAdd;
                tbImage.Text = selectedProduct.Image;
                cbCate.Text = selectedProduct.Category.CategoryName;
                tbImportPrice.Text =selectedProduct.ImportPrice.ToString();
                tbSellPrice.Text = selectedProduct.SellPrice.ToString();
                tbTonKho.Text = selectedProduct.NumberOfInventoty.ToString();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == "" || tbStatus.Text == "" || dpdateAdd.Text == default || tbImage.Text == "" || cbCate.Text == "" || tbImportPrice.Text == "" || tbSellPrice.Text == "" || tbTonKho.Text == "")
            {
                MessageBox.Show("Điền đủ thông tin");
            }
            else
            {
                string name = tbName.Text;
                Product product = products.FirstOrDefault(x => x.ProductName.Equals(tbName));
                if (product == null)
                {
                    Product s = new Product();
                    s.ProductName = tbName.Text;
                    s.DateAdd = Convert.ToDateTime(dpdateAdd.ToString());
                    s.Status = tbStatus.Text;
                    s.Image= tbImage.Text;
                    s.ImportPrice= Convert.ToDecimal(tbImportPrice.ToString());
                    s.SellPrice = Convert.ToDecimal(tbSellPrice.ToString());
                    s.NumberOfInventoty = Convert.ToInt32(tbTonKho.ToString());
                    s.Category.CategoryName = cbCate.ToString();
                    RefershItem();
                    ProductListView.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Student đã tồn tại");
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ProductListView.SelectedItem != null)
            {
                products.Remove((Product)ProductListView.SelectedItem);
                ProductListView.Items.Refresh();
                RefershItem();
            }
            else
            {
                MessageBox.Show("Chọn sản phẩm");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == "" || tbStatus.Text == "" || dpdateAdd.Text == default || tbImage.Text == "" || cbCate.Text == "" || tbImportPrice.Text == "" || tbSellPrice.Text == "" || tbTonKho.Text == "")
            {
                MessageBox.Show("Điền đủ thông tin");
            }
            else
            {
                string name = tbName.Text;
                Product product = products.FirstOrDefault(x => x.ProductName.Equals(tbName));
                if (product != null)
                {
                    Product selectedProduct = (Product)ProductListView.SelectedItem;
                    productRepository.UpdateProduct(selectedProduct);
                    RefershItem();
                    ProductListView.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Student đã tồn tại");
                }
            }
        }
        private void RefershItem()
        {
            tbName.Text = "";
            tbStatus.Text = "";
            dpdateAdd.SelectedDate = default;
            tbImage.Text = "";
            cbCate.Text = "";
            tbImportPrice.Text = "";
            tbSellPrice.Text = "";
            tbTonKho.Text = "";
        }
    }
}
