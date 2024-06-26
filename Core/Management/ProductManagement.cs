﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Management
{
    public class ProductManagement
    {
        private static ProductManagement instance;
        private static readonly object instanceLock = new object();
        private ProductManagement() { }
        public static ProductManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductManagement();
                    }
                    return instance;
                }

            }
        }
        public List<Product> GetProductList()
        {
            List<Product> products;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                products = managerDB.Products.ToList();
                foreach (var product in products)
                {
                    product.Category = managerDB.Categories.FirstOrDefault(x => x.CategoryId == product.CategoryId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return products;
        }
        public List<Product> GetProductsByName(string name)
        {
            List<Product> products;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                products = managerDB.Products.Where(x => x.ProductName.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return products;
        }
        public List<Product> GetProductsOrderBy(string property)
        {
            List<Product> products;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                if (property.Equals("ImportPrice"))
                {
                    products = managerDB.Products.OrderBy(x => x.ImportPrice).ToList();
                }
                else if (property.Equals("SellPrice"))
                {
                    products = managerDB.Products.OrderBy(x => x.SellPrice).ToList();
                }
                else if (property.Equals("Number"))
                {
                    products = managerDB.Products.OrderBy(x => x.NumberOfInventoty).ToList();
                }
                else if (property.Equals("Best seller"))
                {
                    products = managerDB.Products.OrderBy(x => x.ImportPrice).ToList();
                }
                else if (property.Equals("New product"))
                {
                    products = managerDB.Products.OrderBy(x => x.DateAdd).ToList();
                }
                else
                {
                    products = products = managerDB.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return products;
        }
        public Product GetProductByID(int productId)
        {
            Product product = null;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                product = managerDB.Products.SingleOrDefault(product => product.ProductId == productId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
        public void AddNewProduct(Product product)
        {
            if (product != null)
            {
                try
                {
                    Product _product = GetProductByID(product.ProductId);
                    if (_product == null)
                    {
                        var managerDB = new Management_System_ProjectContext();
                        managerDB.Products.Add(product);
                        managerDB.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("The product is already exist");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);

                    throw new Exception(ex.Message);

                }
            }
        }
        public void UpdateProduct(Product product)
        {
            try
            {
                Product _product = GetProductByID(product.ProductId);
                if (_product != null)
                {
                    var managerDB = new Management_System_ProjectContext();
                    managerDB.Entry<Product>(product).State = EntityState.Modified;
                    managerDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteProduct(Product product)
        {
            try
            {
                Product _product = GetProductByID(product.ProductId);
                if (_product != null)
                {
                    var managerDB = new Management_System_ProjectContext();
                    managerDB.Products.Remove(_product);
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
