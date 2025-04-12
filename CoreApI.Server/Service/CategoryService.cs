using CoreApI.Server.Models;

namespace CoreApI.Server.Service
{
    public class CategoryService : ICategoryService

    {
        private readonly MyDbContext _db;

        public CategoryService(MyDbContext db)
        {
            _db = db;
        }

        public List<Category> GetAll()
        {
            return _db.Categories.ToList();
        }

        public Category GetByID(int id)
        {
            return _db.Categories.Find(id);
        }

        public Category GetByName(string name)
        {
            return _db.Categories.SingleOrDefault(x => x.CategoryName == name);
        }

        public Category GetFirstCategory()
        {
            return _db.Categories.First();
        }

        public bool DeleteCategory(int id)
        {
            var product = _db.Products.Find(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
