using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IRepository;
using Core.Repository;
using System.Windows.Input;
using System.Windows;
using Core.Models;

namespace ProjectQLBH.ViewModel
{
    public class CategoryViewModel : BaseViewModel
    {
        ICategoryRepository categoryRepository;
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand BackProductCommand { get; set; }

        private IEnumerable<Category> categories;
        public IEnumerable<Category> Categories { get { return categories; } set { categories = value; OnPropertyChanged(); } }

        private Category category;
        public Category Category
        {
            get => category; set
            {
                category = value; OnPropertyChanged();
                if (category != null)
                {
                    CategoryId = category.CategoryId;
                    CategoryName = category.CategoryName;
                }
            }
        }
        private int categoryId;
        public int CategoryId { get => categoryId; set { categoryId = value; OnPropertyChanged(); } }
        private string categoryName;
        public string CategoryName { get => categoryName; set { categoryName = value; OnPropertyChanged(); } }

        private string textSearch;
        public string TextSearch { get => textSearch; set { textSearch = value; OnPropertyChanged(); } }

        public CategoryViewModel()
        {

            categoryRepository = new CategoryRepository();
            Categories = categoryRepository.GetCategories();
            AddCommand = new ReplayCommand<object>((p) => { return true; }, (p) =>
            {
                if (categoryName == null)
                {
                    MessageBox.Show("CategoryName is empty");
                }
                else
                {
                    var category = new Category()
                    {

                        CategoryName = CategoryName
                    };

                    if (MessageBox.Show("Do you want insert category?", "Insert", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            categoryRepository.InsertCategory(category);
                            Categories = categoryRepository.GetCategories();
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

                    if (category == null)
                    {
                        return false;
                    }
                    var displayProduct = categoryRepository.GetCategoryById(Category.CategoryId);
                    if (displayProduct == null)
                    {
                        return false;
                    }
                    return true;
                },

                (p) =>
                {
                    if (categoryName == null)
                    {
                        MessageBox.Show("CategoryName is empty");
                    }
                    else
                    {
                        var update = categoryRepository.GetCategoryById(Category.CategoryId);

                        update.CategoryName = CategoryName;

                        if (MessageBox.Show("Do you want update category?", "Update", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                categoryRepository.UpdateCategory(update);
                                Categories = categoryRepository.GetCategories();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                });
            DeleteCommand = new ReplayCommand<object>(
                (p) =>
                {

                    if (category == null)
                    {
                        return false;
                    }
                    var displayProduct = categoryRepository.GetCategoryById(Category.CategoryId);
                    if (displayProduct == null)
                    {
                        return false;
                    }
                    return true;
                },

                (p) =>
                {
                    var delete = categoryRepository.GetCategoryById(Category.CategoryId);
                    if (MessageBox.Show("Do you want delete category?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            categoryRepository.DeleteCategory(delete);
                            Categories = categoryRepository.GetCategories();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }


                });

            SearchCommand = new ReplayCommand<Object>((p) => { return true; }, (p) =>
            {
                if (TextSearch == null)
                {
                    Categories = categoryRepository.GetCategories();
                }
                else
                {
                    Categories = categoryRepository.GetCategoriesByName(TextSearch);

                }
            });
            BackProductCommand = new ReplayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
            });

        }


    }

}
