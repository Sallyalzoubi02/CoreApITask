using CoreApI.Server.Models;

namespace CoreApI.Server.Service
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetByID(int id);
        Category GetByName(string name);
        Category GetFirstCategory();
        bool DeleteCategory(int id);
        public void AddCategory(CategoryDTO category);

        bool UpdateCategory(int id, CategoryDTO updatedCategory);

        public bool UpdateCat(int id, CategoryDTO category);
    }
}
