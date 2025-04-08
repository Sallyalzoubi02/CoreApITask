using CoreApI.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext myDb; //DI for Database

        public CategoryController(MyDbContext db)
        {
            myDb = db;
        }

        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategory() {
            var categories = myDb.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var category = myDb.Categories.Find(id);
            return Ok(category);
        }

        [HttpGet("GetCategoryByname")]
        public IActionResult GetCategoryByName(string name)
        {
            var category = myDb.Categories.SingleOrDefault(x=> x.CategoryName == name);
            return Ok(category);
        }

        [HttpGet("GetFirstCategory")]
        public IActionResult GetFirstCategory()
        {
            var category = myDb.Categories.First();
            return Ok(category);
        }
    }
}
