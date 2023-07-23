using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.IRepository
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        void InsertCategory(Category product);
        void UpdateCategory(Category product);
        void DeleteCategory(Category product);
        Category GetCategoryById(int id);
        Category GetCategoryByName(string name);

        List<Category> GetCategoriesByName(string name);
        //void InsertCategory(Category category);
    }
}
