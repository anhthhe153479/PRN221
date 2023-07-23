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
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Product product) => ProductManagement.Instance.DeleteProduct(product);

        public Product GetProductById(int id) => ProductManagement.Instance.GetProductByID(id);

        public List<Product> GetProducts() => ProductManagement.Instance.GetProductList();

        public List<Product> GetProductsByName(string name) => ProductManagement.Instance.GetProductsByName(name);


        public List<Product> GetProductsOrderBy(string property) => ProductManagement.Instance.GetProductsOrderBy(property);


        public void InsertProduct(Product product) => ProductManagement.Instance.AddNewProduct(product);

        public void UpdateProduct(Product product) => ProductManagement.Instance.UpdateProduct(product);

    }
}
