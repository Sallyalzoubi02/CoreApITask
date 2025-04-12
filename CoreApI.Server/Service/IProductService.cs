using CoreApI.Server.Models;

namespace CoreApI.Server.Service
{
    public interface IProductService
    {

        public List<Product> GetAllProducts();
        public List<Product> GetAllProductsByCategory(int catID);
        public Product GetProductByID(int id);
        public List<Product> GetProductByName(string name);
        public Product GetFirstProduct();
        public bool DeleteProduct(int id);
    }
}
