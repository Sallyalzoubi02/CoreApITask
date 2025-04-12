using CoreApI.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreApI.Server.Service
{
    public class ProductService : IProductService
    {
        private readonly MyDbContext myDb; //DI for Database

        public ProductService(MyDbContext db)
        {
            myDb = db;
        }
        public List<Product> GetAllProducts()
        {
            var categories = myDb.Products.ToList();
            return categories;
        }

        public List<Product> GetAllProductsByCategory(int catID)
        {

            var products = myDb.Products.Where(x => x.CategoryId == catID).ToList();
             return products;
           
        }

        public Product GetProductByID(int id)
        {
            var product = myDb.Products.Find(id);
            return product;
        }

        public List<Product> GetProductByName(string name)
        {
            var product = myDb.Products.Where(x => x.Name == name).ToList();
            return product;
        }

        public Product GetFirstProduct()
        {
            var product = myDb.Products.First();
            return product;
        }

        public bool DeleteProduct(int id)
        {
            var product = myDb.Products.Find(id);
            if (product != null)
            {
                myDb.Products.Remove(product);
                myDb.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

    
