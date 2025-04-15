using CoreApI.Server.Models;
using Microsoft.EntityFrameworkCore;

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

        public void AddCategory(CategoryDTO category)
        {
            var newCategory = new Category
            {
                CategoryName = category.CategoryName,
                CategoryDesc = category.CategoryDesc
            };

            _db.Categories.Add(newCategory);
            _db.SaveChanges();
        }

        public bool UpdateCategory(int id, CategoryDTO category)
        {
            var existingCategory = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (existingCategory == null)
            {
                return false;
            }

            existingCategory.CategoryName = category.CategoryName;
            existingCategory.CategoryDesc = category.CategoryDesc;
            _db.SaveChanges();
            return true;
        }


        public bool UpdateCat(int id , CategoryDTO category)
        {
            var cat = _db.Categories.Find(id);

            if (cat == null)
                return false;
            cat.CategoryName = category.CategoryName;
            cat.CategoryDesc = category.CategoryDesc;
            _db.SaveChanges();
            return true;
        }

    }
}
