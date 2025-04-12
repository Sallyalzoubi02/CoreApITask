using CoreApI.Server.Models;

namespace CoreApI.Server.Service
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetByID(int id);
        Category GetByName(string name);
        Category GetFirstCategory();
        public bool DeleteCategory(int id);
    }
}
