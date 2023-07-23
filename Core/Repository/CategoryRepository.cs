using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IRepository;
using Core.Management;
using Core.Models;

namespace Core.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public void DeleteCategory(Category category) => CategoryManagement.Instance.DeleteCategory(category);


        public List<Category> GetCategories() => CategoryManagement.Instance.GetCategoryList();


        public List<Category> GetCategoriesByName(string name) => CategoryManagement.Instance.GetCategoriesByName(name);

        public Category GetCategoryById(int id) => CategoryManagement.Instance.GetCategoryByID(id);

        public Category GetCategoryByName(string name) => CategoryManagement.Instance.GetCategoryByName(name);


        public void InsertCategory(Category category) => CategoryManagement.Instance.AddNewCategory(category);

        public void UpdateCategory(Category category) => CategoryManagement.Instance.UpdateCategory(category);

    }
}
