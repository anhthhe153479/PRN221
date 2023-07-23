using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Management
{
    public class CategoryManagement
    {
        private static CategoryManagement instance;
        private static readonly object instanceLock = new object();
        private CategoryManagement() { }
        public static CategoryManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryManagement();
                    }
                    return instance;
                }

            }
        }
        public List<Category> GetCategoryList()
        {
            List<Category> categories;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                categories = managerDB.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return categories;
        }
        public List<Category> GetCategoriesByName(string name)
        {
            List<Category> categories;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                categories = managerDB.Categories.Where(x => x.CategoryName.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return categories;
        }

        public Category GetCategoryByID(int categoryId)
        {
            Category category = null;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                category = managerDB.Categories.SingleOrDefault(category => category.CategoryId == categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }
        public Category GetCategoryByName(string categoryName)
        {
            Category category = null;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                category = managerDB.Categories.SingleOrDefault(category => category.CategoryName.Equals(categoryName));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }
        public void AddNewCategory(Category category)
        {
            if (category != null)
            {
                try
                {
                    Category _category = GetCategoryByID(category.CategoryId);
                    _category = GetCategoryByName(category.CategoryName);
                    if (_category == null)
                    {
                        var managerDB = new Management_System_ProjectContext();
                        managerDB.Categories.Add(category);
                        managerDB.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("The category is already exist");

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public void UpdateCategory(Category category)
        {
            try
            {
                Category _category = GetCategoryByID(category.CategoryId);
                if (_category != null)
                {
                    var managerDB = new Management_System_ProjectContext();
                    managerDB.Entry<Category>(category).State = EntityState.Modified;
                    managerDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteCategory(Category category)
        {
            try
            {
                Category _category = GetCategoryByID(category.CategoryId);
                if (_category != null)
                {
                    var managerDB = new Management_System_ProjectContext();
                    IEnumerable<Product> list = managerDB.Products.Where(x => x.CategoryId == category.CategoryId).ToList();
                    managerDB.Products.RemoveRange(list);
                    managerDB.Categories.Remove(_category);
                    managerDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
