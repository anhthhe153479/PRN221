using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.IRepository
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Product GetProductById(int id);
        List<Product> GetProductsOrderBy(string property);
        List<Product> GetProductsByName(string name);



    }
}
