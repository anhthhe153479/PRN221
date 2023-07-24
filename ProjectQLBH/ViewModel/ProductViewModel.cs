using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Core.IRepository;
using Core.Models;
using Core.Repository;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectQLBH.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        ICategoryRepository categoryRepository;
        IProductRepository productRepository;
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SelectedItemChangedCommand { get; set; }
        public ICommand ImportExcelCommand { get; set; }
        public ICommand ExportExcelCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        //public ICommand LoatCategoryCommand { get; set; }
        public ICommand ChooseFileCommand { get; set; }
        public ICommand BackHomeCommand { get; set; }
        public ICommand LoadCategoryWindowCommand { get; set; }


        private ObservableCollection<string> _comboItems;
        public ObservableCollection<string> ComboItems
        {
            get { return _comboItems; }
            set
            {
                _comboItems = value;
                OnPropertyChanged("ComboItems");
            }
        }
        private IEnumerable<Category> _comboCategories;
        public IEnumerable<Category> ComboCategories
        {
            get { return _comboCategories; }
            set
            {
                _comboCategories = value;
                OnPropertyChanged("ComboCategories");
            }
        }
        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        private IEnumerable<Product> products;
        public IEnumerable<Product> Products { get { return products; } set { products = value; OnPropertyChanged(); } }

        private Product product;
        public Product Product
        {
            get => product; set
            {
                product = value; OnPropertyChanged();
                if (product != null)
                {
                    ProductName = product.ProductName;
                    ImportPrice = product.ImportPrice;
                    SellPrice = product.SellPrice;
                    NumberOfInventoty = product.NumberOfInventoty;
                    DateAdd = DateTime.ParseExact(product.DateAdd.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture);
                    Image = product.Image;
                    Status = product.Status;
                    CategoryId = product.CategoryId;
                    SelectedCategory = product.Category;
                }
            }
        }

        private string productName;
        public string ProductName { get => productName; set { productName = value; OnPropertyChanged(); } }

        private decimal importPrice;
        public decimal ImportPrice { get => importPrice; set { importPrice = value; OnPropertyChanged(); } }

        private decimal sellPrice;
        public decimal SellPrice { get => sellPrice; set { sellPrice = value; OnPropertyChanged(); } }

        private int numberOfInventoty;
        public int NumberOfInventoty { get => numberOfInventoty; set { numberOfInventoty = value; OnPropertyChanged(); } }

        private DateTime dateAdd;
        public DateTime DateAdd { get => dateAdd; set { dateAdd = value; OnPropertyChanged(); } }

        private string image;
        public string? Image { get => image; set { image = value; OnPropertyChanged(); } }

        private string status;
        public string Status { get => status; set { status = value; OnPropertyChanged(); } }

        private int? categoryId;
        public int? CategoryId { get => categoryId; set { categoryId = value; OnPropertyChanged(); } }

        private string textSearch;
        public string TextSearch { get => textSearch; set { textSearch = value; OnPropertyChanged(); } }

        private Category category;
        public Category Category { get => category; set { category = value; OnPropertyChanged(); } }

        public ProductViewModel()
        {
            LoadCategoryWindowCommand = new ReplayCommand<Window>((p) => { return true; }, (p) =>
            {
                CategoryWindow listOrder = new CategoryWindow();
                listOrder.Show();
            });
            categoryRepository = new CategoryRepository();
            ComboCategories = categoryRepository.GetCategories();
            productRepository = new ProductRepository();
            Products = productRepository.GetProducts();
            dateAdd = DateTime.Now;
            AddCommand = new ReplayCommand<object>((p) => { return true; }, (p) =>
            {
                if (ProductName == null || ImportPrice == null || SellPrice == null || NumberOfInventoty == null || DateAdd == null || Status == null)
                {
                    MessageBox.Show("Property is empty");
                }
                else
                {
                    var product = new Product()
                    {
                        ProductName = ProductName,
                        ImportPrice = ImportPrice,
                        SellPrice = SellPrice,
                        NumberOfInventoty = NumberOfInventoty,
                        DateAdd = DateAdd,
                        Image = Image,
                        Status = Status,
                        CategoryId = SelectedCategory.CategoryId,
                    };

                    if (MessageBox.Show("Do you want insert product?", "Insert", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            productRepository.InsertProduct(product);
                            Products = productRepository.GetProducts();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }

            });
            UpdateCommand = new ReplayCommand<object>(
                (p) =>
                {

                    if (product == null)
                    {
                        return false;
                    }
                    var displayProduct = productRepository.GetProductById(Product.ProductId);
                    if (displayProduct == null)
                    {
                        return false;
                    }
                    return true;
                },
                (p) =>
                {
                    if (ProductName == null || ImportPrice == null || SellPrice == null || NumberOfInventoty == null || DateAdd == null || Status == null)
                    {
                        MessageBox.Show("Property is empty");
                    }
                    else
                    {
                        var update = productRepository.GetProductById(Product.ProductId);

                        update.ProductName = ProductName;
                        update.ImportPrice = ImportPrice;
                        update.SellPrice = SellPrice;
                        update.NumberOfInventoty = NumberOfInventoty;
                        update.DateAdd = DateAdd;
                        update.Image = Image;
                        update.Status = Status;
                        update.CategoryId = SelectedCategory.CategoryId;
                        if (MessageBox.Show("Do you want update product?", "Update", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            productRepository.UpdateProduct(update);
                            Products = productRepository.GetProducts();
                        }
                    }
                });
            DeleteCommand = new ReplayCommand<object>(
                (p) =>
                {

                    if (product == null)
                    {
                        return false;
                    }
                    var displayProduct = productRepository.GetProductById(Product.ProductId);
                    if (displayProduct == null)
                    {
                        return false;
                    }
                    return true;
                },
                (p) =>
                {
                    var delete = productRepository.GetProductById(Product.ProductId);
                    if (MessageBox.Show("Do you want delete product?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        productRepository.DeleteProduct(delete);
                        Products = productRepository.GetProducts();
                    }


                });
            SearchCommand = new ReplayCommand<Object>((p) => { return true; }, (p) =>
            {
                if (TextSearch == null)
                {
                    Products = productRepository.GetProducts();
                }
                else
                {
                    Products = productRepository.GetProductsByName(TextSearch);

                }
            });
            ChooseFileCommand = new ReplayCommand<Object>((p) => { return true; }, (p) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg;*.gif)|*.png;*.jpg;*.jpeg;*.gif";

                // Nếu người dùng chọn một tệp hình ảnh và bấm OK
                if (openFileDialog.ShowDialog() == true)
                {
                    // Lưu đường dẫn của tệp hình ảnh được chọn vào thuộc tính string
                    Image = openFileDialog.FileName;
                }
            });
        }
    }
}
