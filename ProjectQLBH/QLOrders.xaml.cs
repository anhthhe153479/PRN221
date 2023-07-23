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
using Core.IRepository;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectQLBH
{
    /// <summary>
    /// Interaction logic for QLOrders.xaml
    /// </summary>
    public partial class QLOrders : UserControl
    {
        Management_System_ProjectContext _context = new Management_System_ProjectContext();
        private List<Product> products;
        private List<Category> categories;
        private IProductRepository productRepository;
        public QLOrders()
        {
            products = new List<Product>();
            categories = new List<Category>();
            InitializeComponent();
            products = _context.Products.ToList();
            categories = _context.Categories.ToList();
            ProductListView.DataContext = products;
        }
    }
}
